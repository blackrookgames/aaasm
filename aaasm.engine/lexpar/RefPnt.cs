using System;
using aaasm.engine.io;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a source code point of reference</summary>
    /// <param name="path">Path of source file</param>
    /// <param name="line">Line number in source (1 is first line)</param>
    /// <param name="col">Column number in source (1 is first column)</param>
    public readonly struct RefPnt(NormalPath? path, int line, int col)
    {
        #region fields

        private readonly NormalPath? f_Path = path;
        private readonly int f_Line = line;
        private readonly int f_Col = col;

        #endregion

        #region properties

        /// <summary>Path of source file</summary>
        public NormalPath? Path => f_Path;

        /// <summary>Line number in source (1 is first line)</summary>
        public int Line => f_Line;

        /// <summary>Column number in source (1 is first column)</summary>
        public int Col => f_Col;

        #endregion
    }
}
