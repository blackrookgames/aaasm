using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lexpar.mos6502
{
    /// <summary>Rules for MOS 6502 assembly</summary>
    public static class Rules
    {
        #region nested
        
        private class Rules_Lex0 : Lex0Rules
        {
            #region const

            private readonly static ImmutableNullessArray<Lex0CommentRules> COMMENTS = new([ 
                Lex0CommentRules.ASSEMBLY, 
                Lex0CommentRules.C, ]);

            private readonly static ImmutableNullessArray<string> SYMBOLS = new(
                (from c in "()#,+-*/&|^~<>" select new string(c.ToString()))
                .Concat(["<<", ">>"]));

            #endregion

            #region properties

            public override bool ParseSingleQuote => true;

            public override bool ParseDoubleQuote => true;

            public override ImmutableNullessArray<Lex0CommentRules> Comments => COMMENTS;

            public override string? LineContinue => "\\";

            public override ImmutableNullessArray<string> Symbols => SYMBOLS;

            #endregion
        }

        #endregion

        #region const

        /// <summary>Rules for Stage-0 lexical analysis</summary>
        public static Lex0Rules LEX0 { get; } = new Rules_Lex0();

        #endregion
    }
}
