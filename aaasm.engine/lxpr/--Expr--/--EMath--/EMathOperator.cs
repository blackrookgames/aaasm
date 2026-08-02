// This was auto-generated from EMathOperator.cs.py

using System;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a mathematical operator</summary>
    public enum EMathOperator : byte
    {
        /// <summary>Immediate operator</summary>
        IMM,

        /// <summary>Addition operator</summary>
        ADD,

        /// <summary>Subtraction operator</summary>
        SUB,

        /// <summary>Multiplication operator</summary>
        MUL,

        /// <summary>Division operator</summary>
        DIV,

        /// <summary>Modulus operator</summary>
        MOD,

        /// <summary>Negation operator</summary>
        NEG,

        /// <summary>Bitwise-AND operator</summary>
        BITAND,

        /// <summary>Bitwise-OR operator</summary>
        BITOR,

        /// <summary>Bitwise-XOR operator</summary>
        BITXOR,

        /// <summary>Bitwise-NOT operator</summary>
        BITNOT,

        /// <summary>Left-shift operator</summary>
        SHIFTL,

        /// <summary>Signed right-shift operator</summary>
        SHIFTR,

        /// <summary>Unsigned right-shift operator</summary>
        SHIFTRU,

        /// <summary>Lo-byte operator</summary>
        BYTELO,

        /// <summary>Hi-byte operator</summary>
        BYTEHI,

        /// <summary>Equality operator</summary>
        EQU,

        /// <summary>Inequality operator</summary>
        NEQ,

        /// <summary>Less-than operator</summary>
        LSS,

        /// <summary>Less-than-or-equal-to operator</summary>
        LEQ,

        /// <summary>Greater-than operator</summary>
        GTR,

        /// <summary>Greater-than-or-equal-to operator</summary>
        GEQ,

        /// <summary>Boolean-AND operator</summary>
        BOOLAND,

        /// <summary>Boolean-OR operator</summary>
        BOOLOR,

        /// <summary>Boolean-NOT operator</summary>
        BOOLNOT,
    }

    public static class EMathOperator_ext
    {
        /// <summary>Retrieves information about the specified operator</summary>
        public static EMathOperatorInfo About(this EMathOperator @operator)
        {
            return EMath.OPERATORS.Get(@operator);
        }
    }
}
