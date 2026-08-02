using System;
using System.Collections.Generic;
using aaasm.engine.col;

using RoughTokenSpan = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.RoughToken>;

namespace aaasm.engine.lxpr
{
    internal partial class Lex0
    {
        private class Analysis
        {
            #region init

            private Analysis(SrcString source, LexRules rules)
            {
                f_Source = source;
                f_Rules = rules;
                f_Tokens = [];
                f_RevLines = [];
                f_Lines = [];
                Lines = new(f_Lines);
            }

            /// <summary>Runs the analyzer</summary>
            /// <param name="source">Source code</param>
            /// <param name="rules">Lexical analysis rules</param>
            /// <returns>Analysis results</returns>
            /// <exception cref="ArgumentNullException">
            ///     <paramref name="source"/> is null
            ///     <br/>or<br/>
            ///     <paramref name="rules"/> is null
            /// </exception>
            public static Analysis Run(SrcString source, LexRules rules)
            {
                ArgumentNullException.ThrowIfNull(source);
                ArgumentNullException.ThrowIfNull(rules);
                Analysis analyzer = new(source, rules);
                analyzer.MM_QuotesComments();
                analyzer.MM_SplitIntoLines();
                analyzer.MM_RoughTokenization();
                return analyzer;
            }

            #endregion

            #region fields

            private readonly SrcString f_Source;
            private readonly LexRules f_Rules;
            private readonly List<IToken> f_Tokens;
            private readonly List<List<IToken>> f_RevLines;
            private readonly List<RoughTokenSpan> f_Lines;

            #endregion

            #region properties

            /// <summary>Lines</summary>
            public ROList<RoughTokenSpan> Lines { get; }

            #endregion

            #region methods

            private void MM_QuotesComments()
            {
                f_Tokens.Clear();
                List<SrcChar> unparsed = [];
                int pos = 0;
                BadSrcException badEscape(string? what, RefPnt refPnt)
                {
                    string seqText = (what is null) ? "" : $": {what}";
                    return new($"Invalid escape sequence{seqText}", refPnt);
                }
                void addUnparsed()
                {
                    if (unparsed.Count == 0) return;
                    f_Tokens.Add(new InterToken(
                        unparsed[0].Origin, 
                        new(unparsed)));
                    unparsed.Clear();
                }
                void parseQuote(char mark)
                {
                    addUnparsed();
                    SrcChar qmark = new(mark, default);
                    int beg = pos++; // Mark beginning of quoted block
                    List<SrcChar> chars = [qmark];
                    while (true)
                    {
                        if (pos >= f_Source.Length)
                            throw MM_UnexpectedEnd(f_Source, mark.ToString());
                        SrcChar c = f_Source[pos];
                        // Is this the end quote?
                        if (c.Char == mark)
                        {
                            ++pos;
                            break;
                        }
                        // Is this an escape sequence?
                        if (c.Char == '\\')
                        {
                            int escBeg = pos;
                            if (++pos == f_Source.Length)
                                throw badEscape(null, f_Source[escBeg].Origin);
                            char cc = f_Source.Raw[pos++];
                            if (cc >= 'A' && cc <= 'Z') cc = (char)(cc + 0x20);
                            // Is this a simple escape sequence?
                            switch (cc)
                            {
                                case 'n': chars.Add(new('\n', c.Origin)); goto escNext;
                                case 't': chars.Add(new('\t', c.Origin)); goto escNext;
                                case '\\': chars.Add(new('\\', c.Origin)); goto escNext;
                                case '\"': chars.Add(new('\"', c.Origin)); goto escNext;
                                case '\'': chars.Add(new('\'', c.Origin)); goto escNext;
                                case 'b': chars.Add(new('\b', c.Origin)); goto escNext;
                                case 'r': chars.Add(new('\r', c.Origin)); goto escNext;
                                case 'a': chars.Add(new('\a', c.Origin)); goto escNext;
                                case '0': chars.Add(new('\0', c.Origin)); goto escNext;
                            }
                            // No! It must be a character code.
                            int count;
                            switch (cc)
                            {
                                case 'x': count = 2; break;
                                case 'u': count = 4; break;
                                default: goto escBad;
                            }
                            int code = 0;
                            while (count > 0)
                            {
                                if (pos == f_Source.Length) goto escBad;
                                code <<= 4;
                                cc = f_Source.Raw[pos++];
                                if (cc >= 0x30 && cc <= 0x39)
                                    code |= cc - 0x30;
                                else if (cc >= 0x41 && cc <= 0x46)
                                    code |= cc + 10 - 0x41;
                                else if (cc >= 0x61 && cc <= 0x66)
                                    code |= cc + 10 - 0x61;
                                else goto escBad;
                                --count;
                            }
                            chars.Add(new((char)code, c.Origin));
                            // Next
                            escNext: continue;
                            // Bad escape
                            escBad: throw badEscape((string)f_Source.Raw[escBeg..pos], f_Source[escBeg].Origin);
                        }
                        // This is a regular character
                        chars.Add(c);
                        ++pos;
                    }
                    chars.Add(qmark);
                    f_Tokens.Add(new RoughToken(f_Source[beg].Origin, new(chars), mark));
                    beg = pos; // Set beginning to end of quoted block
                }
                while (pos < f_Source.Length)
                {
                    char c = f_Source.Raw[pos];
                    // Is this a quotation mark?
                    if (f_Rules.Expression.Literals.ParseSingleQuote != ExprQuoteType.NONE)
                    {
                        if (c == '\'')
                        {
                            parseQuote(c);
                            continue;
                        }
                    }
                    if (f_Rules.Expression.Literals.ParseDoubleQuote != ExprQuoteType.NONE)
                    {
                        if (c == '"')
                        {
                            parseQuote(c);
                            continue;
                        }
                    }
                    // No! Is this a comment mark?
                    bool isComment = false;
                    foreach (var commentRules in f_Rules.Comments)
                    {
                        if (!MM_CommentAt(commentRules, f_Source, pos, out var end))
                            continue;
                        // Place space to ensure data before/after comment is separated
                        if (pos > 0)
                        {
                            RefPnt prev = f_Source[pos - 1].Origin;
                            unparsed.Add(new(' ', new(prev.Path, prev.Line, prev.Col + 1)));
                        }
                        // Move to end of comment
                        pos = end;
                        // Mark as comment
                        isComment = true;
                        break;
                    }
                    if (isComment) continue;
                    // No!
                    unparsed.Add(f_Source[pos++]);
                }
                addUnparsed();
            }

