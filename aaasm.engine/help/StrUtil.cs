using System;
using System.Collections.Generic;

namespace aaasm.engine.help
{
    /// <summary>Utility for string-related operations</summary>
    public static class StrUtil
    {
        #region helper methods

        /// <summary>
        ///     Assume
        ///     <list type="bullet">
        ///         <item><paramref name="index"/> >= 0</item>
        ///         <item><paramref name="index"/> <= <paramref name="s"/>.Length</item>
        ///     </list>
        /// </summary>
        private static bool MM_SubstrAt(string s, string? substr, int index, bool ignoreCase)
        {
            if (substr is null)
                return false;
            if ((index + substr.Length) > s.Length)
                return false;
            for (int i = 0; i < substr.Length; ++i)
            {
                var a = s[index + i];
                var b = substr[i];
                if (a == b) continue;
                if (ignoreCase)
                {
                    int aa = (a < 'a' || a > 'z') ? a : (a - 0x20);
                    int bb = (b < 'b' || b > 'z') ? b : (b - 0x20);
                    if (aa == bb) continue;
                }
                return false;
            }
            return true;
        }

        #endregion

        #region EnumerateLines, EnumerateLineRanges

        /// <summary>Enumerates thru each line in the string</summary>
        /// <param name="s">String</param>
        /// <returns>Each line in the string (excluding \n and \r characters)</returns>
        public static IEnumerable<string> EnumerateLines(string? s)
        {
            foreach (var range in EnumerateLineRanges(s))
                yield return s!.Substring(range.Beg, range.Len);
        }

        /// <summary>Enumerates thru each line in the string</summary>
        /// <param name="s">String</param>
        /// <returns>Ranges of each line in the string (excluding \n and \r characters)</returns>
        public static IEnumerable<SubRange> EnumerateLineRanges(string? s)
        {
            if (s is null) yield break;
            var inputEnum = s.GetEnumerator(); var i = -1; var notEOF = true;
            void next() { if (notEOF) { ++i; notEOF = inputEnum.MoveNext(); } }
            next();
            do {
                var beg = i;
                var end = i;
                while (notEOF)
                {
                    var c = inputEnum.Current;
                    // Line feed?
                    if (c == '\n')
                    {
                        end = i;
                        next();
                        if (notEOF && inputEnum.Current == '\r')
                            next();
                        break;
                    }
                    // Carriage return?
                    else if (c == '\r')
                    {
                        end = i;
                        next();
                        if (notEOF && inputEnum.Current == '\n')
                            next();
                        break;
                    }
                    // Something else?
                    else
                    {
                        next();
                        end = i;
                    }
                }
                yield return new(beg, end - beg);
            } while (notEOF);
        }

        #endregion

        #region SubstrAt, StartsWith, EndsWith

        /// <summary>
        ///     Checks if there is an occurance of <paramref name="substr"/> 
        ///     at <paramref name="index"/>
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="substr">Substring</param>
        /// <param name="index">Index</param>
        /// <param name="ignoreCase">Whether or not to ignore casing</param>
        /// <returns>
        ///     Whether or not there is an occurance of <paramref name="substr"/> 
        ///     at <paramref name="index"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public static bool SubstrAt(string s, string? substr, int index, bool ignoreCase = false)
        {
            // Validate arguments
            try
            { ArgUtil.ThrowIfOOR(index, 0, s.Length); }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
            // Check
            return MM_SubstrAt(s, substr, index, ignoreCase);
        }

        /// <summary>
        ///     Checks if <paramref name="s"/> starts with <paramref name="substr"/>
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="substr">Substring</param>
        /// <param name="ignoreCase">Whether or not to ignore casing</param>
        /// <returns>
        ///     Whether or not <paramref name="s"/> starts with <paramref name="substr"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool StartsWith(string s, string? substr, bool ignoreCase = false)
        {
            ArgumentNullException.ThrowIfNull(s);
            return MM_SubstrAt(s, substr, 0, ignoreCase);
        }

