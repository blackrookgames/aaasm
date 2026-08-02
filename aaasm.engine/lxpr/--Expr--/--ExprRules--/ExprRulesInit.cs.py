import sys

from pathlib import Path
from ioutil import PathUtil
from typing import cast

_file_path = Path(__file__).resolve()
_file_dir = _file_path.parent
_lxpr_dir = cast(Path, PathUtil.find_parent_name(_file_path, "lxpr"))
sys.path.append(str(_lxpr_dir.joinpath("---py---")))

from InitParams import run # type: ignore
run("ExprRulesInit", _file_dir.joinpath("ExprRules.cs"))