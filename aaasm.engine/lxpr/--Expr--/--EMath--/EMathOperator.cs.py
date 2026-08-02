import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent.parent
_pydir = _filedir.joinpath("---py---")
sys.path.append(str(_pydir))

from EMathOperator import MATHOPS # type: ignore

from help import Outputter
o = Outputter()
o.print()
o.print(f"using System;")
o.print(f"using aaasm.engine.col;")
o.print()
o.print(f"namespace aaasm.engine.lxpr")
o.print("{")
o.indent_inc()

o.print(f"/// <summary>Represents a mathematical operator</summary>")
o.print(f"public enum EMathOperator : byte")
o.print("{")
o.indent_inc()
i = 0
for op in MATHOPS:
    if i > 0: o.print()
    o.print(f"/// <summary>{op.human} operator</summary>")
    o.print(f"{op.name.upper()},")
    i += 1
o.indent_dec()
o.print("}")

o.print()

o.print(f"public static class EMathOperator_ext")
o.print("{")
o.indent_inc()

o.print(f"/// <summary>Retrieves information about the specified operator</summary>")
o.print(f"public static EMathOperatorInfo About(this EMathOperator @operator)")
o.print("{")
o.indent_inc()
o.print(f"return EMath.OPERATORS.Get(@operator);")
o.indent_dec()
o.print("}")

o.indent_dec()
o.print("}")

o.indent_dec()
o.print("}")