using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.help;

using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.data
{
    public partial class Str
    {
        #region private methods

        #region IgnoreCase
        
        private static bool MM_IgnoreCase(Str? s)
        {
            return s is not null && s.PP_IgnoreCase;
        }

        #endregion

        #region SubstrAt
        
        private bool MM_SubstrAt(string? substr, int index, bool otherIgnoreCase,
            [CallArgExp(nameof(index))] string? indexParam = null)
        {
            ArgUtil.ThrowIfOOR(index, 0, f_Raw.Length, param: indexParam);
            if (substr is null) return false;
            if ((index + substr.Length) > f_Raw.Length) return false;
            bool ignoreCase = PP_IgnoreCase || otherIgnoreCase;
            return MM_Equal(f_Raw, index, index + substr.Length, substr, 0, substr.Length, ignoreCase);
        }

        private bool MM_SubstrAt(string? substr, int index,
            [CallArgExp(nameof(index))] string? indexParam = null)
        {
            return MM_SubstrAt(substr, index, false, indexParam: indexParam);
        }

        private bool MM_SubstrAt(Str? substr, int index,
            [CallArgExp(nameof(index))] string? indexParam = null)
        {
            return MM_SubstrAt(substr?.f_Raw, index, MM_IgnoreCase(substr), indexParam: indexParam);
        }

        #endregion

        #region FindSubstr

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="beg"/> &gt;= 0
        ///     <br/>- <paramref name="beg"/> &lt;= <see cref="f_Raw"/>.Length
        ///     <br/>- <paramref name="end"/> &gt;= 0
        ///     <br/>- <paramref name="end"/> &lt;= <see cref="f_Raw"/>.Length
        ///     <br/>- <paramref name="beg"/> &lt;= <paramref name="end"/>
        /// </summary>
        private int MM_FindSubstr_Common(string? substr, int beg, int end, bool otherIgnoreCase)
        {
            if (substr is null) return -1;
            bool ignoreCase = PP_IgnoreCase || otherIgnoreCase;
            int subend = beg + substr.Length;
            while (subend <= end)
            {
                if (MM_Equal(f_Raw, beg, subend, substr, 0, substr.Length, ignoreCase))
                    return beg;
                ++beg; ++subend;
            }
            return -1;
        }

        private int MM_FindSubstr(string? substr, bool otherIgnoreCase)
        {
            return MM_FindSubstr_Common(substr, 0, f_Raw.Length, otherIgnoreCase);
        }

        private int MM_FindSubstr(string? substr, int start, bool otherIgnoreCase,
            [CallArgExp(nameof(start))] string? startParam = null)
        {
            ColArgUtil.ThrowIfOOR(this, start, startParam);
            return MM_FindSubstr_Common(substr, start, f_Raw.Length, otherIgnoreCase);
        }

        private int MM_FindSubstr(string? substr, int start, int count, bool otherIgnoreCase,
            [CallArgExp(nameof(start))] string? startParam = null,
            [CallArgExp(nameof(count))] string? countParam = null)
        {
            ColArgUtil.ThrowIfOOR(this, start, count, startParam, countParam);
            return MM_FindSubstr_Common(substr, start, start + count, otherIgnoreCase);
        }

        #endregion

        #region RFindSubstr

        /// <summary>
        ///     Assume
        ///     <br/>- <paramref name="beg"/> &gt;= 0
        ///     <br/>- <paramref name="beg"/> &lt;= <see cref="f_Raw"/>.Length
        ///     <br/>- <paramref name="end"/> &gt;= 0
        ///     <br/>- <paramref name="end"/> &lt;= <see cref="f_Raw"/>.Length
        ///     <br/>- <paramref name="beg"/> &lt;= <paramref name="end"/>
        /// </summary>
        private int MM_RFindSubstr_Common(string? substr, int beg, int end, bool otherIgnoreCase)
        {
            if (substr is null) return -1;
            bool ignoreCase = PP_IgnoreCase || otherIgnoreCase;
            int subbeg = end - substr.Length;
            while (subbeg >= beg)
            {
                if (MM_Equal(f_Raw, subbeg, end, substr, 0, substr.Length, ignoreCase))
                    return subbeg;
                --end; --subbeg;
            }
            return -1;
        }

        private int MM_RFindSubstr(string? substr, bool otherIgnoreCase)
        {
            return MM_RFindSubstr_Common(substr, 0, f_Raw.Length, otherIgnoreCase);
        }

        private int MM_RFindSubstr(string? substr, int start, bool otherIgnoreCase,
            [CallArgExp(nameof(start))] string? startParam = null)
        {
            ColArgUtil.ThrowIfOOR(this, start, startParam);
            return MM_RFindSubstr_Common(substr, start, f_Raw.Length, otherIgnoreCase);
        }

        private int MM_RFindSubstr(string? substr, int start, int count, bool otherIgnoreCase,
            [CallArgExp(nameof(start))] string? startParam = null,
            [CallArgExp(nameof(count))] string? countParam = null)
        {
            ColArgUtil.ThrowIfOOR(this, start, count, startParam, countParam);
            return MM_RFindSubstr_Common(substr, start, start + count, otherIgnoreCase);
        }

        #endregion

        #region Split

        private IEnumerable<Str> MM_Split(string? sep, bool skipEmpty, bool otherIgnoreCase)
        {
            if (sep is not null)
            {
                if (sep.Length > 0)
                {
                    int start = 0;
                    while (true)
                    {
                        int index = MM_FindSubstr_Common(sep, start, f_Raw.Length, otherIgnoreCase);
                        if (index >= 0)
                        {
                            if ((!skipEmpty) || start < index)
                                yield return this[start..index];
                            start = index + sep.Length;
                        }
                        else
                        {
                            if ((!skipEmpty) || start < f_Raw.Length)
                                yield return this[start..];
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var c in f_Raw)
                        yield return MM_Create(c.ToString());
                }
            }
            else
            {
                if (skipEmpty && f_Raw.Length == 0)
                    yield break;
                yield return this;
            }
        }

        #endregion

        #endregion

        #region Substring

        /// <summary>Retrieves a substring</summary>
        /// <param name="start">Starting index of substring</param>
        /// <returns>Retrieved substring</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> is out of range
        /// </exception>
        public Str Substring(int start)
        {
            try
            { return MM_Create(f_Raw[start..]); }
            catch
            { ColArgUtil.ThrowIfOOR(this, start); throw; }
        }

        /// <summary>Retrieves a substring</summary>
        /// <param name="start">Starting index of substring</param>
        /// <param name="length">Length of substring</param>
        /// <returns>Retrieved substring</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> and <paramref name="length"/> do not denote
        ///     a valid range in the string
        /// </exception>
        public Str Substring(int start, int length)
        {
            try
            { return MM_Create(f_Raw.Substring(start, length)); }
            catch
            { ColArgUtil.ThrowIfOOR(this, start, length); throw; }
        }

        #endregion

        #region EnumLines, EnumLineRanges

        /// <summary>Enumerates thru each line in the string</summary>
        /// <returns>Each line in the string (excluding \n and \r characters)</returns>
        public IEnumerable<Str> EnumLines()
        {
            foreach (var range in EnumLineRanges())
                yield return this[range];
        }

        /// <summary>Enumerates thru each line in the string</summary>
        /// <returns>Ranges of each line in the string (excluding \n and \r characters)</returns>
        public IEnumerable<SubRange> EnumLineRanges()
        {
            return StrUtil.EnumerateLineRanges(f_Raw);
        }

        #endregion
        
        #region SubstrAt, StartsWith, EndsWith

        /// <summary>
        ///     Checks if there is an occurance of <paramref name="substr"/> 
        ///     at <paramref name="index"/>
        /// </summary>
        /// <param name="substr">Substring</param>
        /// <param name="index">Index</param>
        /// <returns>
        ///     Whether or not there is an occurance of <paramref name="substr"/> 
        ///     at <paramref name="index"/>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public bool SubstrAt(Str? substr, int index) => MM_SubstrAt(substr, index);

        /// <inheritdoc cref="SubstrAt(Str?,int)"/>
        public bool SubstrAt(string? substr, int index) => MM_SubstrAt(substr, index);

        /// <summary>
        ///     Checks if the string starts with <paramref name="substr"/>
        /// </summary>
        /// <param name="substr">Substring</param>
        /// <returns>
        ///     Whether or not the string starts with <paramref name="substr"/>
        /// </returns>
        public bool StartsWith(Str? substr) => MM_SubstrAt(substr, 0);
        
        /// <inheritdoc cref="StartsWith(Str?)"/>
        public bool StartsWith(string? substr) => MM_SubstrAt(substr, 0);

        /// <summary>
        ///     Checks if the string ends with <paramref name="substr"/>
        /// </summary>
        /// <param name="substr">Substring</param>
        /// <returns>
        ///     Whether or not the string ends with <paramref name="substr"/>
        /// </returns>
        public bool EndsWith(Str? substr)
        {
            if (substr is null) return false;
            int index = f_Raw.Length - substr.f_Raw.Length;
            if (index < 0) return false;
            return MM_SubstrAt(substr, index);
        }
        
        /// <inheritdoc cref="EndsWith(Str?)"/>
        public bool EndsWith(string? substr)
        {
            if (substr is null) return false;
            int index = f_Raw.Length - substr.Length;
            if (index < 0) return false;
            return MM_SubstrAt(substr, index);
        }

        #endregion

        #region IsWord

        /// <summary>Checks whether or not the string consists entirely of word characters</summary>
        /// <returns>Whether or not the string consists entirely of word characters</returns>
        public bool IsWord()
        {
            return StrUtil.IsWord(f_Raw);
        }

        #endregion

        #region StartsWithLetter, StartsWithLCase, StartsWithUCase, StartsWithDigit

        /// <summary>Checks whether or not the string starts with a letter</summary>
        /// <returns>Whether or not the string starts with a letter</returns>
        public bool StartsWithLetter()
        {
            return StrUtil.StartsWithLetter(f_Raw);
        }

        /// <summary>Checks whether or not the string starts with a lowercase letter</summary>
        /// <returns>Whether or not the string starts with a lowercase letter</returns>
        public bool StartsWithLCase()
        {
            return StrUtil.StartsWithLCase(f_Raw);
        }

        /// <summary>Checks whether or not the string starts with a uppercase letter</summary>
        /// <returns>Whether or not the string starts with a uppercase letter</returns>
        public bool StartsWithUCase()
        {
            return StrUtil.StartsWithUCase(f_Raw);
        }

        /// <summary>Checks whether or not the string starts with a digit</summary>
        /// <returns>Whether or not the string starts with a digit</returns>
        public bool StartsWithDigit()
        {
            return StrUtil.StartsWithDigit(f_Raw);
        }

        #endregion

        #region FindSubstr

        /// <summary>Searches the string for the specified substring</summary>
        /// <param name="substr">Substring to search for</param>
        /// <returns>
        ///     Index of the first occurence of the substring 
        ///     (or -1 if substring could not be found)
        /// </returns>
        public int FindSubstr(Str? substr)
        {
            return MM_FindSubstr(substr?.f_Raw, MM_IgnoreCase(substr));
        }
        
        /// <inheritdoc cref="FindSubstr(Str?)"/>
        /// <param name="start">Starting index</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> is out of range
        /// </exception>
        public int FindSubstr(Str? substr, int start)
        {
            return MM_FindSubstr(substr?.f_Raw, start, MM_IgnoreCase(substr));
        }
        
        /// <inheritdoc cref="FindSubstr(Str?)"/>
        /// <param name="start">Starting index</param>
        /// <param name="count">Number of characters included in search</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> and <paramref name="count"/> do not denote a valid range
        /// </exception>
        public int FindSubstr(Str? substr, int start, int count)
        {
            return MM_FindSubstr(substr?.f_Raw, start, count, MM_IgnoreCase(substr));
        }

        /// <inheritdoc cref="FindSubstr(Str?)"/>
        public int FindSubstr(string? substr)
        {
            return MM_FindSubstr(substr, false);
        }
        
        /// <inheritdoc cref="FindSubstr(Str?,int)"/>
        public int FindSubstr(string? substr, int start)
        {
            return MM_FindSubstr(substr, start, false);
        }
        
        /// <inheritdoc cref="FindSubstr(Str?,int,int)"/>
        public int FindSubstr(string? substr, int start, int count)
        {
            return MM_FindSubstr(substr, start, count, false);
        }

        #endregion
        
        #region RFindSubstr

        /// <summary>Searches the string for the specified substring</summary>
        /// <param name="substr">Substring to search for</param>
        /// <returns>
        ///     Index of the last occurence of the substring 
        ///     (or -1 if substring could not be found)
        /// </returns>
        public int RFindSubstr(Str? substr)
        {
            return MM_RFindSubstr(substr?.f_Raw, MM_IgnoreCase(substr));
        }
        
        /// <inheritdoc cref="RFindSubstr(Str?)"/>
        /// <param name="start">Starting index</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> is out of range
        /// </exception>
        public int RFindSubstr(Str? substr, int start)
        {
            return MM_RFindSubstr(substr?.f_Raw, start, MM_IgnoreCase(substr));
        }
        
        /// <inheritdoc cref="RFindSubstr(Str?)"/>
        /// <param name="start">Starting index</param>
        /// <param name="count">Number of characters included in search</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> and <paramref name="count"/> do not denote a valid range
        /// </exception>
        public int RFindSubstr(Str? substr, int start, int count)
        {
            return MM_RFindSubstr(substr?.f_Raw, start, count, MM_IgnoreCase(substr));
        }

        /// <inheritdoc cref="RFindSubstr(Str?)"/>
        public int RFindSubstr(string? substr)
        {
            return MM_RFindSubstr(substr, false);
        }
        
        /// <inheritdoc cref="RFindSubstr(Str?,int)"/>
        public int RFindSubstr(string? substr, int start)
        {
            return MM_RFindSubstr(substr, start, false);
        }
        
        /// <inheritdoc cref="RFindSubstr(Str?,int,int)"/>
        public int RFindSubstr(string? substr, int start, int count)
        {
            return MM_RFindSubstr(substr, start, count, false);
        }

        #endregion

        #region Split

        /// <summary>Splits the string into segments</summary>
        /// <param name="sep">Substring to separate by</param>
        /// <param name="skipEmpty">Whether or not to exclude empty segments</param>
        /// <returns>Enumeration thru the split segments</returns>
        public IEnumerable<Str> Split(Str? sep, bool skipEmpty = false)
        {
            return MM_Split(sep?.f_Raw, skipEmpty, MM_IgnoreCase(sep));
        }

        /// <inheritdoc cref="Split(Str?,bool)"/>
        public IEnumerable<Str> Split(string? sep, bool skipEmpty = false)
        {
            return MM_Split(sep, skipEmpty, false);
        }

        #endregion
    }
}