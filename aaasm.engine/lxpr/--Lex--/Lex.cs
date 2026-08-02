using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;
using LexLine = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.LexToken>;

namespace aaasm.engine.lxpr
{
    public class Lex
    {
        #region init

        private Lex(ImmNullArray<LexLine> lines)
        {
            f_Lines = lines;
        }

        #endregion

        #region fields

        private readonly ImmNullArray<LexLine> f_Lines;

        #endregion

        #region properties

        /// <summary>Lines of lexically-analyzed tokens</summary>
        public ImmNullArray<LexLine> Lines => f_Lines;

        #endregion

        #region helper methods

        /// <summary>Also accessed by <see cref="Lex1"/></summary>
        internal static Lex MM_Run(SrcString source, LexRules rules, LexParams @params, LexPersistent? persistent)
        {
            try
            {
                // Create persistent data (if nonexistant)
                if (persistent is null)
                {
                    persistent = new();
                    // Add CLI-defined macros
                    foreach (var macroDef in @params.MacroDefs)
                    {
                        if (!LexParUtil.IsLegalName(macroDef.Name))
                            throw new BadSrcException($"Illegal macro name: {macroDef.Name}");
                        if (persistent.Macros.Curr.TryGet(macroDef.Name, out _))
                            throw new BadSrcException($"There is already a macro named {macroDef.Name}");
                        var macroLex = Lex0.Run(new(macroDef.Body), rules);
                        ImmNullArray<RoughToken> macroBody = new(macroLex.Lines.SelectMany(item => item));
                        persistent.Macros.Define(new (macroDef.Name, false, new(), new(), macroBody));
                    }
                }
                // Lexical analysis
                var lex0 = Lex0.Run(source, rules);
                var lex1 = Lex1.Run(lex0, rules, @params, persistent);
                return new(lex1.Lines);
            }
            catch when (source is null)
            { throw new ArgumentNullException(nameof(source)); }
            catch when (rules is null)
            { throw new ArgumentNullException(nameof(rules)); }
        }

        #endregion

        #region methods
        
        /// <summary>Runs the lexical analyzer</summary>
        /// <param name="source">Source</param>
        /// <param name="rules">Rules</param>
        /// <param name="params">Parameters</param>
        /// <returns>Results</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="rules"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     A syntax error was detected
        /// </exception>
        public static Lex Run(SrcString source, LexRules rules, LexParams @params)
        {
            return MM_Run(source, rules, @params, null);
        }

        #endregion
    }
}