namespace aaasm.engine.lxpr
{
    /// <summary>Represents a name ID for a expression value type</summary>
    public enum ETypeNameId : byte
    {
        /// <summary>8-bit unsigned integer</summary>
        U8,
        /// <summary>8-bit signed integer</summary>
        I8,
        /// <summary>16-bit unsigned integer</summary>
        U16,
        /// <summary>16-bit signed integer</summary>
        I16,
        /// <summary>32-bit unsigned integer</summary>
        U32,
        /// <summary>32-bit signed integer</summary>
        I32,
        /// <summary>64-bit unsigned integer</summary>
        U64,
        /// <summary>64-bit signed integer</summary>
        I64,
        /// <summary>32-bit floating-point decimal</summary>
        F32,
        /// <summary>64-bit floating-point decimal</summary>
        F64,
        /// <summary>Array of elements of the same type</summary>
        ARRAY,
        /// <summary>Similar of arrays, but each element can be of a different type</summary>
        TUPLE,
        /// <summary>Immediate</summary>
        IMMEDIATE,
    }
}
