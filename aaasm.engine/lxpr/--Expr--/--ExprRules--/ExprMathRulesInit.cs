// This was auto-generated from ExprMathRulesInit.cs.py
using System;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents initialization parameters for <see cref="ExprMathRules"/></summary>
    public class ExprMathRulesInit
    {
        /// <inheritdoc cref="ExprMathRules.GroupBrackets"/>
        public BracketPair<Str>? GroupBrackets { get; set; } = BracketPair.ROUND;

        /// <inheritdoc cref="ExprMathRules.Operators"/>
        public ImmNullDict<EMathOperator,ImmNullArray<Str>> Operators { get; set; } = ExprMathRules.COMMON_OPERATORS;
    }
}
