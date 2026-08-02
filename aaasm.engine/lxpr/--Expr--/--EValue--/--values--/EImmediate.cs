using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an immediate container</summary>
    public class EImmediate : EValue
    {
        #region init

        /// <summary>Initializer for <see cref="EImmediate"/></summary>
        /// <param name="element">Contained element</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="element"/> is null
        /// </exception>
        public EImmediate(EValue element)
        {
            try
            {
                f_Type = new ETypeImmediate(element.Type);
                f_Element = element;
            }
            catch when (element is null)
            { throw new ArgumentNullException(nameof(element)); }
        }
        
        #endregion

        #region fields

        private readonly EType f_Type;
        private readonly EValue f_Element;

        #endregion

        #region properties

        /// <summary>Contained element</summary>
        public EValue Element => f_Element;

        #endregion

        #region EValue

        /// <inheritdoc/>
        public override EType Type => f_Type;

        /// <inheritdoc/>
        private protected override string MM_ToString(ExprRules? exprRules)
        {
            // TODO: Consider rules
            return $"#{f_Element}";
        }

        /// <inheritdoc/>
        private protected override bool MM_Equals(EValue other)
        {
            if (f_Type != other.Type)
                return false;
            var _other = (EImmediate)other;
            if (f_Element.Type != _other.f_Element.Type)
                return false;
            return f_Element != _other.f_Element;
        }

        /// <inheritdoc/>
        private protected override int MM_GetHashCode()
        {
            return f_Element.GetHashCode();
        }

        #endregion
    }
}
