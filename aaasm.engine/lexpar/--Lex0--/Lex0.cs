using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    /// <summary>
    /// Stage-0 Lexical Analyzer
    /// <list type="bullet">
    ///     <item>Removes comments</item>
    ///     <item>Parses blocks wrapped in quotation marks</item>
    /// </list>
    /// </summary>
    public class Lex0
    {
        #region init

        private Lex0(ImmutableNullessArray<IToken> tokens)
        {
            f_Tokens = tokens;
        }

        /// <summary>Runs the Stage-0 lexical analyzer</summary>
        /// <param name="source">Source</param>
        /// <param name="rules">Rules</param>
        /// <returns>Results</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null
        /// </exception>
        public static Lex0 Run(SrcString source, Lex0Rules? rules = null)
        {
            try
            {
                rules ??= new();
                List<IToken> tokens = [];
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
                    tokens.Add(new Unparsed(
                        unparsed[0].Origin, 
                        new(unparsed)));
                    unparsed.Clear();
                }
                void parseQuote(char mark)
                {
                    addUnparsed();
                    int beg = pos++; // Mark beginning of quoted block
                    List<char> chars = [];
                    while (true)
                    {
                        if (pos >= source.Length)
                            throw MM_UnexpectedEnd(source, mark.ToString());
                        char c = source.Raw[pos];
                        // Is this the end quote?
                        if (c == mark)
                        {
                            ++pos;
                            break;
                        }
                        // Is this an escape sequence?
                        if (c == '\\')
                        {
                            int escBeg = pos;
                            if (++pos == source.Length)
                                throw badEscape(null, source[escBeg].Origin);
                            c = source.Raw[pos++];
                            if (c >= 'A' && c <= 'Z') c = (char)(c + 0x20);
                            // Is this a simple escape sequence?
                            switch (c)
                            {
                                case 'n': chars.Add('\n'); goto escNext;
                                case 't': chars.Add('\t'); goto escNext;
                                case '\\': chars.Add('\\'); goto escNext;
                                case '\"': chars.Add('\"'); goto escNext;
                                case '\'': chars.Add('\''); goto escNext;
                                case 'b': chars.Add('\b'); goto escNext;
                                case 'r': chars.Add('\r'); goto escNext;
                                case 'a': chars.Add('\a'); goto escNext;
                                case '0': chars.Add('\0'); goto escNext;
                            }
                            // No! It must be a character code.
                            int count;
                            switch (c)
                            {
                                case 'x': count = 2; break;
                                case 'u': count = 4; break;
                                default: goto escBad;
                            }
                            int code = 0;
                            while (count > 0)
                            {
                                if (pos == source.Length) goto escBad;
                                code <<= 4;
                                c = source.Raw[pos++];
                                if (c >= 0x30 && c <= 0x39)
                                    code |= c - 0x30;
                                else if (c >= 0x41 && c <= 0x46)
                                    code |= c + 10 - 0x41;
                                else if (c >= 0x61 && c <= 0x66)
                                    code |= c + 10 - 0x61;
                                else goto escBad;
                                --count;
                            }
                            chars.Add((char)code);
                            // Next
                            escNext: continue;
                            // Bad escape
                            escBad: throw badEscape(source.Raw[escBeg..pos], source[escBeg].Origin);
                        }
                        // This is a regular character
                        chars.Add(c);
                        ++pos;
                    }
                    tokens.Add(new QuotedBlock(source[beg].Origin, mark, new([..chars])));
                    beg = pos; // Set beginning to end of quoted block
                }
                while (pos < source.Length)
                {
                    char c = source.Raw[pos];
                    // Is this a quotation mark?
                    if (rules.ParseSingleQuote)
                    {
                        if (c == '\'')
                        {
                            parseQuote(c);
                            continue;
                        }
                    }
                    if (rules.ParseDoubleQuote)
                    {
                        if (c == '"')
                        {
                            parseQuote(c);
                            continue;
                        }
                    }
                    // No! Is this a comment mark?
                    bool isComment = false;
                    foreach (var commentRules in rules.Comments)
                    {
                        if (!MM_CommentAt(commentRules, source, pos, out var end))
                            continue;
                        // Place space to ensure data before/after comment is separated
                        if (pos > 0)
                        {
                            RefPnt prev = source[pos - 1].Origin;
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
                    unparsed.Add(source[pos++]);
                }
                addUnparsed();
                return new(new(tokens));
            }
            catch when (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
        }

        #endregion

        #region fields
        
        private readonly ImmutableNullessArray<IToken> f_Tokens;

        #endregion

        #region properties

        /// <summary>
        ///     Tokens
        ///     <para>
        ///         For the Stage-0 Lexical Analyzer, each token will either be:
        ///         <list type="bullet">
        ///             <item><see cref="Unparsed"/></item>
        ///             <item><see cref="QuotedBlock"/></item>
        ///         </list>
        ///     </para>
        /// </summary>
        public ImmutableNullessArray<IToken> Tokens => f_Tokens;

        #endregion

        #region helper methods

        private static RefPnt MM_EndOfSrc(SrcString source)
        {
            if (source.Length == 0) return default;
            RefPnt last = source[^1].Origin;
            return new(last.Path, last.Line, last.Col + 1);
        }

        private static BadSrcException MM_UnexpectedEnd(SrcString source, string what)
        {
            return new($"{what} expected", MM_EndOfSrc(source));
        }

        private static bool MM_CommentAt(Lex0CommentRules commentRules, SrcString source, int index, out int end)
        {
            end = index;
            if (commentRules.Single is not null)
            {
                if (StrUtil.SubstrAt(source.Raw, commentRules.Single, end))
                {
                    while (++end < source.Length)
                    {
                        char c = source.Raw[end];
                        if (c == '\n' || c == '\r')
                            break;
                    }
                    return true;
                }
            }
            if (commentRules.Multi is not null)
            {
                if (StrUtil.SubstrAt(source.Raw, commentRules.Multi.Open, end))
                {
                    int beg = end;
                    while (true)
                    {
                        if (++end == source.Length)
                            throw MM_UnexpectedEnd(source, commentRules.Multi.Close);
                        if (!StrUtil.SubstrAt(source.Raw, commentRules.Multi.Close, end))
                            continue;
                        end += commentRules.Multi.Close.Length;
                        break;
                    }
                    // Success!!!
                    return true;
                }
            }
            end = -1;
            return false;
        }
        
        #endregion
    }
}