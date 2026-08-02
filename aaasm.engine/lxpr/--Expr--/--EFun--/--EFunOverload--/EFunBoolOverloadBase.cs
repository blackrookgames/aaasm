using System;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    public abstract class EFunBoolOverloadBase : EFunOverload
    {
        #region init

        internal EFunBoolOverloadBase(EFunFunctionId id, ImmNullArray<IEFunParam> parameters) : 
            base(id, parameters)
        { }

        #endregion

        #region abstract methods

        private protected abstract bool MM_Invoke(ExprContext context, EValue[] input);

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public sealed override EValue Invoke(ExprContext context, EValue[] input)
        {
            var value = MM_Invoke(context, input);
            return context.Rules.Boolean.Type().BoolConv().FromBool(value);
        }

        /// <inheritdoc/>
        public sealed override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            MM_ThrowIfInputMismatch(input);
            return rules.Boolean.Type();
        }

        /// <inheritdoc/>
        public sealed override string Debug(ExprContext context, EValue[] input)
        {
            return MM_DummyDebug(context, input);
        }

        #endregion
    }
}