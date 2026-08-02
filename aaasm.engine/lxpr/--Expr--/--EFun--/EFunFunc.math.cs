using System;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region MIN

        /// <summary>
        ///     Determines the minimum of the two input values; 
        ///     the input values must be of the same type
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <return>Minimum value</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="a"/> and <paramref name="b"/> are of different types
        /// </exception>
        public static IENumber MIN(ExprContext context, IENumber a, IENumber b)
        {
            ArgumentNullException.ThrowIfNull(context);
            MM_ThrowIfDifferentTypes(a, b);
            int cmp = a.CompareTo(b);
            return (cmp < 0) ? a : b;
        }

        internal static EType MIN_r_IENumber_IENumber(ExprRules rules, ENodeValueType a, ENodeValueType b)
        {
            MM_ThrowIfDifferentTypes(a, b);
            return a.Type;
        }

        #endregion

        #region MAX

        /// <summary>
        ///     Determines the maximum of the two input values; 
        ///     the input values must be of the same type
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <return>Maximum value</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="a"/> and <paramref name="b"/> are of different types
        /// </exception>
        public static IENumber MAX(ExprContext context, IENumber a, IENumber b)
        {
            ArgumentNullException.ThrowIfNull(context);
            MM_ThrowIfDifferentTypes(a, b);
            int cmp = a.CompareTo(b);
            return (cmp > 0) ? a : b;
        }

        internal static EType MAX_r_IENumber_IENumber(ExprRules rules, ENodeValueType a, ENodeValueType b)
        {
            MM_ThrowIfDifferentTypes(a, b);
            return a.Type;
        }

        #endregion
    }
}