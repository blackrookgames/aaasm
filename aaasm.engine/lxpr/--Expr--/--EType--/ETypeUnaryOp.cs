using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a unary operator</summary>
    public class ETypeUnaryOp
    {
        #region nested

        /// <summary>Operator function</summary>
        /// <param name="arg">Argument</param>
        /// <returns>Return value</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="arg"/>.Type does not equal <see cref="ArgType"/>
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred during the operation
        /// </exception>
        public delegate EValue Func(EValue arg);

        /// <summary>Initializer for <see cref="ETypeUnaryOp"/></summary>
        /// <param name="argType">Argument type</param>
        /// <param name="retType">Return type</param>
        /// <param name="func">Operator function</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="argType"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="retType"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="func"/> is null
        /// </exception>
        public ETypeUnaryOp(EType argType, EType retType, Func func)
        {
            ArgumentNullException.ThrowIfNull(argType);
            ArgumentNullException.ThrowIfNull(retType);
            ArgumentNullException.ThrowIfNull(func);
            f_ArgType = argType;
            f_RetType = retType;
            f_Func = func;
        }

        #endregion

        #region fields

        private readonly EType f_ArgType;
        private readonly EType f_RetType;
        private readonly Func f_Func;

        #endregion

        #region properties

        /// <summary>Argument type</summary>
        public EType ArgType => f_ArgType;

        /// <summary>Return type</summary>
        public EType RetType => f_RetType;

        #endregion

        #region method

        /// <summary>Performs the operation</summary>
        /// <param name="arg">Argument</param>
        /// <returns>Operation result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="arg"/>.Type does not equal <see cref="ArgType"/>
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred during the operation
        /// </exception>
        public EValue Perform(EValue arg)
        {
            try
            { return f_Func(arg); }
            catch when (arg is null)
            { throw new ArgumentNullException(nameof(arg)); }
            catch when (arg.Type != f_ArgType)
            { throw new ArgumentException($"{nameof(arg)}.Type must equal {f_ArgType}.", nameof(arg)); }
        }

        #endregion
    }
}
