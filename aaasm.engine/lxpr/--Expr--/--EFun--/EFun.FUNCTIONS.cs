// This was auto-generated from EFun.FUNCTIONS.cs.py
using System;
using aaasm.engine.col;

#pragma warning disable IDE0047

namespace aaasm.engine.lxpr
{
    public static partial class EFun
    {
        #region const

        /// <summary>All valid expression functions</summary>
        public static EFunFunctions FUNCTIONS { get; } = new(
        [
            new(EFunFunctionId.LEN, new(
            [
                new EFunOverload<IECollection, EI32>(
                    EFunFunctionId.LEN, EFunFunc.LEN, MM_ReturnEI32, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
            ])),
            new(EFunFunctionId.GET, new(
            [
                new EFunOverload<EArray, IEInteger, EValue>(
                    EFunFunctionId.GET, EFunFunc.GET, EFunFunc.GET_r_EArray_IEInteger, 
                    (new EFunTypeParam(ETypeNameId.ARRAY)), 
                    (new EFunFlagParam(ETypeFlags.INTEGER))
                ),
                new EFunOverload<ETuple, int, EValue>(
                    EFunFunctionId.GET, EFunFunc.GET, EFunFunc.GET_r_ETuple_int, 
                    (new EFunTypeParam(ETypeNameId.TUPLE)), 
                    EFunLitModParam.PARAM
                ),
                new EFunOverload<EImmediate, EValue>(
                    EFunFunctionId.GET, EFunFunc.GET, EFunFunc.GET_r_EImmediate, 
                    (new EFunTypeParam(ETypeNameId.IMMEDIATE))
                ),
            ])),
            new(EFunFunctionId.IFELSE, new(
            [
                new EFunOverload<EValue, EValue, EValue, EValue>(
                    EFunFunctionId.IFELSE, EFunFunc.IFELSE, EFunFunc.IFELSE_r_EValue_EValue_EValue, 
                    (new EFunFlagParam(ETypeFlags.NONE)), 
                    (new EFunFlagParam(ETypeFlags.NONE)), 
                    (new EFunFlagParam(ETypeFlags.NONE))
                ),
            ])),
            new(EFunFunctionId.U8, new(
            [
                new EFunOverload<IENumber, EU8>(
                    EFunFunctionId.U8, EFunFunc.U8, MM_ReturnEU8, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.I8, new(
            [
                new EFunOverload<IENumber, EI8>(
                    EFunFunctionId.I8, EFunFunc.I8, MM_ReturnEI8, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.U16, new(
            [
                new EFunOverload<IENumber, EU16>(
                    EFunFunctionId.U16, EFunFunc.U16, MM_ReturnEU16, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.I16, new(
            [
                new EFunOverload<IENumber, EI16>(
                    EFunFunctionId.I16, EFunFunc.I16, MM_ReturnEI16, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.U32, new(
            [
                new EFunOverload<IENumber, EU32>(
                    EFunFunctionId.U32, EFunFunc.U32, MM_ReturnEU32, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.I32, new(
            [
                new EFunOverload<IENumber, EI32>(
                    EFunFunctionId.I32, EFunFunc.I32, MM_ReturnEI32, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.U64, new(
            [
                new EFunOverload<IENumber, EU64>(
                    EFunFunctionId.U64, EFunFunc.U64, MM_ReturnEU64, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.I64, new(
            [
                new EFunOverload<IENumber, EI64>(
                    EFunFunctionId.I64, EFunFunc.I64, MM_ReturnEI64, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.F32, new(
            [
                new EFunOverload<IENumber, EF32>(
                    EFunFunctionId.F32, EFunFunc.F32, MM_ReturnEF32, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.F64, new(
            [
                new EFunOverload<IENumber, EF64>(
                    EFunFunctionId.F64, EFunFunc.F64, MM_ReturnEF64, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.ARRAY, new(
            [
                new EFunOverload<IECollection, EArray>(
                    EFunFunctionId.ARRAY, EFunFunc.ARRAY, EFunFunc.ARRAY_r_IECollection, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
                new EFunOverload<int, EValue, EArray>(
                    EFunFunctionId.ARRAY, EFunFunc.ARRAY, EFunFunc.ARRAY_r_int_EValue, 
                    EFunLitModParam.PARAM, 
                    (new EFunFlagParam(ETypeFlags.NONE))
                ),
            ])),
            new(EFunFunctionId.TUPLE, new(
            [
                new EFunOverload<IECollection, ETuple>(
                    EFunFunctionId.TUPLE, EFunFunc.TUPLE, EFunFunc.TUPLE_r_IECollection, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
            ])),
            new(EFunFunctionId.MIN, new(
            [
                new EFunOverload<IENumber, IENumber, IENumber>(
                    EFunFunctionId.MIN, EFunFunc.MIN, EFunFunc.MIN_r_IENumber_IENumber, 
                    (new EFunFlagParam(ETypeFlags.NUMBER)), 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.MAX, new(
            [
                new EFunOverload<IENumber, IENumber, IENumber>(
                    EFunFunctionId.MAX, EFunFunc.MAX, EFunFunc.MAX_r_IENumber_IENumber, 
                    (new EFunFlagParam(ETypeFlags.NUMBER)), 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
            ])),
            new(EFunFunctionId.SIZEOF, new(
            [
                new EFunOverload<EValue, EI32>(
                    EFunFunctionId.SIZEOF, EFunFunc.SIZEOF, MM_ReturnEI32, 
                    (new EFunFlagParam(ETypeFlags.NONE))
                ),
            ])),
            new(EFunFunctionId.BOOL, new(
            [
                new EFunBoolOverload<EValue>(
                    EFunFunctionId.BOOL, EFunFunc.BOOL, 
                    (new EFunFlagParam(ETypeFlags.NONE))
                ),
            ])),
            new(EFunFunctionId.DBG_CHR, new(
            [
                new EFunOverload<IEInteger, EU8>(
                    EFunFunctionId.DBG_CHR, EFunFunc.DBG_CHR_d, 
                    (new EFunFlagParam(ETypeFlags.INTEGER))
                ),
                new EFunOverload<IECollection, EU8>(
                    EFunFunctionId.DBG_CHR, EFunFunc.DBG_CHR_d, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
            ])),
            new(EFunFunctionId.DBG_DEC, new(
            [
                new EFunOverload<IENumber, EU8>(
                    EFunFunctionId.DBG_DEC, EFunFunc.DBG_DEC_d, 
                    (new EFunFlagParam(ETypeFlags.NUMBER))
                ),
                new EFunOverload<IECollection, EU8>(
                    EFunFunctionId.DBG_DEC, EFunFunc.DBG_DEC_d, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
            ])),
            new(EFunFunctionId.DBG_BIN, new(
            [
                new EFunOverload<IEInteger, EU8>(
                    EFunFunctionId.DBG_BIN, EFunFunc.DBG_BIN_d, 
                    (new EFunFlagParam(ETypeFlags.INTEGER))
                ),
                new EFunOverload<IECollection, EU8>(
                    EFunFunctionId.DBG_BIN, EFunFunc.DBG_BIN_d, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
            ])),
            new(EFunFunctionId.DBG_HEX, new(
            [
                new EFunOverload<IEInteger, EU8>(
                    EFunFunctionId.DBG_HEX, EFunFunc.DBG_HEX_d, 
                    (new EFunFlagParam(ETypeFlags.INTEGER))
                ),
                new EFunOverload<IECollection, EU8>(
                    EFunFunctionId.DBG_HEX, EFunFunc.DBG_HEX_d, 
                    (new EFunFlagParam(ETypeFlags.COLLECTION))
                ),
            ])),
            new(EFunFunctionId.DBG_TYPE, new(
            [
                new EFunOverload<EValue, EU8>(
                    EFunFunctionId.DBG_TYPE, EFunFunc.DBG_TYPE_d, 
                    (new EFunFlagParam(ETypeFlags.NONE))
                ),
            ])),
        ]);

        #endregion

        #region helper methods

        private static EType MM_ReturnEU8(ExprRules rules, ENodeValueType input00) => EType.U8;
        private static EType MM_ReturnEU64(ExprRules rules, ENodeValueType input00) => EType.U64;
        private static EType MM_ReturnEI16(ExprRules rules, ENodeValueType input00) => EType.I16;
        private static EType MM_ReturnEI8(ExprRules rules, ENodeValueType input00) => EType.I8;
        private static EType MM_ReturnEI32(ExprRules rules, ENodeValueType input00) => EType.I32;
        private static EType MM_ReturnEF32(ExprRules rules, ENodeValueType input00) => EType.F32;
        private static EType MM_ReturnEF64(ExprRules rules, ENodeValueType input00) => EType.F64;
        private static EType MM_ReturnEU16(ExprRules rules, ENodeValueType input00) => EType.U16;
        private static EType MM_ReturnEI64(ExprRules rules, ENodeValueType input00) => EType.I64;
        private static EType MM_ReturnEU32(ExprRules rules, ENodeValueType input00) => EType.U32;

        #endregion
    }
}

#pragma warning restore IDE0047
