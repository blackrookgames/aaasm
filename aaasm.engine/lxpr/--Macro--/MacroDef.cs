using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a definition for a CLI-defined macro</summary>
    public class MacroDef
    {
        #region init

        /// <summary>Initializer for <see cref="MacroDef"/></summary>
        /// <param name="name">Macro name</param>
        /// <param name="body">Macro body</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name"/> is null
        /// </exception>
        public MacroDef(string name, string? body)
        {
            ArgumentNullException.ThrowIfNull(name);
            f_Name = name;
            f_Body = body;
        }

        #endregion
        
        #region fields

        private readonly string f_Name;
        private readonly string? f_Body;

        #endregion
        
        #region properties

        /// <summary>Macro name</summary>
        public string Name => f_Name;

        /// <summary>Macro body</summary>
        public string? Body => f_Body;

        #endregion
    }
}
