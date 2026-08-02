// This was auto-generated from ExprRulesInit.cs.py
using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents initialization parameters for <see cref="ExprRules"/></summary>
    public class ExprRulesInit
    {
        /// <inheritdoc cref="ExprRules.Literals"/>
        public ExprLiteralRulesInit Literals { get; } = new();

        /// <inheritdoc cref="ExprRules.Math"/>
        public ExprMathRulesInit Math { get; } = new();

        /// <inheritdoc cref="ExprRules.FuncBrackets"/>
        public BracketPair<Str>? FuncBrackets { get; set; } = BracketPair.ROUND;

        /// <inheritdoc cref="ExprRules.FuncArgSep"/>
        public Str? FuncArgSep { get; set; } = (CIStr)",";

        /// <inheritdoc cref="ExprRules.FuncIds"/>
        public ImmNullDict<Str,EFunFunctionId> FuncIds { get; set; } = ExprRules.COMMON_FUNCIDS;

        /// <inheritdoc cref="ExprRules.Boolean"/>
        public ExprIntType Boolean { get; set; } = ExprIntType.U8;

        /// <inheritdoc cref="ExprRules.Label"/>
        public ExprIntType Label { get; set; } = ExprIntType.U32;

        /// <inheritdoc cref="ExprRules.LabelBranchSymbol"/>
        public Str? LabelBranchSymbol { get; set; } = (CIStr)".";
    }
}
