using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a function definition</summary>
    public class EFunFunction
    {
        #region init

        internal EFunFunction(EFunFunctionId id, ImmNullArray<EFunOverload> overloads)
        {
            f_Id = id;
            f_Overloads = overloads;
        }

        #endregion

        #region fields

        private readonly EFunFunctionId f_Id;
        private readonly ImmNullArray<EFunOverload> f_Overloads;

        #endregion

        #region properties

        /// <summary>Function identifier</summary>
        public EFunFunctionId Id => f_Id;

        /// <summary>Function overloads</summary>
        public ImmNullArray<EFunOverload> Overloads => f_Overloads;

        #endregion

        #region methods

        /// <summary>Attempts to find an overload that matches the specified input values</summary>
        /// <param name="input">Input values</param>
        /// <param name="overload">Found overload</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        public bool TryGet(EValue[] input, [MaybeNullWhen(false)] out EFunOverload overload)
        {
            try
            { return ColUtil.TryFind(f_Overloads, item => item.Match(input), out overload); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        /// <summary>Attempts to find an overload that matches the specified input types</summary>
        /// <param name="input">Input types</param>
        /// <param name="overload">Found overload</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        public bool TryGet(ENodeValueType[] input, [MaybeNullWhen(false)] out EFunOverload overload)
        {
            try
            { return ColUtil.TryFind(f_Overloads, item => item.Match(input), out overload); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion
    }
}
