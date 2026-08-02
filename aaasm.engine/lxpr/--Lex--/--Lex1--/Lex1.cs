using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

using LexTokenSpan = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.LexToken>;

namespace aaasm.engine.lxpr
{
    /// <summary>
    /// Stage-1 Lexical Analyzer
    /// <list type="bullet">
    ///     <item></item>
    /// </list>
    /// </summary>
    internal partial class Lex1
    {
        #region init

        private Lex1(ImmNullArray<LexTokenSpan> lines)
        {
            f_Lines = lines;
        }

        /// <summary>Runs the Stage-1 lexical analyzer</summary>
        /// <param name="source">Source</param>
        /// <param name="rules">Rules</param>
        /// <param name="params">Parameters</param>
        /// <returns>Results</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="rules"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="persistent"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     A syntax error was detected
        /// </exception>
        public static Lex1 Run(Lex0 source, LexRules rules, LexParams @params, LexPersistent persistent)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(rules);
            ArgumentNullException.ThrowIfNull(persistent);
            Handler handler = new(source.Lines, rules, @params, persistent);
            MM_Lines(handler);
            return new(new(handler.Output));
        }

        #endregion

        #region fields
        
        private readonly ImmNullArray<LexTokenSpan> f_Lines;

        #endregion

        #region properties

        /// <summary>Lines of tokens</summary>
        public ImmNullArray<LexTokenSpan> Lines => f_Lines;

        #endregion

        #region helper methods

        private static void MM_Lines(Handler handler)
        {
            void loop(int level)
            {
                while (handler.Input.Pos < handler.Input.Count)
                {
                    // Is it empty?
                    if (handler.Input.Current.Length == 0) continue;
                    // Does it start with prefix?
                    if (handler.Rules.PrePrefix is not null)
                    {
                        var first = handler.Input.Current[0];
                        if (Handler.StartsWith(first, handler.Rules.PrePrefix))
                        {
                            // Make sure it's valid
                            var cmdName = first.RawData.Raw[1..];
                            var valid = handler.Rules.PreNames.TryGetValue(
                                cmdName, out var type);
                            if (!valid)
                                throw new BadSrcException(
                                $"Unknown preprocessor command: {first.RawData.Raw}", 
                                first.RefPnt);
                            // What is it?
                            if (!PRECOMMANDS.TryGetValue(type, out var action))
                                throw new BadSrcException(
                                $"Unsupported preprocessor command: {first.RawData.Raw}", 
                                first.RefPnt);
                            // Excecute command
                            action(handler);
                            // Next
                            continue;
                        }
                    }
                    // No!
                    if (handler.If.Level == handler.If.Active)
                    {
                        var expanded = MM_ExpandMacros(handler, 0, null, out _);
                        var tokens = MM_Analyze(handler, expanded);
                        LexTokenSpan newLine = new(from token in tokens select token);
                        handler.Output.Add(newLine);
                    }
                    ++handler.Input.Pos;
                }
            }
            loop(0);
        }

