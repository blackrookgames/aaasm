using System;
using System.Diagnostics.CodeAnalysis;

namespace aaasm.engine.help
{
    /// <summary>Represents the range of a subset of data</summary>
    /// <param name="beg">Index where subset begins</param>
    /// <param name="len">Length of subset</param>
    public readonly struct SubRange(int beg, int len) : IEquatable<SubRange>
    {
        #region operators

        public static bool operator ==(SubRange left, SubRange right) =>
            left.Equals(right);

        public static bool operator !=(SubRange left, SubRange right) =>
            !left.Equals(right);

        #endregion

        #region fields

        private readonly int f_Beg = beg;
        private readonly int f_Len = len;

        #endregion

        #region properties
        
        /// <summary>Beginning index in raw source</summary>
        public int Beg => f_Beg;
        
        /// <summary>Length of line content (including line feed)</summary>
        public int Len => f_Len;

        #endregion

        #region helper methods

        private bool MM_Equals(SubRange other)
        {
            return f_Beg == other.f_Beg && f_Len == other.f_Len;
        }

        #endregion

        #region object

        /// <summary>Creates a string representation of the range</summary>
        /// <returns>Created string</returns>
        public override string ToString()
        {
            return $"{{Beg: {f_Beg}, Len: {f_Len}}}";
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="SubRange"/> 
        ///     and is equal to the current <see cref="SubRange"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="SubRange"/> 
        ///     and is equal to the current <see cref="SubRange"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null) return false;
            if (obj is not SubRange other) return false;
            return MM_Equals(other);
        }

        /// <summary>Generates a hash code for the range</summary>
        /// <returns>Generated hash code</returns>
        public override int GetHashCode()
        {
            return f_Beg;
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks if the current <see cref="SubRange"/> is equal to the specified other <see cref="SubRange"/>
        /// </summary>
        /// <param name="other">Other <see cref="SubRange"/></param>
        /// <returns>
        ///     Whether or not the two instances of <see cref="SubRange"/> are equal
        /// </returns>
        public bool Equals(SubRange other)
        {
            return MM_Equals(other);
        }

        #endregion
    }
}