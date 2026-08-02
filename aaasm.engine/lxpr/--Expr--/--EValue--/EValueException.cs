using System;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Thrown when a value-related error occurs</summary>
    /// <remarks>Initializer for <see cref="EValueException"/></remarks>
    /// <param name="message">Error message</param>
    public class EValueException(string? message) : Exception(message)
    {
        #region init

        /// <summary>Indicates a failed attempt to divide by zero</summary>
        public static EValueException DivideByZero() =>
            new("Cannot divide by zero.");

        #endregion
    }
}
