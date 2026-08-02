using System;
using System.Collections.Generic;

namespace aaasm.engine.help
{
    /// <summary>Utility for char-related operations</summary>
    public static class CharUtil
    {
        #region IsDigit, IsLCase, IsUCase, IsLetter, IsWord

        /// <summary>Checks whether or not the character is a digit</summary>
        /// <param name="c">Character to check</param>
        /// <returns>Whether or not the character is a digit</returns>
        public static bool IsDigit(char c) => c >= '0' && c <= '9';

        /// <summary>Checks whether or not the character is a lowercase letter</summary>
        /// <param name="c">Character to check</param>
        /// <returns>Whether or not the character is a lowercase letter</returns>
        public static bool IsLCase(char c) => c >= 'a' && c <= 'z';

        /// <summary>Checks whether or not the character is an uppercase letter</summary>
        /// <param name="c">Character to check</param>
        /// <returns>Whether or not the character is an uppercase letter</returns>
        public static bool IsUCase(char c) => c >= 'A' && c <= 'Z';

        /// <summary>Checks whether or not the character is a letter</summary>
        /// <param name="c">Character to check</param>
        /// <returns>Whether or not the character is a letter</returns>
        public static bool IsLetter(char c) => IsLCase(c) || IsUCase(c);

        /// <summary>Checks whether or not the character is a word character</summary>
        /// <param name="c">Character to check</param>
        /// <returns>Whether or not the character is a word character</returns>
        public static bool IsWord(char c) => c == '_' || IsLetter(c) || IsDigit(c);

        #endregion

        #region ToLCase, ToUCase

        /// <summary>Converts an uppercase character to lowercase</summary>
        /// <param name="c">Input character</param>
        /// <returns>
        ///     Resulting character; 
        ///     if the input is not an uppercase letter, the input is returned
        /// </returns>
        public static char ToLCase(char c) => IsUCase(c) ? (char)(c ^ 0x20) : c;

        /// <summary>Converts an lowercase character to uppercase</summary>
        /// <param name="c">Input character</param>
        /// <returns>
        ///     Resulting character; 
        ///     if the input is not an lowercase letter, the input is returned
        /// </returns>
        public static char ToUCase(char c) => IsLCase(c) ? (char)(c ^ 0x20) : c;

        #endregion
    }
}