            private void MM_SplitIntoLines()
            {
                f_RevLines.Clear();
                List<IToken>? revLine = null;
                void addLine()
                {
                    if (revLine is null) return;
                    f_RevLines.Add(revLine);
                    revLine = null;
                }
                void addToLine(IToken token)
                {
                    revLine ??= [];
                    revLine.Add(token);
                }
                List<SrcChar> revToken = [];
                void addToken()
                {
                    if (revToken.Count == 0) return;
                    addToLine(new InterToken(revToken[0].Origin, 
                        new(ColUtil.ReverseLoop(revToken))));
                    revToken.Clear();
                }
                bool newLine = true;
                foreach (var input in ColUtil.ReverseLoop(f_Tokens))
                {
                    if (input is InterToken unparsed)
                    {
                        int pos = unparsed.RawData.Length;
                        while (pos > 0)
                        {
                            // Linespan?
                            if (newLine && f_Rules.LineContinue is not null)
                            {
                                if (pos >= f_Rules.LineContinue.Length)
                                {
                                    int beg = pos - f_Rules.LineContinue.Length;
                                    if (unparsed.RawData.Raw.SubstrAt(f_Rules.LineContinue, beg))
                                    {
                                        // Remove last line
                                        if (f_RevLines.Count > 0)
                                        {
                                            int last = f_RevLines.Count - 1;
                                            revLine = f_RevLines[last];
                                            f_RevLines.RemoveAt(last);
                                        }
                                        // Next
                                        pos = beg;
                                        newLine = false;
                                        continue;
                                    }
                                }
                            }
                            // No! Whitespace?
                            char c = unparsed.RawData.Raw[--pos];
                            if (c <= ' ')
                            {
                                addToken();
                                if (c == '\n' || c == '\r')
                                {
                                    addLine();
                                    newLine = true;
                                }
                            }
                            // No!
                            else
                            {
                                revToken.Add(unparsed.RawData[pos]);
                                newLine = false;
                            }
                        }
                    }
                    else
                    {
                        addToken();
                        addToLine(input!);
                        newLine = false;
                    }
                }
                addToken();
                addLine();
            }

            private void MM_RoughTokenization()
            {
                f_Lines.Clear();
                f_Lines.EnsureCapacity(f_RevLines.Count);
                foreach (var revLine in ColUtil.ReverseLoop(f_RevLines))
                {
                    List<RoughToken> line = [];
                    foreach (var input in ColUtil.ReverseLoop(revLine!))
                    {
                        if (input is InterToken inter)
                        {
                            // Find symbols
                            int beg = 0, pos = 0;
                            void addToken()
                            {
                                if (beg == pos) return;
                                line.Add(new(inter.RawData[beg].Origin, inter.RawData[beg..pos]));
                                beg = pos;
                            }
                            while (pos < inter.RawData.Length)
                            {
                                // Is there a symbol here?
                                int symbolLen = 0;
                                foreach (var symbol in f_Rules.RoughSymbols)
                                {
                                    // Only consider symbol if it's larger than the current match
                                    if (symbol.Length <= symbolLen)
                                        continue;
                                    // Does the symbol match?
                                    if (inter.RawData.Raw.SubstrAt(symbol, pos))
                                        symbolLen = symbol.Length;
                                }
                                if (symbolLen > 0)
                                {
                                    addToken();
                                    pos += symbolLen;
                                    addToken();
                                    continue;
                                }
                                // No!
                                ++pos;
                            }
                            addToken();
                        }
                        else
                        {
                            line.Add((RoughToken)input!);
                        }
                    }
                    f_Lines.Add(new(line));
                }
            }

            #endregion

        }
    }
}