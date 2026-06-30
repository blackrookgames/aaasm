using System;
using System.Collections;
using System.Collections.Generic;

namespace aaasm.engine.data
{
    /// <summary>Represents an 8-character file magic</summary>
    public readonly struct FileMagic8 : 
        IEquatable<FileMagic8>, 
        IEnumerable<char>
    {
        #region init

        /// <summary>Initializer for <see cref="FileMagic8"/></summary>
        /// <param name="src">Source</param>
        public FileMagic8(long src)
        {
            f_Data = src;
        }

        /// <summary>Initializer for <see cref="FileMagic8"/></summary>
        /// <param name="src">Source</param>
        public FileMagic8(string src)
        {
            f_Data = 0;
            if (src is null) return;
            var min = Math.Min(LENGTH, src.Length);
            for (var i = 0; i < min; ++i)
                f_Data |= (long)(src[i] & 0xFF) << (i * 8);
        }

        #endregion

        #region IEquatable

        private bool MM_Equals(FileMagic8 other) => f_Data == other.f_Data;

        /// <summary>
        ///     Checks if the current <see cref="FileMagic8"/> is equal to another <see cref="FileMagic8"/>
        /// </summary>
        /// <param name="other">Other <see cref="FileMagic8"/></param>
        /// <returns>
        ///     Whether or not the current <see cref="FileMagic8"/> is equal to another <see cref="FileMagic8"/>
        /// </returns>
        public bool Equals(FileMagic8 other) => MM_Equals(other);

        #endregion

        #region IEnumerable

        private IEnumerator<char> MM_GetEnumerator()
        {
            long data = f_Data;
            for (int i = 0; i < LENGTH; ++i)
            {
                yield return (char)(data & 0xFF);
                data >>= 8;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => MM_GetEnumerator();

        /// <summary>Gets an enumerator thru the file magic characters</summary>
        /// <returns>An enumerator thru the file magic characters</returns>
        public IEnumerator<char> GetEnumerator() => MM_GetEnumerator();

        #endregion

        #region object

        /// <summary>Creates a string representation of the <see cref="FileMagic8"/></summary>
        /// <returns>String representation of the <see cref="FileMagic8"/></returns>
        public override string ToString()
        {
            var chars = new char[LENGTH];
            long data = f_Data;
            for (int i = 0; i < LENGTH; ++i)
            {
                chars[i] = (char)(data & 0xFF);
                data >>= 8;
            }
            return new string(chars);
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="FileMagic8"/> and equal to the current <see cref="FileMagic8"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if the specified object is a <see cref="FileMagic8"/> and equal to the current <see cref="FileMagic8"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is not FileMagic8 other) return false;
            return MM_Equals(other);
        }

        /// <summary>Gets a hash code for the <see cref="FileMagic8"/></summary>
        /// <returns>Hash code for the <see cref="FileMagic8"/></returns>
        public override int GetHashCode() => f_Data.GetHashCode();

        #endregion

        #region operators

        /// <summary>Checks if two instances of <see cref="FileMagic8"/> are equal in value</summary>
        /// <param name="a">Instance A</param>
        /// <param name="b">Instance B</param>
        /// <returns>Whether or not two instances of <see cref="FileMagic8"/> are equal in value</returns>
        public static bool operator ==(FileMagic8 a, FileMagic8 b) => a.MM_Equals(b);
        
        /// <summary>Checks if two instances of <see cref="FileMagic8"/> are not equal in value</summary>
        /// <param name="a">Instance A</param>
        /// <param name="b">Instance B</param>
        /// <returns>Whether or not two instances of <see cref="FileMagic8"/> are not equal in value</returns>
        public static bool operator !=(FileMagic8 a, FileMagic8 b) => !a.MM_Equals(b);

        /// <summary>Cast a <see cref="FileMagic8"/> to a <see cref="long"/></summary>
        /// <param name="src">Source <see cref="FileMagic8"/></param>
        public static explicit operator long(FileMagic8 src) => src.f_Data;

        /// <summary>Cast a <see cref="long"/> to a <see cref="FileMagic8"/></summary>
        /// <param name="src">Source <see cref="long"/></param>
        public static explicit operator FileMagic8(long src) => new(src);

        /// <summary>Gets the character at the specified index</summary>
        /// <param name="index">Index of the character</param>
        /// <returns>Character at the specified index</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     Index is out of range
        /// </exception>
        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= LENGTH)
                    throw new IndexOutOfRangeException("Index is out of range.");
                return (char)((f_Data >> (index * 8)) & 0xFF);
            }
        }

        #endregion

        #region const

        /// <summary>Number of characters in a file magic</summary>
        public const int LENGTH = sizeof(long);

        #endregion

        #region fields

        private readonly long f_Data;

        #endregion
    }
}