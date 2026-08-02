import sys
from pathlib import Path as _Path
sys.path.append(str(_Path(__file__).resolve().parent))

from help import\
    Outputter as _Outputter

import _functions as _fun

def run(dir:_Path):
    functions = _fun.get_functions(dir)
    o = _Outputter()
    o.print("using aaasm.engine.help;")
    o.print()
    o.print("namespace aaasm.engine.lxpr")
    o.print("{")
    o.print(f"    /// <summary>Represents a function identifier</summary>")
    o.print(f"    public enum EFunFunctionId", end = '')
    if len(functions) > 0:
        o.print()
        o.print("    {")
        o.indent = 2
        for function in functions:
            o.print(f"{function.name},")
        o.indent = 0
        print("    }")
    else:
        o.print(" { }")
    print("}")