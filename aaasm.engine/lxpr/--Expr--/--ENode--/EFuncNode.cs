using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a function call</summary>
    public class EFuncNode : ENode
    {
        #region init

        private EFuncNode(ExprRules rules, LexToken source, 
            EFunOverload overload,
            EType @return,
            IReadOnlyList<ENode> children) :
            base(rules, source, new(@return), new(children))
        {
            f_Overload = overload;
        }

        /// <summary>Parses out all function calls</summary>
        /// <param name="analyzer">Analyzer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="analyzer"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid function data found
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

        #region fields

        private readonly EFunOverload f_Overload;

        #endregion

        #region properties

        /// <summary>Function overload</summary>
        public EFunOverload Overload => f_Overload;

        #endregion

        #region helper methods

        private static bool MM_TryParse(ExprAnalyzer analyzer)
        {
            BadSrcException noParentheses(EAnalNode analNode)
            {
                return new(
                    $"Expected {analyzer.Rules.Expr.FuncBrackets!.Open} after function identifier.",
                    analNode.Source.RefPnt);
            }
            try
            {
                // Is the current token a valid function ID?
                if (analyzer.Current is not EAnalNode idNode)
                    return false;
                if (idNode.Source.Brackets is not null)
                    return false;
                if (!analyzer.Rules.Expr.FuncIds.TryGetValue(
                    idNode.Source.Rough.RawData.Raw, 
                    out var functionId))
                    return false;
                var function = EFun.FUNCTIONS.Get(functionId);
                // Are functions supported?
                if (analyzer.Rules.Expr.FuncBrackets is null)
                {
                    throw new BadSrcException(
                        $"Functions are not supported.", 
                        idNode.Source.RefPnt);
                }
                // Is the syntax valid?
                if ((analyzer.Position + 1) == analyzer.Count)
                    throw noParentheses(idNode);
                if (analyzer[analyzer.Position + 1] is not EAnalNode argsNode)
                    throw noParentheses(idNode);
                if (argsNode.Source.Brackets != analyzer.Rules.Expr.FuncBrackets)
                    throw noParentheses(idNode);
                // Analyze arguments
                var rawArgs = ColUtil.Split(
                    argsNode.Source.Children, 
                    token => analyzer.Rules.Expr.FuncArgSep == token.Rough.RawData.Raw,
                    true);
                ENode[] args = [..
                    from rawArg in rawArgs
                    let analyzed = Analyze(rawArg, analyzer.Rules,
                        failRefPnt: idNode.Source.RefPnt)
                    select analyzed];
                ENodeValueType[] argTypes = [..
                    from arg in args
                    select arg.Return];
                // Is there a matching overload?
                if (!function.TryGet(argTypes, out var overload))
                {
                    using StringWriter w = new();
                    w.Write($"No overload for {idNode.Source.Rough.RawData.Raw} matches (");
                    for (int i = 0; i < argTypes.Length; ++i)
                    {
                        if (i > 0) w.Write(", ");
                        if (argTypes[i].Literal is not null)
                            w.Write("literal ");
                        else
                            w.Write("non-literal ");
                        w.Write(argTypes[i].Type.GetName());
                    }
                    w.Write(").");
                    throw new BadSrcException(w.ToString(), idNode.Source.RefPnt);
                }
                // Get return type
                EType @return;
                try
                { @return = overload.GetReturn(analyzer.Rules.Expr, argTypes); }
                catch (EValueException e)
                { throw new BadSrcException(e.Message, idNode.Source.RefPnt); }
                // Create and replace
                analyzer.Replace(2, new EFuncNode(analyzer.Rules.Expr, idNode.Source, overload, @return, args));
                // Success!!!
                return true;
            }
            catch when (analyzer is null)
            {
                throw new ArgumentNullException(nameof(analyzer));
            }
        }

        private EValue[] MM_ComputeArgs(ExprContext context)
        {
            EValue[] args = new EValue[Children.Length];
            for (int i = 0; i < Children.Length; ++i)
                args[i] = Children[i].Compute(context);
            return args;
        }

        #endregion

        #region IExpr

        /// <inheritdoc/>
        public override EValue Compute(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                return f_Overload.Invoke(context, MM_ComputeArgs(context));
            }
            catch (Exception e) when (TryUtil.TryFind<BadSrcException>(e, out var ee))
            {
                throw ee;
            }
            catch (Exception e) when (TryUtil.TryFind<EValueException>(e, out var ee))
            {
                throw new BadSrcException(ee.Message, Source.RefPnt);
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                return f_Overload.Debug(context, MM_ComputeArgs(context));
            }
            catch (Exception e) when (TryUtil.TryFind<BadSrcException>(e, out var ee))
            {
                throw ee;
            }
            catch (Exception e) when (TryUtil.TryFind<EValueException>(e, out var ee))
            {
                throw new BadSrcException(ee.Message, Source.RefPnt);
            }
        }

        #endregion
    }
}
