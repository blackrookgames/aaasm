// This was auto-generated from ETypeU64.cs.py
using System;
using aaasm.engine.col;

#pragma warning disable IDE0047

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an 64-bit unsigned integer</summary>
    public class ETypeU64 : EType
    {
        #region init

        private ETypeU64() : 
            base(ETypeNameId.U64, FLAGS, 8, 0, null, ImmNullArray<EType>.EMPTY)
        { }

        #endregion

        #region const

        private const ETypeFlags FLAGS = ETypeFlags.NUMBER | ETypeFlags.INTEGER;

        /// <summary>64-bit unsigned integer</summary>
        public static ETypeU64 TYPE { get; } = new();

        private static readonly ImmNullDict<EType, ETypeCompareOp> CMP_OPS = new([
            new(U8, new(U64, U8, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U64, F32, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U64, F64, (a, b) => 
                ((EU64)MM_ValidateType(a, U64)).CompareTo((EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> ADD_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Add((EU64)MM_ValidateType(a, U64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> SUB_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Sub((EU64)MM_ValidateType(a, U64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MUL_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mul((EU64)MM_ValidateType(a, U64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> DIV_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Div((EU64)MM_ValidateType(a, U64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MOD_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(U64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(U64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mod((EU64)MM_ValidateType(a, U64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITAND_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITOR_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITXOR_OPS = new([
            new(U8, new(U64, U8, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(U64, I8, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(U64, U16, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(U64, I16, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(U64, U32, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(U64, I32, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(U64, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(U64, I64, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EU64)MM_ValidateType(a, U64), (EI64)MM_ValidateType(b, I64)))),
        ]);

        #endregion

        #region EType

        /// <inheritdoc/>
        public override string GetName() => "64-bit unsigned integer";

        /// <inheritdoc/>
        public override ETypeBoolConv BoolConv() => 
            new(U64, a => ((EU64)MM_ValidateType(a, U64)).Value != 0, a => new EU64(unchecked((ulong)(a ? 1 : 0))));

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
            new(U64, I64, a => (EValue)EMathUtil.Neg((EU64)MM_ValidateType(a, U64)));

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
            new(U64, U64, a => (EValue)EMathUtil.BitNot((EU64)MM_ValidateType(a, U64)));

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftL(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftL(other);
            return new(U64, other, U64,
                (input, amount) => (EValue)EMathUtil.ShiftL(
                (EU64)MM_ValidateType(input, U64),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftR(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftR(other);
            return new(U64, other, U64,
                (input, amount) => (EValue)EMathUtil.ShiftR(
                (EU64)MM_ValidateType(input, U64),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftRU(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftRU(other);
            return new(U64, other, U64,
                (input, amount) => (EValue)EMathUtil.ShiftRU(
                (EU64)MM_ValidateType(input, U64),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        #endregion
    }
}

#pragma warning restore IDE0047
