using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression value</summary>
    public abstract partial class EValue : IEquatable<EValue>
    {
        #region abstract properties

        /// <summary>Value type</summary>
        public abstract EType Type { get; }

        #endregion

        #region abstract methods

        private protected abstract string MM_ToString(ExprRules? exprRules);

        private protected abstract bool MM_Equals(EValue other);

        private protected abstract int MM_GetHashCode();

        #endregion

        #region private methods

        private static bool MM_Equals(EValue? a, EValue? b)
        {
            if (a is null) return b is null;
            if (b is null) return false;
            return a.MM_Equals(b);
        }

        #endregion

        #region methods

        /// <summary>Generates a string representation of the current <see cref="EValue"/></summary>
        /// <param name="exprRules">Expression rules</param>
        /// <returns>Generated string</returns>
        public string ToString(ExprRules? exprRules)
        {
            return MM_ToString(exprRules);
        }

        #endregion

        #region operators

        public static bool operator ==(EValue? a, EValue? b) => MM_Equals(a, b);
        public static bool operator !=(EValue? a, EValue? b) => !MM_Equals(a, b);

        #endregion

        #region object

        /// <summary>
        ///     Generates a string representation of the current <see cref="EValue"/>
        /// </summary>
        /// <returns>
        ///     Generated string
        /// </returns>
        public override string ToString()
        {
            return MM_ToString(null);
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="EValue"/> 
        ///     and is equal to the current <see cref="EValue"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="EValue"/> 
        ///     and is equal to the current <see cref="EValue"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not EValue other) return false;
            return MM_Equals(other);
        }

        /// <summary>Computes a hash code for the current <see cref="EValue"/></summary>
        /// <returns>Hash code for the current <see cref="EValue"/></returns>
        public override int GetHashCode()
        {
            return MM_GetHashCode();
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks whether or not the current <see cref="EValue"/> is equal to another <see cref="EValue"/>
        /// </summary>
        /// <param name="other">Other <see cref="EValue"/></param>
        /// <returns>
        ///     Whether or not the current <see cref="EValue"/> is equal to <paramref name="other"/>
        /// </returns>
        public bool Equals(EValue? other)
        {
            if (other is null) return false;
            return MM_Equals(other);
        }

        #endregion
    }
}
