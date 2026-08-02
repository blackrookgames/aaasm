import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent.parent
_pydir = _filedir.joinpath("---py---")
sys.path.append(str(_pydir))

from Expr import TYPES, convert # type: ignore

from help import Outputter
o = Outputter()
o.print("namespace aaasm.engine.lxpr")
o.print("{")
o.indent_inc()
o.print("public partial class ENodeValueType")
o.print("{")
o.indent_inc()
i = 0
for type in TYPES.values():
    if i > 0: o.print()
    o.print(f"/// <summary>{type.name}</summary>")
    o.print(f"public static ENodeValueType {type.suffix} {{ get; }} = new(EType.{type.suffix});")
    i += 1
o.indent_dec()
o.print("}")
o.indent_dec()
o.print("}")