using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    internal class ExprAnalyzer : IReadOnlyList<ENode>
    {
        #region init

        /// <summary>Initializer for <see cref="ExprAnalyzer"/></summary>
        /// <param name="src">Source tokens</param>
        /// <param name="rules">Analyzer rules</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="src"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="rules"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     One or more tokens in <paramref name="src"/> are null
        /// </exception>
        public ExprAnalyzer(IEnumerable<LexToken> src, ExprAnalyzerRules rules)
        {
            f_Nodes = [.. 
                from token in ArgUtil.NoNullItems(src)
                select new EAnalNode(rules.Expr, token)];
            f_Rules = ArgUtil.NotNull(rules);
            f_Position = 0;
            MM_UpdateCurrent();
        }

        #endregion

        #region fields

        private readonly List<ENode> f_Nodes;
        private readonly ExprAnalyzerRules f_Rules;
        private int f_Position;
        [MaybeNull] private ENode f_Current;

        #endregion

        #region properties

        /// <summary>Analyzer rules</summary>
        public ExprAnalyzerRules Rules => f_Rules;

        /// <summary>Current position</summary>
        public int Position
        {
            get => f_Position;
            set
            {
                if (f_Position == value) return;
                f_Position = value;
                MM_UpdateCurrent();
            }
        }

        /// <summary>Current node</summary>
        [MaybeNull] public ENode Current => f_Current;

        #endregion

        #region helper methods

        private bool MM_UpdateCurrent()
        {
            if (f_Position >= 0 && f_Position < f_Nodes.Count)
            {
                f_Current = f_Nodes[f_Position];
                return true;
            }
            f_Current = null!;
            return false;
        }

        #endregion

        #region methods

        /// <summary>Moves to the next position</summary>
        /// <returns>Whether or not the new position is valid</returns>
        public bool Next()
        {
            ++f_Position;
            return MM_UpdateCurrent();
        }

        /// <summary>Moves to the previous position</summary>
        /// <returns>Whether or not the new position is valid</returns>
        public bool Prev()
        {
            --f_Position;
            return MM_UpdateCurrent();
        }

        /// <summary>Replaces a number of nodes (starting at current position) with a single node</summary>
        /// <param name="count">Number of nodes to replace</param>
        /// <param name="replacement">Replacement node</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="replacement"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count"/> is out of range
        /// </exception>
        public void Replace(int count, ENode replacement)
        {
            ArgumentNullException.ThrowIfNull(replacement);
            ArgUtil.ThrowIfOOR(count, 0, f_Nodes.Count - f_Position);
            // Replace nodes
            if (count > 0)
            {
                // Remove nodes after current node
                f_Nodes.RemoveRange(f_Position + 1, count - 1);
                // Replace current node
                f_Nodes[f_Position] = replacement;
            }
            else
            {
                // Insert new node
                f_Nodes.Insert(f_Position, replacement);
            }
            // Update current node
            f_Current = replacement;
        }

        #endregion

        #region IReadOnlyList

        /// <summary>Number of nodes</summary>
        public int Count => f_Nodes.Count;

        /// <summary>Gets the node at the specified index</summary>
        /// <param name="index">Index of node</param>
        /// <returns>Node at the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public ENode this[int index]
        {
            get
            {
                try
                { return f_Nodes[index]; }
                catch when (index < 0 || index >= f_Nodes.Count)
                { throw new ArgumentOutOfRangeException(nameof(index)); }
            }
        }

        /// <summary>Gets an enumerator thru the nodes</summary>
        /// <returns>Enumerator thru the nodes</returns>
        public IEnumerator<ENode> GetEnumerator() => f_Nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => f_Nodes.GetEnumerator();

        #endregion
    }
}
