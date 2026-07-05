using System;
using System.Text.RegularExpressions;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a syntax regular expression</summary>
    public class RegularExpression : IExpression, IEquatable<RegularExpression>
    {
        #region init

        /// <summary>Initializer for <see cref="RegularExpression"/></summary>
        /// <param name="str">Expression string</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="str"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="str"/> is not a valid regular expression
        /// </exception>
        public RegularExpression(string str)
        {
            try
            {
                f_Str = str;
                f_Regex = new(str);
            }
            catch when (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("String is not a valid regular expression.", nameof(str));
            }
        }

        #endregion

        #region fields

        private readonly string f_Str;
        private readonly Regex f_Regex;

        #endregion

        #region properties

        /// <summary>Expression string</summary>
        public string Str => f_Str;

        #endregion

        #region helper methods

        private bool MM_Equals(RegularExpression? other)
        {
            if (other is null) return false;
            return f_Str == other.f_Str;
        }

        #endregion

        #region object

        /// <summary>
        ///     Creates a string representation of the current 
        ///     <see cref="RegularExpression"/>
        /// </summary>
        /// <returns>Created string</returns>
        public override string ToString()
        {
            return f_Str;
        }

        /// <summary>
        ///     Checks if the specified object is a 
        ///     <see cref="RegularExpression"/> 
        ///     and is equal to the current 
        ///     <see cref="RegularExpression"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a 
        ///     <see cref="RegularExpression"/> 
        ///     and is equal to the current 
        ///     <see cref="RegularExpression"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not RegularExpression other) return false;
            return MM_Equals(other);
        }

        /// <summary>
        ///     Generates a hash code for the current 
        ///     <see cref="RegularExpression"/> 
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
        ///     <see cref="RegularExpression"/> 
        ///     is equal to the specified other 
        ///     <see cref="RegularExpression"/>
        /// </summary>
        /// <param name="other">
        ///     Other 
        ///     <see cref="RegularExpression"/>
        /// </param>
        /// <returns>
        ///     Whether or not the two instances of 
        ///     <see cref="RegularExpression"/> 
        ///     are equal
        /// </returns>
        public bool Equals(RegularExpression? other)
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
                var regexMatch = f_Regex.Match(str.Raw, start);
                if (regexMatch.Success)
                {
                    range = new(regexMatch.Index, regexMatch.Length);
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
            catch (RegexMatchTimeoutException)
            {
                range = default;
                return false;
            }
        }

        #endregion
    }
}
