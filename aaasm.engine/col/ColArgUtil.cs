using System;
using System.Collections.Generic;
using aaasm.engine.help;

using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.col
{
    /// <summary>Utility for handling collection-related arguments</summary>
    public static class ColArgUtil
    {
        #region ThrowIfOOR, ThrowIfOOREx

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if 
        ///     <paramref name="start"/> and <paramref name="count"/> do not denote
        ///     a valid range in <paramref name="collection"/>
        /// </summary>
        /// <param name="collection">Minimum</param>
        /// <param name="start">Start index argument</param>
        /// <param name="count">Count argument</param>
        /// <param name="startParam">Name of start index parameter</param>
        /// <param name="countParam">Name of count parameter</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="start"/> and <paramref name="count"/> do not denote
        ///     a valid range in <paramref name="collection"/>
        /// </exception>
        public static void ThrowIfOOR<T>(IReadOnlyCollection<T> collection, int start, int count,
            [CallArgExp(nameof(start))] string? startParam = null,
            [CallArgExp(nameof(count))] string? countParam = null)
        {
            try
            {
                if (start < 0 || count < 0 || (start + count) > collection.Count)
                {
                    throw new ArgumentOutOfRangeException(startParam,
                        $"{startParam} and {countParam} do not denote a valid range within the collection.");
                }
            }
            catch when (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="index"/> 
        ///     is less than zero or greater than <paramref name="collection"/>.Count
        /// </summary>
        /// <param name="collection">Minimum</param>
        /// <param name="index">Index argument</param>
        /// <param name="indexParam">Name of index parameter</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public static void ThrowIfOOR<T>(IReadOnlyCollection<T> collection, int index,
            [CallArgExp(nameof(index))] string? indexParam = null)
        {
            try
            { ArgUtil.ThrowIfOOR(index, 0, collection.Count, param: indexParam); }
            catch when (collection is null)
            { throw new ArgumentNullException(nameof(collection)); }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="index"/> 
        ///     is less than zero or greater than or equal to <paramref name="collection"/>.Count
        /// </summary>
        /// <param name="collection">Minimum</param>
        /// <param name="index">Index argument</param>
        /// <param name="indexParam">Name of index parameter</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public static void ThrowIfOOREx<T>(IReadOnlyCollection<T> collection, int index,
            [CallArgExp(nameof(index))] string? indexParam = null)
        {
            try
            { ArgUtil.ThrowIfOOREx(index, 0, collection.Count, param: indexParam); }
            catch when (collection is null)
            { throw new ArgumentNullException(nameof(collection)); }
        }

        #endregion

    }
}