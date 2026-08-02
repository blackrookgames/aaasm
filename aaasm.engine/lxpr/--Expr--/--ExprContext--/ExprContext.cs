using System;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.io;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression context</summary>
    public partial class ExprContext
    {
        #region init

        internal ExprContext(ExprRules rules, ExprParams @params, bool preprocess)
        {
            f_Rules = rules;
            f_Params = @params;
            f_Preprocess = preprocess;
        }

        #endregion

        #region fields

        private readonly ExprRules f_Rules;
        private readonly ExprParams f_Params;
        private readonly bool f_Preprocess = false;

        #endregion

        #region properties

        /// <summary>Expression rules</summary>
        public ExprRules Rules => f_Rules;

        /// <summary>Expression parameters</summary>
        public ExprParams Params => f_Params;

        /// <summary>Whether or not this is a preprocessing context</summary>
        public bool Preprocess => f_Preprocess;

        #endregion
    }
}