import sys
from pathlib import Path
sys.path.append(str(Path(__file__).resolve().parent))

from Expr import\
    Type as _Type,\
    TypeKind as _TypeKind,\
    common_type as _common_type,\
    get_type as _get_type

def in_parentheses(s:str):
    if not s.startswith('('): return False
    if not s.endswith(')'): return False
    level = 0
    for i in range(1, len(s) - 1):
        match(s[i]):
            case '(': level += 1
            case ')': level -= 1
        if level < 0: return False
    return level == 0

def run(type_sffx:str):
    #region nested
    INDENT = ' ' * 4 * 2
    def _header():
        nonlocal type
        print(f"    /// <summary>{type.desc}</summary>")
        print(f"    /// <param name=\"value\">Underlying C# value</param>")
        print(f"    public class E{type.suffix}({type.cstype} value) : ", end = '')
        if type.kind == _TypeKind.FLOAT:
            print(f"ENumber<{type.cstype}>(value)")
        else:
            print(f"EInteger<{type.cstype}>(value)")
    def _operator(template:str, other_evar:str, other_var:str, default:str):
        nonlocal INDENT, type
        VALUE_A = "<VALUE_A>"
        VALUE_B = "<VALUE_B>"
        def __template_replace(target:_Type):
            nonlocal VALUE_A, VALUE_B
            nonlocal other_var
            return template\
                .replace(VALUE_A, f"{target.cstype_method}()")\
                .replace(VALUE_B, f"{other_var}.{target.cstype_method}()")
        def __int():
            nonlocal INDENT, type
            nonlocal other_evar, default
            def ___int(other:_Type):
                nonlocal type
                cmn = _common_type(type, other)
                return f"ETypeNameId.{other.suffix} => {__template_replace(cmn)},"
            def ___float(target:_Type):
                return f"ETypeNameId.{target.suffix} => {__template_replace(target)},"
            nonlocal INDENT, type
            print(f"{INDENT}    return {other_evar}.Type.NameId switch")
            print(f"{INDENT}    {{")
            print(f"{INDENT}        {___int(_get_type('U8'))}")
            print(f"{INDENT}        {___int(_get_type('I8'))}")
            print(f"{INDENT}        {___int(_get_type('U16'))}")
            print(f"{INDENT}        {___int(_get_type('I16'))}")
            print(f"{INDENT}        {___int(_get_type('U32'))}")
            print(f"{INDENT}        {___int(_get_type('I32'))}")
            print(f"{INDENT}        {___int(_get_type('U64'))}")
            print(f"{INDENT}        {___int(_get_type('I64'))}")
            print(f"{INDENT}        {___float(_get_type('F32'))}")
            print(f"{INDENT}        {___float(_get_type('F64'))}")
            print(f"{INDENT}        _ => {default}")
            print(f"{INDENT}    }};")
        def __float():
            nonlocal INDENT, type
            nonlocal other_evar
            if type.numbytes != 8:
                print(f"{INDENT}    if ({other_evar}.Type.NameId == ETypeNameId.F64)")
                print(f"{INDENT}        return {__template_replace(_get_type('F64'))};")
            print(f"{INDENT}    return {__template_replace(type)};")
        if type.kind == _TypeKind.FLOAT:
            __float()
        else:
            __int()
    def _methods():
        nonlocal INDENT, type
        pass
    def _enumber():
        nonlocal INDENT, type
        #region nested
        def __int():
            nonlocal INDENT, type
            def ___expr(other:_Type):
                nonlocal INDENT, type
                if type.suffix == other.suffix:
                    print(f"{INDENT}    Value;")
                elif type.numbytes > other.numbytes:
                    print(f"{INDENT}    unchecked(({other.cstype})(Value & {other.mask}));")
                elif type.min >= other.min and type.max <= other.max:
                    print(f"{INDENT}    Value;")
                else:
                    print(f"{INDENT}    unchecked(({other.cstype})Value);")
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override byte MM_ToByte() => ")
            ___expr(_get_type('U8'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override sbyte MM_ToSbyte() => ")
            ___expr(_get_type('I8'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override ushort MM_ToUshort() => ")
            ___expr(_get_type('U16'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override short MM_ToShort() => ")
            ___expr(_get_type('I16'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override uint MM_ToUint() => ")
            ___expr(_get_type('U32'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override int MM_ToInt() =>")
            ___expr(_get_type('I32'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override ulong MM_ToUlong() => ")
            ___expr(_get_type('U64'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override long MM_ToLong() => ")
            ___expr(_get_type('I64'))
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override float MM_ToFloat() =>")
            print(f"{INDENT}    Value;")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override double MM_ToDouble() =>")
            print(f"{INDENT}    Value;")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override Int128 MM_ToInt128() =>")
            print(f"{INDENT}    unchecked(Value);")
        def __float():
            nonlocal INDENT, type
            round = "Math.Round(Value)"
            cast_float = "(float)" if (type.numbytes != 32) else ""
            cast_double = "(double)" if (type.numbytes != 64) else ""
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override byte MM_ToByte() => ")
            print(f"{INDENT}    unchecked((byte)(((long){round}) & 0xFF));")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override sbyte MM_ToSbyte() => ")
            print(f"{INDENT}    unchecked((sbyte)(((long){round}) & 0xFF));")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override ushort MM_ToUshort() => ")
            print(f"{INDENT}    unchecked((ushort)(((long){round}) & 0xFFFF));")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override short MM_ToShort() => ")
            print(f"{INDENT}    unchecked((short)(((long){round}) & 0xFFFF));")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override uint MM_ToUint() => ")
            print(f"{INDENT}    unchecked((uint)(((long){round}) & 0xFFFFFFFF));")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override int MM_ToInt() =>")
            print(f"{INDENT}    unchecked((int)(((long){round}) & 0xFFFFFFFF));")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override ulong MM_ToUlong() => ")
            print(f"{INDENT}    unchecked((ulong)(long){round});")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override long MM_ToLong() => ")
            print(f"{INDENT}    unchecked((long){round});")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override float MM_ToFloat() =>")
            print(f"{INDENT}    {cast_float}Value;")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override double MM_ToDouble() =>")
            print(f"{INDENT}    {cast_double}Value;")
            print()
            print(f"{INDENT}/// <inheritdoc/>")
            print(f"{INDENT}private protected override Int128 MM_ToInt128() =>")
            print(f"{INDENT}    (Int128)Math.Round(Value);")
        #endregion
        #region ENumber
        print(f"{INDENT}#region ENumber")
        print()
        print(f"{INDENT}/// <inheritdoc/>")
        print(f"{INDENT}private protected override int MM_CompareTo(IENumber other)")
        print(f"{INDENT}{{")
        if (type.suffix != 'F64'):
            print(f"{INDENT}    if (other is not EValue _other) return 1;")
        _operator("<VALUE_A>.CompareTo(<VALUE_B>)", "_other", "other", "1")
        print(f"{INDENT}}}")
        print()
        print(f"{INDENT}/// <inheritdoc/>")
        print(f"{INDENT}private protected override bool MM_ToBool() => ")
        print(f"{INDENT}    Value != 0;")
        print()
        (__float if (type.kind == _TypeKind.FLOAT) else __int)()
        print()
        print(f"{INDENT}#endregion")
        #endregion
    def _einteger():
        nonlocal INDENT, type
        if type.kind == _TypeKind.FLOAT: return
        print()
        print(f"{INDENT}#region EInteger")
        print()
        print(f"{INDENT}/// <inheritdoc/>")
        print(f"{INDENT}private protected override int MM_ToShift() =>")
        if type.kind == _TypeKind.SIGNED and type.numbytes > 4:
            print(f"{INDENT}    (int)Math.Max(int.MinValue, Math.Min(int.MaxValue, Value));")
        elif type.kind == _TypeKind.UNSIGNED and type.numbytes >= 4:
            print(f"{INDENT}    (int)Math.Min(int.MaxValue, Value);")
        else:
            print(f"{INDENT}    Value;")
        print()
        print(f"{INDENT}/// <inheritdoc/>")
        print(f"{INDENT}private protected override bool MM_TryChar(out char result)")
        print(f"{INDENT}{{")
        print(f"{INDENT}    #pragma warning disable IDE0004")
        print(f"{INDENT}    result = unchecked((char)Value);")
        print(f"{INDENT}    {type.cstype} test = unchecked(({type.cstype})result);")
        print(f"{INDENT}    if (Value == test) return true;")
        print(f"{INDENT}    result = default;")
        print(f"{INDENT}    return false;")
        print(f"{INDENT}    #pragma warning restore IDE0004")
        print(f"{INDENT}}}")
        print()
        print(f"{INDENT}/// <inheritdoc/>")
        print(f"{INDENT}private protected override string MM_DebugBin() => $\"{{Value:b{type.numbytes * 8}}}\";")
        print()
        print(f"{INDENT}/// <inheritdoc/>")
        print(f"{INDENT}private protected override string MM_DebugHex() => $\"{{Value:X{type.numbytes * 2}}}\";")
        print()
        print(f"{INDENT}#endregion")
    #endregion
    type = _get_type(type_sffx)
    print(f"using System;")
    print()
    print(f"namespace aaasm.engine.lxpr")
    print(f"{{")
    _header()
    print(f"    {{")
    #region EValue
    print(f"        #region EValue")
    print()
    print(f"        /// <inheritdoc/>")
    print(f"        public override EType Type => EType.{type.suffix};")
    print()
    print(f"        /// <inheritdoc/>")
    print(f"        private protected override string MM_ToString(ExprRules? exprRules)")
    print(f"        {{")
    if type.kind != _TypeKind.FLOAT:
        print(f"            if (exprRules is not null)")
        print(f"            {{")
        print(f"                if (Type == exprRules.Literals.CharType.Type())")
        print(f"                {{")
        print(f"                    try {{ return IEInteger.MM_Chr2Str((char)Value); }}")
        print(f"                    catch {{ }}")
        print(f"                }}")
        print(f"            }}")
    print(f"            return Value.ToString();")
    print(f"        }}")
    print()
    print(f"        /// <inheritdoc/>")
    print(f"        private protected override bool MM_Equals(EValue other)")
    print(f"        {{")
    print(f"            if (other is not IENumber _other) return false;")
    _operator("<VALUE_A> == <VALUE_B>", "other", "_other", "false")
    print(f"        }}")
    print()
    print(f"        #endregion")
    #endregion
    print()
    #region ENumber, EInteger
    _enumber()
    _einteger()
    #endregion
    print()
    print(f"    }}")
    print(f"}}")
    print()