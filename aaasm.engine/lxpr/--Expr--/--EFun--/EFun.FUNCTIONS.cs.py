import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent
_pydir = _filedir.joinpath("---py---")
sys.path.append(str(_pydir))

from EFun_FUNCTIONS import run # type: ignore
run(_filedir)