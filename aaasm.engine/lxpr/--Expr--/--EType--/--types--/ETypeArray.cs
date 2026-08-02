using System;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an array type</summary>
    public class ETypeArray : EType
    {
        #region init

        /// <summary>Initializer for <see cref="ETypeArray"/></summary>
        /// <param name="elementType">Contained element type</param>
        /// <param name="length">Number of elements in array</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elementType"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length"/> is negative
        /// </exception>
        public ETypeArray(EType elementType, int length) : 
            base(ETypeNameId.ARRAY, FLAGS, 0, length, elementType, ImmNullArray<EType>.EMPTY)
        {
            ArgumentNullException.ThrowIfNull(elementType);
            ArgumentOutOfRangeException.ThrowIfNegative(length);
        }

        #endregion

        #region const

        private const ETypeFlags FLAGS = ETypeFlags.COLLECTION;

        #endregion

        #region helper methods

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="other"/>.NameId == <see cref="ETypeNameId.ARRAY"/>
        ///     <br/>- <paramref name="other"/>.ElementType == ElementType
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private ETypeBinaryOp MM_Add_SimilarArray(EType other)
        {
            EValue func(EValue a, EValue b) => 
                new EArray(ElementType!, ((EArray)a).Concat((EArray)b));
            var retType = Array(ElementType!, Length + other.Length);
            return new(this, other, retType, func);
        }

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="other"/>.NameId == <see cref="ETypeNameId.ARRAY"/>
        ///     <br/>- <paramref name="other"/>.ElementType != ElementType
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private ETypeBinaryOp MM_Add_DifferentArray(EType other)
        {
            static EValue func(EValue a, EValue b) => 
                new ETuple(((EArray)a).Concat((EArray)b));
            var retType = Tuple(new(
                ColUtil.Repeat(ElementType!, Length).Concat(
                ColUtil.Repeat(other.ElementType!, other.Length))));
            return new(this, other, retType, func);
        }

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="other"/>.NameId == <see cref="ETypeNameId.TUPLE"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private ETypeBinaryOp MM_Add_Tuple(EType other)
        {
            static EValue func(EValue a, EValue b) => new ETuple(((EArray)a).Concat((ETuple)b));
            var retType = Tuple(new(ColUtil.Repeat(ElementType!, Length).Concat(other.ElementTypes)));
            return new(this, other, retType, func);
        }

        #endregion

        #region EType

        /// <inheritdoc/>
        public override string ToString(ExprContext? context)
        {
            BracketPair<Str> bkt = BracketPair.SQUARE;
            Str sep = (CIStr)",";
            if (context is not null)
            {
                if (context.Rules.Literals.ArrayBrackets is not null)
                    bkt = context.Rules.Literals.ArrayBrackets;
                if (context.Rules.Literals.ElementSep is not null)
                    sep = context.Rules.Literals.ElementSep;
            }
            return $"{NameId}{bkt.Open}{ElementType!.ToString(context)}{sep}{Length}{bkt.Close}";
        }

        /// <inheritdoc/>
        public override string GetName()
        {
            return $"array";
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Add(EType other)
        {
            try
            {
                switch (other.NameId)
                {
                    case ETypeNameId.ARRAY:
                        if (ElementType == other.ElementType)
                            return MM_Add_SimilarArray(other);
                        return MM_Add_DifferentArray(other);
                    case ETypeNameId.TUPLE:
                        return MM_Add_Tuple(other);
                }
                throw MM_CannotAdd(other);
            }
            catch when (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }
        }

        #endregion
    }
}
