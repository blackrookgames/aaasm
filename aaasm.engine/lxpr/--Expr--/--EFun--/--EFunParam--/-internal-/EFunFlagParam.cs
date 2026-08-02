using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents parameter that targets certain type flag</summary>
    /// <param name="flags">Target flags</param>
    internal readonly struct EFunFlagParam(ETypeFlags flags) : IEFunParam
    {
        #region fields

        private readonly ETypeFlags f_Flags = flags;

        #endregion

        #region properties

        /// <summary>Target flags</summary>
        public ETypeFlags Flags => f_Flags;

        #endregion

        #region helper methods

        private bool MM_Match(EType type)
        {
            if (f_Flags == ETypeFlags.NONE) return true; // No flags specified? Any type will do.
            return (type.Flags & f_Flags) != ETypeFlags.NONE;
        }

        #endregion

        #region IEFunParam

        /// <inheritdoc/>
        public bool Match(EValue? value)
        {
            if (value is null) return false;
            return MM_Match(value.Type);
        }

        /// <inheritdoc/>
        public bool AssignableFrom(ENodeValueType? type)
        {
            if (type is null) return false;
            return MM_Match(type.Type);
        }

        /// <inheritdoc/>
        public object Parse(EValue arg)
        {
            try
            {
                if (MM_Match(arg.Type)) return arg;
                throw new BadSrcException($"{arg.Type.GetName()} cannot be assigned to the parameter.");
            }
            catch when (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
        }

        #endregion
    }
}