using System;
using System.Collections;
using System.Collections.Generic;

namespace aaasm.engine.col
{
    /// <summary>
    ///     Represents an immutable array that is guaranteed to contain zero null elements
    /// </summary>
    public readonly struct ImmutableNullessArray<T> : IReadOnlyList<T>
    {
        #region init

        /// <summary>Initializer for <see cref="ImmutableNullessArray{T}"/></summary>
        /// <param name="elements">Source elements</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elements"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="elements"/> contains one or more null elements
        /// </exception>
        public ImmutableNullessArray(IReadOnlyList<T> elements)
        {
            try
            {
                f_Length = elements.Count;
                f_Elements = new T[f_Length];
                for (int i = 0; i < f_Length; ++i)
                {
                    var element = elements[i];
                    if (element is null) throw new ArgumentException(
                        "Source collection contains one or more null elements.",
                        nameof(elements));
                    f_Elements[i] = element;
                }
            }
            catch when (elements is null)
            { throw new ArgumentNullException(nameof(elements)); }
        }

        /// <summary>Initializer for <see cref="ImmutableNullessArray{T}"/></summary>
        /// <param name="elements">Source elements</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elements"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="elements"/> contains one or more null elements
        /// </exception>
        public ImmutableNullessArray(IEnumerable<T> elements)
        {
            IEnumerable<T> loop()
            {
                foreach (var element in elements)
                {
                    if (element is null) throw new ArgumentException(
                        "Source collection contains one or more null elements.",
                        nameof(elements));
                    yield return element;
                }
            }
            try
            {
                f_Elements = [..loop()];
                f_Length = f_Elements.Length;
            }
            catch when (elements is null)
            { throw new ArgumentNullException(nameof(elements)); }
        }

        #endregion

        #region const

        /// <summary>Empty array</summary>
        public static ImmutableNullessArray<T> EMPTY { get; } = new();

        #endregion

        #region fields

        private readonly int f_Length;
        private readonly T[] f_Elements;

        #endregion

        #region properties

        /// <summary>Length of array</summary>
        public int Length => f_Length;

        #endregion

        #region helper methods

        private IEnumerator<T> MM_GetEnumerator()
        {
            if (f_Length == 0) yield break;
            foreach (var element in f_Elements)
                yield return element;
        }

        #endregion

        #region IReadOnlyList

        /// <summary>Gets the element at the specified index</summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element at the specified index</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     Index is out of range
        /// </exception>
        public T this[int index]
        {
            get
            {
                try
                { return f_Elements[index]; }
                catch when (index < 0 || index >= f_Length)
                { throw new IndexOutOfRangeException(); }
            }
        }

        /// <summary>Gets an enumerator thru the array</summary>
        /// <returns>Enumerator thru the array</returns>
        public IEnumerator<T> GetEnumerator() => MM_GetEnumerator();

        int IReadOnlyCollection<T>.Count => f_Length;

        IEnumerator IEnumerable.GetEnumerator() => MM_GetEnumerator();

        #endregion
    }
}