        /// <summary>
        ///     Checks if <paramref name="s"/> ends with <paramref name="substr"/>
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="substr">Substring</param>
        /// <param name="ignoreCase">Whether or not to ignore casing</param>
        /// <returns>
        ///     Whether or not <paramref name="s"/> ends with <paramref name="substr"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool EndsWith(string s, string? substr, bool ignoreCase = false)
        {
            ArgumentNullException.ThrowIfNull(s);
            if (substr is null) return false;
            if (s.Length < substr.Length) return false;
            return MM_SubstrAt(s, substr, s.Length - substr.Length, ignoreCase);
        }

        #endregion

        #region IsWord

        /// <summary>Checks whether or not the string consists entirely of word characters</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the string consists entirely of word characters</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool IsWord(string s)
        {
            try
            {
                foreach (var c in s)
                { if (!CharUtil.IsWord(c)) return false; }
                return true;
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        #endregion

        #region StartsWithLetter, StartsWithLCase, StartsWithUCase, StartsWithDigit

        /// <summary>Checks whether or not the string starts with a letter</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the string starts with a letter</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool StartsWithLetter(string s)
        {
            try
            {
                if (s.Length == 0) return false;
                return CharUtil.IsLetter(s[0]);
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        /// <summary>Checks whether or not the string starts with a lowercase letter</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the string starts with a lowercase letter</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool StartsWithLCase(string s)
        {
            try
            {
                if (s.Length == 0) return false;
                return CharUtil.IsLCase(s[0]);
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        /// <summary>Checks whether or not the string starts with a uppercase letter</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the string starts with a uppercase letter</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool StartsWithUCase(string s)
        {
            try
            {
                if (s.Length == 0) return false;
                return CharUtil.IsUCase(s[0]);
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        /// <summary>Checks whether or not the string starts with a digit</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the string starts with a digit</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public static bool StartsWithDigit(string s)
        {
            try
            {
                if (s.Length == 0) return false;
                return CharUtil.IsDigit(s[0]);
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        #endregion

        #region Equal, Compare

        /// <summary>Checks if the two strings are equal</summary>
        /// <param name="a">String A</param>
        /// <param name="b">String B</param>
        /// <param name="ignoreCase">Whether or not to ignore casing</param>
        /// <returns>Whether or not the two strings are equal</returns>
        public static bool Equal(string? a, string? b, bool ignoreCase = false)
        {
            if (a is null) return b is null;
            if (b is null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; ++i)
            {
                var aa = a[i];
                var bb = b[i];
                if (aa == bb)
                    continue;
                if (ignoreCase && CharUtil.ToUCase(aa) == CharUtil.ToUCase(bb))
                    continue;
                return false;
            }
            return true;
        }

        /// <summary>Compares the to strings</summary>
        /// <param name="a">String A</param>
        /// <param name="b">String B</param>
        /// <param name="ignoreCase">Whether or not to ignore casing</param>
        /// <returns>
        ///     If return value is:
        ///     <br/>- Less than zero, <paramref name="a"/> is less than <paramref name="b"/>
        ///     <br/>- Equal to zero, <paramref name="a"/> is equal to <paramref name="b"/>
        ///     <br/>- Greater than zero, <paramref name="a"/> is greater than <paramref name="b"/>
        /// </returns>
        public static int Compare(string? a, string? b, bool ignoreCase = false)
        {
            if (a is null) return (b is null) ? 0 : -1;
            if (b is null) return 1;
            // Compare lengths
            int lencmp = a.Length - b.Length;
            int minlen = Math.Min(a.Length, b.Length);
            // Compare characters
            for (int i = 0; i < minlen; ++i)
            {
                var aa = a[i];
                var bb = b[i];
                if (aa == bb) continue;
                if (!ignoreCase) return aa - bb;
                var aaa = CharUtil.ToUCase(aa);
                var bbb = CharUtil.ToUCase(bb);
                if (aaa == bbb) continue;
                return aaa - bbb;
            }
            // Return length comparison
            return lencmp;
        }

        #endregion
    }
}