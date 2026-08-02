using System;
using System.Collections;
using System.Collections.Generic;
using aaasm.engine.help;

namespace aaasm.engine.data
{
    /// <summary>Represents a string</summary>
    /// <param name="src">Source</param>
    public partial class Str(string? src) : IEquatable<Str>, IComparable<Str>, IReadOnlyList<char>
    {
        #region fields

        private readonly string f_Raw = (src is null) ? "" : src;

        #endregion

        #region properties

        /// <summary>Number of characters in string</summary>
        public int Length => f_Raw.Length;

        #endregion

        #region virtual properties

        private protected virtual bool PP_IgnoreCase => false;

        #endregion

        #region private methods

        private static int MM_CompareChars(char a, char b, bool ignoreCase)
        {
            if (a == b) return 0;
            if (ignoreCase)
            {
                if (a >= 'a' && a <= 'z')
                    a = (char)(a - 0x20);
                if (b >= 'a' && b <= 'z')
                    b = (char)(b - 0x20);
            }
            return a - b;
        }

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="aBeg"/> &gt;= 0 
        ///     <br/>- <paramref name="aBeg"/> &lt;= <paramref name="a"/>.Length
        ///     <br/>- <paramref name="aEnd"/> &gt;= 0 
        ///     <br/>- <paramref name="aEnd"/> &lt;= <paramref name="a"/>.Length
        ///     <br/>- <paramref name="aBeg"/> &lt;= <paramref name="aEnd"/>
        ///     <br/>- <paramref name="bBeg"/> &gt;= 0 
        ///     <br/>- <paramref name="bBeg"/> &lt;= <paramref name="b"/>.Length
        ///     <br/>- <paramref name="bEnd"/> &gt;= 0 
        ///     <br/>- <paramref name="bEnd"/> &lt;= <paramref name="b"/>.Length
        ///     <br/>- <paramref name="bBeg"/> &lt;= <paramref name="bEnd"/>
        /// </summary>
        private static bool MM_Equal(string a, int aBeg, int aEnd, string b, int bBeg, int bEnd, bool ignoreCase)
        {
            if ((aEnd - aBeg) != (bEnd - bBeg))
                return false;
            while (aBeg < aEnd)
            {
                if (MM_CompareChars(a[aBeg++], b[bBeg++], ignoreCase) != 0)
                    return false;
            }
            return true;
        }

        private static bool MM_Equal(string a, string b, bool ignoreCase)
        {
            if (!ignoreCase) return a == b;
            return MM_Equal(a, 0, a.Length, b, 0, b.Length, true);
        }

        private static int MM_Compare(string a, string b, bool ignoreCase)
        {
            // Compare lengths
            int lenCmp = a.Length - b.Length;
            int minLen = (lenCmp < 0) ? a.Length : b.Length;
            // Compare characters
            for (int i = 0; i < minLen; ++i)
            {
                var cmp = MM_CompareChars(a[i], b[i], ignoreCase);
                if (cmp != 0) return cmp;
            }
            // Return length result
            return lenCmp;
        }

        private bool MM_Equals(string? other)
        {
            if (other is null) return false;
            return MM_Equal(f_Raw, other, PP_IgnoreCase);
        }

        private bool MM_Equals(Str? other)
        {
            if (other is null) return false;
            return MM_Equal(f_Raw, other.f_Raw, PP_IgnoreCase || other.PP_IgnoreCase);
        }
        
        private int MM_CompareTo(string? other)
        {
            if (other is null) return 1;
            return MM_Compare(f_Raw, other, PP_IgnoreCase);
        }

        private int MM_CompareTo(Str? other)
        {
            if (other is null) return 1;
            return MM_Compare(f_Raw, other.f_Raw, PP_IgnoreCase || other.PP_IgnoreCase);
        }
        
        #endregion

        #region methods

        /// <summary>Checks if the two strings are equal</summary>
        /// <remarks>Check may be case-insensitive depending on the string types</remarks>
        /// <param name="a">String A</param>
        /// <param name="b">String B</param>
        /// <returns>Whether or not the two strings are equal</returns>
        public static bool Equal(Str? a, Str? b)
        {
            if (a is null) return b is null;
            return a.MM_Equals(b);
        }

        /// <inheritdoc cref="Equal(Str?, Str?)"/>
        public static bool Equal(Str? a, string? b)
        {
            if (a is null) return b is null;
            return a.MM_Equals(b);
        }

        /// <inheritdoc cref="Equal(Str?, Str?)"/>
        public static bool Equal(string? a, Str? b)
        {
            return Equal(b, a);
        }

        /// <summary>Compares the two strings</summary>
        /// <remarks>Comparison may be case-insensitive depending on the string types</remarks>
        /// <param name="a">String A</param>
        /// <param name="b">String B</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, <paramref name="a"/> is less than <paramref name="b"/>
        ///     <br/>- Equal to zero, <paramref name="a"/> is equal to <paramref name="b"/>
        ///     <br/>- Greater than zero, <paramref name="a"/> is greater than <paramref name="b"/>
        /// </returns>
        public static int Compare(Str? a, Str? b)
        {
            if (a is null) return (b is null) ? 0 : (-1);
            return a.MM_CompareTo(b);
        }

        /// <inheritdoc cref="Compare(Str?, Str?)"/>
        public static int Compare(Str? a, string? b)
        {
            if (a is null) return (b is null) ? 0 : (-1);
            return a.MM_CompareTo(b);
        }

