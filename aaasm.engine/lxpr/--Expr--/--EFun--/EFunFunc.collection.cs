using System;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region LEN

        /// <summary>Gets the number of elements in the collection</summary>
        /// <param name="context">Context</param>
        /// <param name="collection">Collection</param>
        /// <return>Number of elements in the collection</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="collection"/> is null
        /// </exception>
        public static EI32 LEN(ExprContext context, IECollection collection)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                return new(collection.Length);
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(collection);
                throw;
            }
        }

        #endregion

        #region GET

        /// <summary>Gets the element at the specified index</summary>
        /// <param name="context">Context</param>
        /// <param name="array">Array</param>
        /// <param name="index">Index of element</param>
        /// <return>Element at the specified index</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="array"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="index"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public static EValue GET(ExprContext context, EArray array, IEInteger index)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                var _index = index.ToShift(); // Use ToShift to clamp to a valid 32-bit signed integer
                MM_ThrowIfIndexOOR(array.Length, _index);
                return array[_index];
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(array);
                ArgumentNullException.ThrowIfNull(index);
                throw;
            }
        }

        internal static EType GET_r_EArray_IEInteger(ExprRules rules, ENodeValueType array, ENodeValueType index)
        {
            return array.Type.ElementType!;
        }

        /// <summary>Gets the element at the specified index</summary>
        /// <param name="context">Context</param>
        /// <param name="tuple">Tuple</param>
        /// <param name="index">Index of element</param>
        /// <return>Element at the specified index</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="tuple"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="index"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public static EValue GET(ExprContext context, ETuple tuple, int index)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                MM_ThrowIfIndexOOR(tuple.Length, index);
                return tuple[index];
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(tuple);
                throw;
            }
        }

        internal static EType GET_r_ETuple_int(ExprRules rules, ENodeValueType tuple, ENodeValueType index)
        {
            int _index = EFunLitModParam.Parse(index.Literal!);
            MM_ThrowIfIndexOOR(tuple.Type.Length, _index);
            return tuple.Type.ElementTypes[_index];
        }

        /// <summary>Gets the encapsulated element</summary>
        /// <param name="context">Context</param>
        /// <param name="immediate">Immediate</param>
        /// <return>Encapsulated element</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="immediate"/> is null
        /// </exception>
        public static EValue GET(ExprContext context, EImmediate immediate)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                return immediate.Element;
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(immediate);
                throw;
            }
        }

        internal static EType GET_r_EImmediate(ExprRules rules, ENodeValueType immediate)
        {
            return immediate.Type.ElementType!;
        }

        #endregion
    }
}

