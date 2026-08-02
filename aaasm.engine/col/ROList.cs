using System;
using System.Collections;
using System.Collections.Generic;

namespace aaasm.engine.col
{
    /// <summary>Represents read-only access to a list</summary>
    public class ROList<T> : IReadOnlyList<T>
    {
        #region init

        /// <summary>Initializer for <see cref="ROList{T}"/></summary>
        /// <param name="list">List to encapsulate</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="list"/> is null
        /// </exception>
        public ROList(IReadOnlyList<T> list)
        {
            ArgumentNullException.ThrowIfNull(list);
            f_List = list;
        }

        #endregion

        #region const

        /// <summary>Empty list</summary>
        public static ROList<T> EMPTY { get; } = new([]);

        #endregion

        #region fields

        private readonly IReadOnlyList<T> f_List;

        #endregion

        #region IReadOnlyList

        /// <summary>Number of elements in list</summary>
        public int Count => f_List.Count;

        /// <summary>Retrieves the element at the specified index</summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element at the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public T this[int index]
        {
            get
            {
                try
                { return f_List[index]; }
                catch when (index < 0 || index >= f_List.Count)
                { throw new ArgumentOutOfRangeException(nameof(index)); }
            }
        }

        /// <summary>Gets an enumerator thru the list</summary>
        /// <returns>Enumerator thru the list</returns>
        public IEnumerator<T> GetEnumerator() => 
            f_List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            f_List.GetEnumerator();

        #endregion
    }
}