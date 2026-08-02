// This was auto-generated from EF32.cs.py
using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a 32-bit floating-point decimal</summary>
    /// <param name="value">Underlying C# value</param>
    public class EF32(float value) : ENumber<float>(value)
    {
        #region EValue

        /// <inheritdoc/>
        public override EType Type => EType.F32;

        /// <inheritdoc/>
        private protected override string MM_ToString(ExprRules? exprRules)
        {
            return Value.ToString();
        }

        /// <inheritdoc/>
        private protected override bool MM_Equals(EValue other)
        {
            if (other is not IENumber _other) return false;
            if (other.Type.NameId == ETypeNameId.F64)
                return ToDouble() == _other.ToDouble();
            return ToFloat() == _other.ToFloat();
        }

        #endregion

        #region ENumber

        /// <inheritdoc/>
        private protected override int MM_CompareTo(IENumber other)
        {
            if (other is not EValue _other) return 1;
            if (_other.Type.NameId == ETypeNameId.F64)
                return ToDouble().CompareTo(other.ToDouble());
            return ToFloat().CompareTo(other.ToFloat());
        }

        /// <inheritdoc/>
        private protected override bool MM_ToBool() => 
            Value != 0;

        /// <inheritdoc/>
        private protected override byte MM_ToByte() => 
            unchecked((byte)(((long)Math.Round(Value)) & 0xFF));

        /// <inheritdoc/>
        private protected override sbyte MM_ToSbyte() => 
            unchecked((sbyte)(((long)Math.Round(Value)) & 0xFF));

        /// <inheritdoc/>
        private protected override ushort MM_ToUshort() => 
            unchecked((ushort)(((long)Math.Round(Value)) & 0xFFFF));

        /// <inheritdoc/>
        private protected override short MM_ToShort() => 
            unchecked((short)(((long)Math.Round(Value)) & 0xFFFF));

        /// <inheritdoc/>
        private protected override uint MM_ToUint() => 
            unchecked((uint)(((long)Math.Round(Value)) & 0xFFFFFFFF));

        /// <inheritdoc/>
        private protected override int MM_ToInt() =>
            unchecked((int)(((long)Math.Round(Value)) & 0xFFFFFFFF));

        /// <inheritdoc/>
        private protected override ulong MM_ToUlong() => 
            unchecked((ulong)(long)Math.Round(Value));

        /// <inheritdoc/>
        private protected override long MM_ToLong() => 
            unchecked((long)Math.Round(Value));

        /// <inheritdoc/>
        private protected override float MM_ToFloat() =>
            (float)Value;

        /// <inheritdoc/>
        private protected override double MM_ToDouble() =>
            (double)Value;

        /// <inheritdoc/>
        private protected override Int128 MM_ToInt128() =>
            (Int128)Math.Round(Value);

        #endregion

    }
}

