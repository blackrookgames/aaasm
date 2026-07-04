using System;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents source content that has not been parsed yet</summary>
    public class Unparsed : IToken
    {
        #region init

        internal Unparsed(RefPnt refPnt, SrcString rawData)
        {
            f_RefPnt = refPnt;
            f_RawData = rawData;
        }

        #endregion

        #region fields
        
        private readonly RefPnt f_RefPnt;
        private readonly SrcString f_RawData;

        #endregion

        #region IToken
        
        /// <inheritdoc/>
        public RefPnt RefPnt => f_RefPnt;

        /// <summary>Raw data</summary>
        public SrcString RawData => f_RawData;

        #endregion
    }
}
