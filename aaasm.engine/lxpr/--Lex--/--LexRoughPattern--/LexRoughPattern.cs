using System;
using aaasm.engine.data;
using aaasm.engine.help;
using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a rough pattern</summary>
    /// <param name="dontSplit">If true, pattern will not be used to split a token</param>
    /// <param name="newlineOnly">
    ///     If true, match should only be considered valid if it's at the start of a newline
    /// </param>
    public abstract class LexRoughPattern(bool dontSplit, bool newlineOnly)
    {
        #region fields

        private readonly bool f_DontSplit = dontSplit;
        private readonly bool f_NewlineOnly = newlineOnly;

        #endregion

        #region fields

        /// <summary>If true, pattern will not be used to split a token</summary>
        public bool DontSplit => f_DontSplit;

        /// <summary>
        ///     If true, match should only be considered valid if it's at the start of a newline
        /// </summary>
        /// <remarks>
        ///     This value exists soley for informational purposes and 
        ///     does not affect the return value of <see cref="MatchAt"/> in any way.
        /// </remarks>
        public bool NewlineOnly => f_NewlineOnly;

        #endregion

        #region private protected methods

        private protected static void MM_MatchAt_ValidateArgs(Str input, int index,
            [CallArgExp(nameof(input))] string? inputParam = null,
            [CallArgExp(nameof(index))] string? indexParam = null)
        {
            try
            { ArgUtil.ThrowIfOOR(index, 0, input.Length, indexParam); }
            catch when (input is null)
            { throw new ArgumentNullException(inputParam); }
        }

        #endregion

        #region abstract methods
        
        /// <summary>Looks for a matching substring at the specified index</summary>
        /// <param name="input">Input string</param>
        /// <param name="index">Index at which matching substring must be found</param>
        /// <returns>Length of matching substring (or 0 if no match could be found or match is empty)</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public abstract int MatchAt(Str input, int index);

        #endregion
    }
}