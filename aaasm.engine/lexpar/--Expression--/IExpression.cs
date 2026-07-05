using System;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a syntax expression</summary>
    public interface IExpression
    {
        #region methods

        /// <summary>Attempts to for a match within the specified string</summary>
        /// <param name="str">String to search thru</param>
        /// <param name="start">Position at which to start the search</param>
        /// <param name="range">Range of the matching substring</param>
        /// <returns>Whether or not sucessful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="str"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> is less than zero or greater than <paramref name="str"/>.Length
        /// </exception>
        public bool TryMatch(SrcString str, int start, out SubRange range);

        #endregion
    }
}
