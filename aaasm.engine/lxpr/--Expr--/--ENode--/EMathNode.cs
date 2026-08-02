using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a mathematical operation</summary>
    public class EMathNode : ENode
    {
        #region nested

        private class EOpAnalNode(ExprRules rules, LexToken source, EMathOperatorInfo @operator) : 
            ENode(rules, source, default!, ImmNullArray<ENode>.EMPTY)
        {
            #region fields

            private readonly EMathOperatorInfo f_Operator = @operator;

            #endregion

            #region properties

            public EMathOperatorInfo Operator => f_Operator;

            #endregion

            #region ENode

            public override EValue Compute(ExprContext context) => throw new NotImplementedException();

            #endregion
        }

        private interface IBoolean
        {
            #region abstract properties

            /// <summary>Return type</summary>
            public EType RetType { get; }

            /// <summary>Whether or not the methods are designed to perform short-circuit evaluations</summary>
            public bool ShortCircuit { get; }

            #endregion
        }

        private class Comparer(ETypeCompareOp op, ETypeBoolConv boolConv) : IBoolean
        {
            #region fields

            private readonly ETypeCompareOp f_Op = op;
            private readonly ETypeBoolConv f_BoolConv = boolConv;

            #endregion

            #region properties

            public EType RetType => f_BoolConv.Type;
            
            public bool ShortCircuit => false;

            #endregion

            #region methods

            public EValue Lss(EValue a, EValue b) => f_BoolConv.FromBool(f_Op.Perform(a, b) < 0);
            public EValue Leq(EValue a, EValue b) => f_BoolConv.FromBool(f_Op.Perform(a, b) <= 0);
            public EValue Gtr(EValue a, EValue b) => f_BoolConv.FromBool(f_Op.Perform(a, b) > 0);
            public EValue Geq(EValue a, EValue b) => f_BoolConv.FromBool(f_Op.Perform(a, b) >= 0);

            #endregion
        }

        private class EqualCmp(ETypeBoolConv boolConv) : IBoolean
        {
            #region fields

            private readonly ETypeBoolConv f_BoolConv = boolConv;

            #endregion

            #region properties

            public EType RetType => f_BoolConv.Type;
            
            public bool ShortCircuit => false;

            #endregion

            #region methods

            public EValue Equ(EValue a, EValue b) => f_BoolConv.FromBool(a == b);
            public EValue Neq(EValue a, EValue b) => f_BoolConv.FromBool(a != b);

            #endregion
        }

        private class BoolUnary(ETypeBoolConv input, ETypeBoolConv output) : IBoolean
        {
            #region fields

            private readonly ETypeBoolConv f_Input = input;
            private readonly ETypeBoolConv f_Output = output;

            #endregion

            #region properties

            public EType RetType => f_Output.Type;
            
            public bool ShortCircuit => false;

            #endregion

            #region methods

            public EValue Not(EValue input) => f_Output.FromBool(!f_Input.ToBool(input));

            #endregion
        }

        private class BoolBinary(ETypeBoolConv inputA, ETypeBoolConv inputB, ETypeBoolConv output) : IBoolean
        {
            #region fields

            private readonly ETypeBoolConv f_InputA = inputA;
            private readonly ETypeBoolConv f_InputB = inputB;
            private readonly ETypeBoolConv f_Output = output;

            #endregion

            #region properties

            public EType RetType => f_Output.Type;
            
            public bool ShortCircuit => true;

            #endregion

            #region helper methods

            private bool MM_And(ExprContext context, ENode a, ENode b)
            {
                bool aa = f_InputA.ToBool(a.Compute(context));
                if (!aa) return false;
                bool bb = f_InputB.ToBool(b.Compute(context));
                return bb;
            }

            private bool MM_Or(ExprContext context, ENode a, ENode b)
            {
                bool aa = f_InputA.ToBool(a.Compute(context));
                if (aa) return true;
                bool bb = f_InputB.ToBool(b.Compute(context));
                return bb;
            }

            #endregion

            #region methods

            public EValue And(ExprContext context, ENode a, ENode b) => 
                f_Output.FromBool(MM_And(context, a, b));
                
            public EValue Or(ExprContext context, ENode a, ENode b) =>
                f_Output.FromBool(MM_Or(context, a, b));

            #endregion
        }

        #endregion

        #region init

        private EMathNode(ExprRules rules, LexToken source, ETypeUnaryOp op, ENode input) : 
            base(rules, source, new(op.RetType), new([input]))
        {
            f_Method = METHOD_UNARY;
            f_MethodObj = op;
            f_ShortCircuit = false;
        }

        private EMathNode(ExprRules rules, LexToken source, ETypeBinaryOp op, ENode inputA, ENode inputB) : 
            base(rules, source, new(op.RetType), new([inputA, inputB]))
        {
            f_Method = METHOD_BINARY;
            f_MethodObj = op;
            f_ShortCircuit = false;
        }

        private EMathNode(ExprRules rules, LexToken source, IBoolean boolean, MethodInfo method, ENode input) : 
            base(rules, source, new(boolean.RetType), new([input]))
        {
            f_Method = method;
            f_MethodObj = boolean;
            f_ShortCircuit = boolean.ShortCircuit;
        }

        private EMathNode(ExprRules rules, LexToken source, IBoolean boolean, MethodInfo method, ENode inputA, ENode inputB) : 
            base(rules, source, new(boolean.RetType), new([inputA, inputB]))
        {
            f_Method = method;
            f_MethodObj = boolean;
            f_ShortCircuit = boolean.ShortCircuit;
        }

        /// <summary>Parses out all mathematical operations</summary>
        /// <param name="analyzer">Analyzer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="analyzer"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid numeric/string data found
        /// </exception>
        internal static void ParseOut(ExprAnalyzer analyzer)
        {
            void parseUnary(Func<EType, ETypeUnaryOp> getOp)
            {
                var source = analyzer.Current!.Source;
                try
                {
                    var input = MM_GetValue(analyzer, 1);
                    var newNode = new EMathNode(analyzer.Rules.Expr, source,
                        getOp(input.Return.Type), input);
                    analyzer.Replace(2, newNode);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, source.RefPnt);
                }
            }
            void parseBinary(Func<EType, EType, ETypeBinaryOp> getOp)
            {
                var source = analyzer.Current!.Source;
                try
                {
                    var inputA = MM_GetValue(analyzer, -1);
                    var inputB = MM_GetValue(analyzer, 1);
                    var newNode = new EMathNode(analyzer.Rules.Expr, source, 
                        getOp(inputA.Return.Type, inputB.Return.Type), inputA, inputB);
                    analyzer.Prev();
                    analyzer.Replace(3, newNode);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, source.RefPnt);
                }
            }
            void parseCompare(Func<EType, EType, ETypeCompareOp> getOp, MethodInfo method)
            {
                var source = analyzer.Current!.Source;
                try
                {
                    var inputA = MM_GetValue(analyzer, -1);
                    var inputB = MM_GetValue(analyzer, 1);
                    Comparer comparer = new(getOp(inputA.Return.Type, inputB.Return.Type), analyzer.Rules.BoolConv);
                    var newNode = new EMathNode(analyzer.Rules.Expr, source, 
                        comparer, method, inputA, inputB);
                    analyzer.Prev();
                    analyzer.Replace(3, newNode);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, source.RefPnt);
                }
            }
            void parseEquality(MethodInfo method)
            {
                var source = analyzer.Current!.Source;
                try
                {
                    var inputA = MM_GetValue(analyzer, -1);
                    var inputB = MM_GetValue(analyzer, 1);
                    EqualCmp equalCmp = new (analyzer.Rules.BoolConv);
                    var newNode = new EMathNode(analyzer.Rules.Expr, source, 
                        equalCmp, method, inputA, inputB);
                    analyzer.Prev();
                    analyzer.Replace(3, newNode);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, source.RefPnt);
                }
            }
            void parseBoolUnary(MethodInfo method)
            {
                var source = analyzer.Current!.Source;
                try
                {
                    var input = MM_GetValue(analyzer, 1);
                    BoolUnary @bool = new (input.Return.Type.BoolConv(), analyzer.Rules.BoolConv);
                    var newNode = new EMathNode(analyzer.Rules.Expr, source, 
                        @bool, method, input);
                    analyzer.Replace(2, newNode);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, source.RefPnt);
                }
            }
            void parseBoolBinary(MethodInfo method)
            {
                var source = analyzer.Current!.Source;
                try
                {
                    var inputA = MM_GetValue(analyzer, -1);
                    var inputB = MM_GetValue(analyzer, 1);
                    BoolBinary @bool = new (inputA.Return.Type.BoolConv(), inputB.Return.Type.BoolConv(), analyzer.Rules.BoolConv);
                    var newNode = new EMathNode(analyzer.Rules.Expr, source, 
                        @bool, method, inputA, inputB);
                    analyzer.Prev();
                    analyzer.Replace(3, newNode);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, source.RefPnt);
                }
            }
            try
            {
                var retPos = analyzer.Position;
                // Look for labels (these will be nodes can't be recognized as operators)
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EAnalNode analNode) continue;
                    var raw = analNode.Source.Rough.RawData.Raw;
                    // Can this possibily be parsed as an operator?
                    var couldBeOp = analyzer.Rules.ValidOps.Contains(raw);
                    if (couldBeOp) continue;
                    // No! Is this a possible label reference?
                    if (analyzer.Rules.Expr.IsValidLabelReference(raw))
                    {
                        var labelNode = new ELabelNode(
                            analyzer.Rules.Expr,
                            analNode.Source, 
                            (string)raw,
                            analyzer.Rules.Expr.Label.Type());
                        analyzer.Replace(1, labelNode);
                        continue;
                    }
                    // No!
                    throw BadSrcException.Unexpected((string)raw, analNode.Source.RefPnt);
                }
                // Look thru the remaining unanalyzed nodes
                for (analyzer.Position = analyzer.Count - 1; analyzer.Position >= 0; analyzer.Prev())
                {
                    if (analyzer.Current is not EAnalNode analNode) continue;
                    // Is this a unary or binary operator?
                    bool unary = analyzer.Position == 0 || analyzer[analyzer.Position - 1] is EAnalNode;
                    var validOps = unary ? analyzer.Rules.UnaryOps : analyzer.Rules.BinaryOps;
                    if (!validOps.TryGetValue(
                        analNode.Source.Rough.RawData.Raw, 
                        out var @operator))
                    {
                        throw new BadSrcException(
                            $"Invalid {(unary ? "unary" : "binary")} operator: {analNode.Source.Rough.RawData.Raw}",
                            analNode.Source.RefPnt);
                    }
                    // Replace
                    analyzer.Replace(1, new EOpAnalNode(analyzer.Rules.Expr, analNode.Source, @operator));
                }
                // Unary
                for (analyzer.Position = analyzer.Count - 1; analyzer.Position >= 0; analyzer.Prev())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.IMM:
                            parseUnary(MM_GetOp_Imm);
                            break;
                        case EMathOperator.NEG:
                            parseUnary(t => t.Neg());
                            break;
                        case EMathOperator.BITNOT:
                            parseUnary(t => t.BitNot());
                            break;
                        case EMathOperator.BYTELO:
                            parseUnary(t => t.ByteLo());
                            break;
                        case EMathOperator.BYTEHI:
                            parseUnary(t => t.ByteHi());
                            break;
                        case EMathOperator.BOOLNOT:
                            parseBoolUnary(METHOD_BOOLNOT);
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Multiplication, division, modulus
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.MUL:
                            parseBinary((a, b) => a.Mul(b));
                            break;
                        case EMathOperator.DIV:
                            parseBinary((a, b) => a.Div(b));
                            break;
                        case EMathOperator.MOD:
                            parseBinary((a, b) => a.Mod(b));
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Addition, subtraction
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.ADD:
                            parseBinary((a, b) => a.Add(b));
                            break;
                        case EMathOperator.SUB:
                            parseBinary((a, b) => a.Sub(b));
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Bit-shift
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.SHIFTL:
                            parseBinary((a, b) => a.ShiftL(b));
                            break;
                        case EMathOperator.SHIFTR:
                            parseBinary((a, b) => a.ShiftR(b));
                            break;
                        case EMathOperator.SHIFTRU:
                            parseBinary((a, b) => a.ShiftRU(b));
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Bitwise
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.BITAND:
                            parseBinary((a, b) => a.BitAnd(b));
                            break;
                        case EMathOperator.BITOR:
                            parseBinary((a, b) => a.BitOr(b));
                            break;
                        case EMathOperator.BITXOR:
                            parseBinary((a, b) => a.BitXor(b));
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Comparer
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.LSS:
                            parseCompare((a, b) => a.Cmp(b), METHOD_LSS);
                            break;
                        case EMathOperator.LEQ:
                            parseCompare((a, b) => a.Cmp(b), METHOD_LEQ);
                            break;
                        case EMathOperator.GTR:
                            parseCompare((a, b) => a.Cmp(b), METHOD_GTR);
                            break;
                        case EMathOperator.GEQ:
                            parseCompare((a, b) => a.Cmp(b), METHOD_GEQ);
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Equality
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.EQU:
                            parseEquality(METHOD_EQU);
                            break;
                        case EMathOperator.NEQ:
                            parseEquality(METHOD_NEQ);
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Boolean
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    switch (opAnalNode.Operator.Operator)
                    {
                        case EMathOperator.BOOLAND:
                            parseBoolBinary(METHOD_BOOLAND);
                            break;
                        case EMathOperator.BOOLOR:
                            parseBoolBinary(METHOD_BOOLOR);
                            break;
                        default: goto next;
                    }
                    next: continue;
                }
                // Any operators left (this shouldn't happen)?
                for (analyzer.Position = 0; analyzer.Position < analyzer.Count; analyzer.Next())
                {
                    if (analyzer.Current is not EOpAnalNode opAnalNode) continue;
                    string opType = opAnalNode.Operator.IsUnary ? "unary" : "binary";
                    Str opSymbol = opAnalNode.Source.Rough.RawData.Raw;
                    throw new BadSrcException($"The {opType} operator {opSymbol} is not currently supported.");
                }
                // Success!!!
                analyzer.Position = retPos;
            }
            catch when (analyzer is null)
            {
                throw new ArgumentNullException(nameof(analyzer));
            }
        }

        #endregion

        #region const

        private static readonly MethodInfo METHOD_UNARY = 
            typeof(ETypeUnaryOp).GetMethod(nameof(ETypeUnaryOp.Perform))!;
        private static readonly MethodInfo METHOD_BINARY = 
            typeof(ETypeBinaryOp).GetMethod(nameof(ETypeBinaryOp.Perform))!;
        private static readonly MethodInfo METHOD_LSS = 
            typeof(Comparer).GetMethod(nameof(Comparer.Lss))!;
        private static readonly MethodInfo METHOD_LEQ = 
            typeof(Comparer).GetMethod(nameof(Comparer.Leq))!;
        private static readonly MethodInfo METHOD_GTR = 
            typeof(Comparer).GetMethod(nameof(Comparer.Gtr))!;
        private static readonly MethodInfo METHOD_GEQ = 
            typeof(Comparer).GetMethod(nameof(Comparer.Geq))!;
        private static readonly MethodInfo METHOD_EQU = 
            typeof(EqualCmp).GetMethod(nameof(EqualCmp.Equ))!;
        private static readonly MethodInfo METHOD_NEQ = 
            typeof(EqualCmp).GetMethod(nameof(EqualCmp.Neq))!;
        private static readonly MethodInfo METHOD_BOOLAND = 
            typeof(BoolBinary).GetMethod(nameof(BoolBinary.And))!;
        private static readonly MethodInfo METHOD_BOOLOR = 
            typeof(BoolBinary).GetMethod(nameof(BoolBinary.Or))!;
        private static readonly MethodInfo METHOD_BOOLNOT = 
            typeof(BoolUnary).GetMethod(nameof(BoolUnary.Not))!;

        #endregion

        #region fields

        private readonly MethodInfo f_Method;
        private readonly object f_MethodObj;
        private readonly bool f_ShortCircuit;

        #endregion

        #region helper methods

        private static ENode MM_GetValue(ExprAnalyzer analyzer, int relPos)
        {
            RefPnt? refPnt = null;
            int index = analyzer.Position + relPos;
            if (index >= 0 && index < analyzer.Count)
            {
                ENode node = analyzer[index];
                if (!(node is EAnalNode || node is EOpAnalNode))
                    return node;
                refPnt = node.Source.RefPnt;
            }
            else if (analyzer.Position >= 0 && analyzer.Position < analyzer.Count)
            {
                refPnt = analyzer.Current!.Source.RefPnt;
            }
            throw new BadSrcException(
                "Expected a literal, array, tuple, parentheses, or function call.", 
                refPnt);
        }

        private static ETypeUnaryOp MM_GetOp_Imm(EType type) => 
            new (type, EType.Immediate(type), element => new EImmediate(element));

        #endregion

        #region ENode

        /// <inheritdoc/>
        public override EValue Compute(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            try
            {
                if (f_ShortCircuit)
                {
                    return (EValue)f_Method.Invoke(f_MethodObj, [
                        context, ..Children])!;
                }
                else
                {
                    return (EValue)f_Method.Invoke(f_MethodObj, [..
                        from child in Children
                        select child.Compute(context)])!;
                }
            }
            catch (Exception e) when (TryUtil.TryFind<BadSrcException>(e, out var ee))
            {
                throw ee;
            }
            catch (Exception e) when (TryUtil.TryFind<EValueException>(e, out var ee))
            {
                throw new BadSrcException(ee.Message, Source.RefPnt);
            }
        }

        #endregion
    }
}
