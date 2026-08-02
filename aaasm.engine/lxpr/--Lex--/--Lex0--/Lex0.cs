using System;
using aaasm.engine.col;

using RoughTokenSpan = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.RoughToken>;

namespace aaasm.engine.lxpr
{
    /// <summary>
    /// Stage-0 Lexical Analyzer
    /// <list type="bullet">
    ///     <item>Removes comments</item>
    ///     <item>Splits source code by line, with line-continuation sequences resolved</item>
    ///     <item>Performs rough tokenization</item>
    /// </list>
    /// </summary>
    internal partial class Lex0
    {
        #region init

        private Lex0(ImmNullArray<RoughTokenSpan> tokens)
        {
            f_Lines = tokens;
        }

        /// <summary>Runs the Stage-0 lexical analyzer</summary>
        /// <param name="source">Source</param>
        /// <param name="rules">Rules</param>
        /// <returns>Results</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="rules"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     A syntax error was detected
        /// </exception>
        public static Lex0 Run(SrcString source, LexRules rules)
        {
            try
            {
                Analysis analysis = Analysis.Run(source, rules);
                return new(new(analysis.Lines));
            }
            catch when (source is null)
            { throw new ArgumentNullException(nameof(source)); }
            catch when (rules is null)
            { throw new ArgumentNullException(nameof(rules)); }
        }

        #endregion

        #region fields
        
        private readonly ImmNullArray<RoughTokenSpan> f_Lines;

        #endregion

        #region properties

        /// <summary>Lines of rough tokens</summary>
        public ImmNullArray<RoughTokenSpan> Lines => f_Lines;

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

        private static bool MM_CommentAt(LexCommentRules commentRules, SrcString source, int index, out int end)
        {
            end = index;
            if (commentRules.Single is not null)
            {
                if (source.Raw.SubstrAt(commentRules.Single, end))
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
                if (source.Raw.SubstrAt(commentRules.Multi.Open, end))
                {
                    int beg = end;
                    while (true)
                    {
                        if (++end == source.Length)
                            throw MM_UnexpectedEnd(source, (string)commentRules.Multi.Close);
                        if (!source.Raw.SubstrAt(commentRules.Multi.Close, end))
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