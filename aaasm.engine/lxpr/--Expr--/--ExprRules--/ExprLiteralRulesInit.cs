// This was auto-generated from ExprLiteralRulesInit.cs.py
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents initialization parameters for <see cref="ExprLiteralRules"/></summary>
    public class ExprLiteralRulesInit
    {
        /// <inheritdoc cref="ExprLiteralRules.Bin"/>
        public ImmNullArray<ExprNumNotation> Bin { get; set; } = new([ExprNumNotation.C_BIN]);

        /// <inheritdoc cref="ExprLiteralRules.Hex"/>
        public ImmNullArray<ExprNumNotation> Hex { get; set; } = new([ExprNumNotation.C_HEX]);

        /// <inheritdoc cref="ExprLiteralRules.DefaultDecimal"/>
        public ExprIntType DefaultDecimal { get; set; } = ExprIntType.I32;

        /// <inheritdoc cref="ExprLiteralRules.CharType"/>
        public ExprIntType CharType { get; set; } = ExprIntType.U8;

        /// <inheritdoc cref="ExprLiteralRules.ParseSingleQuote"/>
        public ExprQuoteType ParseSingleQuote { get; set; } = ExprQuoteType.CHARACTER;

        /// <inheritdoc cref="ExprLiteralRules.ParseDoubleQuote"/>
        public ExprQuoteType ParseDoubleQuote { get; set; } = ExprQuoteType.STRING;

        /// <inheritdoc cref="ExprLiteralRules.ArrayBrackets"/>
        public BracketPair<Str>? ArrayBrackets { get; set; } = BracketPair.SQUARE;

        /// <inheritdoc cref="ExprLiteralRules.ElementSep"/>
        public Str? ElementSep { get; set; } = (CIStr)",";
    }
}
