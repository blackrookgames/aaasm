using System;
using System.Collections.Generic;

namespace aaasm.engine.help
{
    /// <summary>Utility for string-related operations</summary>
    public static class StrUtil
    {
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

        #region OccuranceOf

        /// <summary>
        ///     Checks if there is an occurance of <paramref name="substr"/> 
        ///     at <paramref name="index"/>
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="substr">Substring</param>
        /// <param name="index">Index</param>
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
        public static bool SubstrAt(string s, string? substr, int index)
        {
            // Validate arguments
            try
            { ArgUtil.ThrowIfOOR(index, 0, s.Length); }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
            // Check
            if (substr is null)
                return false;
            if ((index + substr.Length) > s.Length)
                return false;
            for (int i = 0; i < substr.Length; ++i)
            {
                if (s[index + i] != substr[i])
                    return false;
            }
            return true;
        }

        #endregion
    }
}