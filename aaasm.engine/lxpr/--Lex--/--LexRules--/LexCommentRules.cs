using System;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents comment rules for lexical analysis</summary>
    public class LexCommentRules
    {
        #region init

        /// <summary>Initializer for <see cref="LexCommentRules"/></summary>
        /// <param name="init">Initialization arguments</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="init"/> is null
        /// </exception>
        public LexCommentRules(LexCommentRulesInit init)
        {
            try
            {
                Single = init.Single;
                Multi = init.Multi;
            }
            catch when (init is null)
            {
                throw new ArgumentNullException(nameof(init));
            }
        }

        #endregion

        #region const

        /// <summary>Assembly-style commenting</summary>
        public static LexCommentRules ASSEMBLY { get; } = new(new()
        {
            Single = (CIStr)";",
            Multi = null,
        });

        /// <summary>C-style commenting</summary>
        public static LexCommentRules C { get; } = new(new()
        {
            Single = (CIStr)"//",
            Multi = new((CIStr)"/*", (CIStr)"*/"),
        });

        #endregion
        
        #region properties

        /// <summary>Marker for single-line comments</summary>
        [InitParam(value: """ (CIStr)";" """)]
        public Str? Single { get; }

        /// <summary>Opening and closing delimiters for multiline comments</summary>
        [InitParam(value: """ null """)]
        public BracketPair<Str>? Multi { get; }

        #endregion
    }
}
