using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression integer</summary>
    public partial interface IEInteger
    {
        #region methods

        /// <summary>Gets a character representation of the integer</summary>
        /// <param name="rules">Expression rules</param>
        /// <returns>Character representation</returns>
        public string GetChar(ExprRules? rules = null)
        {
            // TODO: Consider rules
            if (TryChar(out var result))
                return MM_Chr2Str(result, rules);
            return "?";
        }

        #endregion

        #region private protected methods

        private protected static string MM_Chr2Str(char c, ExprRules? rules = null)
        {
            // TODO: Consider rules
            if (c >= ' ' && c < 0x7F)
            {
                if (c == '\\') return "\\\\";
                if (c == '\"') return "\\\"";
                if (c == '\'') return "\\'";
                return c.ToString();
            }
            int cc = c;
            if ((cc & 0xFF) == cc) return $"\\x{cc:X2}";
            return $"\\u{cc:X4}";
        }

        #endregion

        #region abstract properties

        /// <summary>Value type</summary>
        public EType Type { get; }

        #endregion

        #region abstract methods

        /// <summary>Converts the integer to a proper bit-shift amount, clamping if necessary</summary>
        /// <returns>Result</returns>
        public int ToShift();

        /// <summary>Attempts to convert the integer to a C# character</summary>
        /// <param name="result">Result</param>
        /// <returns>Whether or not successful</returns>
        public bool TryChar(out char result);

        /// <summary>Prints the number in binary format</summary>
        /// <returns>Generated string</returns>
        public string DebugBin();

        /// <summary>Prints the number in hexadecimal format</summary>
        /// <returns>Generated string</returns>
        public string DebugHex();
        
        #endregion
    }
}
