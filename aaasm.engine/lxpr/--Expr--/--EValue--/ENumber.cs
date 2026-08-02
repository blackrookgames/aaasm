using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression numerical value</summary>
    /// <typeparam name="T">Underlying C# value type</typeparam>
    /// <param name="value">Underlying C# value</param>
    public abstract class ENumber<T>(T value) : EValue, IENumber where T: struct
    {
        #region fields

        private readonly T f_Value = value;

        #endregion
        
        #region properties

        /// <summary>Underlying C# value</summary>
        public T Value => f_Value;

        #endregion
        
        #region abstract methods

        private protected abstract int MM_CompareTo(IENumber other);

        private protected abstract bool MM_ToBool();

        private protected abstract byte MM_ToByte();

        private protected abstract sbyte MM_ToSbyte();

        private protected abstract ushort MM_ToUshort();

        private protected abstract short MM_ToShort();

        private protected abstract uint MM_ToUint();

        private protected abstract int MM_ToInt();

        private protected abstract ulong MM_ToUlong();

        private protected abstract long MM_ToLong();

        private protected abstract float MM_ToFloat();

        private protected abstract double MM_ToDouble();
        
        private protected abstract Int128 MM_ToInt128();

        #endregion

        #region methods

        /// <inheritdoc cref="ToByte"/>
        public EU8 ToU8() => new(ToByte());

        /// <inheritdoc cref="ToSbyte"/>
        public EI8 ToI8() => new(ToSbyte());

        /// <inheritdoc cref="ToUshort"/>
        public EU16 ToU16() => new(ToUshort());

        /// <inheritdoc cref="ToShort"/>
        public EI16 ToI16() => new(ToShort());

        /// <inheritdoc cref="ToUint"/>
        public EU32 ToU32() => new(ToUint());

        /// <inheritdoc cref="ToInt"/>
        public EI32 ToI32() => new(ToInt());

        /// <inheritdoc cref="ToUlong"/>
        public EU64 ToU64() => new(ToUlong());

        /// <inheritdoc cref="ToLong"/>
        public EI64 ToI64() => new(ToLong());

        /// <inheritdoc cref="ToFloat"/>
        public EF32 ToF32() => new(ToFloat());

        /// <inheritdoc cref="ToDouble"/>
        public EF64 ToF64() => new(ToDouble());

        #endregion

        #region EValue

        /// <inheritdoc/>
        private protected override int MM_GetHashCode() =>
            f_Value.GetHashCode();

        #endregion

        #region IENumber

        /// <inheritdoc/>
        public bool ToBool() => MM_ToBool();

        /// <inheritdoc/>
        public byte ToByte() => MM_ToByte();

        /// <inheritdoc/>
        public sbyte ToSbyte() => MM_ToSbyte();

        /// <inheritdoc/>
        public short ToShort() => MM_ToShort();

        /// <inheritdoc/>
        public ushort ToUshort() => MM_ToUshort();

        /// <inheritdoc/>
        public uint ToUint() => MM_ToUint();

        /// <inheritdoc/>
        public int ToInt() => MM_ToInt();

        /// <inheritdoc/>
        public ulong ToUlong() => MM_ToUlong();

        /// <inheritdoc/>
        public long ToLong() => MM_ToLong();

        /// <inheritdoc/>
        public float ToFloat() => MM_ToFloat();

        /// <inheritdoc/>
        public double ToDouble() => MM_ToDouble();
        
        /// <inheritdoc/>
        public Int128 ToInt128() => MM_ToInt128();

        /// <inheritdoc/>
        public string DebugDec() => $"{f_Value}";

        #endregion

        #region IComparable
        
        /// <summary>
        ///     Performs a comparison between 
        ///     the current <see cref="IENumber"/> 
        ///     and another <see cref="IENumber"/>
        /// </summary>
        /// <param name="other">Other <see cref="IENumber"/></param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero,
        ///         the current <see cref="IENumber"/> 
        ///         is less than <paramref name="other"/>
        ///     <br/>- Equal to zero, 
        ///         the current <see cref="IENumber"/> 
        ///         is equal to <paramref name="other"/>
        ///     <br/>- Greater than zero, 
        ///         the current <see cref="IENumber"/> 
        ///         is greater than <paramref name="other"/>
        /// </returns>
        public int CompareTo(IENumber? other)
        {
            if (other is null) return 1;
            return MM_CompareTo(other);
        }

        #endregion
    }
}
