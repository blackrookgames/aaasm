using System;
using aaasm.engine.col;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents rules for Stage-0 lexical analysis</summary>
    public abstract class Lex0Rules
    {
        #region properties

        /// <summary>Whether or not single-quotation marks should be parsed as a quoted block</summary>
        public abstract bool ParseSingleQuote { get; }

        /// <summary>Whether or not double-quotation marks should be parsed as a quoted block</summary>
        public abstract bool ParseDoubleQuote { get; }

        /// <summary>Rules regarding comments</summary>
        public abstract ImmutableNullessArray<Lex0CommentRules> Comments { get; }

        /// <summary>
        ///     Line-continuation identifier; 
        ///     this must be the last character in the line
        /// </summary>
        public abstract string? LineContinue { get; }

        /// <summary>
        ///     <para>
        ///         Symbols; these may include
        ///         <list type="bullet">
        ///             <item>Operators</item>
        ///             <item>Delimiters</item>
        ///             <item>Operator keywords</item>
        ///         </list>
        ///     </para>
        /// </summary>
        public abstract ImmutableNullessArray<string> Symbols { get; }

        #endregion
    }
}
