using System;
using aaasm.engine.col;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents rules for Stage-0 lexical analysis</summary>
    public class Lex0Rules
    {
        #region const

        private readonly static ImmutableNullessArray<Lex0CommentRules> COMMENTS = new(
        [
            Lex0CommentRules.ASSEMBLY,
            Lex0CommentRules.C,
        ]);

        #endregion

        #region properties

        /// <summary>Whether or not single-quotation marks should be parsed as a quoted block</summary>
        public virtual bool ParseSingleQuote => true;

        /// <summary>Whether or not double-quotation marks should be parsed as a quoted block</summary>
        public virtual bool ParseDoubleQuote => true;

        /// <summary>Rules regarding comments</summary>
        public virtual ImmutableNullessArray<Lex0CommentRules> Comments => COMMENTS;

        #endregion
    }
}
