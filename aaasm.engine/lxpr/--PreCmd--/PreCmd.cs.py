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
o.print(f"namespace aaasm.engine.lxpr")
o.print(f"{{")
o.print(f"    /// <summary>Represents a type of preprocessor command</summary>")
o.print(f"    public enum PreCmd : byte")
o.print(f"    {{")
o.indent = 2
for i in range(len(PRECMDS)):
    cmd = PRECMDS[i]
    if i > 0: o.print()
    o.print(f"/// <summary>{cmd.desc}</summary>")
    o.print(f"{cmd.name},")
o.indent = 0
print(f"    }}")
print(f"}}")