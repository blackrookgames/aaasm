// This was auto-generated from EMath.ops.cs.py
using System;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    public static partial class EMath
    {
        static EMath()
        {
            OPERATORS = new([
                new(EMathOperator.IMM, true),
                new(EMathOperator.ADD, false),
                new(EMathOperator.SUB, false),
                new(EMathOperator.MUL, false),
                new(EMathOperator.DIV, false),
                new(EMathOperator.MOD, false),
                new(EMathOperator.NEG, true),
                new(EMathOperator.BITAND, false),
                new(EMathOperator.BITOR, false),
                new(EMathOperator.BITXOR, false),
                new(EMathOperator.BITNOT, true),
                new(EMathOperator.SHIFTL, false),
                new(EMathOperator.SHIFTR, false),
                new(EMathOperator.SHIFTRU, false),
                new(EMathOperator.BYTELO, true),
                new(EMathOperator.BYTEHI, true),
                new(EMathOperator.EQU, false),
                new(EMathOperator.NEQ, false),
                new(EMathOperator.LSS, false),
                new(EMathOperator.LEQ, false),
                new(EMathOperator.GTR, false),
                new(EMathOperator.GEQ, false),
                new(EMathOperator.BOOLAND, false),
                new(EMathOperator.BOOLOR, false),
                new(EMathOperator.BOOLNOT, true),
            ]);
            UNARY = new([.. from info in OPERATORS where info.IsUnary select info]);
            BINARY = new([.. from info in OPERATORS where !info.IsUnary select info]);
        }
    }
}
