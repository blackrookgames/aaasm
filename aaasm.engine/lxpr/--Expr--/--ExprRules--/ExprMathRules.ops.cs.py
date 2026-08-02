import sys

from pathlib import Path
from help import Outputter
from ioutil import PathUtil
from typing import cast

_file_path = Path(__file__).resolve()
_file_dir = _file_path.parent
_expr_dir = cast(Path, PathUtil.find_parent_name(_file_path, "--Expr--"))
sys.path.append(str(_expr_dir.joinpath("---py---")))

from EMathOperator import MATHOPS # type: ignore

from help import Outputter
o = Outputter()
o.print(f"using System;")
o.print(f"using aaasm.engine.col;")
o.print(f"using aaasm.engine.data;")
o.print(f"")
o.print(f"namespace aaasm.engine.lxpr")
o.print(f"{{")
o.print(f"    public partial class ExprMathRules")
o.print(f"    {{")
o.indent = 2
o.print("/// <summary>Common mathematical operators</summary>")
o.print(f"public static readonly ImmNullDict<EMathOperator, ImmNullArray<Str>> COMMON_OPERATORS = new([", end = '')
if len(MATHOPS) > 0:
    o.print()
    o.indent_inc()
    for op in MATHOPS:
        o.print(f"new(EMathOperator.{op.name.upper()}, new([(CIStr)\"{op.symbol}\"])),")
    o.indent_dec()
o.print(f"]);")
o.indent = 0
o.print(f"    }}")
o.print(f"}}")
