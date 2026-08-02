using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a numeric or string literal</summary>
    public class ELiteralNode : ENode
    {
        #region init

        private ELiteralNode(ExprRules rules, LexToken source, ENodeValueType literal) : 
            base(rules, source, literal, ImmNullArray<ENode>.EMPTY)
        { }

        /// <summary>Parses out all numeric and string literals</summary>
        /// <param name="analyzer">Analyzer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="analyzer"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid numeric/string data found
        /// </exception>
        internal static void ParseOut(ExprAnalyzer analyzer)
        {
            try
            {
                var retPos = analyzer.Position;
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EAnalNode analNode)
                        continue;
                    if (analNode.Source.Brackets is not null)
                        continue;
                    if (!analyzer.Rules.Expr.Literals.Run(analNode.Source.Rough, out var value))
                        continue;
                    analyzer.Replace(1, new ELiteralNode(analyzer.Rules.Expr, analNode.Source, new(value)));
                }
                analyzer.Position = retPos;
            }
            catch when (analyzer is null)
            {
                throw new ArgumentNullException(nameof(analyzer));
            }
        }

        #endregion

        #region properties

        /// <summary>Value</summary>
        public EValue Value => Return.Literal!;

        #endregion

        #region ENode

        /// <inheritdoc/>
        public override EValue Compute(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            return Return.Literal!;
        }

        #endregion
    }
}
