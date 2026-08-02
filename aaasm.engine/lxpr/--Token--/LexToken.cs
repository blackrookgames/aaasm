using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a lexically-analyzed token</summary>
    public class LexToken : IToken
    {
        #region init

        internal LexToken(
            RoughToken rough, 
            ImmNullArray<LexToken> children, 
            BracketPair<Str>? brackets)
        {
            f_Rough = rough;
            f_Children = children;
            f_Brackets = brackets;
        }

        #endregion
        
        #region fields

        private readonly RoughToken f_Rough;
        private readonly IReadOnlyList<LexToken> f_Children;
        private readonly BracketPair<Str>? f_Brackets;

        #endregion
        
        #region properties

        /// <summary>Rough</summary>
        public RoughToken Rough => f_Rough;

        /// <summary>Child tokens</summary>
        public IReadOnlyList<LexToken> Children => f_Children;

        /// <summary>Enclosing brackets</summary>
        public BracketPair<Str>? Brackets => f_Brackets;

        #endregion
        
        #region IToken

        /// <inheritdoc/>
        public RefPnt RefPnt => f_Rough.RefPnt;

        #endregion
    }
}