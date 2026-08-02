using System;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region U8, I8, U16, I16, U32, I32, U64, I64, F32, F64
        
        /// <summary>Conversion to 8-bit unsigned integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EU8 U8(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToU8(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 8-bit signed integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EI8 I8(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToI8(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 16-bit unsigned integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EU16 U16(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToU16(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 16-bit signed integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EI16 I16(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToI16(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 32-bit unsigned integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EU32 U32(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToU32(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 32-bit signed integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EI32 I32(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToI32(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 64-bit unsigned integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EU64 U64(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToU64(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 64-bit signed integer</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EI64 I64(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToI64(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 32-bit floating-point decimal</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EF32 F32(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToF32(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        /// <summary>Conversion to 64-bit floating-point decimal</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static EF64 F64(ExprContext context, IENumber input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return input.ToF64(); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }
        
        #endregion

        #region ARRAY
        
        private static readonly EType ARRAY_DEFAULT_ELEMENT = EType.I32;

        /// <summary>Conversion to array</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Not all elements are of the same type
        /// </exception>
        public static EArray ARRAY(ExprContext context, IECollection input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                if (input.Length > 0)
                {
                    var correct = input[0].Type;
                    try
                    { return new EArray(correct, input); }
                    catch when (input.Any(element => element.Type != correct))
                    { throw new EValueException("Not all elements are of the same type"); }
                }
                return new EArray(ARRAY_DEFAULT_ELEMENT, []);
            }
            catch when (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
        }

        internal static EType ARRAY_r_IECollection(ExprRules rules, ENodeValueType input)
        {
            if (input.Type.NameId == ETypeNameId.TUPLE)
            {
                if (input.Type.Length > 0)
                {
                    var correct = input.Type.ElementTypes[0];
                    if (input.Type.ElementTypes.Any(t => t != correct))
                        throw new EValueException("Not all elements are of the same type");
                    return EType.Array(correct, input.Type.Length);
                }
                return EType.Array(ARRAY_DEFAULT_ELEMENT, 0);
            }
            return input.Type;
        }

        /// <summary>Creates a new array of the specified length</summary>
        /// <param name="context">Context</param>
        /// <param name="length">Number of elements in array</param>
        /// <param name="fill">Fill value</param>
        /// <returns>Created array</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="fill"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length"/> is negative
        /// </exception>
        public static EArray ARRAY(ExprContext context, int length, EValue fill)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                return new EArray(fill.Type, ColUtil.Repeat(fill, length));
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(fill);
                ArgumentOutOfRangeException.ThrowIfNegative(length);
                throw;
            }
        }

        internal static EType ARRAY_r_int_EValue(ExprRules rules, ENodeValueType length, ENodeValueType fill)
        {
            int _length = EFunLitModParam.Parse(length.Literal!);
            if (_length < 0) throw new EValueException("Length cannot be negative.");
            return EType.Array(fill.Type, _length);
        }

        #endregion
        
        #region TUPLE

        /// <summary>Conversion to tuple</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <return>Conversion result</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        public static ETuple TUPLE(ExprContext context, IECollection input)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            { return new ETuple(input); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        internal static EType TUPLE_r_IECollection(ExprRules rules, ENodeValueType input)
        {
            if (input.Type.NameId != ETypeNameId.ARRAY) return input.Type;
            return EType.Tuple(new(ColUtil.Repeat(input.Type.ElementType, input.Type.Length)!));
        }

        #endregion
    }
}

