using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    internal class ExprAnalyzerRules
    {
        #region init

        /// <summary>Initializer for <see cref="ExprAnalyzerRules"/></summary>
        /// <param name="expr">Expression rules</param>
        /// <param name="literal">Literal parser</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="expr"/> is null
        /// </exception>
        public ExprAnalyzerRules(ExprRules expr)
        {
            f_Expr = ArgUtil.NotNull(expr);
            MM_ExtractMathOps(f_Expr.Math, out f_ValidOps, out f_UnaryOps, out f_BinaryOps);
            f_BoolConv = f_Expr.Boolean.Type().BoolConv();
        }

        #endregion

        #region fields

        private readonly ExprRules f_Expr;
        private readonly ImmNullHashSet<Str> f_ValidOps;
        private readonly ImmNullDict<Str, EMathOperatorInfo> f_UnaryOps;
        private readonly ImmNullDict<Str, EMathOperatorInfo> f_BinaryOps;
        private readonly ETypeBoolConv f_BoolConv;

        #endregion

        #region properties

        /// <summary>Expression rules</summary>
        public ExprRules Expr => f_Expr;

        /// <summary>Valid mathematical operators</summary>
        public ImmNullHashSet<Str> ValidOps => f_ValidOps;

        /// <summary>Unary mathematical operators</summary>
        public ImmNullDict<Str, EMathOperatorInfo> UnaryOps => f_UnaryOps;

        /// <summary>Binary mathematical operators</summary>
        public ImmNullDict<Str, EMathOperatorInfo> BinaryOps => f_BinaryOps;
        
        /// <summary>Boolean converter</summary>
        public ETypeBoolConv BoolConv => f_BoolConv;

        #endregion

        #region helper methods

        private static void MM_ExtractMathOps(ExprMathRules mathRules, 
            out ImmNullHashSet<Str> validOps,
            out ImmNullDict<Str, EMathOperatorInfo> unaryOps, 
            out ImmNullDict<Str, EMathOperatorInfo> binaryOps)
        {
            List<Str> _validOps = new(mathRules.Operators.Count);
            List<KeyValuePair<Str, EMathOperatorInfo>> _unaryOps = new(mathRules.Operators.Count);
            List<KeyValuePair<Str, EMathOperatorInfo>> _binaryOps = new(mathRules.Operators.Count);
            foreach (var inputOp in mathRules.Operators)
            {
                var info = inputOp.Key.About();
                foreach (var value in inputOp.Value)
                {
                    _validOps.Add(value);
                    (info.IsUnary ? _unaryOps : _binaryOps).Add(new(value, info));
                }
            }
            validOps = new(_validOps.DistinctBy(value => value));
            unaryOps = new(_unaryOps.DistinctBy(kvp => kvp.Key));
            binaryOps = new(_binaryOps.DistinctBy(kvp => kvp.Key));
        }

        #endregion
    }
}
