import sys
from pathlib import Path
sys.path.append(str(Path(__file__).resolve().parent))

from help import\
    Outputter as _Outputter

from Expr import\
    convert as _convert,\
    dominant_type as _dominant_type,\
    get_type as _get_type,\
    TypeKind as _TypeKind,\
    TYPES as _TYPES

def run(type_sffx:str):
    #region nested
    def _dict_binary(method_id:str, no_float:bool = False):
        nonlocal o, type
        o.print(f"private static readonly ImmNullDict<EType, ETypeBinaryOp> {method_id.upper()}_OPS = new([", end = '')
        if len(_TYPES) > 0:
            o.print(f"")
            o.indent_inc()
            for t in _TYPES.iter_values():
                if no_float and t.kind == _TypeKind.FLOAT:
                    continue
                dom = _dominant_type(type, t)
                o.print("new({1}, new({0}, {1}, {2}, (a, b) => "\
                    .format(type.suffix, t.suffix, dom.suffix))
                o.print("    (EValue)EMathUtil.{0}((E{1})MM_ValidateType(a, {1}), (E{2})MM_ValidateType(b, {2})))),"\
                    .format(method_id, type.suffix, t.suffix))
            o.indent_dec()
        o.print(f"]);")
    def _method_unary(method_id:str, rettype:None|str = None):
        nonlocal o, type
        o.print(f"/// <inheritdoc/>")
        o.print(f"public override ETypeUnaryOp {method_id}() => ")
        o.print("    new({0}, {2}, a => (EValue)EMathUtil.{1}((E{0})MM_ValidateType(a, {0})));"\
            .format(type.suffix, method_id, type.suffix if (rettype is None) else rettype))
    def _method_binary(method_id:str):
        nonlocal o
        o.print(f"/// <inheritdoc/>")
        o.print(f"public override ETypeBinaryOp {method_id}(EType other)")
        o.print(f"{{")
        o.print(f"    if ({method_id.upper()}_OPS.TryGetValue(other, out var op)) return op;")
        o.print(f"    throw MM_Cannot{method_id}(other);")
        o.print(f"}}")
    def _method_shift(method_id:str):
        nonlocal o
        o.print(f"/// <inheritdoc/>")
        o.print(f"public override ETypeBinaryOp {method_id}(EType other)")
        o.print(f"{{")
        o.print(f"if (!other.IsInteger()) throw MM_Cannot{method_id}(other);")
        o.print(f"    return new({type.suffix}, other, {type.suffix},")
        o.print(f"        (input, amount) => (EValue)EMathUtil.{method_id}(")
        o.print(f"        (E{type.suffix})MM_ValidateType(input, {type.suffix}),")
        o.print(f"        (IEInteger)MM_ValidateType(amount, other)));")
        o.print(f"}}")
    #endregion
    type = _get_type(type_sffx)
    flags = f"ETypeFlags.NUMBER{"" if (type.kind == _TypeKind.FLOAT) else " | ETypeFlags.INTEGER"}"
    o = _Outputter()
    o.print(f"using System;")
    o.print(f"using aaasm.engine.col;")
    o.print(f"")
    o.print(f"#pragma warning disable IDE0047")
    o.print(f"")
    o.print(f"namespace aaasm.engine.lxpr")
    o.print(f"{{")
    o.print(f"    /// <summary>{type.desc}</summary>")
    o.print(f"    public class EType{type.suffix} : EType")
    o.print(f"    {{")
    o.indent = 2

    #region init

    o.print(f"#region init")
    o.print(f"")

    o.print(f"private EType{type.suffix}() : ")
    o.print(f"    base(ETypeNameId.{type.suffix}, FLAGS, {type.numbytes}, 0, null, ImmNullArray<EType>.EMPTY)")
    o.print(f"{{ }}")
    o.print(f"")

    o.print(f"#endregion")

    #endregion

    o.print(f"")

    #region const

    o.print(f"#region const")
    o.print(f"")

    o.print(f"private const ETypeFlags FLAGS = {flags};")
    o.print(f"")

    o.print(f"/// <summary>{type.name}</summary>")
    o.print(f"public static EType{type.suffix} TYPE {{ get; }} = new();")
    o.print(f"")
    
    o.print(f"private static readonly ImmNullDict<EType, ETypeCompareOp> CMP_OPS = new([", end = '')
    if len(_TYPES) > 0:
        o.print(f"")
        o.indent_inc()
        for t in _TYPES.iter_values():
            o.print("new({1}, new({0}, {1}, (a, b) => "\
                .format(type.suffix, t.suffix))
            o.print("    ((E{0})MM_ValidateType(a, {0})).CompareTo((E{1})MM_ValidateType(b, {1})))),"\
                .format(type.suffix, t.suffix))
        o.indent_dec()
    o.print(f"]);")
    o.print(f"")

    _dict_binary("Add")
    o.print(f"")
    _dict_binary("Sub")
    o.print(f"")
    _dict_binary("Mul")
    o.print(f"")
    _dict_binary("Div")
    o.print(f"")
    _dict_binary("Mod")
    o.print(f"")
    if type.kind != _TypeKind.FLOAT:
        _dict_binary("BitAnd", no_float = True)
        o.print(f"")
        _dict_binary("BitOr", no_float = True)
        o.print(f"")
        _dict_binary("BitXor", no_float = True)
        o.print(f"")

    o.print(f"#endregion")

    #endregion

    o.print(f"")

    #region EType

    o.print(f"#region EType")
    o.print(f"")

    o.print(f"/// <inheritdoc/>")
    o.print(f"public override string GetName() => \"{type.name}\";")
    o.print(f"")

    o.print(f"/// <inheritdoc/>")
    o.print(f"public override ETypeBoolConv BoolConv() => ")
    o.print("    new({0}, a => ((E{0})MM_ValidateType(a, {0})).Value != 0, a => new E{0}({1}));".format(\
        type.suffix, _convert(_TYPES['I32'], type, "(a ? 1 : 0)")))
    o.print(f"")

    o.print(f"/// <inheritdoc/>")
    o.print(f"public override ETypeCompareOp Cmp(EType other)")
    o.print(f"{{")
    o.print(f"    if (CMP_OPS.TryGetValue(other, out var op)) return op;")
    o.print(f"    throw MM_CannotCmp(other);")
    o.print(f"}}")
    o.print(f"")

    _method_binary("Add")
    o.print(f"")
    _method_binary("Sub")
    o.print(f"")
    _method_binary("Mul")
    o.print(f"")
    _method_binary("Div")
    o.print(f"")
    _method_binary("Mod")
    o.print(f"")
    _method_unary("Neg", rettype = type.signtype)
    o.print(f"")
    if type.kind != _TypeKind.FLOAT:
        _method_binary("BitAnd")
        o.print(f"")
        _method_binary("BitOr")
        o.print(f"")
        _method_binary("BitXor")
        o.print(f"")
        _method_unary("BitNot")
        o.print(f"")
        _method_shift("ShiftL")
        o.print(f"")
        _method_shift("ShiftR")
        o.print(f"")
        _method_shift("ShiftRU")
        o.print(f"")
        if type.numbytes == 2:
            _method_unary("ByteLo", rettype = "U8")
            o.print(f"")
            _method_unary("ByteHi", rettype = "U8")
            o.print(f"")

    o.print(f"#endregion")

    #endregion

    o.indent = 0
    o.print(f"    }}")
    o.print(f"}}")
    o.print(f"")
    o.print(f"#pragma warning restore IDE0047")