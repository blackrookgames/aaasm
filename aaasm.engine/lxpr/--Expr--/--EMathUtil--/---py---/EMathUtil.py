import sys
from pathlib import Path
sys.path.append(str(Path(__file__).resolve().parent))
sys.path.append(str(Path(__file__).resolve().parent.parent.parent.joinpath("---py---")))

from collections.abc import\
    Iterable as _Iterable

import help

from Expr import Type as _Type # type: ignore
from Expr import TypeKind as _TypeKind # type: ignore
from Expr import common_type as _common_type # type: ignore
from Expr import convert as _convert # type: ignore
from Expr import dominant_type as _dominant_type # type: ignore
from Expr import get_type as _get_type # type: ignore

def try_open(o:help.Outputter):
    o.print(f"try")
    o.print(f"{{")
    o.indent_inc()

def try_close(o:help.Outputter, nullparams:None|_Iterable[str] = None):
    catched = False
    o.indent_dec()
    o.print(f"}}")
    # ArgumentNullException
    if nullparams is not None:
        for nullparam in nullparams:
            o.print(f"catch when ({nullparam} is null)")
            o.print(f"{{ throw new ArgumentNullException(nameof({nullparam})); }}")
            catched = True
    # May sure there's a catch
    if not catched: o.print(f"catch {{ }}")

