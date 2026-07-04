using System;
using System.Collections.Generic;

namespace aaasm.engine.col
{
    /// <summary>Utility for collection-related operations</summary>
    public static class ColUtil
    {
        #region FilterNull

        /// <summary>Enumerates thru all non-null values in source collection</summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="src">Source collection</param>
        /// <returns>Non-null values in collection</returns>
        public static IEnumerable<T> FilterNull<T>(IEnumerable<T?>? src)
        {
            if (src is null) yield break;
            foreach (var item in src)
            {
                if (item is null) continue;
                yield return item;
            }
        }

        #endregion

        #region ArrayEnumerator

        /// <summary>Gets an enumerator thru the specified array</summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="array">Array</param>
        /// <returns>Enumerator thru the specified array</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="array"/> is not null
        /// </exception>
        public static IEnumerator<T> ArrayEnumerator<T>(T[] array)
        {
            ArgumentNullException.ThrowIfNull(array);
            foreach (T item in array) yield return item;
        }

        #endregion
    }
}