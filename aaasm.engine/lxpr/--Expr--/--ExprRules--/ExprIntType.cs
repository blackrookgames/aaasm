// This was auto-generated from ExprIntType.cs.py
using System;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a name ID for a integer value type</summary>
    public enum ExprIntType : byte
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
    }

    public static class ExprIntType_ext
    {
        private static readonly ImmNullDict<ExprIntType, Func<EType>> TYPES = new([
            new(ExprIntType.U8, () => EType.U8),
            new(ExprIntType.I8, () => EType.I8),
            new(ExprIntType.U16, () => EType.U16),
            new(ExprIntType.I16, () => EType.I16),
            new(ExprIntType.U32, () => EType.U32),
            new(ExprIntType.I32, () => EType.I32),
            new(ExprIntType.U64, () => EType.U64),
            new(ExprIntType.I64, () => EType.I64),
        ]);

        /// <summary>Retrieves the actual expression value type</summary>
        public static EType Type(this ExprIntType id) => TYPES[id]();

    }
}
