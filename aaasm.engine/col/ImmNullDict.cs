using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace aaasm.engine.col
{
    /// <summary>
    ///     Represents an immutable dictionary that is guaranteed to contain zero null keys or values
    /// </summary>
    public readonly struct ImmNullDict<TKey, TValue> : 
        IReadOnlyDictionary<TKey, TValue> 
        where TKey : notnull
    {
        #region init

        /// <summary>Initializer for <see cref="ImmNullDict{TKey, TValue}"/></summary>
        /// <param name="elements">Source elements</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elements"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="elements"/> contains one or more null keys
        ///     <br/>or<br/>
        ///     <paramref name="elements"/> contains one or more null values
        ///     <br/>or<br/>
        ///     <paramref name="elements"/> contains two or more keys of equal value
        /// </exception>
        public ImmNullDict(IReadOnlyCollection<KeyValuePair<TKey, TValue>> elements)
        {
            try
            {
                f_Count = elements.Count;
                f_Elements = new (f_Count);
                MM_FillDict(f_Elements, elements);
            }
            catch when (elements is null)
            { throw new ArgumentNullException(nameof(elements)); }
        }

        /// <inheritdoc cref="ImmNullDict(IReadOnlyCollection{KeyValuePair{TKey, TValue}})"/>
        public ImmNullDict(IEnumerable<KeyValuePair<TKey, TValue>> elements)
        {
            try
            {
                f_Elements = [];
                MM_FillDict(f_Elements, elements);
                f_Count = f_Elements.Count;
            }
            catch when (elements is null)
            { throw new ArgumentNullException(nameof(elements)); }
        }

        #endregion

        #region const

        /// <summary>Empty dictionary</summary>
        public static ImmNullDict<TKey, TValue> EMPTY { get; } = new();

        #endregion

        #region fields

        private readonly int f_Count;
        private readonly Dictionary<TKey, TValue> f_Elements;

        #endregion

        #region helper methods

        private static void MM_FillDict(
            Dictionary<TKey, TValue> dict,
            IEnumerable<KeyValuePair<TKey, TValue>> arg,
            [CallerArgumentExpression(nameof(arg))] string? param = null)
        {
            try
            {
                foreach (var item in arg)
                {
                    if (item.Key is null) throw new ArgumentException(
                        "Source collection contains one or more null keys.",
                        param);
                    if (item.Value is null) throw new ArgumentException(
                        "Source collection contains one or more null values.",
                        param);
                    if (!dict.TryAdd(item.Key, item.Value)) throw new ArgumentException(
                        "Source collection contains two or more keys of equal value.",
                        param);
                }
            }
            catch when (arg is null)
            { throw new ArgumentNullException(param); }
        }

        private IEnumerator<KeyValuePair<TKey, TValue>> MM_GetEnumerator()
        {
            if (f_Count == 0) yield break;
            foreach (var element in f_Elements)
                yield return element;
        }

        #endregion

        #region IReadOnlyDictionary

        /// <summary>Number of elements in dictionary</summary>
        public int Count => f_Count;

        /// <summary>Dictionary keys</summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                if (f_Count == 0)
                    yield break;
                foreach (var key in f_Elements.Keys)
                    yield return key;
            }
        }

        /// <summary>Dictionary values</summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                if (f_Count == 0)
                    yield break;
                foreach (var values in f_Elements.Values)
                    yield return values;
            }
        }

        /// <summary>Retrieves the element with the specified key</summary>
        /// <param name="key">Key</param>
        /// <returns>Value of the element with the specified key</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="key"/> is null
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        ///     <paramref name="key"/> does not exist in dictionary
        /// </exception>
        public TValue this[TKey key]
        {
            get
            {
                try
                {
                    if (TryGetValue(key, out var value)) return value;
                    throw new KeyNotFoundException("Could not find the specified key.");
                }
                catch when (key is null)
                { throw new ArgumentNullException(nameof(key)); }
            }
        }

        /// <summary>Gets an enumerator thru the dictionary</summary>
        /// <returns>Enumerator thru the dictionary</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => MM_GetEnumerator();

        /// <summary>Checks if there's an element with the specified key</summary>
        /// <param name="key">Key</param>
        /// <returns>Whether or not there's an element with the specified key</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="key"/> is null
        /// </exception>
        public bool ContainsKey(TKey key)
        {
            ArgumentNullException.ThrowIfNull(key);
            if (f_Count == 0) return false;
            return f_Elements.ContainsKey(key);
        }

        /// <summary>Attempts to retrieve the element with the specified key</summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value of the retrieved element</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="key"/> is null
        /// </exception>
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            ArgumentNullException.ThrowIfNull(key);
            if (f_Count > 0)
                return f_Elements.TryGetValue(key, out value);
            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => MM_GetEnumerator();

        #endregion
    }
}
