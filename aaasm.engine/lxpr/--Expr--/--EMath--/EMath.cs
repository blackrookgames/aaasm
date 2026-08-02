
using System;
using System.Linq;

namespace aaasm.engine.lxpr
{
    /// <summary>Information about mathematical operators</summary>
    public static partial class EMath
    {
        /// <summary>Operators</summary>
        public static EMathOperatorInfos OPERATORS { get; }

        /// <summary>Unary operators</summary>
        public static EMathOperatorInfos UNARY { get; }

        /// <summary>Binary operators</summary>
        public static EMathOperatorInfos BINARY { get; }
    }
}
