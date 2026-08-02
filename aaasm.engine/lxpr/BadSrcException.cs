using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Thrown when invalid data is found in source code</summary>
    /// <param name="message">Error message</param>
    /// <param name="refPnt">Point of reference</param>
    public class BadSrcException(string? message, RefPnt? refPnt = null) : Exception(message)
    {
        #region init

        /// <summary>Creates a <see cref="BadSrcException"/> indicating unexpected content</summary>
        /// <param name="what">What was unexpected</param>
        /// <param name="refPnt">Point of reference</param>
        /// <returns>Created <see cref="BadSrcException"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="what"/> is null
        /// </exception>
        public static BadSrcException Unexpected(SrcString what, RefPnt? refPnt = null)
        {
            ArgumentNullException.ThrowIfNull(what);
            refPnt ??= (what.Length == 0) ? null : what[0].Origin;
            return new($"Unexpected: {what.Raw}", refPnt);
        }

        /// <inheritdoc cref="Unexpected(SrcString, RefPnt?)"/>
        public static BadSrcException Unexpected(string what, RefPnt? refPnt = null)
        {
            ArgumentNullException.ThrowIfNull(what);
            return new($"Unexpected: {what}", refPnt);
        }

        /// <summary>Creates a <see cref="BadSrcException"/> indicating expected but missing content</summary>
        /// <param name="what">What was expected</param>
        /// <param name="refPnt">Point of reference</param>
        /// <param name="noColumn">If true, column information will be removed</param>
        /// <returns>Created <see cref="BadSrcException"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="what"/> is null
        /// </exception>
        public static BadSrcException Expected(string what, RefPnt? refPnt = null, bool noColumn = false)
        {
            ArgumentNullException.ThrowIfNull(what);
            if (noColumn && refPnt is not null)
                refPnt = new(refPnt.Value.Path, refPnt.Value.Line, -1);
            return new($"{what} expected", refPnt);
        }

        #endregion

        #region fields

        private readonly RefPnt? f_RefPnt = refPnt;

        #endregion

        #region properties

        /// <summary>Point of reference</summary>
        public RefPnt? RefPnt => f_RefPnt;

        #endregion
    }
}