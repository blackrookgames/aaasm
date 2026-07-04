using System;
using aaasm.engine.io;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a character from a source file</summary>
    /// <param name="char">Actual character</param>
    /// <param name="origin">Information regarding the character's original source</param>
    public readonly struct SrcChar(char @char, RefPnt origin)
    {
        #region object

        /// <summary>Creates a C# string representation</summary>
        /// <returns>C# string representation</returns>
        public override string ToString() => f_Char.ToString();

        #endregion

        #region fields

        private readonly char f_Char = @char;
        private readonly RefPnt f_Origin = origin;

        #endregion

        #region properties

        /// <summary>Actual character</summary>
        public char Char => f_Char;

        /// <summary>Information regarding the character's original source</summary>
        public RefPnt Origin => f_Origin;

        #endregion
    }
}
