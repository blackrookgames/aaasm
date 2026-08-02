using System;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents information about a mathematical operator</summary>
    public class EMathOperatorInfo
    {
        #region init

        internal EMathOperatorInfo(EMathOperator @operator, bool isUnary)
        {
            f_Operator = @operator;
            f_IsUnary = isUnary;
        }

        #endregion

        #region fields

        private readonly EMathOperator f_Operator;
        private readonly bool f_IsUnary;

        #endregion

        #region properties

        /// <summary>Operator</summary>
        public EMathOperator Operator => f_Operator;

        /// <summary>Whether or not this is a unary operator as opposed to a binary operator</summary>
        public bool IsUnary => f_IsUnary;

        #endregion
    }
}
