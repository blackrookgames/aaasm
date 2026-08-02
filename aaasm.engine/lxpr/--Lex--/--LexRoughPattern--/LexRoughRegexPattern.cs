using System;
using System.Text.RegularExpressions;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a regex-based rough pattern</summary>
    public class LexRoughRegexPattern : LexRoughPattern
    {
        #region init
        
        /// <summary>Initializer for <see cref="LexRoughRegexPattern"/></summary>
        /// <param name="regex">Regex pattern</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="regex"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="regex"/> is not a valid regular expression
        /// </exception>
        /// <inheritdoc cref="LexRoughPattern(bool)"/>
        public LexRoughRegexPattern(string regex, 
            bool dontSplit = false, bool newlineOnly = false) : 
            base(dontSplit, newlineOnly)
        {
            ArgumentNullException.ThrowIfNull(regex);
            try 
            { f_Regex = new($"\\G{regex}"); }
            catch (ArgumentException)
            { throw new ArgumentException("Regular expression is not valid.", nameof(regex)); }
        }

        #endregion

        #region fields

        private readonly Regex f_Regex;

        #endregion

        #region ILexRoughPattern
        
        /// <inheritdoc/>
        public override int MatchAt(Str input, int index)
        {
            MM_MatchAt_ValidateArgs(input, index);
            var match = f_Regex.Match((string)input, index);
            if (!match.Success) return 0;
            return match.Length;
        }

        #endregion
    }
}