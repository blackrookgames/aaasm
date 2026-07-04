using System;
using System.Collections;
using System.Collections.Generic;
using aaasm.engine.help;
using aaasm.engine.io;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a string of source characters</summary>
    public class SrcString : IReadOnlyList<SrcChar>
    {
        #region init

        /// <summary>
        ///     Assume
        ///     <list type="bullet">
        ///         <item><paramref name="raw"/>.Length == <paramref name="origins"/>.Length</item>
        ///     </list>
        /// </summary>
        /// <param name="raw"></param>
        /// <param name="origins"></param>
        private SrcString(string raw, RefPnt[] origins)
        {
            f_Raw = raw;
            f_Origins = origins;
        }

        /// <summary>Initializer for <see cref="SrcString"/></summary>
        /// <param name="chars">Source characters</param>
        public SrcString(SrcChar[]? chars)
        {
            if (chars is not null)
            {
                char[] rawChars = new char[chars.Length];
                f_Origins = new RefPnt[chars.Length];
                for (int i = 0; i < chars.Length; ++i)
                {
                    var c = chars[i];
                    rawChars[i] = c.Char;
                    f_Origins[i] = c.Origin;
                }
                f_Raw = new(rawChars);
            }
            else
            {
                f_Raw = "";
                f_Origins = [];
            }
        }

        /// <summary>Initializer for <see cref="SrcString"/></summary>
        /// <param name="chars">Source characters</param>
        public SrcString(IEnumerable<SrcChar> chars) : this((chars is null) ? null : [..chars]) { }

        /// <summary>Initializer for <see cref="SrcString"/></summary>
        /// <param name="src">Source content</param>
        /// <param name="srcpath">Path of file containing source content</param>
        public SrcString(string? src, NormalPath? srcpath = null)
        {
            if (src is not null)
            {
                f_Raw = src;
                f_Origins = new RefPnt[src.Length];
                var lineNum = 0;
                var lineBeg = 0;
                var pos = 0;
                foreach (var range in StrUtil.EnumerateLineRanges(src))
                {
                    // Add newline characters
                    while (pos < range.Beg)
                    {
                        var origin = new RefPnt(srcpath, lineNum, pos + 1 - lineBeg);
                        f_Origins[pos++] = origin;
                    }
                    // Update line info
                    ++lineNum;
                    lineBeg = range.Beg;
                    // Add characters
                    for (int i = 0; i < range.Len; ++i)
                    {
                        var origin = new RefPnt(srcpath, lineNum, pos + 1 - lineBeg);
                        f_Origins[pos++] = origin;
                    }
                }
                // Add newline characters
                while (pos < f_Raw.Length)
                {
                    var origin = new RefPnt(srcpath, lineNum, pos + 1 - lineBeg);
                    f_Origins[pos++] = origin;
                }
            }
            else
            {
                f_Raw = "";
                f_Origins = [];
            }
        }

        #endregion

        #region object

        /// <summary>Creates a C# string representation</summary>
        /// <returns>C# string representation</returns>
        public override string ToString() => f_Raw;

        #endregion

        #region IReadOnlyList

        /// <summary>Gets the character at the specified index</summary>
        /// <param name="index">Index of the character</param>
        /// <returns>Character at the specified index</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     Index is out of range
        /// </exception>
        public SrcChar this[int index]
        {
            get
            {
                try
                { return new(f_Raw[index], f_Origins[index]); }
                catch when (index < 0 || index >= f_Raw.Length)
                { throw new IndexOutOfRangeException(); }
            }
        }

        /// <summary>Gets an enumerator thru the string</summary>
        /// <returns>Enumerator thru the string</returns>
        public IEnumerator<SrcChar> GetEnumerator() => MM_GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => MM_GetEnumerator();

        int IReadOnlyCollection<SrcChar>.Count => f_Raw.Length;

        #endregion

        #region operators

        /// <summary>Creates of substring of the specified range</summary>
        /// <param name="range">Range</param>
        /// <returns>Created substring</returns>
        /// <exception cref="ArgumentException">
        ///     Range is not valid
        /// </exception>
        public SrcString this[Range range]
        {
            get
            {
                try
                {
                    return new(f_Raw[range], f_Origins[range]);
                }
                catch
                {
                    ArgUtil.RangeBegEnd(range, f_Raw.Length);
                    throw;
                }
            }
        }

        #endregion

        #region const

        /// <summary>Empty string</summary>
        public static SrcString EMPTY { get; } = new(null);

        #endregion

        #region fields

        private readonly string f_Raw;
        private readonly RefPnt[] f_Origins;

        #endregion

        #region properties

        /// <summary>Number of characters in string</summary>
        public int Length => f_Raw.Length;

        /// <summary>Raw string</summary>
        public string Raw => f_Raw;

        #endregion

        #region helper methods

        private IEnumerator<SrcChar> MM_GetEnumerator() 
        {
            for (int i = 0; i < f_Raw.Length; ++i)
                yield return new(f_Raw[i], f_Origins[i]);
        }

        #endregion
    }
}
