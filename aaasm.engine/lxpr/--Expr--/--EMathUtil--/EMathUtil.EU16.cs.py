import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent
_pydir = _filedir.joinpath("---py---")
sys.path.append(str(_pydir))
import EMathUtil # type: ignore
EMathUtil.run('U16')