// This was auto-generated from ETypeU8.cs.py
using System;
using aaasm.engine.col;

#pragma warning disable IDE0047

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an 8-bit unsigned integer</summary>
    public class ETypeU8 : EType
    {
        #region init

        private ETypeU8() : 
            base(ETypeNameId.U8, FLAGS, 1, 0, null, ImmNullArray<EType>.EMPTY)
        { }

        #endregion

        #region const

        private const ETypeFlags FLAGS = ETypeFlags.NUMBER | ETypeFlags.INTEGER;

        /// <summary>8-bit unsigned integer</summary>
        public static ETypeU8 TYPE { get; } = new();

        private static readonly ImmNullDict<EType, ETypeCompareOp> CMP_OPS = new([
            new(U8, new(U8, U8, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U8, F32, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U8, F64, (a, b) => 
                ((EU8)MM_ValidateType(a, U8)).CompareTo((EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> ADD_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U8, F32, F32, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U8, F64, F64, (a, b) => 
                (EValue)EMathUtil.Add((EU8)MM_ValidateType(a, U8), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> SUB_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U8, F32, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U8, F64, F64, (a, b) => 
                (EValue)EMathUtil.Sub((EU8)MM_ValidateType(a, U8), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MUL_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U8, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U8, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mul((EU8)MM_ValidateType(a, U8), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> DIV_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U8, F32, F32, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U8, F64, F64, (a, b) => 
                (EValue)EMathUtil.Div((EU8)MM_ValidateType(a, U8), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MOD_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U8, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U8, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mod((EU8)MM_ValidateType(a, U8), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITAND_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITOR_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITXOR_OPS = new([
            new(U8, new(U8, U8, U8, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U8, I8, U8, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U8, U16, U16, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U8, I16, I16, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U8, U32, U32, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U8, I32, I32, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U8, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U8, I64, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU8)MM_ValidateType(a, U8), (EI64)MM_ValidateType(b, I64)))),
        ]);

        #endregion

        #region EType

        /// <inheritdoc/>
        public override string GetName() => "8-bit unsigned integer";

        /// <inheritdoc/>
        public override ETypeBoolConv BoolConv() => 
            new(U8, a => ((EU8)MM_ValidateType(a, U8)).Value != 0, a => new EU8(unchecked((byte)((a ? 1 : 0) & 255))));

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
            new(U8, I8, a => (EValue)EMathUtil.Neg((EU8)MM_ValidateType(a, U8)));

        /// <inheritdoc/>
        public override ETypeBinaryOp BitAnd(EType other)
        {
            if (BITAND_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotBitAnd(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp BitOr(EType other)
        {
            if (BITOR_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotBitOr(other);
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp BitXor(EType other)
        {
            if (BITXOR_OPS.TryGetValue(other, out var op)) return op;
            throw MM_CannotBitXor(other);
        }

        /// <inheritdoc/>
        public override ETypeUnaryOp BitNot() => 
            new(U8, U8, a => (EValue)EMathUtil.BitNot((EU8)MM_ValidateType(a, U8)));

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftL(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftL(other);
            return new(U8, other, U8,
                (input, amount) => (EValue)EMathUtil.ShiftL(
                (EU8)MM_ValidateType(input, U8),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftR(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftR(other);
            return new(U8, other, U8,
                (input, amount) => (EValue)EMathUtil.ShiftR(
                (EU8)MM_ValidateType(input, U8),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftRU(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftRU(other);
            return new(U8, other, U8,
                (input, amount) => (EValue)EMathUtil.ShiftRU(
                (EU8)MM_ValidateType(input, U8),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        #endregion
    }
}

#pragma warning restore IDE0047
