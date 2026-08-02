using System;
using System.Collections.Generic;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a collection</summary>
    public partial interface IECollection : IReadOnlyList<EValue>
    {
        #region abstract properties

        /// <summary>Value type</summary>
        public EType Type { get; }

        /// <summary>Number of elements in collection</summary>
        public int Length { get; }

        #endregion
    }
}
