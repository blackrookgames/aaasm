using System;
using aaasm.engine.data;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Utility for parsing and lexical analysis</summary>
    public static class LexParUtil
    {
        #region IsLegalName

        /// <summary>Checks whether or not the specified name is legal</summary>
        /// <param name="name">Name to check</param>
        /// <returns>Whether or not the specified name is legal</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name"/> is null
        /// </exception>
        public static bool IsLegalName(string name)
        {
            try
            { return (!StrUtil.StartsWithDigit(name)) && StrUtil.IsWord(name); }
            catch when (name is null)
            { throw new ArgumentNullException(nameof(name)); }
        }

        /// <summary>Checks whether or not the specified name is legal</summary>
        /// <param name="name">Name to check</param>
        /// <returns>Whether or not the specified name is legal</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name"/> is null
        /// </exception>
        public static bool IsLegalName(Str name)
        {
            try
            { return (!name.StartsWithDigit()) && name.IsWord(); }
            catch when (name is null)
            { throw new ArgumentNullException(nameof(name)); }
        }

        #endregion
    }
}
