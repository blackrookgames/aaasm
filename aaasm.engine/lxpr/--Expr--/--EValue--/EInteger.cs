using System;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression integer</summary>
    /// <typeparam name="T">Underlying C# value type</typeparam>
    /// <param name="value">Underlying C# value</param>
    public abstract class EInteger<T>(T value) : ENumber<T>(value), IEInteger where T : struct
    {
        #region abstract methods

        private protected abstract int MM_ToShift();

        private protected abstract bool MM_TryChar(out char result);

        private protected abstract string MM_DebugBin();

        private protected abstract string MM_DebugHex();

        #endregion

        #region methods

        /// <inheritdoc/>
        public int ToShift() => MM_ToShift();

        /// <inheritdoc/>
        public bool TryChar(out char result) => MM_TryChar(out result);

        /// <inheritdoc/>
        public string DebugBin() => MM_DebugBin();

        /// <inheritdoc/>
        public string DebugHex() => MM_DebugHex();

        #endregion
    }
}
