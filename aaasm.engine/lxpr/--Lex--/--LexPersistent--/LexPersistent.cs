using System;
using System.Collections.Generic;
using aaasm.engine.col;
using LexLine = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.LexToken>;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents persistent data during lexical analysis</summary>
    internal class LexPersistent
    {
        #region fields

        private readonly LexPersistentMacros f_Macros = new();

        #endregion

        #region properties

        /// <summary>Macros</summary>
        public LexPersistentMacros Macros => f_Macros;

        #endregion
    }
}