def run(type_sffx:str, override_neg:None|str = None):
    #region nested
    INDENT = ' ' * 4 * 2
    MODTYPE = "public static IENumber"
    def _header():
        nonlocal o, type
        o.print(f"    public partial class EMathUtil")
    def _unary(suffix:str, desc:str, template:str):
        nonlocal INDENT, o, type
        def __template(template:str, value:str):
            TEMP_VALUE = "<VALUE>"
            return template.replace(TEMP_VALUE, value)
        mathtype = _get_type(type.mathtype)
        tempexpr = __template(template, "input.Value")
        fullexpr = f"new E{type.suffix}({_convert(mathtype, type, tempexpr)})"
        # region start
        o.print(f"#region {desc}")
        o.print(f"")
        # header
        o.print(f"/// <summary>{desc}</summary>")
        o.print(f"/// <param name=\"input\">Input</param>")
        o.print(f"/// <returns>Result</returns>")
        o.print(f"/// <exception cref=\"ArgumentNullException\">")
        o.print(f"///     <paramref name=\"input\"/> is null")
        o.print(f"/// </exception>")
        # body open
        o.print(f"{MODTYPE} {suffix}(E{type.suffix} input)")
        o.print(f"{{")
        o.indent_inc()
        try_open(o)
        # body main
        o.print(f"return {fullexpr};")
        # body close
        try_close(o, nullparams = [ "input" ])
        o.indent_dec()
        o.print(f"}}")
        # region end
        o.print(f"")
        o.print(f"#endregion")
    def _binary(suffix:str, desc:str, template:str, no_float:bool = False, div:bool = False, shift:bool = False):
        nonlocal INDENT, o, type
        def __template(value_a:str, value_b:str):
            nonlocal template
            TEMP_VALUE_A = "<VALUE_A>"
            TEMP_VALUE_B = "<VALUE_B>"
            return template.replace(TEMP_VALUE_A, value_a).replace(TEMP_VALUE_B, value_b)
        def __common(other:_Type):
            nonlocal type
            if type.kind == _TypeKind.FLOAT:
                if other.kind == _TypeKind.FLOAT:
                    if type.suffix == other.suffix: return type
                    return _get_type('F64')
                else:
                    return type
            if other.kind == _TypeKind.FLOAT:
                return other
            return _common_type(type, other)
        def __create(other:_Type):
            nonlocal INDENT, o, type, div
            dominant = _dominant_type(type, other)
            mathtype = _get_type(__common(other).mathtype)
            # header
            o.print(f"/// <summary>{desc}</summary>")
            o.print(f"/// <param name=\"a\">Input A</param>")
            o.print(f"/// <param name=\"b\">Input B</param>")
            o.print(f"/// <returns>Result</returns>")
            o.print(f"/// <exception cref=\"ArgumentNullException\">")
            o.print(f"///     <paramref name=\"a\"/> is null")
            o.print(f"///     <br/>or<br/>")
            o.print(f"///     <paramref name=\"b\"/> is null")
            o.print(f"/// </exception>")
            if div:
                o.print(f"/// <exception cref=\"EValueException\">")
                o.print(f"///     <paramref name=\"b\"/>.Value == 0")
                o.print(f"/// </exception>")
            # body open
            o.print(f"{MODTYPE} {suffix}(E{type.suffix} a, E{other.suffix} b)")
            o.print(f"{{")
            o.indent_inc()
            try_open(o)
            # body main
            tempexpr = __template("aa", "bb")
            o.print(f"var aa = a.{mathtype.cstype_method}();")
            o.print(f"var bb = b.{"ToShift" if shift else f"{mathtype.cstype_method}"}();")
            if div: o.print(f"if (bb == 0) throw new EValueException(\"Division by zero\");")
            o.print(f"return new E{dominant.suffix}({_convert(mathtype, dominant, tempexpr)});")
            # body close
            try_close(o, nullparams = [ "a", "b" ])
            o.indent_dec()
            o.print(f"}}")
        o.print(f"#region {desc}")
        o.print(f"")
        __create(_get_type('U8'))
        o.print(f"")
        __create(_get_type('I8'))
        o.print(f"")
        __create(_get_type('U16'))
        o.print(f"")
        __create(_get_type('I16'))
        o.print(f"")
        __create(_get_type('U32'))
        o.print(f"")
        __create(_get_type('I32'))
        o.print(f"")
        __create(_get_type('U64'))
        o.print(f"")
        __create(_get_type('I64'))
        if not no_float:
            o.print(f"")
            __create(_get_type('F32'))
            o.print(f"")
            __create(_get_type('F64'))
        o.print(f"")
        o.print(f"#endregion")
    def _negation(suffix:str, desc:str, template:str, override:None|str = None):
        nonlocal INDENT, o, type
        def __template(template:str, value:str):
            TEMP_VALUE = "<VALUE>"
            return template.replace(TEMP_VALUE, value)
        mathtype = _get_type(type.mathtype)
        rettype = type.get_signtype()
        tempexpr = __template(template if (override is None) else override, "input.Value")
        fullexpr = tempexpr if (override is not None) else\
            f"new E{rettype.suffix}({_convert(mathtype, rettype, tempexpr)})"
        # region start
        o.print(f"#region {desc}")
        o.print(f"")
        # header
        o.print(f"/// <summary>{desc}</summary>")
        o.print(f"/// <param name=\"input\">Input</param>")
        o.print(f"/// <returns>Result</returns>")
        o.print(f"/// <exception cref=\"ArgumentNullException\">")
        o.print(f"///     <paramref name=\"input\"/> is null")
        o.print(f"/// </exception>")
        # body open
        o.print(f"{MODTYPE} {suffix}(E{type.suffix} input)")
        o.print(f"{{")
        o.indent_inc()
        try_open(o)
        # body main
        o.print(f"return {fullexpr};")
        # body close
        try_close(o, nullparams = [ "input" ])
        o.indent_dec()
        o.print(f"}}")
        # region end
        o.print(f"")
        o.print(f"#endregion")
    def _bytelh(suffix:str, desc:str, template:str):
        nonlocal INDENT, o, type
        def __template(template:str, value:str):
            TEMP_VALUE = "<VALUE>"
            return template.replace(TEMP_VALUE, value)
        rettype = _get_type('U8')
        mathtype = _get_type(type.mathtype)
        tempexpr = __template(template, "input.Value")
        fullexpr = f"new E{rettype.suffix}({_convert(mathtype, rettype, tempexpr)})"
        # region start
        o.print(f"#region {desc}")
        o.print(f"")
        # header
        o.print(f"/// <summary>{desc}</summary>")
        o.print(f"/// <param name=\"input\">Input</param>")
        o.print(f"/// <returns>Result</returns>")
        o.print(f"/// <exception cref=\"ArgumentNullException\">")
        o.print(f"///     <paramref name=\"input\"/> is null")
        o.print(f"/// </exception>")
        # body open
        o.print(f"{MODTYPE} {suffix}(E{type.suffix} input)")
        o.print(f"{{")
        o.indent_inc()
        try_open(o)
        # body main
        o.print(f"return {fullexpr};")
        # body close
        try_close(o, nullparams = [ "input" ])
        o.indent_dec()
        o.print(f"}}")
        # region end
        o.print(f"")
        o.print(f"#endregion")
    #endregion
    o = help.Outputter()
    type = _get_type(type_sffx)
    o.print(f"using System;")
    o.print(f"")
    o.print(f"#pragma warning disable IDE0047")
    o.print(f"")
    o.print(f"namespace aaasm.engine.lxpr")
    o.print(f"{{")
    _header()
    o.print(f"    {{")
    o.indent = 2
    _binary("Add", "Addition", "(<VALUE_A> + <VALUE_B>)")
    o.print(f"")
    _binary("Sub", "Subtraction", "(<VALUE_A> - <VALUE_B>)")
    o.print(f"")
    _binary("Mul", "Multiplication", "(<VALUE_A> * <VALUE_B>)")
    o.print(f"")
    _binary("Div", "Division", "(<VALUE_A> / <VALUE_B>)", div = True)
    o.print(f"")
    _binary("Mod", "Modulus", "(<VALUE_A> % <VALUE_B>)", div = True)
    o.print(f"")
    _negation("Neg", "Negation", "(-<VALUE>)", override = override_neg)
    if type.kind != _TypeKind.FLOAT:
        o.print(f"")
        _binary("BitAnd", "Bitwise-AND", "(<VALUE_A> & <VALUE_B>)", no_float = True)
        o.print(f"")
        _binary("BitOr", "Bitwise-OR", "(<VALUE_A> | <VALUE_B>)", no_float = True)
        o.print(f"")
        _binary("BitXor", "Bitwise-XOR", "(<VALUE_A> ^ <VALUE_B>)", no_float = True)
        o.print(f"")
        _unary("BitNot", "Bitwise-NOT", "(~<VALUE>)")
        o.print(f"")
        _binary("ShiftL", "Left-Shift", "(<VALUE_A> << <VALUE_B>)", no_float = True, shift = True)
        o.print(f"")
        _binary("ShiftR", "Signed right-Shift", "(<VALUE_A> >> <VALUE_B>)", no_float = True, shift = True)
        o.print(f"")
        _binary("ShiftRU", "Unsigned right-Shift", "(<VALUE_A> >>> <VALUE_B>)", no_float = True, shift = True)
        if type.numbytes == 2:
            o.print(f"")
            _bytelh("ByteLo", "Lo-byte", "(<VALUE> & 0xFF)")
            o.print(f"")
            _bytelh("ByteHi", "Hi-byte", "((<VALUE> >> 8) & 0xFF)")
    o.indent = 0
    o.print(f"    }}")
    o.print(f"}}")
    o.print(f"")
    o.print(f"#pragma warning restore IDE0047")
    o.print(f"")