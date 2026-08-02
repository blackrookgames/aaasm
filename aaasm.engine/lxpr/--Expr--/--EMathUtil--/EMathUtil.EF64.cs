// This was auto-generated from EMathUtil.EF64.cs.py
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
        public static IENumber Add(EF64 a, EU8 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EI8 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EU16 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EI16 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EU32 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EI32 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EU64 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EI64 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EF32 b)
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

        /// <summary>Addition</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Add(EF64 a, EF64 b)
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
        public static IENumber Sub(EF64 a, EU8 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EI8 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EU16 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EI16 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EU32 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EI32 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EU64 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EI64 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EF32 b)
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

        /// <summary>Subtraction</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Sub(EF64 a, EF64 b)
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
        public static IENumber Mul(EF64 a, EU8 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EI8 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EU16 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EI16 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EU32 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EI32 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EU64 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EI64 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EF32 b)
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

        /// <summary>Multiplication</summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="a"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="b"/> is null
        /// </exception>
        public static IENumber Mul(EF64 a, EF64 b)
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
        public static IENumber Div(EF64 a, EU8 b)
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
        public static IENumber Div(EF64 a, EI8 b)
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
        public static IENumber Div(EF64 a, EU16 b)
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
        public static IENumber Div(EF64 a, EI16 b)
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
        public static IENumber Div(EF64 a, EU32 b)
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
        public static IENumber Div(EF64 a, EI32 b)
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
        public static IENumber Div(EF64 a, EU64 b)
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
        public static IENumber Div(EF64 a, EI64 b)
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
        public static IENumber Div(EF64 a, EF32 b)
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
        public static IENumber Div(EF64 a, EF64 b)
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
        public static IENumber Mod(EF64 a, EU8 b)
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
        public static IENumber Mod(EF64 a, EI8 b)
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
        public static IENumber Mod(EF64 a, EU16 b)
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
        public static IENumber Mod(EF64 a, EI16 b)
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
        public static IENumber Mod(EF64 a, EU32 b)
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
        public static IENumber Mod(EF64 a, EI32 b)
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
        public static IENumber Mod(EF64 a, EU64 b)
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
        public static IENumber Mod(EF64 a, EI64 b)
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
        public static IENumber Mod(EF64 a, EF32 b)
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
        public static IENumber Mod(EF64 a, EF64 b)
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
        public static IENumber Neg(EF64 input)
        {
            try
            {
                return new EF64((-input.Value));
            }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion
    }
}

#pragma warning restore IDE0047

