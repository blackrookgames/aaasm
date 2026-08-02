using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace aaasm.engine.col
{
    /// <summary>Represents a collection of keyed items</summary>
    public interface IKeyedCollection<TKey, TItem> : IReadOnlyCollection<TItem>
    {
        #region abstract methods

        /// <summary>Attempts to get the item with the specified key</summary>
        /// <param name="key">key</param>
        /// <param name="item">Found item</param>
        /// <returns>Whether or not successful</returns>
        public bool TryGet(TKey? key, [MaybeNullWhen(false)] out TItem item);

        #endregion
    }

    public static class IKeyedCollection_ext
    {
        #region methods

        /// <summary>Gets the item with the specified key</summary>
        /// <param name="collection">Collection</param>
        /// <param name="key">Key</param>
        /// <returns>Found item</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        ///     <paramref name="key"/> does not exist in <paramref name="collection"/>
        /// </exception>
        public static TItem Get<TKey, TItem>(this IKeyedCollection<TKey, TItem> collection, TKey? key)
        {
            try
            {
                if (collection.TryGet(key, out var value)) return value;
                throw new KeyNotFoundException("Could not find the specified key.");
            }
            catch when (collection is null)
            { throw new ArgumentNullException(nameof(collection)); }
        }

        #endregion
    }
}
