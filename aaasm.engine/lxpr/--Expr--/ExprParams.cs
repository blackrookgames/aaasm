using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.io;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents expression parameters</summary>
    public struct ExprParams
    {
        // Leave as fields

        /// <summary>
        ///     Explicitly defined search directories; 
        ///     higher indexes take higher priority
        /// </summary>
        public ImmNullArray<NormalPath> SearchDirectories;

        /// <summary>
        ///     If true, the parent directories of files specified with @INCLUDE 
        ///     will not be automatically added to the search list
        /// </summary>
        public bool DoNotAddIncludeDirs;
    }
}