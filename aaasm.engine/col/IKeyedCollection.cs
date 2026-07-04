using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace aaasm.engine.col
{
    /// <summary>Represents a collection of keyed items</summary>
    public interface IKeyedCollection<TKey, TItem> : IReadOnlyCollection<TItem>
    {
        #region methods

        /// <summary>Attempts to get the item with the specified key</summary>
        /// <param name="key">key</param>
        /// <param name="item">Found item</param>
        /// <returns>Whether or not successful</returns>
        public bool TryGet(TKey? key, [MaybeNullWhen(false)] out TItem item);

        #endregion
    }
}
