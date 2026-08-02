using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using aaasm.engine.col;
using System.Collections;
using aaasm.engine.help;

using LexTokenSpan = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.LexToken>;
using RoughTokenSpan = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.RoughToken>;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    internal partial class Lex1
    {
        private class Handler(
            IReadOnlyList<RoughTokenSpan> input,
            LexRules rules,
            LexParams @params,
            LexPersistent persistent)
        {
            #region fields

            private readonly LineIter f_Input = new(input);
            private readonly LexRules f_Rules = rules;
            private readonly LexParams f_Params = @params;
            private readonly List<LexTokenSpan> f_Output = new(input.Count);
            private readonly LexPersistent f_Persistent = persistent;

            private readonly ExprContext f_Context = new(rules.Expression, @params.Expression, true);

            private readonly IfLevel f_If = new();

            #endregion
            
            #region properties

            public LineIter Input => f_Input;
            public LexRules Rules => f_Rules;
            public LexParams Params => f_Params;
            public List<LexTokenSpan> Output => f_Output;
            public LexPersistent Persistent => f_Persistent;

            public ExprContext Context => f_Context;

            public IfLevel If => f_If;

            #endregion

            #region methods

            public static bool Equal(RoughToken a, Str? b) =>
                Str.Equal(a.RawData.Raw, b);

            public static bool StartsWith(RoughToken s, Str? sub) =>
                s.RawData.Raw.StartsWith(sub);

            public static bool EndsWith(RoughToken s, Str? sub) =>
                s.RawData.Raw.EndsWith(sub);

            #endregion
        }
    }
}