using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace aaasm.engine.io
{
    /// <summary>Represents a normalized path</summary>
    public class NormalPath : 
        IEquatable<NormalPath>, 
        IComparable<NormalPath>, 
        IReadOnlyList<char>
    {
        #region init

        /// <summary>
        ///     Initializer for <see cref="NormalPath"/>
        /// </summary>
        /// <param name="path">Input path</param>
        /// <param name="basePath">Base path</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="path"/> is not valid
        /// </exception>
        /// <exception cref="SecurityException">
        ///     Caller does not have the required permissions
        /// </exception>
        public NormalPath(string path, NormalPath basePath = null)
        {
            try
            {
                f_Path = ((basePath is null) ? Path.GetFullPath(path) : Path.GetFullPath(path, basePath.f_Path))
                    .Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
            }
            catch when (path is null) { throw new ArgumentNullException(nameof(path)); }
            catch (SecurityException) { throw; }
            catch { throw new ArgumentException("Input path is not valid.", nameof(path)); }
        }

        #endregion

        #region object

        /// <summary>Creates a string representation of the <see cref="NormalPath"/></summary>
        /// <returns>String representation of the <see cref="NormalPath"/></returns>
        public override string ToString() => f_Path;

        /// <summary>
        ///     Checks if an object is a <see cref="NormalPath"/> 
        ///     and equal to the current <see cref="NormalPath"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="NormalPath"/> 
        ///     and equal to the current <see cref="NormalPath"/>; false otherwise
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is not NormalPath other) return false;
            return f_Path == other.f_Path;
        }

        /// <summary>Gets a hashcode for the <see cref="NormalPath"/></summary>
        /// <returns>Hashcode for the <see cref="NormalPath"/></returns>
        public override int GetHashCode() => f_Path.GetHashCode();

        #endregion

        #region Equals

        /// <summary>Checks if this <see cref="NormalPath"/> is equal to another <see cref="NormalPath"/></summary>
        /// <param name="other">Other <see cref="NormalPath"/></param>
        /// <returns>Whether or not this <see cref="NormalPath"/> is equal to <paramref name="other"/></returns>
        public bool Equals(NormalPath other) => f_Path == other?.f_Path;

        #endregion

        #region CompareTo

        /// <summary>Compares this <see cref="NormalPath"/> with another <see cref="NormalPath"/></summary>
        /// <param name="other">Other <see cref="NormalPath"/> value</param>
        /// <returns>
        ///     A signed number that indicates whether this <see cref="NormalPath"/> precedes, follows, 
        ///     or appears in the same position in the sort order as <paramref name="other"/>.
        ///     <br/><b>Values:</b>
        ///     <br/>&lt;0 - This <see cref="NormalPath"/> precedes <paramref name="other"/>
        ///     <br/>=0 - This <see cref="NormalPath"/> appears in the same position in the sort order as <paramref name="other"/>
        ///     <br/>&gt;0 - This <see cref="NormalPath"/> follows <paramref name="other"/>
        /// </returns>
        public int CompareTo(NormalPath other) => f_Path.CompareTo(other?.f_Path);

        #endregion

        #region IReadOnlyList

        /// <summary>Gets the character at the specified index</summary>
        /// <param name="index">Index of the character</param>
        /// <returns>Character at the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public char this[int index]
        {
            get
            {
                try
                { return f_Path[index]; }
                catch when (index < 0 || index >= f_Path.Length)
                { throw new ArgumentOutOfRangeException(nameof(index)); }
            }
        }

        /// <summary>Gets an enumerator thru each character in the path</summary>
        /// <returns>Enumerator thru each character in the path</returns>
        public IEnumerator<char> GetEnumerator() => f_Path.GetEnumerator();

        int IReadOnlyCollection<char>.Count => f_Path.Length;

        IEnumerator IEnumerable.GetEnumerator() => f_Path.GetEnumerator();

        #endregion

        #region operators

        public static bool operator ==(NormalPath a, NormalPath b) => a?.f_Path == b?.f_Path;
        public static bool operator !=(NormalPath a, NormalPath b) => a?.f_Path != b?.f_Path;
        
        public static implicit operator string(NormalPath src) => src?.f_Path;

        #endregion

        #region fields

        private readonly string f_Path;

        #endregion

        #region properties

        /// <summary>Path length</summary>
        public int Length => f_Path.Length;

        #endregion
    }
}