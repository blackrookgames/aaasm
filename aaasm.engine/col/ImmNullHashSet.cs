using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace aaasm.engine.col
{
    /// <summary>
    ///     Represents an immutable hash set that is guaranteed to contain zero null elements
    /// </summary>
    public readonly struct ImmNullHashSet<T> : IReadOnlySet<T>
    {
        #region init

        /// <summary>Initializer for <see cref="ImmNullHashSet{T}"/></summary>
        /// <param name="elements">Source elements</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elements"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="elements"/> contains ont or more null items
        ///     <br/>or<br/>
        ///     <paramref name="elements"/> contains two or more keys of equal value
        /// </exception>
        public ImmNullHashSet(IReadOnlyCollection<T> elements)
        {
            try
            {
                f_Elements = new(elements.Count); 
                MM_Fill(f_Elements, elements);
                f_Count = f_Elements.Count;
            }
            catch when (elements is null)
            { throw new ArgumentNullException(nameof(elements)); }
        }

        /// <summary>Initializer for <see cref="ImmNullHashSet{T}"/></summary>
        /// <param name="elements">Source elements</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elements"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="elements"/> contains ont or more null items
        ///     <br/>or<br/>
        ///     <paramref name="elements"/> contains two or more items of equal value
        /// </exception>
        public ImmNullHashSet(IEnumerable<T> elements)
        {
            f_Elements = []; 
            MM_Fill(f_Elements, elements);
            f_Count = f_Elements.Count;
        }

        #endregion

        #region const

        private static readonly HashSet<T> EMPTY_SET = [];

        /// <summary>Empty hash set</summary>
        public static readonly ImmNullHashSet<T> EMPTY = new();

        #endregion

        #region fields

        private readonly HashSet<T> f_Elements;
        private readonly int f_Count;

        #endregion

        #region helper methods

        private static void MM_Fill(HashSet<T> set, IEnumerable<T> arg,
            [CallerArgumentExpression(nameof(arg))] string? param = null)
        {
            try
            {
                foreach (var element in arg)
                {
                    if (element is null) throw new ArgumentException(
                        "Source collection contains one or more null elements.",
                        param);
                    if (!set.Add(element)) throw new ArgumentException(
                        "Source collection contains two or more elements of equal value.",
                        param);
                }
            }
            catch when (arg is null)
            { throw new ArgumentNullException(param); }
        }

        private IEnumerator<T> MM_GetEnumerator()
        {
            if (f_Count == 0) yield break;
            foreach (var element in f_Elements)
                yield return element;
        }

        #endregion

        #region IReadOnlySet

        /// <summary>Number of elements in hash set</summary>
        public int Count => f_Count;

        /// <summary>Gets an enumerator thru the hash set</summary>
        /// <returns>Enumerator thru the hash set</returns>
        public IEnumerator<T> GetEnumerator() => MM_GetEnumerator();

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            if (f_Count == 0) return false;
            return f_Elements.Contains(item);
        }

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            try
            {
                if (f_Count == 0)
                    EMPTY_SET.IsProperSubsetOf(other);
                return f_Elements.IsProperSubsetOf(other);
            }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            try
            {
                if (f_Count == 0)
                    EMPTY_SET.IsProperSupersetOf(other);
                return f_Elements.IsProperSupersetOf(other);
            }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            try
            {
                if (f_Count == 0)
                    EMPTY_SET.IsSubsetOf(other);
                return f_Elements.IsSubsetOf(other);
            }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            try
            {
                if (f_Count == 0)
                    EMPTY_SET.IsSupersetOf(other);
                return f_Elements.IsSupersetOf(other);
            }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            try
            {
                if (f_Count == 0)
                    EMPTY_SET.Overlaps(other);
                return f_Elements.Overlaps(other);
            }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            try
            {
                if (f_Count == 0)
                    EMPTY_SET.SetEquals(other);
                return f_Elements.SetEquals(other);
            }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        IEnumerator IEnumerable.GetEnumerator() => MM_GetEnumerator();

        #endregion
    }
}
