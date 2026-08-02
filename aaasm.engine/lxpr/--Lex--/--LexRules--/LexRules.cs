using System;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents rules for lexical analysis</summary>
    public partial class LexRules
    {
        #region init

        /// <summary>Initializer for <see cref="LexRules"/></summary>
        /// <param name="init">Initialization arguments</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="init"/> is null
        /// </exception>
        public LexRules(LexRulesInit init)
        {
            try
            {
                Comments = init.Comments;
                LineContinue = init.LineContinue;
                RoughPatterns = init.RoughPatterns;
                PrePrefix = init.PrePrefix;
                PreNames = init.PreNames;
                PreCmdArgSep = init.PreCmdArgSep;
                BracketPairs = init.BracketPairs;
                MacroBrackets = init.MacroBrackets;
                MacroParamSep = init.MacroParamSep;
                Expression = new(init.Expression);
            }
            catch when (init is null)
            {
                throw new ArgumentNullException(nameof(init));
            }
        }

        #endregion

        #region properties

        /// <summary>Rules regarding comments</summary>
        [InitParam(value: "new([LexCommentRules.ASSEMBLY, LexCommentRules.C])")]
        public ImmNullArray<LexCommentRules> Comments { get; }

        /// <summary>
        ///     Line-continuation identifier; 
        ///     this must be the last character in the line
        /// </summary>
        [InitParam(value: """ (CIStr)"\\" """)]
        public Str? LineContinue { get; }

        /// <summary>
        ///     <para>
        ///         Rough patterns to be detected during the rough tokenization phase. 
        ///         Lower indexes have higher priority.
        ///     </para>
        ///     <para>
        ///         Examples:
        ///         <list type="bullet">
        ///             <item>Mathematical operators + - * / %</item>
        ///             <item>Bitwise operators &lt;&lt; &gt;&gt; &amp; | ~</item>
        ///             <item>Equality operators == != &lt; &lt;= &gt; &gt;=</item>
        ///             <item>Boolean operators &amp;&amp; || !</item>
        ///             <item>Delimiters , ( ) { } [ ]</item>
        ///             <item>Command prefixes</item>
        ///         </list>
        ///     </para>
        /// </summary>
        [InitParam(value: """ new() """)]
        public ImmNullArray<LexRoughPattern> RoughPatterns { get; }

        /// <summary>Prefix for preprocessor commands</summary>
        [InitParam(value: """ (CIStr)"@" """)]
        public Str? PrePrefix { get; }

        /// <summary>Names of the preprocessor commands</summary>
        [InitParam(value: """ LexRules.COMMON_PRENAMES """)]
        public ImmNullDict<Str, PreCmd> PreNames { get; }
        
        /// <summary>Character for separating preprocessor command arguments</summary>
        [InitParam(value: """ (CIStr)"," """)]
        public Str? PreCmdArgSep { get; }

        /// <summary>Valid bracket pairs</summary>
        [InitParam(value: """ new([ BracketPair.CURLY, BracketPair.SQUARE, BracketPair.ROUND, ]) """)]
        public ImmNullArray<BracketPair<Str>> BracketPairs { get; }
        
        /// <summary>Brackets used during a macro definition and macro call</summary>
        [InitParam(value: """ BracketPair.ROUND """)]
        public BracketPair<Str>? MacroBrackets { get; }
        
        /// <summary>Character for separating macro parameters and arguments</summary>
        [InitParam(value: """ (CIStr)"," """)]
        public Str? MacroParamSep { get; }

        /// <summary>Expression rules</summary>
        [InitParam(type: "ExprRulesInit", value: """ new() """, set: false)]
        public ExprRules Expression { get; }

        #endregion
    }
}
