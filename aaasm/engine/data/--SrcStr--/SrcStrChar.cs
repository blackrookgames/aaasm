using System;
using aaasm.engine.io;

namespace aaasm.engine.data
{
    /// <summary>Represents a character from a source file</summary>
    /// <param name="char">Actual character</param>
    /// <param name="plc">Path, line, and column information</param>
    public readonly struct SrcStrChar(char @char, SrcStrPLC plc)
    {
        #region object

        /// <summary>Creates a C# string representation</summary>
        /// <returns>C# string representation</returns>
        public override string ToString() => f_Char.ToString();

        #endregion

        #region fields

        private readonly char f_Char = @char;
        private readonly SrcStrPLC f_PLC = plc;

        #endregion

        #region properties

        /// <summary>Actual character</summary>
        public char Char => f_Char;

        /// <summary>Path, line, and column information</summary>
        public SrcStrPLC PLC => f_PLC;

        #endregion
    }
}
