using System;
using System.Collections;
using System.Collections.Generic;

namespace aaasm.engine.data
{
    /// <summary>Represents a string of source characters</summary>
    public readonly struct SrcStr : IReadOnlyList<SrcStrChar>
    {
        #region init

        /// <summary>Initializer for <see cref="SrcStr"/></summary>
        /// <param name="chars">Source characters</param>
        public SrcStr(SrcStrChar[] chars)
        {
            if (chars is not null)
            {
                f_Length = chars.Length;
                char[] rawChars = new char[f_Length];
                f_PLCs = new SrcStrPLC[f_Length];
                for (int i = 0; i < f_Length; ++i)
                {
                    var c = chars[i];
                    rawChars[i] = c.Char;
                    f_PLCs[i] = c.PLC;
                }
                f_Raw = new(rawChars);
            }
            else
            {
                f_Length = 0;
                f_Raw = "";
                f_PLCs = [];
            }
        }

        /// <summary>Initializer for <see cref="SrcStr"/></summary>
        /// <param name="chars">Source characters</param>
        public SrcStr(IEnumerable<SrcStrChar> chars) : this((chars is null) ? null : [..chars]) { }

        #endregion

        #region object

        /// <summary>Creates a C# string representation</summary>
        /// <returns>C# string representation</returns>
        public override string ToString() => (f_Length == 0) ? "" : new(f_Raw);

        #endregion

        #region IReadOnlyList

        /// <summary>Gets the character at the specified index</summary>
        /// <param name="index">Index of the character</param>
        /// <returns>Character at the specified index</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     Index is out of range
        /// </exception>
        public SrcStrChar this[int index]
        {
            get
            {
                try
                { return new(f_Raw[index], f_PLCs[index]); }
                catch when (index < 0 || index >= f_Length)
                { throw new IndexOutOfRangeException(); }
            }
        }

        /// <summary>Gets an enumerator thru the string</summary>
        /// <returns>Enumerator thru the string</returns>
        public IEnumerator<SrcStrChar> GetEnumerator() => MM_GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => MM_GetEnumerator();

        int IReadOnlyCollection<SrcStrChar>.Count => f_Length;

        #endregion

        #region const

        private static readonly SrcStrPLC[] EMPTY = [];

        #endregion

        #region fields

        private readonly int f_Length; // This will protect against null references in default state
        private readonly string f_Raw;
        private readonly SrcStrPLC[] f_PLCs;

        #endregion

        #region properties

        /// <summary>Number of characters in string</summary>
        public int Length => f_Length;

        /// <summary>Raw string</summary>
        public string Raw => f_Raw;

        #endregion

        #region helper methods

        private IEnumerator<SrcStrChar> MM_GetEnumerator()
        {
            for (int i = 0; i < f_Length; ++i)
                yield return new(f_Raw[i], f_PLCs[i]);
        }

        #endregion
    }
}
