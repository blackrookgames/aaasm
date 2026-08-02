using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.col
{
    /// <summary>Utility for collection-related operations</summary>
    public static class ColUtil
    {
        #region helper methods

        private static void MM_ThrowIfReadOnly<T>(ICollection<T> arg,
            [CallArgExp(nameof(arg))] string? argParam = null)
        {
            try
            {
                if (!arg.IsReadOnly) return;
                throw new ArgumentException("Collection cannot be read-only.", argParam);
            }
            catch when (arg is null)
            {
                throw new ArgumentNullException(argParam);
            }
        }

        private static int MM_Comparison<T>(T? a, T? b)
            where T: IComparable<T>
        {
            if (a is not null) return a.CompareTo(b);
            return (b is null) ? 0 : -1;
        }

        #endregion

        #region AnyNull

        /// <summary>Checks whether or not the collection contains any null elements</summary>
        /// <param name="collection">Collection to check</param>
        /// <returns>Whether or not the collection contains any null elements</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        /// </exception>
        public static bool AnyNull(IEnumerable collection)
        {
            try
            {
                foreach (var item in collection)
                { if (item is null) return true; }
                return false;
            }
            catch when (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
        }

        #endregion

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

        #region Repeat

        /// <summary>Repeats a value a certain number of times</summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="value">
        ///     Value to repeat
        /// </param>
        /// <param name="count">
        ///     Number of times to repeat<br/>
        ///     If 1, the resulting collection will contain 1 element<br/>
        ///     If 2, the resulting collection will contain 2 elements<br/>
        ///     If 15, the resulting collection will contain 15 elements
        /// </param>
        /// <returns>Resulting collection</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count"/> is negative
        /// </exception>
        public static IEnumerable<T> Repeat<T>(T value, int count)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(count);
            while (count-- > 0) yield return value;
        }

        #endregion

        #region ReverseLoop

        /// <summary>Loop thru the list in reverse</summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="list">List to loop thru</param>
        /// <returns>List items, starting with last item</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="list"/> is null
        /// </exception>
        public static IEnumerable<T> ReverseLoop<T>(IReadOnlyList<T> list)
        {
            // Initialize position
            int pos;
            try
            { pos = list.Count; }
            catch when (list is null)
            { throw new ArgumentNullException(nameof(list)); }
            // Loop thru
            while (pos > 0) yield return list[--pos];
        }

        #endregion

        #region TryFind, TryFindIndex

        private static bool MM_Find<T>(IEnumerable<T> collection, Predicate<T> criteria, 
            [MaybeNullWhen(false)] out T item, out int index,
            [CallArgExp(nameof(collection))] string? collectionParam = null,
            [CallArgExp(nameof(criteria))] string? criteriaParam = null)
        {
            ArgumentNullException.ThrowIfNull(collection, collectionParam);
            ArgumentNullException.ThrowIfNull(criteria, criteriaParam);
            var iter = collection.GetEnumerator();
            index = -1;
            while (iter.MoveNext())
            {
                item = iter.Current;
                ++index;
                if (criteria(item)) return true;
            }
            item = default;
            index = -1;
            return false;
        }

        /// <summary>Attempts to find an element that meets the specified criteria</summary>
        /// <param name="collection">Collection to search thru</param>
        /// <param name="criteria">Criteria</param>
        /// <param name="item">Found item</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="criteria"/> is null
        /// </exception>
        public static bool TryFind<T>(IEnumerable<T> collection, Predicate<T> criteria, 
            [MaybeNullWhen(false)] out T item)
        {
            return MM_Find(collection, criteria, out item, out _);
        }

        /// <summary>Attempts to find an element that meets the specified criteria</summary>
        /// <param name="collection">Collection to search thru</param>
        /// <param name="criteria">Criteria</param>
        /// <param name="index">Index of found item</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="criteria"/> is null
        /// </exception>
        public static bool TryFindIndex<T>(IEnumerable<T> collection, Predicate<T> criteria, 
            out int index)
        {
            return MM_Find(collection, criteria, out _, out index);
        }

        #endregion
    
        #region BinSearch, BinSearchIndex

        private static bool MM_BinSearch<TItem, TKey>(
            IReadOnlyList<TItem> items, TKey key,
            Func<TItem, TKey> getKey, Comparison<TKey> cmp,
            [MaybeNullWhen(false)] out TItem item, out int index,
            [CallArgExp(nameof(items))] string? itemsParam = null,
            [CallArgExp(nameof(getKey))] string? getKeyParam = null,
            [CallArgExp(nameof(cmp))] string? cmpParam = null)
        {
            ArgumentNullException.ThrowIfNull(items, itemsParam);
            ArgumentNullException.ThrowIfNull(getKey, getKeyParam);
            ArgumentNullException.ThrowIfNull(cmp, cmpParam);
            int beg = 0;
            int end = items.Count;
            while (beg < end)
            {
                index = (beg + end) / 2;
                item = items[index];
                var cmpResult = cmp(key, getKey(item));
                if (cmpResult == 0)
                    return true;
                if (cmpResult < 0)
                    end = index;
                else
                    beg = index + 1;
            }
            item = default;
            index = -1;
            return false;
        }

        /// <summary>Performs a binary search to find an item with the matching key</summary>
        /// <param name="items">Item collection to search thru</param>
        /// <param name="key">Key to match</param>
        /// <param name="getKey">Function for extracting the key from an item</param>
        /// <param name="item">Found item</param>
        /// <returns>Whether or not successful</returns>
        /// <remarks>
        ///     Item collection MUST be sorted by key in order for this to work
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="items"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="getKey"/> is null
        /// </exception>
        public static bool BinSearch<TItem, TKey>(
            IReadOnlyList<TItem> items, TKey key,
            Func<TItem, TKey> getKey,
            [MaybeNullWhen(false)] out TItem item)
            where TKey: IComparable<TKey>
        {
            return MM_BinSearch(items, key, getKey, MM_Comparison, out item, out _);
        }
        
        /// <summary>Performs a binary search to find an item with the matching key</summary>
        /// <param name="items">Item collection to search thru</param>
        /// <param name="key">Key to match</param>
        /// <param name="getKey">Function for extracting the key from an item</param>
        /// <param name="cmp">Comparison function</param>
        /// <param name="item">Found item</param>
        /// <returns>Whether or not successful</returns>
        /// <remarks>
        ///     Item collection MUST be sorted by key in order for this to work
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="items"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="getKey"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="cmp"/> is null
        /// </exception>
        public static bool BinSearch<TItem, TKey>(
            IReadOnlyList<TItem> items, TKey key,
            Func<TItem, TKey> getKey, Comparison<TKey> cmp,
            [MaybeNullWhen(false)] out TItem item)
        {
            return MM_BinSearch(items, key, getKey, cmp, out item, out _);
        }
        
        /// <summary>Performs a binary search to find an item with the matching key</summary>
        /// <param name="items">Item collection to search thru</param>
        /// <param name="key">Key to match</param>
        /// <param name="getKey">Function for extracting the key from an item</param>
        /// <param name="index">Index of the found item</param>
        /// <returns>Whether or not successful</returns>
        /// <remarks>
        ///     Item collection MUST be sorted by key in order for this to work
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="items"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="getKey"/> is null
        /// </exception>
        public static bool BinSearchIndex<TItem, TKey>(
            IReadOnlyList<TItem> items, TKey key,
            Func<TItem, TKey> getKey,
            out int index)
            where TKey: IComparable<TKey>
        {
            return MM_BinSearch(items, key, getKey, MM_Comparison, out _, out index);
        }

        /// <summary>Performs a binary search to find an item with the matching key</summary>
        /// <param name="items">Item collection to search thru</param>
        /// <param name="key">Key to match</param>
        /// <param name="getKey">Function for extracting the key from an item</param>
        /// <param name="cmp">Comparison function</param>
        /// <param name="index">Index of the found item</param>
        /// <returns>Whether or not successful</returns>
        /// <remarks>
        ///     Item collection MUST be sorted by key in order for this to work
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="items"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="getKey"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="cmp"/> is null
        /// </exception>
        public static bool BinSearchIndex<TItem, TKey>(
            IReadOnlyList<TItem> items, TKey key,
            Func<TItem, TKey> getKey, Comparison<TKey> cmp,
            out int index)
        {
            return MM_BinSearch(items, key, getKey, cmp, out _, out index);
        }

        #endregion

        #region BinInsert

        private static int MM_BinInsert<T>(
            IList<T> items, T item, Comparison<T> cmp,
            [CallArgExp(nameof(items))] string? itemsParam = null,
            [CallArgExp(nameof(cmp))] string? cmpParam = null)
        {
            MM_ThrowIfReadOnly(items, itemsParam);
            ArgumentNullException.ThrowIfNull(cmp, cmpParam);
            int index = 0;
            while (index < items.Count)
            {
                if (cmp(item, items[index]) < 0)
                    break;
                ++index;
            }
            items.Insert(index, item);
            return index;
        }

        /// <summary>Inserts an item into a list that is assumed to be sorted</summary>
        /// <param name="items">List to search thru</param>
        /// <param name="item">Item to insert</param>
        /// <returns>Index at which item was inserted</returns>
        /// <remarks>List MUST be sorted in order for this to be accurate</remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="items"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="items"/> is read-only
        /// </exception>
        public static int BinInsert<T>(IList<T> items, T item) where T: IComparable<T>
        {
            return MM_BinInsert(items, item, MM_Comparison);
        }

        /// <summary>Inserts an item into a list that is assumed to be sorted</summary>
        /// <param name="items">List to search thru</param>
        /// <param name="item">Item to insert</param>
        /// <param name="cmp">Comparison function</param>
        /// <returns>Index at which item was inserted</returns>
        /// <remarks>List MUST be sorted in order for this to be accurate</remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="items"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="cmp"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="items"/> is read-only
        /// </exception>
        public static int BinInsert<T>(IList<T> items, T item, Comparison<T> cmp)
        {
            return MM_BinInsert(items, item, cmp);
        }

        #endregion
        
        #region Split

        private static IEnumerable<T[]> MM_Split<T>(
            IEnumerable<T> collection, Predicate<T> criteria,
            bool noEmpty,
            [CallArgExp(nameof(collection))] string? collectionParam = null,
            [CallArgExp(nameof(criteria))] string? criteriaParam = null)
        {
            ArgumentNullException.ThrowIfNull(collection, collectionParam);
            ArgumentNullException.ThrowIfNull(criteria, criteriaParam);
            List<T> current = [];
            bool include() => (!noEmpty) || current.Count > 0;
            foreach (var item in collection)
            {
                if (criteria(item))
                {
                    if (include())
                        yield return current.ToArray();
                    current.Clear();
                }
                else
                {
                    current.Add(item);
                }
            }
            if (include())
                yield return current.ToArray();
        }

        /// <summary>Splits the collection into smaller collections</summary>
        /// <param name="collection">Collection to split up</param>
        /// <param name="criteria">Criteria for considering items as "delimiters"</param>
        /// <param name="noEmpty">If true, empty collections will not be included</param>
        /// <returns>Resulting smaller collections</returns>
        /// <remarks>The original collection will not be affected in any way</remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="criteria"/> is null
        /// </exception>
        public static IEnumerable<T[]> Split<T>(
            IEnumerable<T> collection, Predicate<T> criteria,
            bool noEmpty = false)
        {
            return MM_Split(collection, criteria, noEmpty);
        }

        /// <summary>Splits the collection into smaller collections</summary>
        /// <param name="collection">Collection to split up</param>
        /// <param name="delimiter">"Delimiter" to use when splitting up the collection</param>
        /// <param name="noEmpty">If true, empty collections will not be included</param>
        /// <returns>Resulting smaller collections</returns>
        /// <remarks>The original collection will not be affected in any way</remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="collection"/> is null
        /// </exception>
        public static IEnumerable<T[]> Split<T>(
            IEnumerable<T> collection, T delimiter,
            bool noEmpty = false)
        {
            bool equals(T other)
            {
                if (delimiter is null) return other is null;
                return delimiter.Equals(other);
            }
            return MM_Split(collection, equals, noEmpty);
        }

        #endregion
    }
}