using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a parameter that targets a literal 32-bit signed integer</summary>
    internal class EFunLitModParam : IEFunParam
    {
        #region const

        /// <summary>Static instance of <see cref="EFunLitModParam"/></summary>
        public static EFunLitModParam PARAM { get; } = new();

        #endregion

        #region methods

        /// <summary>Parses the specified arg</summary>
        /// <param name="arg">Argument to parse</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     <paramref name="arg"/> is invalid
        /// </exception>
        public static int Parse(EValue arg)
        {
            try
            {
                if (arg is IEInteger integer) return integer.ToShift(); // Use ToShift for clamping
                throw new BadSrcException($"{arg.Type.GetName()} cannot be assigned to the parameter.");
            }
            catch when (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
        }

        #endregion

        #region IEFunParam

        /// <inheritdoc/>
        public bool Match(EValue? value)
        {
            if (value is null) return false;
            return value.Type.IsInteger();
        }

        /// <inheritdoc/>
        public bool AssignableFrom(ENodeValueType? type)
        {
            if (type is null) return false;
            if (type.Literal is null) return false;
            return type.Type.IsInteger();
        }

        object IEFunParam.Parse(EValue arg) => Parse(arg);

        #endregion
    }
}