// This was auto-generated from EFunOverload.common.cs.py
using System;

namespace aaasm.engine.lxpr
{
    public class EFunOverload<TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context);

        public delegate EType GetReturnFunc(ExprRules rules);

        public delegate string DebugFunc(ExprContext context);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn) : 
            base(id, new([]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug) : 
            base(id, new([]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context)!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context)!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0) : 
            base(id, new([param0]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0) : 
            base(id, new([param0]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1) : 
            base(id, new([param0, param1]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1) : 
            base(id, new([param0, param1]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2) : 
            base(id, new([param0, param1, param2]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2) : 
            base(id, new([param0, param1, param2]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3) : 
            base(id, new([param0, param1, param2, param3]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3) : 
            base(id, new([param0, param1, param2, param3]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4) : 
            base(id, new([param0, param1, param2, param3, param4]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4) : 
            base(id, new([param0, param1, param2, param3, param4]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5) : 
            base(id, new([param0, param1, param2, param3, param4, param5]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5) : 
            base(id, new([param0, param1, param2, param3, param4, param5]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8, ENodeValueType arg9);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8, ENodeValueType arg9, ENodeValueType arg10);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8, ENodeValueType arg9, ENodeValueType arg10, ENodeValueType arg11);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8, ENodeValueType arg9, ENodeValueType arg10, ENodeValueType arg11, ENodeValueType arg12);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11, IEFunParam param12) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11, IEFunParam param12) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11], (TArg12)fixedInput[12])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11], (TArg12)fixedInput[12])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8, ENodeValueType arg9, ENodeValueType arg10, ENodeValueType arg11, ENodeValueType arg12, ENodeValueType arg13);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11, IEFunParam param12, IEFunParam param13) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11, IEFunParam param12, IEFunParam param13) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11], (TArg12)fixedInput[12], (TArg13)fixedInput[13])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11], (TArg12)fixedInput[12], (TArg13)fixedInput[13])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }

    public class EFunOverload<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn> : EFunOverload
    {
        #region nested

        public delegate TReturn InvokeFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14);

        public delegate EType GetReturnFunc(ExprRules rules, ENodeValueType arg0, ENodeValueType arg1, ENodeValueType arg2, ENodeValueType arg3, ENodeValueType arg4, ENodeValueType arg5, ENodeValueType arg6, ENodeValueType arg7, ENodeValueType arg8, ENodeValueType arg9, ENodeValueType arg10, ENodeValueType arg11, ENodeValueType arg12, ENodeValueType arg13, ENodeValueType arg14);

        public delegate string DebugFunc(ExprContext context, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14);

        #endregion

        #region init

        internal EFunOverload(EFunFunctionId id, InvokeFunc invoke, GetReturnFunc getReturn, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11, IEFunParam param12, IEFunParam param13, IEFunParam param14) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14]))
        {
            f_Invoke = invoke;
            f_GetReturn = getReturn;
            f_Debug = null;
        }

        internal EFunOverload(EFunFunctionId id, DebugFunc debug, 
            IEFunParam param0, IEFunParam param1, IEFunParam param2, IEFunParam param3, IEFunParam param4, IEFunParam param5, IEFunParam param6, IEFunParam param7, IEFunParam param8, IEFunParam param9, IEFunParam param10, IEFunParam param11, IEFunParam param12, IEFunParam param13, IEFunParam param14) : 
            base(id, new([param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14]))
        {
            f_Invoke = null;
            f_GetReturn = null;
            f_Debug = debug;
        }

        #endregion

        #region fields

        private readonly InvokeFunc? f_Invoke;
        private readonly GetReturnFunc? f_GetReturn;
        private readonly DebugFunc? f_Debug;

        #endregion

        #region EFunOverload

        /// <inheritdoc/>
        public override EValue Invoke(ExprContext context, EValue[] input)
        {
            if (f_Invoke is null) return MM_DummyInvoke(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return (EValue)(object)f_Invoke(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11], (TArg12)fixedInput[12], (TArg13)fixedInput[13], (TArg14)fixedInput[14])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        /// <inheritdoc/>
        public override EType GetReturn(ExprRules rules, ENodeValueType[] input)
        {
            if (f_GetReturn is null) return MM_DummyGetReturn(rules, input);
            ArgumentNullException.ThrowIfNull(rules);
            MM_ValidateInputCount(input);
            try
            {
                return f_GetReturn(rules, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14]);
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
        }

        /// <inheritdoc/>
        public override string Debug(ExprContext context, EValue[] input)
        {
            if (f_Debug is null) return MM_DummyDebug(context, input);
            MM_ValidateInputCount(input);
            try
            {
                var fixedInput = MM_FixInput(input);
                return f_Debug(context, (TArg0)fixedInput[0], (TArg1)fixedInput[1], (TArg2)fixedInput[2], (TArg3)fixedInput[3], (TArg4)fixedInput[4], (TArg5)fixedInput[5], (TArg6)fixedInput[6], (TArg7)fixedInput[7], (TArg8)fixedInput[8], (TArg9)fixedInput[9], (TArg10)fixedInput[10], (TArg11)fixedInput[11], (TArg12)fixedInput[12], (TArg13)fixedInput[13], (TArg14)fixedInput[14])!;
            }
            catch
            {
                MM_ThrowIfInputMismatch(input);
                throw;
            }
            
        }

        #endregion
    }
}
