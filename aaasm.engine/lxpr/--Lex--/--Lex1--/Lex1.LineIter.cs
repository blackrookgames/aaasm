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
        private class LineIter
        {
            #region iter

            public LineIter(IReadOnlyList<RoughTokenSpan> lines)
            {
                f_Lines = lines;
                f_Pos = 0;
                f_Current = (f_Pos == f_Lines.Count) ? 
                    RoughTokenSpan.EMPTY : f_Lines[f_Pos];
            }

            #endregion
            
            #region fields

            private readonly IReadOnlyList<RoughTokenSpan> f_Lines;

            private int f_Pos;

            private RoughTokenSpan f_Current;

            #endregion
            
            #region properties

            public int Pos
            {
                get
                {
                    return f_Pos;
                }
                set
                {
                    f_Pos = value;
                    f_Current = (f_Pos < 0 || f_Pos >= f_Lines.Count) ? 
                        RoughTokenSpan.EMPTY : f_Lines[f_Pos];
                }
            }

            public RoughTokenSpan Current => f_Current;

            public int Count => f_Lines.Count;

            #endregion
        }
    }
}