        private static IEnumerable<RoughToken> MM_ExpandMacros(
            Handler handler, int beg, Str? close, out int end)
        {
            static IEnumerable<RoughToken> expandMacros(Handler _handler, 
                IReadOnlyList<RoughToken> _input, 
                IReadOnlyDictionary<string, IEnumerable<RoughToken>>? _inputArgs,
                int _beg, Str? _close, Str? _throwIf, out int _end)
            {
                int pos = _beg;
                bool endOf(Str? expected)
                {
                    if (pos < _input.Count) return false;
                    if (expected is null) return true;
                    RefPnt? refPnt = (_input.Count == 0) ?
                        null : _input[^1].RefPnt;
                    throw BadSrcException.Expected((string)expected, refPnt, true);
                }
                bool endOfExpect(Str? expected)
                {
                    if (endOf(expected)) return true;
                    if (expected is not null)
                    {
                        var token = _input[pos];
                        if (!Handler.Equal(token, expected))
                            throw BadSrcException.Expected((string)expected, token.RefPnt);
                    }
                    return false;
                }
                List<RoughToken> expanded = [];
                while (!endOf(_close))
                {
                    var token = _input[pos++];
                    // Is this a parameter reference?
                    if (_inputArgs is not null && _inputArgs.TryGetValue((string)token.RawData.Raw, out var inputArg))
                    {
                        expanded.AddRange(inputArg);
                    }
                    // No! Is this a macro?
                    else if (_handler.Persistent.Macros.Curr.TryGet((string)token.RawData.Raw, out var macro))
                    {
                        // Gather arguments.
                        Dictionary<string, IEnumerable<RoughToken>> args = new(macro.Params.Count);
                        if (macro.IsFuncLike)
                        {
                            if (_handler.Rules.MacroBrackets is null) // I'm almost certain this won't happen
                            {
                                throw new BadSrcException(
                                    "Function-like macros are not supported.",
                                    token.RefPnt);
                            }
                            // Next token must be open bracket
                            endOfExpect(_handler.Rules.MacroBrackets.Open); ++pos;
                            // Get arguments
                            if (macro.Params.Count > 0)
                            {
                                if (macro.Params.Count > 1 && _handler.Rules.MacroParamSep is null) // I'm almost certain this won't happen
                                {
                                    throw new BadSrcException(
                                        "Multiple arguments are not supported.",
                                        token.RefPnt);
                                }
                                var iter = macro.Params.GetEnumerator();
                                // All arguments except last
                                IEnumerable<RoughToken> e;
                                for (int i = 1; i < macro.Params.Count; ++i)
                                {
                                    e = expandMacros(
                                        _handler, _input, _inputArgs, pos, 
                                        _handler.Rules.MacroParamSep!, _handler.Rules.MacroBrackets.Close, 
                                        out pos);
                                    iter.MoveNext();
                                    args.Add(iter.Current, e);
                                }
                                // Last argument
                                e = expandMacros(
                                    _handler, _input, _inputArgs, pos, 
                                    _handler.Rules.MacroBrackets.Close, _handler.Rules.MacroParamSep!, 
                                    out pos);
                                iter.MoveNext();
                                args.Add(iter.Current, e);
                            }
                            else
                            {
                                // Next token must be close bracket
                                endOfExpect(_handler.Rules.MacroBrackets.Close); ++pos;
                            }
                        }
                        // Expand the macro
                        var body = expandMacros(
                            _handler, macro.Body, args, 0, 
                            null, null, out _);
                        expanded.AddRange(body);
                    }
                    // No! Is this the close?
                    else if (Handler.Equal(token, _close))
                    {
                        break;
                    }
                    // No! Is this invalid?
                    else if (Handler.Equal(token, _throwIf))
                    {
                        throw BadSrcException.Unexpected(token.RawData, token.RefPnt);
                    }
                    // No!
                    else
                    {
                        expanded.Add(token);
                    }
                }
                _end = pos;
                return expanded;
            }
            return expandMacros(handler, handler.Input.Current, null, beg, close, null, out end);
        }

        private static IReadOnlyList<LexToken> MM_Analyze(
            Handler handler, IEnumerable<RoughToken> input)
        {
            var iter = input.GetEnumerator();
            RoughToken? current = null;
            IEnumerable<LexToken> analyze(Str? close)
            {
                while (true)
                {
                    // Is this the end?
                    if (!iter.MoveNext())
                    {
                        if (close is null) break;
                        throw BadSrcException.Expected((string)close, current?.RefPnt, true);
                    }
                    // No! Get current token
                    current = iter.Current;
                    // Is this the closing bracket?
                    if (Handler.Equal(current, close))
                    {
                        break;
                    }
                    // No! Is this an opening bracket?
                    bool opening = false;
                    foreach (var pair in handler.Rules.BracketPairs)
                    {
                        if (!Handler.Equal(current, pair.Open))
                            continue;
                        RoughToken open = current;
                        LexTokenSpan children = new(analyze(pair.Close));
                        yield return new LexToken(open, children, pair);
                        opening = true;
                        break;
                    }
                    if (opening) continue;
                    // No!
                    yield return new LexToken(current, LexTokenSpan.EMPTY, null);
                }
            }
            return [..analyze(null)];
        }

        #endregion
    }
}