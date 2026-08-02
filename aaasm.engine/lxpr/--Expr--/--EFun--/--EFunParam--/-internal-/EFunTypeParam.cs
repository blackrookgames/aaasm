using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary></summary>
    /// <param name="nameId"></param>
    internal readonly struct EFunTypeParam(ETypeNameId nameId) : IEFunParam
    {
        #region fields

        private readonly ETypeNameId f_NameId = nameId;

        #endregion

        #region properties

        /// <summary>Name ID of target type</summary>
        public ETypeNameId NameId => f_NameId;

        #endregion

        #region IEFunParam

        /// <inheritdoc/>
        public bool Match(EValue? value)
        {
            if (value is null) return false;
            return value.Type.NameId == f_NameId;
        }

        /// <inheritdoc/>
        public bool AssignableFrom(ENodeValueType? type)
        {
            if (type is null) return false;
            return type.Type.NameId == f_NameId;
        }

        /// <inheritdoc/>
        public object Parse(EValue arg)
        {
            try
            {
                if (arg.Type.NameId == f_NameId) return arg;
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