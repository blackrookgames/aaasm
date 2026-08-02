// This was auto-generated from ETypeF32.cs.py
using System;
using aaasm.engine.col;

#pragma warning disable IDE0047

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a 32-bit floating-point decimal</summary>
    public class ETypeF32 : EType
    {
        #region init

        private ETypeF32() : 
            base(ETypeNameId.F32, FLAGS, 4, 0, null, ImmNullArray<EType>.EMPTY)
        { }

        #endregion

        #region const

        private const ETypeFlags FLAGS = ETypeFlags.NUMBER;

        /// <summary>32-bit floating-point decimal</summary>
        public static ETypeF32 TYPE { get; } = new();

        private static readonly ImmNullDict<EType, ETypeCompareOp> CMP_OPS = new([
            new(U8, new(F32, U8, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EU8)MM_ValidateType(b, U8)))),
            new(I8, new(F32, I8, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EI8)MM_ValidateType(b, I8)))),
            new(U16, new(F32, U16, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EU16)MM_ValidateType(b, U16)))),
            new(I16, new(F32, I16, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EI16)MM_ValidateType(b, I16)))),
            new(U32, new(F32, U32, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EU32)MM_ValidateType(b, U32)))),
            new(I32, new(F32, I32, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EI32)MM_ValidateType(b, I32)))),
            new(U64, new(F32, U64, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EU64)MM_ValidateType(b, U64)))),
            new(I64, new(F32, I64, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EI64)MM_ValidateType(b, I64)))),
            new(F32, new(F32, F32, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EF32)MM_ValidateType(b, F32)))),
            new(F64, new(F32, F64, (a, b) => 
                ((EF32)MM_ValidateType(a, F32)).CompareTo((EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> ADD_OPS = new([
            new(U8, new(F32, U8, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(F32, I8, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(F32, U16, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(F32, I16, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(F32, U32, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(F32, I32, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(F32, U64, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(F32, I64, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(F32, F32, F32, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(F32, F64, F64, (a, b) => 
                (EValue)EMathUtil.Add((EF32)MM_ValidateType(a, F32), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> SUB_OPS = new([
            new(U8, new(F32, U8, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(F32, I8, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(F32, U16, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(F32, I16, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(F32, U32, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(F32, I32, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(F32, U64, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(F32, I64, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(F32, F32, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(F32, F64, F64, (a, b) => 
                (EValue)EMathUtil.Sub((EF32)MM_ValidateType(a, F32), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MUL_OPS = new([
            new(U8, new(F32, U8, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(F32, I8, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(F32, U16, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(F32, I16, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(F32, U32, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(F32, I32, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(F32, U64, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(F32, I64, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(F32, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(F32, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mul((EF32)MM_ValidateType(a, F32), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> DIV_OPS = new([
            new(U8, new(F32, U8, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(F32, I8, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(F32, U16, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(F32, I16, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(F32, U32, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(F32, I32, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(F32, U64, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(F32, I64, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(F32, F32, F32, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(F32, F64, F64, (a, b) => 
                (EValue)EMathUtil.Div((EF32)MM_ValidateType(a, F32), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MOD_OPS = new([
            new(U8, new(F32, U8, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(F32, I8, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(F32, U16, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(F32, I16, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(F32, U32, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(F32, I32, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(F32, U64, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(F32, I64, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(F32, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(F32, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mod((EF32)MM_ValidateType(a, F32), (EF64)MM_ValidateType(b, F64)))),
        ]);

        #endregion

        #region EType

        /// <inheritdoc/>
        public override string GetName() => "32-bit floating-point decimal";

        /// <inheritdoc/>
        public override ETypeBoolConv BoolConv() => 
            new(F32, a => ((EF32)MM_ValidateType(a, F32)).Value != 0, a => new EF32((a ? 1 : 0)));

        /// <inheritdoc/>
        public override ETypeCompareOp Cmp(EType other)
        {
            if (CMP_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotCmp(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Add(EType other)
        {
            if (ADD_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotAdd(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Sub(EType other)
        {
            if (SUB_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotSub(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Mul(EType other)
        {
            if (MUL_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotMul(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Div(EType other)
        {
            if (DIV_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotDiv(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Mod(EType other)
        {
            if (MOD_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotMod(other);
        }

        /// <inheritdoc/>
        public override ETypeUnaryOp Neg() => 
            new(F32, F32, a => (EValue)EMathUtil.Neg((EF32)MM_ValidateType(a, F32)));

        #endregion
    }
}

#pragma warning restore IDE0047
