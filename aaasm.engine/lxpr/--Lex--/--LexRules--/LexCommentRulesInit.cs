// This was auto-generated from LexCommentRulesInit.cs.py
using System;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents initialization parameters for <see cref="LexCommentRules"/></summary>
    public class LexCommentRulesInit
    {
        /// <inheritdoc cref="LexCommentRules.Single"/>
        public Str? Single { get; set; } = (CIStr)";";

        /// <inheritdoc cref="LexCommentRules.Multi"/>
        public BracketPair<Str>? Multi { get; set; } = null;
    }
}
