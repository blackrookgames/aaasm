// This was auto-generated from LexRules.auto.cs.py
using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    public partial class LexRules
    {
        /// <summary>Commonly used names of the preprocessor commands</summary>
        public static ImmNullDict<Str, PreCmd> COMMON_PRENAMES { get; } = new([
            new ((CIStr)"ECHO", PreCmd.ECHO),
            new ((CIStr)"INCLUDE", PreCmd.INCLUDE),
            new ((CIStr)"DEFINE", PreCmd.DEFINE),
            new ((CIStr)"UNDEF", PreCmd.UNDEF),
            new ((CIStr)"IF", PreCmd.IF),
            new ((CIStr)"ELSE", PreCmd.ELSE),
            new ((CIStr)"ELIF", PreCmd.ELIF),
            new ((CIStr)"ENDIF", PreCmd.ENDIF),
            new ((CIStr)"IFDEF", PreCmd.IFDEF),
            new ((CIStr)"IFNDEF", PreCmd.IFNDEF),
            new ((CIStr)"ELIFDEF", PreCmd.ELIFDEF),
            new ((CIStr)"ELIFNDEF", PreCmd.ELIFNDEF),]);
    }
}