        /// <inheritdoc cref="Compare(Str?, Str?)"/>
        public static int Compare(string? a, Str? b)
        {
            return -Compare(b, a);
        }

        #endregion

        #region virtual methods

        private protected virtual Str MM_Create(string? src) => new(src);

        #endregion

        #region operators

        public static explicit operator Str(string src) => new(src);
        public static explicit operator string(Str src) => src.f_Raw;

        #region equality

        /// <remarks>Check may be case-insensitive depending on the string types</remarks>
        public static bool operator ==(Str? a, Str? b) => Equal(a, b);
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator !=(Str? a, Str? b) => !Equal(a, b);
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator <(Str? a, Str? b) => Compare(a, b) < 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator <=(Str? a, Str? b) => Compare(a, b) <= 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator >(Str? a, Str? b) => Compare(a, b) > 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator >=(Str? a, Str? b) => Compare(a, b) >= 0;

        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator ==(Str? a, string? b) => Equal(a, b);
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator !=(Str? a, string? b) => !Equal(a, b);
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator <(Str? a, string? b) => Compare(a, b) < 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator <=(Str? a, string? b) => Compare(a, b) <= 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator >(Str? a, string? b) => Compare(a, b) > 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator >=(Str? a, string? b) => Compare(a, b) >= 0;

        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator ==(string? a, Str? b) => Equal(a, b);
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator !=(string? a, Str? b) => !Equal(a, b);
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator <(string? a, Str? b) => Compare(a, b) < 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator <=(string? a, Str? b) => Compare(a, b) <= 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator >(string? a, Str? b) => Compare(a, b) > 0;
        /// <inheritdoc cref="operator ==(Str?, Str?)"/>
        public static bool operator >=(string? a, Str? b) => Compare(a, b) >= 0;

        #endregion

        #region indexing

        /// <summary>Retrieves the substring within the specified range</summary>
        /// <param name="range">Range</param>
        /// <returns>Substring within the specified range</returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="range"/> is not valid
        /// </exception>
        public Str this[Range range]
        {
            get
            {
                try
                { return MM_Create(f_Raw[range]); }
                catch
                { ArgUtil.RangeBegEnd(range, f_Raw.Length); throw; }
            }
        }

        /// <summary>Retrieves the substring within the specified range</summary>
        /// <param name="range">Substring range</param>
        /// <returns>Substring within the specified range</returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="range"/> is not valid
        /// </exception>
        public Str this[SubRange range]
        {
            get
            {
                try
                { return MM_Create(f_Raw.Substring(range.Beg, range.Len)); }
                catch when (range.Beg < 0 || range.Len < 0 || (range.Beg + range.Len) > f_Raw.Length)
                { throw new ArgumentException("Range is not valid.", nameof(range)); }
            }
        }

        #endregion

        #endregion

        #region object

        /// <summary>Creates a string representation of the <see cref="Str"/></summary>
        /// <returns>Created string</returns>
        public sealed override string ToString()
        {
            return f_Raw;
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="Str"/> 
        ///     and is equal to the current <see cref="Str"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="Str"/> 
        ///     and is equal to the current <see cref="Str"/>; 
        ///     false otherwise
        /// </returns>
        public sealed override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Str other) return false;
            return MM_Equals(other);
        }

        /// <summary>Computes a hash code for the current <see cref="Str"/></summary>
        /// <returns>Hash code for the current <see cref="Str"/></returns>
        public sealed override int GetHashCode()
        {
            return (int)new CaseInsensitiveHash(f_Raw);
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks if the current <see cref="Str"/> 
        ///     is equal to another <see cref="Str"/>
        /// </summary>
        /// <remarks>
        ///     Check may be case-insensitive depending on the string types
        /// </remarks>
        /// <param name="other">Other <see cref="Str"/></param>
        /// <returns>
        ///     Whether or not the current <see cref="Str"/> 
        ///     is equal to <paramref name="other"/>
        /// </returns>
        public bool Equals(Str? other) => MM_Equals(other);
    
        #endregion

        #region IComparable

        /// <summary>
        ///     Compares the current <see cref="Str"/> 
        ///     with another <see cref="Str"/>
        /// </summary>
        /// <remarks>
        ///     Comparison may be case-insensitive depending on the string types
        /// </remarks>
        /// <param name="other">Other <see cref="Str"/> value</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, the current <see cref="Str"/> is less than <paramref name="other"/>
        ///     <br/>- Equal to zero, <see cref="Str"/> is equal to <paramref name="other"/>
        ///     <br/>- Greater than zero, <see cref="Str"/> is greater than <paramref name="other"/>
        /// </returns>
        public int CompareTo(Str? other) => MM_CompareTo(other);

        #endregion

        #region IReadOnlyList

        /// <summary>Gets the character at the specified index</summary>
        /// <param name="index">Indexof character</param>
        /// <returns>Character at the specified index</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public char this[int index]
        {
            get
            {
                try
                { return f_Raw[index]; }
                catch when (index < 0 || index >= f_Raw.Length)
                { throw new IndexOutOfRangeException(); }
            }
        }

        /// <summary>Gets an enumerator thru the characters in the string</summary>
        /// <returns>Enumerator thru the characters in the string</returns>
        public IEnumerator<char> GetEnumerator() => f_Raw.GetEnumerator();

        int IReadOnlyCollection<char>.Count => f_Raw.Length;

        IEnumerator IEnumerable.GetEnumerator() => f_Raw.GetEnumerator();

        #endregion
    }
}