using System;

using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.lxpr
{
    public abstract partial class EType
    {
        #region protected methods

        private EValueException MM_CannotOp(string op) =>
            new($"Cannot perform {op} operation on {GetName()}.");
        private EValueException MM_CannotOp(string op, EType other) =>
            new($"Cannot perform {op} operation on {GetName()} and {other.GetName()}.");

        private protected static EValue MM_ValidateType(EValue arg, EType type,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            try
            {
                if (arg.Type == type) return arg;
                throw new ArgumentException($"{param}.Type must equal {type}.", param);
            }
            catch when (arg is null)
            {
                throw new ArgumentNullException(param);
            }
        }

        private protected EValueException MM_CannotBoolConv() =>
            new($"Cannot convert from {GetName()} to boolean.");
        
        private protected EValueException MM_CannotConvert(EType output) =>
            new($"Cannot convert from {GetName()} to {output.GetName()}.");
            
        private protected EValueException MM_CannotCmp(EType other) =>
            new($"Cannot compare {GetName()} to {other.GetName()}.");

        private protected EValueException MM_CannotAdd(EType other) =>
            new($"Cannot add {GetName()} to {other.GetName()}.");
        private protected EValueException MM_CannotSub(EType other) =>
            new($"Cannot subtract {GetName()} from {other.GetName()}.");
        private protected EValueException MM_CannotMul(EType other) =>
            new($"Cannot multiply {GetName()} by {other.GetName()}.");
        private protected EValueException MM_CannotDiv(EType other) =>
            new($"Cannot divide {GetName()} by {other.GetName()}.");
        private protected EValueException MM_CannotMod(EType other) =>
            new($"Cannot divide {GetName()} by {other.GetName()}."); // I don't know how else to describe it
        private protected EValueException MM_CannotNeg() =>
            new($"Cannot negate {GetName()}.");
        private protected EValueException MM_CannotBitAnd(EType other) =>
            MM_CannotOp("bitwise AND", other);
        private protected EValueException MM_CannotBitOr(EType other) =>
            MM_CannotOp("bitwise OR", other);
        private protected EValueException MM_CannotBitXor(EType other) =>
            MM_CannotOp("bitwise XOR", other);
        private protected EValueException MM_CannotBitNot() =>
            new($"Cannot perform bitwise NOT on {GetName()}.");
        private protected EValueException MM_CannotShiftL(EType other) =>
            MM_CannotOp("left-shift", other);
        private protected EValueException MM_CannotShiftR(EType other) =>
            MM_CannotOp("right-shift", other);
        private protected EValueException MM_CannotShiftRU(EType other) =>
            MM_CannotOp("unsigned right-shift", other);
        private protected EValueException MM_CannotByteHi() =>
            MM_CannotOp("hi-byte");
        private protected EValueException MM_CannotByteLo() =>
            MM_CannotOp("lo-byte");

        #endregion

        #region abstract methods

        /// <summary>Computes the human-readable name of the type</summary>
        /// <returns>Human-readable name of type</returns>
        public abstract string GetName();

        /// <summary>Retrieves a boolean converter</summary>
        /// <returns>Retrieved converter</returns>
        /// <exception cref="EValueException">
        ///     Cannot perform boolean conversion
        /// </exception>
        public virtual ETypeBoolConv BoolConv() => throw MM_CannotBoolConv();

        /// <summary>
        ///     Retrieves an comparison operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform comparison between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeCompareOp Cmp(EType other) => throw MM_CannotCmp(other);

        /// <summary>
        ///     Retrieves an addition operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform addition between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp Add(EType other) => throw MM_CannotAdd(other);

        /// <summary>
        ///     Retrieves a subtraction operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform subtraction between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp Sub(EType other) => throw MM_CannotSub(other);

        /// <summary>
        ///     Retrieves a multiplication operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform multiplication between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp Mul(EType other) => throw MM_CannotMul(other);

        /// <summary>
        ///     Retrieves a division operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform division between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp Div(EType other) => throw MM_CannotDiv(other);

        /// <summary>
        ///     Retrieves a modulus operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform modulus between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp Mod(EType other) => throw MM_CannotMod(other);

        /// <summary>Retrieves a negation operator</summary>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="EValueException">
        ///     Cannot perform negation operation
        /// </exception>
        public virtual ETypeUnaryOp Neg() => throw MM_CannotNeg();

        /// <summary>
        ///     Retrieves a bitwise-AND operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform a bitwise-AND operation between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp BitAnd(EType other) => throw MM_CannotBitAnd(other);

        /// <summary>
        ///     Retrieves an bitwise-OR operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform a bitwise-OR operation between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp BitOr(EType other) => throw MM_CannotBitOr(other);

        /// <summary>
        ///     Retrieves a bitwise-XOR operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform a bitwise-XOR operation between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp BitXor(EType other) => throw MM_CannotBitXor(other);

        /// <summary>Retrieves a bitwise NOT operator</summary>
        /// <returns>Retrieved converter</returns>
        /// <exception cref="EValueException">
        ///     Cannot perform bitwise NOT operation
        /// </exception>
        public virtual ETypeUnaryOp BitNot() => throw MM_CannotBitNot();

        /// <summary>
        ///     Retrieves a left-shift operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform a left-shift operation between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp ShiftL(EType other) => throw MM_CannotShiftL(other);

        /// <summary>
        ///     Retrieves a signed right-shift operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform a signed right-shift operation between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp ShiftR(EType other) => throw MM_CannotShiftR(other);

        /// <summary>
        ///     Retrieves an unsigned right-shift operator 
        ///     for the current type and specified other type
        /// </summary>
        /// <param name="other">Other type</param>
        /// <returns>Retrieved operator</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="other"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Cannot perform an unsigned right-shift operation between 
        ///     the current type and <paramref name="other"/>
        /// </exception>
        public virtual ETypeBinaryOp ShiftRU(EType other) => throw MM_CannotShiftRU(other);

        /// <summary>Retrieves a lo-byte operator</summary>
        /// <returns>Retrieved converter</returns>
        /// <exception cref="EValueException">
        ///     Cannot perform lo-byte operation
        /// </exception>
        public virtual ETypeUnaryOp ByteLo() => throw MM_CannotByteLo();

        /// <summary>Retrieves a hi-byte operator</summary>
        /// <returns>Retrieved converter</returns>
        /// <exception cref="EValueException">
        ///     Cannot perform hi-byte operation
        /// </exception>
        public virtual ETypeUnaryOp ByteHi() => throw MM_CannotByteHi();

        #endregion
    
        #region virtual methods

        /// <summary>Generates a string representation of the expression value type</summary>
        /// <param name="context">Expression context</param>
        /// <returns>Generated string</returns>
        public virtual string ToString(ExprContext? context)
        {
            return NameId.ToString();
        }

        #endregion
    }
}
