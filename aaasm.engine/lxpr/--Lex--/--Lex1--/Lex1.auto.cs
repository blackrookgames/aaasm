// This was auto-generated from Lex1.auto.cs.py
using System;
using System.Collections.Generic;

namespace aaasm.engine.lxpr
{
    internal partial class Lex1
    {
        private static readonly Dictionary<PreCmd, Action<Handler>> PRECOMMANDS = new()
        {
            { PreCmd.ECHO, MM_PreCmd_ECHO },
            { PreCmd.INCLUDE, MM_PreCmd_INCLUDE },
            { PreCmd.DEFINE, MM_PreCmd_DEFINE },
            { PreCmd.UNDEF, MM_PreCmd_UNDEF },
            { PreCmd.IF, MM_PreCmd_IF },
            { PreCmd.ELSE, MM_PreCmd_ELSE },
            { PreCmd.ELIF, MM_PreCmd_ELIF },
            { PreCmd.ENDIF, MM_PreCmd_ENDIF },
            { PreCmd.IFDEF, MM_PreCmd_IFDEF },
            { PreCmd.IFNDEF, MM_PreCmd_IFNDEF },
            { PreCmd.ELIFDEF, MM_PreCmd_ELIFDEF },
            { PreCmd.ELIFNDEF, MM_PreCmd_ELIFNDEF },
        };
    }
}
