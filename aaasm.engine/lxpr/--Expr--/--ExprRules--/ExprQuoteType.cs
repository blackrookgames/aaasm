using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a quotation type</summary>
    public enum ExprQuoteType
    {
        /// <summary>Not a quotation type</summary>
        NONE,
        /// <summary>Quotation represents a single character</summary>
        CHARACTER,
        /// <summary>Quotation represents a string of characters</summary>
        STRING,
    }
}
