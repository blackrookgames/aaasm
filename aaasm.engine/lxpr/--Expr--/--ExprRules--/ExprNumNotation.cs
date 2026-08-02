using System;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a numerical notation</summary>
    public class ExprNumNotation
    {
        #region init

        /// <summary>Initializer for <see cref="ExprNumNotation"/></summary>
        /// <param name="init">Initialization arguments</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="init"/> is null
        /// </exception>
        public ExprNumNotation(ExprNumNotationInit init)
        {
            try
            {
                Prefix = init.Prefix;
                Suffix = init.Suffix;
            }
            catch when (init is null)
            {
                throw new ArgumentNullException(nameof(init));
            }
        }

        #endregion

        #region const

        protected const bool COMMON_IGNORECASE = true;

        /// <summary>C-style binary notation (ex: 0b01100111)</summary>
        public static ExprNumNotation C_BIN { get; } = new(new(){ Prefix = (CIStr)"0b" });

        /// <summary>C-style hexadecimal notation (ex: 0x2A)</summary>
        public static ExprNumNotation C_HEX { get; } = new(new(){ Prefix = (CIStr)"0x" });

        /// <summary>Motorola-style binary notation (ex: %01100111)</summary>
        public static ExprNumNotation MOTOROLA_BIN { get; } = new(new(){ Prefix = (CIStr)"%" });

        /// <summary>Motorola-style hexadecimal notation (ex: $2A)</summary>
        public static ExprNumNotation MOTOROLA_HEX { get; } = new(new(){ Prefix = (CIStr)"$" });

        /// <summary>Intel-style binary notation (ex: 01100111b)</summary>
        public static ExprNumNotation INTEL_BIN { get; } = new(new(){ Suffix = (CIStr)"b" });

        /// <summary>Intel-style hexadecimal notation (ex: 2Ah)</summary>
        public static ExprNumNotation INTEL_HEX { get; } = new(new(){ Suffix = (CIStr)"h" });

        #endregion

        #region properties

        /// <summary>Required prefix</summary>
        [InitParam(value: "null")]
        public Str? Prefix { get; }
        
        /// <summary>Required suffix</summary>
        [InitParam(value: "null")]
        public Str? Suffix { get; }

        #endregion
    }
}
