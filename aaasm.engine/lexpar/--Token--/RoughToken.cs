namespace aaasm.engine.lexpar
{
    /// <summary>Represents a rough token</summary>
    public class RoughToken : IToken
    {
        #region init

        internal RoughToken(RefPnt refPnt, SrcString rawData)
        {
            f_RefPnt = refPnt;
            f_RawData = rawData;
            f_Quoted = false;
            f_QuoteChar = default;
        }

        internal RoughToken(RefPnt refPnt, SrcString rawData, char quoteChar)
        {
            f_RefPnt = refPnt;
            f_RawData = rawData;
            f_Quoted = true;
            f_QuoteChar = quoteChar;
        }

        #endregion

        #region fields
        
        private readonly RefPnt f_RefPnt;
        private readonly SrcString f_RawData;
        private readonly bool f_Quoted;
        private readonly char f_QuoteChar;

        #endregion

        #region IToken
        
        /// <inheritdoc/>
        public RefPnt RefPnt => f_RefPnt;

        /// <summary>Raw data</summary>
        public SrcString RawData => f_RawData;

        /// <summary>Whether or not raw data is wrapped in quotation marks</summary>
        public bool Quoted => f_Quoted;

        /// <summary>
        ///     Quotation mark character 
        ///     (meaningless if raw data is not wrapped in quotation marks)
        /// </summary>
        public char QuoteChar => f_QuoteChar;

        #endregion
    }
}