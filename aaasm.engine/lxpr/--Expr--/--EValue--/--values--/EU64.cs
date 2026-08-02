// This was auto-generated from EU64.cs.py
using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an 64-bit unsigned integer</summary>
    /// <param name="value">Underlying C# value</param>
    public class EU64(ulong value) : EInteger<ulong>(value)
    {
        #region EValue

        /// <inheritdoc/>
        public override EType Type => EType.U64;

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
                ETypeNameId.U8 => ToUlong() == _other.ToUlong(),
                ETypeNameId.I8 => ToInt128() == _other.ToInt128(),
                ETypeNameId.U16 => ToUlong() == _other.ToUlong(),
                ETypeNameId.I16 => ToInt128() == _other.ToInt128(),
                ETypeNameId.U32 => ToUlong() == _other.ToUlong(),
                ETypeNameId.I32 => ToInt128() == _other.ToInt128(),
                ETypeNameId.U64 => ToUlong() == _other.ToUlong(),
                ETypeNameId.I64 => ToInt128() == _other.ToInt128(),
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
                ETypeNameId.U8 => ToUlong().CompareTo(other.ToUlong()),
                ETypeNameId.I8 => ToInt128().CompareTo(other.ToInt128()),
                ETypeNameId.U16 => ToUlong().CompareTo(other.ToUlong()),
                ETypeNameId.I16 => ToInt128().CompareTo(other.ToInt128()),
                ETypeNameId.U32 => ToUlong().CompareTo(other.ToUlong()),
                ETypeNameId.I32 => ToInt128().CompareTo(other.ToInt128()),
                ETypeNameId.U64 => ToUlong().CompareTo(other.ToUlong()),
                ETypeNameId.I64 => ToInt128().CompareTo(other.ToInt128()),
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
            unchecked((uint)(Value & 4294967295));

        /// <inheritdoc/>
        private protected override int MM_ToInt() =>
            unchecked((int)(Value & 4294967295));

        /// <inheritdoc/>
        private protected override ulong MM_ToUlong() => 
            Value;

        /// <inheritdoc/>
        private protected override long MM_ToLong() => 
            unchecked((long)Value);

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
            (int)Math.Min(int.MaxValue, Value);

        /// <inheritdoc/>
        private protected override bool MM_TryChar(out char result)
        {
            #pragma warning disable IDE0004
            result = unchecked((char)Value);
            ulong test = unchecked((ulong)result);
            if (Value == test) return true;
            result = default;
            return false;
            #pragma warning restore IDE0004
        }

        /// <inheritdoc/>
        private protected override string MM_DebugBin() => $"{Value:b64}";

        /// <inheritdoc/>
        private protected override string MM_DebugHex() => $"{Value:X16}";

        #endregion

    }
}

