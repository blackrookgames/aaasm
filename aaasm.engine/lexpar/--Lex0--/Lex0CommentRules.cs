using System;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents comment rules for Stage-0 lexical analysis</summary>
    public class Lex0CommentRules
    {
        #region const

        /// <summary>Assembly-style commenting</summary>
        public static Lex0CommentRules ASSEMBLY { get; } = new();

        /// <summary>C-style commenting</summary>
        public static Lex0CommentRules C { get; } = new Rules_CStyle();

        #endregion
        
        #region properties

        /// <summary>Marker for single-line comments</summary>
        public virtual string? Single => ";";

        /// <summary>Opening and closing delimiters for multiline comments</summary>
        public virtual BracketPair<string>? Multi => null;

        #endregion
    }

    file class Rules_CStyle : Lex0CommentRules
    {
        #region const

        private static readonly BracketPair<string> MULTI = new("/*", "*/");

        #endregion

        #region properties

        public override string? Single => "//";

        public override BracketPair<string>? Multi => MULTI;

        #endregion
    }
}
