// This was auto-generated from LexRulesInit.cs.py
using System;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents initialization parameters for <see cref="LexRules"/></summary>
    public class LexRulesInit
    {
        /// <inheritdoc cref="LexRules.Comments"/>
        public ImmNullArray<LexCommentRules> Comments { get; set; } = new([LexCommentRules.ASSEMBLY, LexCommentRules.C]);

        /// <inheritdoc cref="LexRules.LineContinue"/>
        public Str? LineContinue { get; set; } = (CIStr)"\\";

        /// <inheritdoc cref="LexRules.RoughSymbols"/>
        public ImmNullArray<Str> RoughSymbols { get; set; } = new();

        /// <inheritdoc cref="LexRules.PrePrefix"/>
        public Str? PrePrefix { get; set; } = (CIStr)"@";

        /// <inheritdoc cref="LexRules.PreNames"/>
        public ImmNullDict<Str,PreCmd> PreNames { get; set; } = LexRules.COMMON_PRENAMES;

        /// <inheritdoc cref="LexRules.PreCmdArgSep"/>
        public Str? PreCmdArgSep { get; set; } = (CIStr)",";

        /// <inheritdoc cref="LexRules.BracketPairs"/>
        public ImmNullArray<BracketPair<Str>> BracketPairs { get; set; } = new([ BracketPair.CURLY, BracketPair.SQUARE, BracketPair.ROUND, ]);

        /// <inheritdoc cref="LexRules.MacroBrackets"/>
        public BracketPair<Str>? MacroBrackets { get; set; } = BracketPair.ROUND;

        /// <inheritdoc cref="LexRules.MacroParamSep"/>
        public Str? MacroParamSep { get; set; } = (CIStr)",";

        /// <inheritdoc cref="LexRules.Expression"/>
        public ExprRulesInit Expression { get; } = new();
    }
}
