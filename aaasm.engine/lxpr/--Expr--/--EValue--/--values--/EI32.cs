// This was auto-generated from EI32.cs.py
using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an 32-bit signed integer</summary>
    /// <param name="value">Underlying C# value</param>
    public class EI32(int value) : EInteger<int>(value)
    {
        #region EValue

        /// <inheritdoc/>
        public override EType Type => EType.I32;

        /// <inheritdoc/>
        private protected override string MM_ToString(ExprRules? exprRules)
        {
            if (exprRules is not null)
            {
                if (Type == exprRules.Literals.CharType.Type())
                {
                    try { return IEInteger.MM_Chr2Str((char)Value); }
                    catch { }
                }
            }
            return Value.ToString();
        }

        /// <inheritdoc/>
        private protected override bool MM_Equals(EValue other)
        {
            if (other is not IENumber _other) return false;
            return other.Type.NameId switch
            {
                ETypeNameId.U8 => ToInt() == _other.ToInt(),
                ETypeNameId.I8 => ToInt() == _other.ToInt(),
                ETypeNameId.U16 => ToInt() == _other.ToInt(),
                ETypeNameId.I16 => ToInt() == _other.ToInt(),
                ETypeNameId.U32 => ToLong() == _other.ToLong(),
                ETypeNameId.I32 => ToInt() == _other.ToInt(),
                ETypeNameId.U64 => ToInt128() == _other.ToInt128(),
                ETypeNameId.I64 => ToLong() == _other.ToLong(),
                ETypeNameId.F32 => ToFloat() == _other.ToFloat(),
                ETypeNameId.F64 => ToDouble() == _other.ToDouble(),
                _ => false
            };
        }

        #endregion

        #region ENumber

        /// <inheritdoc/>
        private protected override int MM_CompareTo(IENumber other)
        {
            if (other is not EValue _other) return 1;
            return _other.Type.NameId switch
            {
                ETypeNameId.U8 => ToInt().CompareTo(other.ToInt()),
                ETypeNameId.I8 => ToInt().CompareTo(other.ToInt()),
                ETypeNameId.U16 => ToInt().CompareTo(other.ToInt()),
                ETypeNameId.I16 => ToInt().CompareTo(other.ToInt()),
                ETypeNameId.U32 => ToLong().CompareTo(other.ToLong()),
                ETypeNameId.I32 => ToInt().CompareTo(other.ToInt()),
                ETypeNameId.U64 => ToInt128().CompareTo(other.ToInt128()),
                ETypeNameId.I64 => ToLong().CompareTo(other.ToLong()),
                ETypeNameId.F32 => ToFloat().CompareTo(other.ToFloat()),
                ETypeNameId.F64 => ToDouble().CompareTo(other.ToDouble()),
                _ => 1
            };
        }

        /// <inheritdoc/>
        private protected override bool MM_ToBool() => 
            Value != 0;

        /// <inheritdoc/>
        private protected override byte MM_ToByte() => 
            unchecked((byte)(Value & 255));

        /// <inheritdoc/>
        private protected override sbyte MM_ToSbyte() => 
            unchecked((sbyte)(Value & 255));

        /// <inheritdoc/>
        private protected override ushort MM_ToUshort() => 
            unchecked((ushort)(Value & 65535));

        /// <inheritdoc/>
        private protected override short MM_ToShort() => 
            unchecked((short)(Value & 65535));

        /// <inheritdoc/>
        private protected override uint MM_ToUint() => 
            unchecked((uint)Value);

        /// <inheritdoc/>
        private protected override int MM_ToInt() =>
            Value;

        /// <inheritdoc/>
        private protected override ulong MM_ToUlong() => 
            unchecked((ulong)Value);

        /// <inheritdoc/>
        private protected override long MM_ToLong() => 
            Value;

        /// <inheritdoc/>
        private protected override float MM_ToFloat() =>
            Value;

        /// <inheritdoc/>
        private protected override double MM_ToDouble() =>
            Value;

        /// <inheritdoc/>
        private protected override Int128 MM_ToInt128() =>
            unchecked(Value);

        #endregion

        #region EInteger

        /// <inheritdoc/>
        private protected override int MM_ToShift() =>
            Value;

        /// <inheritdoc/>
        private protected override bool MM_TryChar(out char result)
        {
            #pragma warning disable IDE0004
            result = unchecked((char)Value);
            int test = unchecked((int)result);
            if (Value == test) return true;
            result = default;
            return false;
            #pragma warning restore IDE0004
        }

        /// <inheritdoc/>
        private protected override string MM_DebugBin() => $"{Value:b32}";

        /// <inheritdoc/>
        private protected override string MM_DebugHex() => $"{Value:X8}";

        #endregion

    }
}

