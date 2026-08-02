using System;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a string-based rough pattern</summary>
    public class LexRoughStrPattern : LexRoughPattern
    {
        #region init
        
        /// <summary>Initializer for <see cref="LexRoughStrPattern"/></summary>
        /// <param name="substr">Substring</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="substr"/> is null
        /// </exception>
        /// <inheritdoc cref="LexRoughPattern(bool)"/>
        public LexRoughStrPattern(Str substr, 
            bool dontSplit = false, bool newlineOnly = false) : 
            base(dontSplit, newlineOnly)
        {
            ArgumentNullException.ThrowIfNull(substr);
            f_Substr = substr;
        }

        #endregion

        #region fields

        private readonly Str f_Substr;

        #endregion

        #region ILexRoughPattern
        
        /// <inheritdoc/>
        public override int MatchAt(Str input, int index)
        {
            try
            { return input.SubstrAt(f_Substr, index) ? f_Substr.Length : 0; }
            catch
            { MM_MatchAt_ValidateArgs(input, index); throw; }
        }

        #endregion
    }
}