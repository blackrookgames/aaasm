using System;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a boolean converter</summary>
    /// <param name="type">Type for converting to/from bool</param>
    /// <param name="toBool">Function for converting to bool</param>
    /// <param name="fromBool">Function for converting from bool</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="type"/> is null
    ///     <br/>or<br/>
    ///     <paramref name="toBool"/> is null
    ///     <br/>or<br/>
    ///     <paramref name="fromBool"/> is null
    /// </exception>
    public class ETypeBoolConv(EType type, ETypeBoolConv.ToBoolFunc toBool, ETypeBoolConv.FromBoolFunc fromBool)
    {
        #region nested

        /// <summary>Function for converting to bool</summary>
        /// <param name="input">Input</param>
        /// <returns>Conversion result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/>.Type does not equal <see cref="Type"/>
        /// </exception>
        public delegate bool ToBoolFunc(EValue input);

        /// <summary>Function for converting from bool</summary>
        /// <param name="input">Input</param>
        /// <returns>Conversion result</returns>
        public delegate EValue FromBoolFunc(bool input);

        #endregion

        #region fields

        private readonly EType f_Type = ArgUtil.NotNull(type);
        private readonly ToBoolFunc f_ToBoolFunc = ArgUtil.NotNull(toBool);
        private readonly FromBoolFunc f_FromBoolFunc = ArgUtil.NotNull(fromBool);

        #endregion

        #region properties

        /// <summary>Type for converting to/from bool</summary>
        public EType Type => f_Type;

        #endregion

        #region method

        /// <summary>Converts to bool</summary>
        /// <param name="input">Input</param>
        /// <returns>Conversion result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/>.Type does not equal <see cref="Type"/>
        /// </exception>
        public bool ToBool(EValue input)
        {
            try
            { return f_ToBoolFunc(input); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
            catch when (input.Type != f_Type)
            { throw new ArgumentException($"{nameof(input)}.Type must equal {f_Type}.", nameof(input)); }
        }

        /// <summary>Converts from bool</summary>
        /// <param name="input">Input</param>
        /// <returns>Conversion result</returns>
        public EValue FromBool(bool input)
        {
            return f_FromBoolFunc(input);
        }

        #endregion
    }
}
