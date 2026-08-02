// This was auto-generated from EMathUtil.EU8.cs.py
using System;

#pragma warning disable IDE0047

namespace aaasm.engine.lxpr
{
    public partial class EMathUtil
    {
        #region Addition

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa + bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa + bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU16(unchecked((ushort)((aa + bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI16(unchecked((short)((aa + bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                return new EU32((aa + bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI32((aa + bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                return new EU64((aa + bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EI64((aa + bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EF32 b)
        {
            try
            {
                var aa = a.ToFloat();
                var bb = b.ToFloat();
                return new EF32((aa + bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EU8 a, EF64 b)
        {
            try
            {
                var aa = a.ToDouble();
                var bb = b.ToDouble();
                return new EF64((aa + bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Subtraction

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa - bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa - bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU16(unchecked((ushort)((aa - bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI16(unchecked((short)((aa - bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                return new EU32((aa - bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI32((aa - bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                return new EU64((aa - bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EI64((aa - bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EF32 b)
        {
            try
            {
                var aa = a.ToFloat();
                var bb = b.ToFloat();
                return new EF32((aa - bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EU8 a, EF64 b)
        {
            try
            {
                var aa = a.ToDouble();
                var bb = b.ToDouble();
                return new EF64((aa - bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Multiplication

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa * bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa * bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU16(unchecked((ushort)((aa * bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI16(unchecked((short)((aa * bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                return new EU32((aa * bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI32((aa * bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                return new EU64((aa * bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EI64((aa * bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EF32 b)
        {
            try
            {
                var aa = a.ToFloat();
                var bb = b.ToFloat();
                return new EF32((aa * bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EU8 a, EF64 b)
        {
            try
            {
                var aa = a.ToDouble();
                var bb = b.ToDouble();
                return new EF64((aa * bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Division

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU8(unchecked((byte)((aa / bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU8(unchecked((byte)((aa / bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU16(unchecked((ushort)((aa / bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EI16(unchecked((short)((aa / bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU32((aa / bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EI32((aa / bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU64((aa / bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EI64((aa / bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EF32 b)
        {
            try
            {
                var aa = a.ToFloat();
                var bb = b.ToFloat();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EF32((aa / bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Division</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Div(EU8 a, EF64 b)
        {
            try
            {
                var aa = a.ToDouble();
                var bb = b.ToDouble();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EF64((aa / bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Modulus

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU8(unchecked((byte)((aa % bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU8(unchecked((byte)((aa % bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU16(unchecked((ushort)((aa % bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EI16(unchecked((short)((aa % bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU32((aa % bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EI32((aa % bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU64((aa % bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EI64((aa % bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EF32 b)
        {
            try
            {
                var aa = a.ToFloat();
                var bb = b.ToFloat();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EF32((aa % bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Modulus</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="b"/>.Value == 0
        /// </exception>
        public static IENumber Mod(EU8 a, EF64 b)
        {
            try
            {
                var aa = a.ToDouble();
                var bb = b.ToDouble();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EF64((aa % bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Negation

        /// <summary>Negation</summary>
        /// <param name="input">Input</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        public static IENumber Neg(EU8 input)
        {
            try
            {
                return new EI8(unchecked((sbyte)((-input.Value) & 255)));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion

        #region Bitwise-AND

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa & bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa & bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU16(unchecked((ushort)((aa & bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI16(unchecked((short)((aa & bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                return new EU32((aa & bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI32((aa & bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                return new EU64((aa & bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-AND</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitAnd(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EI64((aa & bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Bitwise-OR

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa | bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa | bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU16(unchecked((ushort)((aa | bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI16(unchecked((short)((aa | bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                return new EU32((aa | bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI32((aa | bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                return new EU64((aa | bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-OR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitOr(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EI64((aa | bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Bitwise-XOR

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa ^ bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU8(unchecked((byte)((aa ^ bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EU16(unchecked((ushort)((aa ^ bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI16(unchecked((short)((aa ^ bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToUint();
                return new EU32((aa ^ bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToInt();
                return new EI32((aa ^ bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToUlong();
                return new EU64((aa ^ bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Bitwise-XOR</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber BitXor(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EI64((aa ^ bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Bitwise-NOT

        /// <summary>Bitwise-NOT</summary>
        /// <param name="input">Input</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        public static IENumber BitNot(EU8 input)
        {
            try
            {
                return new EU8(unchecked((byte)((~input.Value) & 255)));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion

        #region Left-Shift

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU8(unchecked((byte)((aa << bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU8(unchecked((byte)((aa << bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU16(unchecked((ushort)((aa << bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EI16(unchecked((short)((aa << bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToShift();
                return new EU32((aa << bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EI32((aa << bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToShift();
                return new EU64((aa << bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Left-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftL(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToShift();
                return new EI64((aa << bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Signed right-Shift

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU8(unchecked((byte)((aa >> bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU8(unchecked((byte)((aa >> bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU16(unchecked((ushort)((aa >> bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EI16(unchecked((short)((aa >> bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToShift();
                return new EU32((aa >> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EI32((aa >> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToShift();
                return new EU64((aa >> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Signed right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftR(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToShift();
                return new EI64((aa >> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion

        #region Unsigned right-Shift

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EU8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU8(unchecked((byte)((aa >>> bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EI8 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU8(unchecked((byte)((aa >>> bb) & 255)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EU16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EU16(unchecked((ushort)((aa >>> bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EI16 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EI16(unchecked((short)((aa >>> bb) & 65535)));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EU32 b)
        {
            try
            {
                var aa = a.ToUint();
                var bb = b.ToShift();
                return new EU32((aa >>> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EI32 b)
        {
            try
            {
                var aa = a.ToInt();
                var bb = b.ToShift();
                return new EI32((aa >>> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EU64 b)
        {
            try
            {
                var aa = a.ToUlong();
                var bb = b.ToShift();
                return new EU64((aa >>> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber ShiftRU(EU8 a, EI64 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToShift();
                return new EI64((aa >>> bb));
            }
            catch when (a is null)
            { throw new ArgumentNullException(nameof(a)); }
            catch when (b is null)
            { throw new ArgumentNullException(nameof(b)); }
        }

        #endregion
    }
}

#pragma warning restore IDE0047

