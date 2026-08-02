import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent.parent
_pydir = _filedir.joinpath("---py---")
sys.path.append(str(_pydir))

from EMathOperator import MATHOPS # type: ignore

from help import Outputter
o = Outputter()
o.print("using System;")
o.print("using System.Linq;")
o.print("using aaasm.engine.col;")
o.print("")
o.print("namespace aaasm.engine.lxpr")
o.print("{")
o.indent_inc()
o.print("public static partial class EMath")
o.print("{")
o.indent_inc()

o.print(f"static EMath()")
o.print("{")
o.indent_inc()

o.print(f"OPERATORS = new([", end = '')
o.indent_inc()
if len(MATHOPS) > 0:
    o.print()
    for op in MATHOPS:
        o.print(f"new(EMathOperator.{op.name.upper()}, {str(op.unary).lower()}),")
o.indent_dec()
o.print("]);")
o.print("UNARY = new([.. from info in OPERATORS where info.IsUnary select info]);")
o.print("BINARY = new([.. from info in OPERATORS where !info.IsUnary select info]);")

o.indent_dec()
o.print("}")

o.indent_dec()
o.print("}")
o.indent_dec()
o.print("}")