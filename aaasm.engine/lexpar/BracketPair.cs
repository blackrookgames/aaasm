using System;
using aaasm.engine.io;

namespace aaasm.engine.lexpar
{
    /// <summary>Represents a bracket pair</summary>
    public class BracketPair<T>
    {
        #region init

        /// <summary>Initializer for <see cref="BracketPair{T}"/></summary>
        /// <param name="open">Open bracket</param>
        /// <param name="close">Close bracket</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="open"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="close"/> is null
        /// </exception>
        public BracketPair(T open, T close)
        {
            if (open is null)
                throw new ArgumentNullException(nameof(open));
            if (close is null)
                throw new ArgumentNullException(nameof(close));
            f_Open = open;
            f_Close = close;
        }

        #endregion

        #region fields

        private readonly T f_Open;
        private readonly T f_Close;

        #endregion

        #region properties

        /// <summary>Open bracket</summary>
        public T Open => f_Open;

        /// <summary>Close bracket</summary>
        public T Close => f_Close;

        #endregion
    }
}
