import sys

from pathlib import Path
from help import Outputter
from ioutil import PathUtil
from typing import cast

_file_path = Path(__file__).resolve()
_file_dir = _file_path.parent
_expr_dir = cast(Path, PathUtil.find_parent_name(_file_path, "--Expr--"))
sys.path.append(str(_expr_dir.joinpath("---py---")))

from Expr import TypeKind, TYPES # type: ignore

o = Outputter()
o.print("using System;")
o.print("using aaasm.engine.col;")
o.print()
o.print("namespace aaasm.engine.lxpr")
o.print("{")
o.indent_inc()

o.print("/// <summary>Represents a name ID for a integer value type</summary>")
o.print("public enum ExprIntType : byte")
o.print("{")
o.indent_inc()
for type in TYPES.values():
    if type.kind == TypeKind.FLOAT: continue
    o.print(f"/// <summary>{type.name}</summary>")
    o.print(f"{type.suffix},")
o.indent_dec()
o.print("}")

o.print()

o.print("public static class ExprIntType_ext")
o.print("{")
o.indent_inc()
o.print("private static readonly ImmNullDict<ExprIntType, Func<EType>> TYPES = new([", end = '')
if len(TYPES) > 0:
    o.print()
    o.indent_inc()
    for type in TYPES.values():
        if type.kind == TypeKind.FLOAT: continue
        o.print(f"new(ExprIntType.{type.suffix}, () => EType.{type.suffix}),")
    o.indent_dec()
o.print("]);")
o.print()
o.print("/// <summary>Retrieves the actual expression value type</summary>")
o.print("public static EType Type(this ExprIntType id) => TYPES[id]();")
o.print()
o.indent_dec()
o.print("}")

o.indent_dec()
o.print("}")
