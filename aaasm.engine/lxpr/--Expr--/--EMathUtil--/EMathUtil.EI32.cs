// This was auto-generated from EMathUtil.EI32.cs.py
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
        public static IENumber Add(EI32 a, EU8 b)
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
        public static IENumber Add(EI32 a, EI8 b)
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
        public static IENumber Add(EI32 a, EU16 b)
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
        public static IENumber Add(EI32 a, EI16 b)
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
        public static IENumber Add(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EU32(unchecked((uint)((aa + bb) & 4294967295)));
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
        public static IENumber Add(EI32 a, EI32 b)
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
        public static IENumber Add(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                return new EU64(unchecked((ulong)((aa + bb) & 18446744073709551615)));
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
        public static IENumber Add(EI32 a, EI64 b)
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
        public static IENumber Add(EI32 a, EF32 b)
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
        public static IENumber Add(EI32 a, EF64 b)
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
        public static IENumber Sub(EI32 a, EU8 b)
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
        public static IENumber Sub(EI32 a, EI8 b)
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
        public static IENumber Sub(EI32 a, EU16 b)
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
        public static IENumber Sub(EI32 a, EI16 b)
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
        public static IENumber Sub(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EU32(unchecked((uint)((aa - bb) & 4294967295)));
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
        public static IENumber Sub(EI32 a, EI32 b)
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
        public static IENumber Sub(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                return new EU64(unchecked((ulong)((aa - bb) & 18446744073709551615)));
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
        public static IENumber Sub(EI32 a, EI64 b)
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
        public static IENumber Sub(EI32 a, EF32 b)
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
        public static IENumber Sub(EI32 a, EF64 b)
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
        public static IENumber Mul(EI32 a, EU8 b)
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
        public static IENumber Mul(EI32 a, EI8 b)
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
        public static IENumber Mul(EI32 a, EU16 b)
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
        public static IENumber Mul(EI32 a, EI16 b)
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
        public static IENumber Mul(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EU32(unchecked((uint)((aa * bb) & 4294967295)));
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
        public static IENumber Mul(EI32 a, EI32 b)
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
        public static IENumber Mul(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                return new EU64(unchecked((ulong)((aa * bb) & 18446744073709551615)));
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
        public static IENumber Mul(EI32 a, EI64 b)
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
        public static IENumber Mul(EI32 a, EF32 b)
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
        public static IENumber Mul(EI32 a, EF64 b)
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
        public static IENumber Div(EI32 a, EU8 b)
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
        public static IENumber Div(EI32 a, EI8 b)
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
        public static IENumber Div(EI32 a, EU16 b)
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
        public static IENumber Div(EI32 a, EI16 b)
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
        public static IENumber Div(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU32(unchecked((uint)((aa / bb) & 4294967295)));
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
        public static IENumber Div(EI32 a, EI32 b)
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
        public static IENumber Div(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU64(unchecked((ulong)((aa / bb) & 18446744073709551615)));
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
        public static IENumber Div(EI32 a, EI64 b)
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
        public static IENumber Div(EI32 a, EF32 b)
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
        public static IENumber Div(EI32 a, EF64 b)
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
        public static IENumber Mod(EI32 a, EU8 b)
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
        public static IENumber Mod(EI32 a, EI8 b)
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
        public static IENumber Mod(EI32 a, EU16 b)
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
        public static IENumber Mod(EI32 a, EI16 b)
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
        public static IENumber Mod(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU32(unchecked((uint)((aa % bb) & 4294967295)));
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
        public static IENumber Mod(EI32 a, EI32 b)
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
        public static IENumber Mod(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                if (bb == 0) throw new EValueException("Division by zero");
                return new EU64(unchecked((ulong)((aa % bb) & 18446744073709551615)));
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
        public static IENumber Mod(EI32 a, EI64 b)
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
        public static IENumber Mod(EI32 a, EF32 b)
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
        public static IENumber Mod(EI32 a, EF64 b)
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
        public static IENumber Neg(EI32 input)
        {
            try
            {
                return new EI32((-input.Value));
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
        public static IENumber BitAnd(EI32 a, EU8 b)
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
        public static IENumber BitAnd(EI32 a, EI8 b)
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
        public static IENumber BitAnd(EI32 a, EU16 b)
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
        public static IENumber BitAnd(EI32 a, EI16 b)
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
        public static IENumber BitAnd(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EU32(unchecked((uint)((aa & bb) & 4294967295)));
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
        public static IENumber BitAnd(EI32 a, EI32 b)
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
        public static IENumber BitAnd(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                return new EU64(unchecked((ulong)((aa & bb) & 18446744073709551615)));
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
        public static IENumber BitAnd(EI32 a, EI64 b)
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
        public static IENumber BitOr(EI32 a, EU8 b)
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
        public static IENumber BitOr(EI32 a, EI8 b)
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
        public static IENumber BitOr(EI32 a, EU16 b)
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
        public static IENumber BitOr(EI32 a, EI16 b)
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
        public static IENumber BitOr(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EU32(unchecked((uint)((aa | bb) & 4294967295)));
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
        public static IENumber BitOr(EI32 a, EI32 b)
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
        public static IENumber BitOr(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                return new EU64(unchecked((ulong)((aa | bb) & 18446744073709551615)));
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
        public static IENumber BitOr(EI32 a, EI64 b)
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
        public static IENumber BitXor(EI32 a, EU8 b)
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
        public static IENumber BitXor(EI32 a, EI8 b)
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
        public static IENumber BitXor(EI32 a, EU16 b)
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
        public static IENumber BitXor(EI32 a, EI16 b)
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
        public static IENumber BitXor(EI32 a, EU32 b)
        {
            try
            {
                var aa = a.ToLong();
                var bb = b.ToLong();
                return new EU32(unchecked((uint)((aa ^ bb) & 4294967295)));
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
        public static IENumber BitXor(EI32 a, EI32 b)
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
        public static IENumber BitXor(EI32 a, EU64 b)
        {
            try
            {
                var aa = a.ToInt128();
                var bb = b.ToInt128();
                return new EU64(unchecked((ulong)((aa ^ bb) & 18446744073709551615)));
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
        public static IENumber BitXor(EI32 a, EI64 b)
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
        public static IENumber BitNot(EI32 input)
        {
            try
            {
                return new EI32((~input.Value));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion

        #region Left-Shift

        /// <summary>Left-Shift</summary>
        /// <param name="input">Input</param>
        /// <param name="amount">Shift amount</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="amount"/> is null
        /// </exception>
        public static IENumber ShiftL(EI32 input, IEInteger amount)
        {
            try
            {
                var _input = input.ToInt();
                var _amount = amount.ToShift();
                return new EI32((_input << _amount));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
            catch when (amount is null)
            { throw new ArgumentNullException(nameof(amount)); }
        }

        #endregion

        #region Signed right-Shift

        /// <summary>Signed right-Shift</summary>
        /// <param name="input">Input</param>
        /// <param name="amount">Shift amount</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="amount"/> is null
        /// </exception>
        public static IENumber ShiftR(EI32 input, IEInteger amount)
        {
            try
            {
                var _input = input.ToInt();
                var _amount = amount.ToShift();
                return new EI32((_input >> _amount));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
            catch when (amount is null)
            { throw new ArgumentNullException(nameof(amount)); }
        }

        #endregion

        #region Unsigned right-Shift

        /// <summary>Unsigned right-Shift</summary>
        /// <param name="input">Input</param>
        /// <param name="amount">Shift amount</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="amount"/> is null
        /// </exception>
        public static IENumber ShiftRU(EI32 input, IEInteger amount)
        {
            try
            {
                var _input = input.ToInt();
                var _amount = amount.ToShift();
                return new EI32((_input >>> _amount));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
            catch when (amount is null)
            { throw new ArgumentNullException(nameof(amount)); }
        }

        #endregion
    }
}

#pragma warning restore IDE0047

