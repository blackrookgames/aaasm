using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an array or tuple construction</summary>
    public class EArTuNode : ENode
    {
        #region init

        private EArTuNode(ExprRules rules, LexToken source, EType @return, IReadOnlyList<ENode> children) : 
            base(rules, source, new(@return), new(children))
        { }

        /// <summary>Parses out all array and tuple constructions</summary>
        /// <param name="analyzer">Analyzer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="analyzer"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid array/tuple data found
        /// </exception>
        internal static void ParseOut(ExprAnalyzer analyzer)
        {
            try
            {
                var retPos = analyzer.Position;
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                    MM_TryParse(analyzer);
                analyzer.Position = retPos;
            }
            catch when (analyzer is null)
            {
                throw new ArgumentNullException(nameof(analyzer));
            }
        }

        #endregion

        #region helper methods

        private static bool MM_TryParse(ExprAnalyzer analyzer)
        {
            try
            {
                if (analyzer.Current is not EAnalNode analNode)
                    return false;
                if (analNode.Source.Brackets != analyzer.Rules.Expr.Literals.ArrayBrackets)
                    return false;
                // Analyze elements
                var rawElements = ColUtil.Split(
                    analNode.Source.Children, 
                    token => analyzer.Rules.Expr.Literals.ElementSep == token.Rough.RawData.Raw,
                    true);
                ENode[] elements = [..
                    from rawElement in rawElements
                    let analyzed = Analyze(rawElement, analyzer.Rules,
                        failRefPnt: analNode.Source.RefPnt)
                    select analyzed];
                EType[] elementTypes = [..
                    from element in elements
                    select element.Return.Type];
                // Get array element type
                EType? elementType = (elementTypes.Length == 0) ? null : elementTypes[0];
                if (elementType is not null)
                {
                    for (int i = 1; i < elements.Length; ++i)
                    {
                        if (elementTypes[i] == elementType)
                            continue;
                        elementType = null;
                        break;
                    }
                }
                // Create return type
                EType returnType = (elementType is not null) ?
                    EType.Array(elementType, elements.Length) :
                    EType.Tuple(new(elementTypes));
                // Create and replace
                analyzer.Replace(1, new EArTuNode(analyzer.Rules.Expr, analNode.Source, returnType, elements));
                // Success!!!
                return true;
            }
            catch when (analyzer is null)
            {
                throw new ArgumentNullException(nameof(analyzer));
            }
        }

        #endregion

        #region IExpr

        /// <inheritdoc/>
        public override EValue Compute(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            var elements = from child in Children select child.Compute(context);
            if (Return.Type.NameId == ETypeNameId.ARRAY)
                return new EArray(Return.Type.ElementType!, elements);
            return new ETuple(elements);
        }

        #endregion
    }
}
