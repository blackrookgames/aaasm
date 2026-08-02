using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents expression value type flags</summary>
    [Flags]
    public enum ETypeFlags : byte
    {
        /// <summary>No flags are set</summary>
        NONE = 0,

        /// <summary>Number flag is set, indicating a value is numeric</summary>
        NUMBER = 1 << 0,

        /// <summary>Integer flag is set, indicating a value is an integer</summary>
        INTEGER = 1 << 1,

        /// <summary>Collection flag, indicating a value is a collection</summary>
        COLLECTION = 1 << 2,
    }
}