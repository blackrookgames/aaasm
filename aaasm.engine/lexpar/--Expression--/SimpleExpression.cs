using System;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a syntax simple expression</summary>
    public class SimpleExpression : IExpression, IEquatable<SimpleExpression>
    {
        #region init

        /// <summary>Initializer for <see cref="SimpleExpression"/></summary>
        /// <param name="str">Expression string</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="str"/> is null
        /// </exception>
        public SimpleExpression(string str)
        {
            ArgumentNullException.ThrowIfNull(str);
            f_Str = str;
        }

        #endregion

        #region fields

        private readonly string f_Str;

        #endregion

        #region properties

        /// <summary>Expression string</summary>
        public string Str => f_Str;

        #endregion

        #region helper methods

        private bool MM_Equals(SimpleExpression? other)
        {
            if (other is null) return false;
            return f_Str == other.f_Str;
        }

        #endregion

        #region object

        /// <summary>
        ///     Creates a string representation of the current 
        ///     <see cref="SimpleExpression"/>
        /// </summary>
        /// <returns>Created string</returns>
        public override string ToString()
        {
            return f_Str;
        }

        /// <summary>
        ///     Checks if the specified object is a 
        ///     <see cref="SimpleExpression"/> 
        ///     and is equal to the current 
        ///     <see cref="SimpleExpression"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a 
        ///     <see cref="SimpleExpression"/> 
        ///     and is equal to the current 
        ///     <see cref="SimpleExpression"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not SimpleExpression other) return false;
            return MM_Equals(other);
        }

        /// <summary>
        ///     Generates a hash code for the current 
        ///     <see cref="SimpleExpression"/> 
        /// </summary>
        /// <returns>Generated hash code</returns>
        public override int GetHashCode()
        {
            return f_Str.GetHashCode();
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks if the current 
        ///     <see cref="SimpleExpression"/> 
        ///     is equal to the specified other 
        ///     <see cref="SimpleExpression"/>
        /// </summary>
        /// <param name="other">
        ///     Other 
        ///     <see cref="SimpleExpression"/>
        /// </param>
        /// <returns>
        ///     Whether or not the two instances of 
        ///     <see cref="SimpleExpression"/> 
        ///     are equal
        /// </returns>
        public bool Equals(SimpleExpression? other)
        {
            return MM_Equals(other);
        }

        #endregion

        #region ISyntaxExpression

        /// <inheritdoc/>
        public bool TryMatch(SrcString str, int start, out SubRange range)
        {
            try
            {
                var beg = str.Raw.IndexOf(f_Str, start);
                if (beg >= 0)
                {
                    range = new (beg, f_Str.Length);
                    return true;
                }
                else
                {
                    range = default;
                    return false;
                }
            }
            catch when (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            catch when (start < 0 || start >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
        }

        #endregion
    }
}
