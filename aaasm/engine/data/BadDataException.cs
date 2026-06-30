using System;

namespace aaasm.engine.data
{
    /// <summary>Thrown when invalid data is found</summary>
    /// <param name="message">Exception message</param>
    public class BadDataException(string message) : Exception(message) { }
}
