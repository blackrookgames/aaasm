using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;

using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.lxpr
{
    public abstract class EFunOverload
    {
        #region init

        internal EFunOverload(EFunFunctionId id, ImmNullArray<IEFunParam> parameters)
        {
            f_Id = id;
            f_Parameters = parameters;
        }

        #endregion

        #region fields

        private readonly EFunFunctionId f_Id;
        private readonly ImmNullArray<IEFunParam> f_Parameters;

        #endregion

        #region properties

        /// <summary>Function identifier</summary>
        public EFunFunctionId Id => f_Id;

        /// <summary>Function parameters</summary>
        public ImmNullArray<IEFunParam> Parameters => f_Parameters;

        #endregion

        #region private methods

        private bool MM_Match<T>(IReadOnlyCollection<T> input, Func<IEFunParam, T, bool> match,
            [CallArgExp(nameof(input))] string? inputParam = null)
        {
            try
            {
                if (input.Count != f_Parameters.Length)
                    return false;
                if (f_Parameters.Zip(input).Any(item => !match(item.First, item.Second)))
                    return false;
                return true;
            }
            catch when (input is null)
            {
                throw new ArgumentNullException(inputParam);
            }
        }

        private void MM_ThrowIfInputMismatch<T>(IReadOnlyCollection<T> input, 
            Func<IEFunParam, T, bool> match,
            [CallArgExp(nameof(input))] string? inputParam = null)
        {
            MM_ValidateInputCount(input, inputParam);
            if (MM_Match(input, match, inputParam)) return;
            throw new ArgumentException("Input items do not match the parameters.", inputParam);
        }

        private static bool MM_MatchParam(IEFunParam param, EValue? value) => param.Match(value);
        
        private static bool MM_MatchParam(IEFunParam param, ENodeValueType? value) => param.AssignableFrom(value);

        #endregion

        #region protected methods

        protected void MM_ValidateInputCount<T>(IReadOnlyCollection<T> input,
            [CallArgExp(nameof(input))] string? inputParam = null)
        {
            try
            {
                if (input.Count == f_Parameters.Length) return;
                throw new ArgumentException(
                    "Number of input items must equal to the number of parameters.",
                    inputParam);
            }
            catch when (input is null)
            {
                throw new ArgumentNullException(inputParam);
            }
        }

        protected void MM_ThrowIfInputMismatch(IReadOnlyCollection<EValue> input, 
            [CallArgExp(nameof(input))] string? inputParam = null)
        {
            MM_ThrowIfInputMismatch(input, MM_MatchParam, inputParam);
        }

        protected void MM_ThrowIfInputMismatch(IReadOnlyCollection<ENodeValueType> input, 
            [CallArgExp(nameof(input))] string? inputParam = null)
        {
            MM_ThrowIfInputMismatch(input, MM_MatchParam, inputParam);
        }

        protected IReadOnlyList<object> MM_FixInput(EValue[] input)
        {
            object[] fixedInput = new object[input.Length];
            for (int i = 0; i < input.Length; ++i)
            {
                if (i < f_Parameters.Length)
                {
                    fixedInput[i] = f_Parameters[i].Parse(input[i]);
                }
                else
                {
                    fixedInput[i] = input[i];
                }
            }
            return fixedInput;
        }

        protected EValue MM_DummyInvoke(ExprContext context, EValue[] input)
        {
            ArgumentNullException.ThrowIfNull(context);
            MM_ValidateInputCount(input);
            return new EU8(0);
        }

        protected EType MM_DummyGetReturn(ExprRules rules, ENodeValueType[] input)
        {
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            return EType.U8;
        }

        protected string MM_DummyDebug(ExprContext context, EValue[] input)
        {
            return Invoke(context, input).ToString(context.Rules);
        }

        #endregion

        #region methods

        /// <summary>Checks whether or not the specified input values match the function's parameters</summary>
        /// <param name="input">Input values</param>
        /// <returns>Whether or not <paramref name="input"/> matches the function's parameters</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        public bool Match(EValue[] input) => MM_Match(input, MM_MatchParam);

        /// <summary>Checks whether or not the specified input types match the function's parameters</summary>
        /// <param name="input">Input types</param>
        /// <returns>Whether or not <paramref name="input"/> matches the function's parameters</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        public bool Match(ENodeValueType[] input) => MM_Match(input, MM_MatchParam);
        
        #endregion

        #region abstract methods

        /// <summary>Invokes the function</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/> contains one or more null items
        ///     <br/>or<br/>
        ///     <paramref name="input"/> items do not match the function parameters
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public abstract EValue Invoke(ExprContext context, EValue[] input);

        /// <summary>Computes the return type for the specified input types</summary>
        /// <param name="rules">Node rules</param>
        /// <param name="input">Input types</param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="rules"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/> contains one or more null items
        ///     <br/>or<br/>
        ///     <paramref name="input"/> items do not match the function parameters
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public abstract EType GetReturn(ExprRules rules, ENodeValueType[] input);

        /// <summary>Computes debug info</summary>
        /// <param name="context">Context</param>
        /// <param name="input">Input</param>
        /// <returns>Debug info (null means function does not provide debug info)</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="input"/> contains one or more null items
        ///     <br/>or<br/>
        ///     <paramref name="input"/> items do not match the function parameters
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public abstract string Debug(ExprContext context, EValue[] input);

        #endregion
    }
}