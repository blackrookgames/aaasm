using System;
using System.Diagnostics.CodeAnalysis;

namespace aaasm.engine.data
{
    /// <summary>Represents a case-insensitive hash created from a string</summary>
    public readonly struct CaseInsensitiveHash : 
        IEquatable<CaseInsensitiveHash>,
        IComparable<CaseInsensitiveHash>
    {
        #region init

        private CaseInsensitiveHash(int value) { f_Value = value; }

        /// <summary>Initializer for <see cref="CaseInsensitiveHash"/></summary>
        /// <param name="src">Source string</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="src"/> is null
        /// </exception>
        public CaseInsensitiveHash(string src)
        {
            const int MASK = 0b11011111; // This will clear the bit the distinguishes lowercase from uppercase
            try
            {
                int inc = src.Length / 4;
                if (inc > 0)
                {
                    f_Value = 
                        (0b11011111 & src[0]) | 
                        ((MASK & src[inc]) << 8) | 
                        ((MASK & src[inc * 2]) << 16) | 
                        ((MASK & src[inc * 3]) << 24);
                }
                else
                {
                    f_Value = 0;
                    if (src.Length > 0) f_Value |= 0b11011111 & src[0];
                    if (src.Length > 1) f_Value |= (MASK & src[inc]) << 8;
                    if (src.Length > 2) f_Value |= (MASK & src[inc * 2]) << 16;
                    if (src.Length > 3) f_Value |= (MASK & src[inc * 3]) << 24;
                }
            }
            catch when (src is null)
            {
                throw new ArgumentNullException(nameof(src));
            }
        }

        #endregion

        #region fields

        private readonly int f_Value;

        #endregion

        #region object

        /// <summary>Creates a string representation of the <see cref="CaseInsensitiveHash"/></summary>
        /// <returns>Created string</returns>
        public override string ToString()
        {
            return $"{f_Value:X8}";
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="CaseInsensitiveHash"/> 
        ///     and is equal to the current <see cref="CaseInsensitiveHash"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="CaseInsensitiveHash"/> 
        ///     and is equal to the current <see cref="CaseInsensitiveHash"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null) return false;
            if (obj is not CaseInsensitiveHash other) return false;
            return f_Value == other.f_Value;
        }

        /// <summary>Computes a hash code for the current <see cref="CaseInsensitiveHash"/></summary>
        /// <returns>Hash code for the current <see cref="CaseInsensitiveHash"/></returns>
        public override int GetHashCode()
        {
            return f_Value;
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks if the current <see cref="CaseInsensitiveHash"/> 
        ///     is equal to another <see cref="CaseInsensitiveHash"/>
        /// </summary>
        /// <param name="other">Other <see cref="CaseInsensitiveHash"/></param>
        /// <returns>
        ///     Whether or not the current <see cref="CaseInsensitiveHash"/> 
        ///     is equal to <paramref name="other"/>
        /// </returns>
        public bool Equals(CaseInsensitiveHash other) => f_Value == other.f_Value;
    
        #endregion

        #region IComparable

        /// <summary>
        ///     Compares the current <see cref="CaseInsensitiveHash"/> 
        ///     with another <see cref="CaseInsensitiveHash"/>
        /// </summary>
        /// <param name="other">Other <see cref="CaseInsensitiveHash"/> value</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, the current <see cref="CaseInsensitiveHash"/> is less than <paramref name="other"/>
        ///     <br/>- Equal to zero, <see cref="CaseInsensitiveHash"/> is equal to <paramref name="other"/>
        ///     <br/>- Greater than zero, <see cref="CaseInsensitiveHash"/> is greater than <paramref name="other"/>
        /// </returns>
        public int CompareTo(CaseInsensitiveHash other) => f_Value - other.f_Value;

        #endregion

        #region operators

        public static explicit operator CaseInsensitiveHash(int src) => new(src);
        public static explicit operator int(CaseInsensitiveHash src) => src.f_Value;

        public static bool operator ==(CaseInsensitiveHash a, CaseInsensitiveHash b) => a.Equals(b);
        public static bool operator !=(CaseInsensitiveHash a, CaseInsensitiveHash b) => !a.Equals(b);
        public static bool operator <(CaseInsensitiveHash a, CaseInsensitiveHash b) => a.CompareTo(b) < 0;
        public static bool operator <=(CaseInsensitiveHash a, CaseInsensitiveHash b) => a.CompareTo(b) <= 0;
        public static bool operator >(CaseInsensitiveHash a, CaseInsensitiveHash b) => a.CompareTo(b) > 0;
        public static bool operator >=(CaseInsensitiveHash a, CaseInsensitiveHash b) => a.CompareTo(b) >= 0;

        #endregion
    }
}