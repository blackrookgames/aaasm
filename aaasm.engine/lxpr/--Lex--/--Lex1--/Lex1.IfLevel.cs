using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

using LexTokenSpan = aaasm.engine.col.ImmNullArray<aaasm.engine.lxpr.LexToken>;

namespace aaasm.engine.lxpr
{
    internal partial class Lex1
    {
        private class IfLevel
        {
            #region fields

            private bool f_Met = true;
            private int f_Level = 0;
            private int f_Active = 0;

            #endregion

            #region properties

            /// <summary>Whether or not an IF condition has been met</summary>
            public bool Met => f_Met;

            /// <summary>Current IF level</summary>
            public int Level => f_Level;

            /// <summary>Level at which code can be analysed</summary>
            public int Active => f_Active;

            #endregion

            #region helper methods

            private void MM_ValidateIfLevel()
            {
                if (f_Level > 0) return;
                throw new InvalidOperationException("Not currently within an IF block.");
            }

            #endregion

            #region methods
            
            /// <summary>If</summary>
            /// <param name="condition">Condition</param>
            public void If(bool condition)
            {
                // Should be consider IF?
                if (f_Active == f_Level)
                {
                    if (condition) ++f_Active;
                    else f_Met = false;
                }
                // Increment level
                ++f_Level;
            }

            /// <summary>Else</summary>
            /// <param name="condition">Condition</param>
            /// <exception cref="InvalidOperationException">
            ///     <see cref="IfLevel"/> == 0
            /// </exception>
            public void Else(bool condition = true)
            {
                MM_ValidateIfLevel();
                // Currently active?
                if (f_Active == f_Level)
                {
                    --f_Active;
                }
                // No! Should we take consider the ELSE?
                else if ((f_Active + 1) == f_Level && (!f_Met))
                {
                    if (condition)
                    {
                        ++f_Active;
                        f_Met = true;
                    }
                }
            }

            /// <summary>End if</summary>
            /// <exception cref="InvalidOperationException">
            ///     <see cref="IfLevel"/> == 0
            /// </exception>
            public void EndIf()
            {
                MM_ValidateIfLevel();
                // Currently active?
                if (f_Active == f_Level)
                    --f_Active;
                // No! Could it become active?
                else if ((f_Active + 1) == f_Level)
                    f_Met = true;
                // Decrement level
                --f_Level;
            }

            #endregion
        }
    }
}