using System;
using System.Diagnostics.CodeAnalysis;

namespace aaasm.engine.help
{
    /// <summary>Useful methods for try, catch, and finally blocks</summary>
    public static class TryUtil
    {
        #region TryFind

        /// <summary>
        ///     Searches for an exception of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">
        ///     Exception type to look for
        /// </typeparam>
        /// <param name="e">
        ///     First exception to check; if not of type <typeparamref name="T"/>, 
        ///     its inner exceptions will also be checked
        /// </param>
        /// <param name="found">
        ///     Found exception of type <typeparamref name="T"/>
        /// </param>
        /// <returns>
        ///     Whether or not an exception of type <typeparamref name="T"/> was found
        /// </returns>
        public static bool TryFind<T>(Exception? e, [MaybeNullWhen(false)] out T found)
            where T: Exception
        {
            while (e is not null)
            {
                if (e is T t)
                {
                    found = t;
                    return true;
                }
                e = e.InnerException;
            }
            found = default;
            return false;
        }

        #endregion
    }
}