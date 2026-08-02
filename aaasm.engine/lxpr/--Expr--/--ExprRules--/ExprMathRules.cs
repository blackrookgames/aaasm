using System;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents rules for mathematical operations</summary>
    public partial class ExprMathRules
    {
        #region init

        /// <summary>Initializer for <see cref="ExprMathRules"/></summary>
        /// <param name="init">Initialization arguments</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="init"/> is null
        /// </exception>
        public ExprMathRules(ExprMathRulesInit init)
        {
            try
            {
                GroupBrackets = init.GroupBrackets;
                Operators = init.Operators;
            }
            catch when (init is null)
            {
                throw new ArgumentNullException(nameof(init));
            }
        }

        #endregion

        #region properties

        /// <summary>Brackets used for grouping mathematical terms</summary>
        [InitParam(value: """ BracketPair.ROUND """)]
        public BracketPair<Str>? GroupBrackets { get; }

        /// <summary>Mathematical operators</summary>
        [InitParam(value: """ ExprMathRules.COMMON_OPERATORS """)]
        public ImmNullDict<EMathOperator, ImmNullArray<Str>> Operators { get; }

        #endregion
    }
}
