using System;
using System.Collections.Generic;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents lexical analysis parameters</summary>
    public struct LexParams
    {
        // Leave as fields
        
        /// <summary>Expression parameters</summary>
        public ExprParams Expression;

        /// <summary>CLI-defined macro defininitions</summary>
        public ImmNullArray<MacroDef> MacroDefs;
    }
}