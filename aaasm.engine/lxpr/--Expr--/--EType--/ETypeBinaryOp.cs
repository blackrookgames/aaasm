using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a binary operator</summary>
    public class ETypeBinaryOp
    {
        #region nested

        /// <summary>Operator function</summary>
        /// <param name="a">Argument A</param>
        /// <param name="b">Argument B</param>
        /// <returns>Return value</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="a"/>.Type does not equal <see cref="ArgTypeA"/>
        ///     <br/>or<br/>
        ///     <paramref name="b"/>.Type does not equal <see cref="ArgTypeB"/>
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred during the operation
        /// </exception>
        public delegate EValue Func(EValue a, EValue b);

        /// <summary>Initializer for <see cref="ETypeBinaryOp"/></summary>
        /// <param name="argTypeA">Argument A type</param>
        /// <param name="argTypeB">Argument B type</param>
        /// <param name="retType">Return type</param>
        /// <param name="func">Operator function</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="argTypeA"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="argTypeB"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="retType"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="func"/> is null
        /// </exception>
        public ETypeBinaryOp(EType argTypeA, EType argTypeB, EType retType, Func func)
        {
            ArgumentNullException.ThrowIfNull(argTypeA);
            ArgumentNullException.ThrowIfNull(argTypeB);
            ArgumentNullException.ThrowIfNull(retType);
            ArgumentNullException.ThrowIfNull(func);
            f_ArgTypeA = argTypeA;
            f_ArgTypeB = argTypeB;
            f_RetType = retType;
            f_Func = func;
        }

        #endregion

        #region fields

        private readonly EType f_ArgTypeA;
        private readonly EType f_ArgTypeB;
        private readonly EType f_RetType;
        private readonly Func f_Func;

        #endregion

        #region properties

        /// <summary>Argument A type</summary>
        public EType ArgTypeA => f_ArgTypeA;

        /// <summary>Argument B type</summary>
        public EType ArgTypeB => f_ArgTypeB;

        /// <summary>Return type</summary>
        public EType RetType => f_RetType;

        #endregion

        #region method

        /// <summary>Performs the operation</summary>
        /// <param name="a">Argument A</param>
        /// <param name="b">Argument B</param>
        /// <returns>Operation result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="a"/>.Type does not equal <see cref="ArgTypeA"/>
        ///     <br/>or<br/>
        ///     <paramref name="b"/>.Type does not equal <see cref="ArgTypeB"/>
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred during the operation
        /// </exception>
        public EValue Perform(EValue a, EValue b)
        {
            try
            { return f_Func(a, b); }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
            catch when (a.Type != f_ArgTypeA)
            { throw new ArgumentException($"{nameof(a)}.Type must equal {f_ArgTypeA}.", nameof(a)); }
            catch when (b.Type != f_ArgTypeB)
            { throw new ArgumentException($"{nameof(b)}.Type must equal {f_ArgTypeB}.", nameof(b)); }
        }

        #endregion
    }
}
