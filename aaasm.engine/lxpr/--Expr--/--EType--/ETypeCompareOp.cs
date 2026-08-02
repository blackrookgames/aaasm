using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a comparison operator</summary>
    public class ETypeCompareOp
    {
        #region nested

        /// <summary>Operator function</summary>
        /// <param name="a">Value A</param>
        /// <param name="b">Value B</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, <paramref name="a"/> is less than <paramref name="b"/>
        ///     <br/>- Equal to zero, <paramref name="a"/> is equal to <paramref name="b"/>
        ///     <br/>- Greater than zero, <paramref name="a"/> is greater than <paramref name="b"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="a"/>.Type does not equal <see cref="ValTypeA"/>
        ///     <br/>or<br/>
        ///     <paramref name="b"/>.Type does not equal <see cref="ValTypeB"/>
        /// </exception>
        public delegate int Func(EValue a, EValue b);

        /// <summary>Initializer for <see cref="ETypeCompareOp"/></summary>
        /// <param name="valTypeA">Value A type</param>
        /// <param name="valTypeB">Value B type</param>
        /// <param name="func">Operator function</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="valTypeA"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="valTypeB"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="func"/> is null
        /// </exception>
        public ETypeCompareOp(EType valTypeA, EType valTypeB, Func func)
        {
            ArgumentNullException.ThrowIfNull(valTypeA);
            ArgumentNullException.ThrowIfNull(valTypeB);
            ArgumentNullException.ThrowIfNull(func);
            f_ValTypeA = valTypeA;
            f_ValTypeB = valTypeB;
            f_Func = func;
        }

        #endregion

        #region fields

        private readonly EType f_ValTypeA;
        private readonly EType f_ValTypeB;
        private readonly Func f_Func;

        #endregion

        #region properties

        /// <summary>Value A type</summary>
        public EType ValTypeA => f_ValTypeA;

        /// <summary>Value B type</summary>
        public EType ValTypeB => f_ValTypeB;

        #endregion

        #region method

        /// <summary>Performs the operation</summary>
        /// <param name="a">Value A</param>
        /// <param name="b">Value B</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, <paramref name="a"/> is less than <paramref name="b"/>
        ///     <br/>- Equal to zero, <paramref name="a"/> is equal to <paramref name="b"/>
        ///     <br/>- Greater than zero, <paramref name="a"/> is greater than <paramref name="b"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="a"/>.Type does not equal <see cref="ValTypeA"/>
        ///     <br/>or<br/>
        ///     <paramref name="b"/>.Type does not equal <see cref="ValTypeB"/>
        /// </exception>
        public int Perform(EValue a, EValue b)
        {
            try
            { return f_Func(a, b); }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
            catch when (a.Type != f_ValTypeA)
            { throw new ArgumentException($"{nameof(a)}.Type must equal {f_ValTypeA}.", nameof(a)); }
            catch when (b.Type != f_ValTypeB)
            { throw new ArgumentException($"{nameof(b)}.Type must equal {f_ValTypeB}.", nameof(b)); }
        }

        #endregion
    }
}
