using System;
using System.Collections;
using System.Collections.Generic;

namespace aaasm.engine.col
{
    /// <summary>Represents read-only access to a hash set</summary>
    public class ROHashSet<T> : IReadOnlySet<T>
    {
        #region init

        /// <summary>Initializer for <see cref="ROHashSet{T}"/></summary>
        /// <param name="hashSet">Hash set to encapsulate</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="hashSet"/> is null
        /// </exception>
        public ROHashSet(IReadOnlySet<T> hashSet)
        {
            ArgumentNullException.ThrowIfNull(hashSet);
            f_HashSet = hashSet;
        }

        #endregion

        #region const

        /// <summary>Empty hash set</summary>
        public static ROHashSet<T> EMPTY { get; } = new(new HashSet<T>());

        #endregion

        #region fields

        private readonly IReadOnlySet<T> f_HashSet;

        #endregion

        #region IReadOnlySet

        /// <summary>Number of elements in hash set</summary>
        public int Count => f_HashSet.Count;

        /// <summary>Gets an enumerator thru the hash set</summary>
        /// <returns>Enumerator thru the hash set</returns>
        public IEnumerator<T> GetEnumerator() => 
            f_HashSet.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            f_HashSet.GetEnumerator();

        /// <inheritdoc/>
        public bool Contains(T item) => f_HashSet.Contains(item);

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            try { return f_HashSet.IsProperSubsetOf(other); }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            try { return f_HashSet.IsProperSupersetOf(other); }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            try { return f_HashSet.IsSubsetOf(other); }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            try { return f_HashSet.IsSupersetOf(other); }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            try { return f_HashSet.Overlaps(other); }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            try { return f_HashSet.SetEquals(other); }
            catch when (other is null)
            { throw new ArgumentNullException(nameof(other)); }
        }

        #endregion
    }
}
