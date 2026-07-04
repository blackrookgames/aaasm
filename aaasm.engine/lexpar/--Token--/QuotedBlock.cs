using System;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a quoted block</summary>
    public class QuotedBlock : IToken
    {
        #region init

        internal QuotedBlock(RefPnt refPnt, char mark, string value)
        {
            f_RefPnt = refPnt;
            f_Mark = mark;
            f_Value = value;
        }

        #endregion

        #region fields
        
        private readonly RefPnt f_RefPnt;

        private readonly char f_Mark;
        private readonly string f_Value;

        #endregion

        #region properties

        /// <summary>Quotation mark character</summary>
        public char Mark => f_Mark;

        /// <summary>Literal value</summary>
        public string Value => f_Value;

        #endregion

        #region IToken
        
        /// <inheritdoc/>
        public RefPnt RefPnt => f_RefPnt;

        #endregion
    }
}
