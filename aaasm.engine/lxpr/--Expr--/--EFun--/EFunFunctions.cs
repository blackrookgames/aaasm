using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a collection of function definitions</summary>
    public class EFunFunctions : IKeyedCollection<EFunFunctionId, EFunFunction>
    {
        #region init

        internal EFunFunctions(IEnumerable<EFunFunction> elements)
        {
            static KeyValuePair<EFunFunctionId, EFunFunction> toKVP(EFunFunction element) =>
                new(element.Id, element);
            f_Elements = new(elements.Select(toKVP));
        }

        #endregion

        #region fields

        private readonly Dictionary<EFunFunctionId, EFunFunction> f_Elements;

        #endregion

        #region methods

        #endregion

        #region IKeyedCollection

        /// <summary>Number of function definitions in the collection</summary>
        public int Count => f_Elements.Count;

        /// <summary>Gets an enumerator thru the collection</summary>
        /// <returns>Enumerator thru the collection</returns>
        public IEnumerator<EFunFunction> GetEnumerator()
        {
            return f_Elements.Values.GetEnumerator();
        }

        /// <summary>Attempts to retrieve a function definition with the specified identifier</summary>
        /// <param name="id">Function identifier</param>
        /// <param name="func">Retrieved function</param>
        /// <returns>Whether or not successful</returns>
        public bool TryGet(EFunFunctionId id, [MaybeNullWhen(false)] out EFunFunction func)
        {
            return f_Elements.TryGetValue(id, out func);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return f_Elements.Values.GetEnumerator();
        }

        #endregion
    }
}
