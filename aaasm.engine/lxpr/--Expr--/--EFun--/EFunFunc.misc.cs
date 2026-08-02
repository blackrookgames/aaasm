using System;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region SIZEOF

        /// <summary>Returns the size (in bytes) of the input</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Size (in bytes)</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EI32 SIZEOF(ExprContext context, EValue input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return new EI32(input.Type.GetSize()); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion

        #region BOOL

        /// <summary>Casts the value as a boolean</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Size (in bytes)</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="input"/> cannot be casted as a boolean
        /// </exception>
        public static bool BOOL(ExprContext context, EValue input)
        {
            ArgumentNullException.ThrowIfNull(context);
            return MM_ToBool(input);
        }

        #endregion
    }
}

