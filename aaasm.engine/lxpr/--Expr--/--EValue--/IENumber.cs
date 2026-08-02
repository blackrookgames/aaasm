using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression numerical value</summary>
    public partial interface IENumber : IComparable<IENumber>
    {
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

        #region abstract properties

        /// <summary>Value type</summary>
        public EType Type { get; }

        #endregion

        #region abstract methods

        /// <summary>Operator function</summary>
        /// <param name="a">Value A</param>
        /// <param name="b">Value B</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, <paramref name="a"/> is less than <paramref name="b"/>
        ///     <br/>- Equal to zero, <paramref name="a"/> is equal to <paramref name="b"/>
        ///     <br/>- Greater than zero, <paramref name="a"/> is greater than <paramref name="b"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="a"/>.Type does not equal <see cref="ValTypeA"/>
        ///     <br/>or<br/>
        ///     <paramref name="b"/>.Type does not equal <see cref="ValTypeB"/>
        /// </exception>
        /// <summary>Converts the numeric value to a boolean</summary>
        /// <returns>Result</returns>
        public bool ToBool();

        /// <summary>Converts the numeric value to an 8-bit unsigned integer</summary>
        /// <returns>Result</returns>
        public byte ToByte();

        /// <summary>Converts the numeric value to an 8-bit signed integer</summary>
        /// <returns>Result</returns>
        public sbyte ToSbyte();

        /// <summary>Converts the numeric value to a 16-bit unsigned integer</summary>
        /// <returns>Result</returns>
        public ushort ToUshort();

        /// <summary>Converts the numeric value to a 16-bit signed integer</summary>
        /// <returns>Result</returns>
        public short ToShort();

        /// <summary>Converts the numeric value to a 32-bit unsigned integer</summary>
        /// <returns>Result</returns>
        public uint ToUint();

        /// <summary>Converts the numeric value to a 32-bit signed integer</summary>
        /// <returns>Result</returns>
        public int ToInt();

        /// <summary>Converts the numeric value to a 64-bit unsigned integer</summary>
        /// <returns>Result</returns>
        public ulong ToUlong();

        /// <summary>Converts the numeric value to a 64-bit signed integer</summary>
        /// <returns>Result</returns>
        public long ToLong();

        /// <summary>Converts the numeric value to a 32-bit floating-point decimal</summary>
        /// <returns>Result</returns>
        public float ToFloat();

        /// <summary>Converts the numeric value to a 64-bit floating-point decimal</summary>
        /// <returns>Result</returns>
        public double ToDouble();

        /// <summary>Converts the numeric value to a 128-bit signed integer</summary>
        /// <returns>Result</returns>
        public Int128 ToInt128();

        /// <summary>Prints the number in decimal format</summary>
        /// <returns>Generated string</returns>
        public string DebugDec();

        #endregion
    }
}
