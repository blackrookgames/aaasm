using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using aaasm.engine.col;
using System.Collections;

namespace aaasm.engine.lxpr
{
    internal class LexPersistentMacros
    {
        #region nested

        private class CurrMacros : IMacros
        {
            #region fields

            private readonly Dictionary<string, Macro> f_Elements = [];

            #endregion

            #region properties

            public Dictionary<string, Macro> Elements => f_Elements;

            #endregion

            #region IMacros

            public int Count => f_Elements.Count;

            public IEnumerator<Macro> GetEnumerator() => f_Elements.Values.GetEnumerator();

            public bool TryGet(string? key, [MaybeNullWhen(false)] out Macro macro)
            {
                if (key is null) { macro = default; return false; }
                return f_Elements.TryGetValue(key, out macro);
            }

            IEnumerator IEnumerable.GetEnumerator() => f_Elements.Values.GetEnumerator();

            #endregion
        }

        #endregion

        #region init

        public LexPersistentMacros()
        {
            f_All = [];
            f_Curr = new();
            f__All = new(f_All);
        }

        #endregion

        #region fields

        private readonly List<Macro> f_All;
        private readonly CurrMacros f_Curr;

        private ROList<Macro> f__All;

        #endregion

        #region properties

        public ROList<Macro> All => f__All;

        public IMacros Curr => f_Curr;

        #endregion

        #region methods

        /// <summary>
        ///     Assume
        ///     <list type="bullet">
        ///         <item>
        ///             <see cref="Curr"/> does not contain a macro 
        ///             named <paramref name="macro"/>.Name
        ///         </item>
        ///     </list>
        /// </summary>
        public void Define(Macro macro)
        {
            f_All.Add(macro);
            f_Curr.Elements.Add(macro.Name, macro);
        }

        /// <summary>
        ///     Assume
        ///     <list type="bullet">
        ///         <item>
        ///             <see cref="Curr"/> contains a macro 
        ///             named <paramref name="macroName"/>
        ///         </item>
        ///     </list>
        /// </summary>
        public void Undefine(string macroName)
        {
            f_Curr.Elements.Remove(macroName);
        }

        #endregion
    }
}