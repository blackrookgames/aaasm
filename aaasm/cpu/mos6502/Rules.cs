using System.Collections.Generic;
using System.Linq;
using aaasm.engine.lxpr;

namespace aaasm.cpu.mos6502
{
    /// <summary>Rules for handling MOS 6502 assembly code</summary>
    public static partial class Rules
    {
        static Rules()
        {
            LexRulesInit lex = new();
            lex.RoughPatterns = new([
                new LexRoughStrPattern((CIStr)"@", newlineOnly: true, dontSplit: true),
                new LexRoughStrPattern((CIStr)"!", newlineOnly: true, dontSplit: true),
                new LexRoughStrPattern((CIStr)">>>"),
                new LexRoughStrPattern((CIStr)"<<"),
                new LexRoughStrPattern((CIStr)">>"),
                new LexRoughStrPattern((CIStr)"!="),
                new LexRoughStrPattern((CIStr)"=="),
                new LexRoughStrPattern((CIStr)"<="),
                new LexRoughStrPattern((CIStr)">="),
                new LexRoughStrPattern((CIStr)"&&"),
                new LexRoughStrPattern((CIStr)"||"),
                new LexRoughStrPattern((CIStr)"("),
                new LexRoughStrPattern((CIStr)")"),
                new LexRoughStrPattern((CIStr)"["),
                new LexRoughStrPattern((CIStr)"]"),
                new LexRoughStrPattern((CIStr)"#"),
                new LexRoughStrPattern((CIStr)","),
                new LexRoughStrPattern((CIStr)"+"),
                new LexRoughStrPattern((CIStr)"-"),
                new LexRoughStrPattern((CIStr)"*"),
                new LexRoughStrPattern((CIStr)"/"),
                new LexRoughStrPattern((CIStr)"&"),
                new LexRoughStrPattern((CIStr)"|"),
                new LexRoughStrPattern((CIStr)"^"),
                new LexRoughStrPattern((CIStr)"~"),
                new LexRoughStrPattern((CIStr)"<"),
                new LexRoughStrPattern((CIStr)">"),
                new LexRoughStrPattern((CIStr)"!")]);
            lex.Expression.Literals.DefaultDecimal = ExprIntType.U8;
            lex.Expression.Literals.CharType = ExprIntType.U8;
            lex.Expression.Literals.Hex = new([
                ExprNumNotation.C_HEX,
                ExprNumNotation.MOTOROLA_HEX]);
            lex.Expression.Literals.Bin = new([
                ExprNumNotation.C_BIN,
                ExprNumNotation.MOTOROLA_BIN]);
            LEX = new(lex);
        }

        /// <summary>Lexical-analysis rules for MOS 6502 assembly</summary>
        public static LexRules LEX { get; }
    }
}