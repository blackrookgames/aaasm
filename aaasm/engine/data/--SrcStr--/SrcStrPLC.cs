using System;
using aaasm.engine.io;

namespace aaasm.engine.data
{
    /// <summary>Represents path, line, and column information</summary>
    /// <param name="path">Path of source</param>
    /// <param name="line">Line number (1 is first line)</param>
    /// <param name="col">Column number (1 is first column)</param>
    public readonly struct SrcStrPLC(NormalPath path, int line, int col)
    {
        #region fields

        private readonly NormalPath f_Path = path;
        private readonly int f_Line = line;
        private readonly int f_Col = col;

        #endregion

        #region properties

        /// <summary>Path of source</summary>
        public NormalPath Path => f_Path;

        /// <summary>Line number (1 is first line)</summary>
        public int Line => f_Line;

        /// <summary>Column number (1 is first column)</summary>
        public int Col => f_Col;

        #endregion
    }
}
