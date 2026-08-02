import sys
from pathlib import Path
_filedir = Path(__file__).resolve().parent
_pydir = _filedir.parent.parent.joinpath("---py---")
sys.path.append(str(_pydir))
import evalue # type: ignore
evalue.run('U32')