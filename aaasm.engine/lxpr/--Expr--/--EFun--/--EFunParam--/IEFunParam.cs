using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a function parameter</summary>
    public interface IEFunParam
    {
        #region abstract methods

        /// <summary>Checks whether or not the specified value can be assigned to the parameter</summary>
        /// <param name="value">Expression value</param>
        /// <returns>Whether or not <paramref name="value"/> can be assigned to the parameter</returns>
        public bool Match(EValue? value);

        /// <summary>Checks whether or not the specified type can be assigned to the parameter</summary>
        /// <param name="type">Expression node value type</param>
        /// <returns>Whether or not <paramref name="type"/> can be assigned to the parameter</returns>
        public bool AssignableFrom(ENodeValueType? type);

        /// <summary>Parses the specified arg</summary>
        /// <param name="arg">Argument to parse</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     <paramref name="arg"/> is invalid
        /// </exception>
        public object Parse(EValue arg);

        #endregion
    }
}