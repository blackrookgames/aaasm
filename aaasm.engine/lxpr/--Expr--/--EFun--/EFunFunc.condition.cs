using System;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region IFELSE

        /// <summary>Tests a given condition returns a value based on that condition</summary>
        /// <param name="condition">Condition to test</param>
        /// <param name="context">Context</param>
        /// <param name="ifTrue">Value to return if condition is true</param>
        /// <param name="ifFalse">Value to return if condition is false</param>
        /// <returns>Value based on whether or not condition is true or false</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="ifTrue"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="ifFalse"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="condition"/> cannot be casted as boolean
        ///     <br/>or<br/>
        ///     <paramref name="ifTrue"/> and <paramref name="ifFalse"/> are not of the same type
        /// </exception>
        public static EValue IFELSE(ExprContext context,
            EValue condition, EValue ifTrue, EValue ifFalse)
        {
            ArgumentNullException.ThrowIfNull(context);
            bool _condition = MM_ToBool(condition);
            MM_ThrowIfDifferentTypes(ifTrue, ifFalse);
            return _condition ? ifTrue : ifFalse;
        }

        internal static EType IFELSE_r_EValue_EValue_EValue(ExprRules rules, 
            ENodeValueType condition, ENodeValueType ifTrue, ENodeValueType ifFalse)
        {
            MM_ThrowIfDifferentTypes(ifTrue, ifFalse);
            return ifTrue.Type;
        }

        #endregion
        
    }
}

