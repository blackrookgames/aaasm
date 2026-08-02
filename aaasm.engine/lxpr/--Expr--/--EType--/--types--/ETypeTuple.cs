using System;
using System.IO;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a tuple type</summary>
    /// <param name="elementTypes">Contained element types</param>
    public class ETypeTuple(ImmNullArray<EType> elementTypes) : 
        EType(ETypeNameId.TUPLE, FLAGS, 0, elementTypes.Length, null, elementTypes)
    {
        #region const

        private const ETypeFlags FLAGS = ETypeFlags.COLLECTION;

        #endregion

        #region helper methods

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="other"/>.NameId == <see cref="ETypeNameId.ARRAY"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private ETypeBinaryOp MM_Add_Array(EType other)
        {
            static EValue func(EValue a, EValue b) => new ETuple(((ETuple)a).Concat((EArray)b));
            var retType = Tuple(new(ElementTypes.Concat(ColUtil.Repeat(other.ElementType!, other.Length))));
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
            static EValue func(EValue a, EValue b) => new ETuple(((ETuple)a).Concat((ETuple)b));
            var retType = Tuple(new(ElementTypes.Concat(other.ElementTypes)));
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
            using StringWriter w = new();
            w.Write(NameId);
            w.Write(bkt.Open);
            for (int i = 0; i < ElementTypes.Length; ++i)
            {
                if (i > 0) w.Write(sep);
                w.Write(ElementTypes[i].ToString(context));
            }
            w.Write(bkt.Close);
            return w.ToString();
        }

        /// <inheritdoc/>
        public override string GetName()
        {
            return "tuple";
        }

        /// <inheritdoc/>
        public override ETypeBinaryOp Add(EType other)
        {
            try
            {
                switch (other.NameId)
                {
                    case ETypeNameId.ARRAY:
                        return MM_Add_Array(other);
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
