// This was auto-generated from ETypeI64.cs.py
using System;
using aaasm.engine.col;

#pragma warning disable IDE0047

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an 64-bit signed integer</summary>
    public class ETypeI64 : EType
    {
        #region init

        private ETypeI64() : 
            base(ETypeNameId.I64, FLAGS, 8, 0, null, ImmNullArray<EType>.EMPTY)
        { }

        #endregion

        #region const

        private const ETypeFlags FLAGS = ETypeFlags.NUMBER | ETypeFlags.INTEGER;

        /// <summary>64-bit signed integer</summary>
        public static ETypeI64 TYPE { get; } = new();

        private static readonly ImmNullDict<EType, ETypeCompareOp> CMP_OPS = new([
            new(U8, new(I64, U8, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EI64)MM_ValidateType(b, I64)))),
            new(F32, new(I64, F32, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EF32)MM_ValidateType(b, F32)))),
            new(F64, new(I64, F64, (a, b) => 
                ((EI64)MM_ValidateType(a, I64)).CompareTo((EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> ADD_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(I64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(I64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Add((EI64)MM_ValidateType(a, I64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> SUB_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(I64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(I64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Sub((EI64)MM_ValidateType(a, I64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MUL_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(I64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(I64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mul((EI64)MM_ValidateType(a, I64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> DIV_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(I64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(I64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Div((EI64)MM_ValidateType(a, I64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> MOD_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
            new(F32, new(I64, F32, F32, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EF32)MM_ValidateType(b, F32)))),
            new(F64, new(I64, F64, F64, (a, b) => 
                (EValue)EMathUtil.Mod((EI64)MM_ValidateType(a, I64), (EF64)MM_ValidateType(b, F64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITAND_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.BitAnd((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITOR_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.BitOr((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
        ]);

        private static readonly ImmNullDict<EType, ETypeBinaryOp> BITXOR_OPS = new([
            new(U8, new(I64, U8, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EU8)MM_ValidateType(b, U8)))),
            new(I8, new(I64, I8, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EI8)MM_ValidateType(b, I8)))),
            new(U16, new(I64, U16, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EU16)MM_ValidateType(b, U16)))),
            new(I16, new(I64, I16, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EI16)MM_ValidateType(b, I16)))),
            new(U32, new(I64, U32, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EU32)MM_ValidateType(b, U32)))),
            new(I32, new(I64, I32, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EI32)MM_ValidateType(b, I32)))),
            new(U64, new(I64, U64, U64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EU64)MM_ValidateType(b, U64)))),
            new(I64, new(I64, I64, I64, (a, b) => 
                (EValue)EMathUtil.BitXor((EI64)MM_ValidateType(a, I64), (EI64)MM_ValidateType(b, I64)))),
        ]);

        #endregion

        #region EType

        /// <inheritdoc/>
        public override string GetName() => "64-bit signed integer";

        /// <inheritdoc/>
        public override ETypeBoolConv BoolConv() => 
            new(I64, a => ((EI64)MM_ValidateType(a, I64)).Value != 0, a => new EI64((a ? 1 : 0)));

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
            new(I64, I64, a => (EValue)EMathUtil.Neg((EI64)MM_ValidateType(a, I64)));

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
            new(I64, I64, a => (EValue)EMathUtil.BitNot((EI64)MM_ValidateType(a, I64)));

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftL(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftL(other);
            return new(I64, other, I64,
                (input, amount) => (EValue)EMathUtil.ShiftL(
                (EI64)MM_ValidateType(input, I64),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftR(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftR(other);
            return new(I64, other, I64,
                (input, amount) => (EValue)EMathUtil.ShiftR(
                (EI64)MM_ValidateType(input, I64),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp ShiftRU(EType other)
        {
        if (!other.IsInteger()) throw MM_CannotShiftRU(other);
            return new(I64, other, I64,
                (input, amount) => (EValue)EMathUtil.ShiftRU(
                (EI64)MM_ValidateType(input, I64),
                (IEInteger)MM_ValidateType(amount, other)));
        }

        #endregion
    }
}

#pragma warning restore IDE0047
