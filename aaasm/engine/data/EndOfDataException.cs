using System;

namespace aaasm.engine.data
{
    /// <summary>Thrown when data ends unexpectedly</summary>
    /// <param name="message">Exception message</param>
    public class EndOfDataException(string message) : Exception(message)
    {
        #region init

        /// <summary>Initializer for <see cref="EndOfDataException"/></summary>
        public EndOfDataException() : this("Unexpected end of data.") { }

        #endregion
    }
}
