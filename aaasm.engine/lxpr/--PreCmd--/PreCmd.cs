// This was auto-generated from PreCmd.cs.py
namespace aaasm.engine.lxpr
{
    /// <summary>Represents a type of preprocessor command</summary>
    public enum PreCmd : byte
    {
        /// <summary>Prints information to the console</summary>
        ECHO,

        /// <summary>Include code from another file</summary>
        INCLUDE,

        /// <summary>Define a macro</summary>
        DEFINE,

        /// <summary>Undefines a macro</summary>
        UNDEF,

        /// <summary>Start of an if..else block</summary>
        IF,

        /// <summary>Start of an else block</summary>
        ELSE,

        /// <summary>Start of an else-if block</summary>
        ELIF,

        /// <summary>End of an if..else block</summary>
        ENDIF,

        /// <summary>Checks if a macro is defined</summary>
        IFDEF,

        /// <summary>Checks if a macro is not defined</summary>
        IFNDEF,

        /// <summary>Checks if a macro is defined, if previous conditions were false</summary>
        ELIFDEF,

        /// <summary>Checks if a macro is not defined, if previous conditions were false</summary>
        ELIFNDEF,
    }
}
