using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents expression data wrapped in parentheses</summary>
    public class EParenthesesNode : ENode
    {
        #region init

        private EParenthesesNode(ExprRules rules, LexToken source, ENode wrapped) : 
            base(rules, source, wrapped.Return, new([wrapped]))
        {
            f_Wrapped = wrapped;
        }

        /// <summary>Parses out all parentheses</summary>
        /// <param name="analyzer">Analyzer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="analyzer"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid data found
        /// </exception>
        internal static void ParseOut(ExprAnalyzer analyzer)
        {
            try
            {
                var retPos = analyzer.Position;
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    // Is this wrapped in parentheses?
                    if (analyzer.Current is not EAnalNode analNode)
                        continue;
                    if (analNode.Source.Brackets != analyzer.Rules.Expr.Math.GroupBrackets)
                        continue;
                    // Analyze wrapped tokens
                    ENode wrapped = Analyze(analNode.Source.Children, analyzer.Rules, 
                        failRefPnt: analNode.Source.RefPnt);
                    // Create and replace
                    analyzer.Replace(1, new EParenthesesNode(analyzer.Rules.Expr, analNode.Source, wrapped));
                }
                analyzer.Position = retPos;
            }
            catch when (analyzer is null)
            {
                throw new ArgumentNullException(nameof(analyzer));
            }
        }

        #endregion

        #region fields

        private readonly ENode f_Wrapped;

        #endregion

        #region properties

        /// <summary>Node wrapped by parentheses</summary>
        public ENode Wrapped => f_Wrapped;

        #endregion

        #region IExpr

        /// <inheritdoc/>
        public override EValue Compute(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            return f_Wrapped.Compute(context);
        }

        #endregion
    }
}
