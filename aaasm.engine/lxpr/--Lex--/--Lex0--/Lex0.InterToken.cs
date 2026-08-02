using System;

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
        private class InterToken(RefPnt refPnt, SrcString rawData) : IToken
        {
            #region fields
            
            private readonly RefPnt f_RefPnt = refPnt;
            private readonly SrcString f_RawData = rawData;

            #endregion

            #region IToken
            
            /// <inheritdoc/>
            public RefPnt RefPnt => f_RefPnt;

            /// <summary>Raw data</summary>
            public SrcString RawData => f_RawData;

            #endregion
        }
    }
}