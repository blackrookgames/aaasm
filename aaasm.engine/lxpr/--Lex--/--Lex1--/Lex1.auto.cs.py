import sys

from pathlib import Path
from help import Outputter
from ioutil import PathUtil
from typing import cast

_file_path = Path(__file__).resolve()
_file_dir = _file_path.parent
_lxpr_dir = cast(Path, PathUtil.find_parent_name(_file_path, "lxpr"))
sys.path.append(str(_lxpr_dir.joinpath("---py---")))

from precmd import PRECMDS # type: ignore

o = Outputter()
o.print(f"using System;")
o.print(f"using System.Collections.Generic;")
o.print(f"")
o.print(f"namespace aaasm.engine.lxpr")
o.print(f"{{")
o.print(f"    internal partial class Lex1")
o.print(f"    {{")
o.indent = 2

o.print(f"private static readonly Dictionary<PreCmd, Action<Handler>> PRECOMMANDS = new()")
o.print(f"{{")
o.indent_inc()
for cmd in PRECMDS:
    o.print(f"{{ PreCmd.{cmd.name}, MM_PreCmd_{cmd.name} }},")
o.indent_dec()
o.print(f"}};")

o.indent = 0
o.print(f"    }}")
o.print(f"}}")
