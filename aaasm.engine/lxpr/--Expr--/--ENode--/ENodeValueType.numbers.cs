// This was auto-generated from ENodeValueType.numbers.cs.py
namespace aaasm.engine.lxpr
{
    public partial class ENodeValueType
    {
        /// <summary>8-bit unsigned integer</summary>
        public static ENodeValueType U8 { get; } = new(EType.U8);

        /// <summary>8-bit signed integer</summary>
        public static ENodeValueType I8 { get; } = new(EType.I8);

        /// <summary>16-bit unsigned integer</summary>
        public static ENodeValueType U16 { get; } = new(EType.U16);

        /// <summary>16-bit signed integer</summary>
        public static ENodeValueType I16 { get; } = new(EType.I16);

        /// <summary>32-bit unsigned integer</summary>
        public static ENodeValueType U32 { get; } = new(EType.U32);

        /// <summary>32-bit signed integer</summary>
        public static ENodeValueType I32 { get; } = new(EType.I32);

        /// <summary>64-bit unsigned integer</summary>
        public static ENodeValueType U64 { get; } = new(EType.U64);

        /// <summary>64-bit signed integer</summary>
        public static ENodeValueType I64 { get; } = new(EType.I64);

        /// <summary>32-bit floating-point decimal</summary>
        public static ENodeValueType F32 { get; } = new(EType.F32);

        /// <summary>64-bit floating-point decimal</summary>
        public static ENodeValueType F64 { get; } = new(EType.F64);
    }
}
