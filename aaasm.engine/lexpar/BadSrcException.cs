using System;

namespace aaasm.engine.lexpar
{
    /// <summary>Thrown when invalid data is found in source code</summary>
    /// <param name="refPnt">Point of reference</param>
    /// <param name="message">Error message</param>
    public class BadSrcException(string? message, RefPnt? refPnt = null) : Exception(message)
    {
        #region fields

        private readonly RefPnt? f_RefPnt = refPnt;

        #endregion

        #region properties

        /// <summary>Point of reference</summary>
        public RefPnt? RefPnt => f_RefPnt;

        #endregion
    }
}
