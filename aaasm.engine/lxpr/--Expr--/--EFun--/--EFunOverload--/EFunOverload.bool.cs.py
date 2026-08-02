import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent.parent
_pydir = _filedir.joinpath("---py---")
sys.path.append(str(_pydir))

from EFunOverload_bool import run # type: ignore
run()