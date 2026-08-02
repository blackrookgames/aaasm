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
# Usings
o.print(f"using System;")
o.print(f"using System.Collections.Generic;")
o.print(f"using aaasm.engine.col;")
o.print(f"using aaasm.engine.data;")
o.print(f"")
# Header
o.print(f"namespace aaasm.engine.lxpr")
o.print(f"{{")
o.print(f"    public partial class LexRules")
o.print(f"    {{")
o.indent = 2
# Body
o.print(f"/// <summary>Commonly used names of the preprocessor commands</summary>")
o.print(f"public static ImmNullDict<Str, PreCmd> COMMON_PRENAMES {{ get; }} = new([")
o.indent_inc()
for i in range(len(PRECMDS)):
    cmd = PRECMDS[i]
    end = "," if ((i + 1) < len(PRECMDS)) else ",]);"
    o.print(f"new ((CIStr)\"{cmd.name}\", PreCmd.{cmd.name}){end}")
o.indent_dec()
# Footer
o.indent = 0
o.print(f"    }}")
o.print(f"}}")