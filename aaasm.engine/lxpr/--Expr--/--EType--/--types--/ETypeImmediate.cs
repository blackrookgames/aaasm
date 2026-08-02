using System;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an immediate type</summary>
    public class ETypeImmediate : EType
    {
        #region init

        /// <summary>Initializer for <see cref="ETypeImmediate"/></summary>
        /// <param name="elementType">Contained element type</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elementType"/> is null
        /// </exception>
        public ETypeImmediate(EType elementType) : 
            base(ETypeNameId.IMMEDIATE, FLAGS, 0, 1, elementType, ImmNullArray<EType>.EMPTY)
        {
            ArgumentNullException.ThrowIfNull(elementType);
        }

        #endregion

        #region const

        private const ETypeFlags FLAGS = ETypeFlags.NONE;

        #endregion

        #region EType

        /// <inheritdoc/>
        public override string ToString(ExprContext? context)
        {
            BracketPair<Str> bkt = BracketPair.SQUARE;
            if (context is not null)
            {
                if (context.Rules.Literals.ArrayBrackets is not null)
                    bkt = context.Rules.Literals.ArrayBrackets;
            }
            return $"{NameId}{bkt.Open}{ElementType!.ToString(context)}{bkt.Close}";
        }

        /// <inheritdoc/>
        public override string GetName()
        {
            return "immediate";
        }

        #endregion
    }
}
