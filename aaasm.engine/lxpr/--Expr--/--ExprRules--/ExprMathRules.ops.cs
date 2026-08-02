// This was auto-generated from ExprMathRules.ops.cs.py
using System;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    public partial class ExprMathRules
    {
        /// <summary>Common mathematical operators</summary>
        public static readonly ImmNullDict<EMathOperator, ImmNullArray<Str>> COMMON_OPERATORS = new([
            new(EMathOperator.IMM, new([(CIStr)"#"])),
            new(EMathOperator.ADD, new([(CIStr)"+"])),
            new(EMathOperator.SUB, new([(CIStr)"-"])),
            new(EMathOperator.MUL, new([(CIStr)"*"])),
            new(EMathOperator.DIV, new([(CIStr)"/"])),
            new(EMathOperator.MOD, new([(CIStr)"%"])),
            new(EMathOperator.NEG, new([(CIStr)"-"])),
            new(EMathOperator.BITAND, new([(CIStr)"&"])),
            new(EMathOperator.BITOR, new([(CIStr)"|"])),
            new(EMathOperator.BITXOR, new([(CIStr)"^"])),
            new(EMathOperator.BITNOT, new([(CIStr)"~"])),
            new(EMathOperator.SHIFTL, new([(CIStr)"<<"])),
            new(EMathOperator.SHIFTR, new([(CIStr)">>"])),
            new(EMathOperator.SHIFTRU, new([(CIStr)">>>"])),
            new(EMathOperator.BYTELO, new([(CIStr)"<"])),
            new(EMathOperator.BYTEHI, new([(CIStr)">"])),
            new(EMathOperator.EQU, new([(CIStr)"=="])),
            new(EMathOperator.NEQ, new([(CIStr)"!="])),
            new(EMathOperator.LSS, new([(CIStr)"<"])),
            new(EMathOperator.LEQ, new([(CIStr)"<="])),
            new(EMathOperator.GTR, new([(CIStr)">"])),
            new(EMathOperator.GEQ, new([(CIStr)">="])),
            new(EMathOperator.BOOLAND, new([(CIStr)"&&"])),
            new(EMathOperator.BOOLOR, new([(CIStr)"||"])),
            new(EMathOperator.BOOLNOT, new([(CIStr)"!"])),
        ]);
    }
}
