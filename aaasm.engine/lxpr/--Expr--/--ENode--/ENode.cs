using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a node inside an expression tree</summary>
    public abstract class ENode
    {
        #region init

        private protected ENode(
            ExprRules rules,
            LexToken source, 
            ENodeValueType @return, 
            ImmNullArray<ENode> children)
        {
            f_Rules = rules;
            f_Source = source;
            f_Return = @return;
            f_Children = children;
        }

        /// <summary>Analyzes the source tokens</summary>
        /// <param name="src">Source tokens</param>
        /// <param name="rules">Analyzer rules</param>
        /// <param name="failRefPnt">Reference point to use for throwing certain exceptions</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="src"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="rules"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     One or more elements in <paramref name="src"/> are null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid data was found
        /// </exception>
        internal static ENode Analyze(IEnumerable<LexToken> src, ExprAnalyzerRules rules,
            RefPnt? failRefPnt = null)
        {
            static BadSrcException unexpected(ENode node)
            {
                return BadSrcException.Unexpected(
                    node.Source.Rough.RawData,
                    node.Source.Rough.RefPnt);
            }
            try
            {
                ExprAnalyzer analyzer = new(src, rules);
                // 0: Numeric and string literals
                ELiteralNode.ParseOut(analyzer);
                // 1: Array/Tuple constructors
                EArTuNode.ParseOut(analyzer);
                // 2: Function calls
                EFuncNode.ParseOut(analyzer);
                // 3: Parentheses
                EParenthesesNode.ParseOut(analyzer);
                // 4: Mathematical operators
                EMathNode.ParseOut(analyzer);
                // Is everything parsed?
                foreach (var node in analyzer)
                {
                    if (node is not EAnalNode analNode) continue;
                    throw unexpected(analNode);
                }
                if (analyzer.Count != 1)
                {
                    if (analyzer.Count > 1) throw unexpected(analyzer[1]);
                    throw new BadSrcException("Expression cannot be empty", failRefPnt);
                }
                // Success!!!
                return analyzer[0];
            }
            catch
            {
                ArgUtil.ThrowIfNullItems(src);
                ArgumentNullException.ThrowIfNull(rules);
                throw;
            }
        }

        #endregion

        #region fields

        private readonly ExprRules f_Rules;
        private readonly LexToken f_Source;
        private readonly ENodeValueType f_Return;
        private readonly ImmNullArray<ENode> f_Children;

        #endregion
        
        #region abstract properties

        /// <summary>Rules</summary>
        public ExprRules Rules => f_Rules;

        /// <summary>Source token</summary>
        public LexToken Source => f_Source;

        /// <summary>Return type</summary>
        public ENodeValueType Return => f_Return;

        /// <summary>Child nodes</summary>
        public virtual ImmNullArray<ENode> Children => f_Children;

        #endregion

        #region abstract methods

        /// <summary>Computes a value</summary>
        /// <param name="context">Expression context</param>
        /// <returns>Computation result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     An error occurred.
        /// </exception>
        public abstract EValue Compute(ExprContext context);

        /// <summary>Performs a debug computation</summary>
        /// <returns>Computation result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     An error occurred.
        /// </exception>
        public virtual string Debug(ExprContext context)
        {
            try
            { return Compute(context).ToString(context.Rules); }
            catch when (context is null)
            { throw new ArgumentNullException(nameof(context)); }
        }

        #endregion
    }
}
