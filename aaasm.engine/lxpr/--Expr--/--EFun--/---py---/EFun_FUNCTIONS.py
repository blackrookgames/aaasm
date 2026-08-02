import sys
from pathlib import Path as _Path
sys.path.append(str(_Path(__file__).resolve().parent))

from help import\
    Outputter as _Outputter

import _functions as _fun

class _AutoMethod:
    def __init__(self, rettype:str, num_params:int):
        self.__rettype = rettype
        self.__num_params = num_params
    def __eq__(self, other:object):
        return self.__eq(other)
    def __ne__(self, other:object):
        return not self.__eq(other)
    def __hash__(self):
        return hash(self.__rettype)
    @property
    def rettype(self):
        return self.__rettype
    @property
    def num_params(self):
        return self.__num_params
    def __eq(self, other:object):
        if not isinstance(other, _AutoMethod):
            return False
        if self.__rettype != other.__rettype:
            return False
        if self.__num_params != other.__num_params:
            return False
        return True
    def get_name(self):
        return f"MM_Return{self.__rettype}"

def run(dir:_Path):
    functions = _fun.get_functions(dir)
    o = _Outputter()
    o.print("using System;")
    o.print("using aaasm.engine.col;")
    o.print()
    o.print("#pragma warning disable IDE0047")
    o.print()
    o.print("namespace aaasm.engine.lxpr")
    o.print("{")
    o.indent_inc()
    o.print("public static partial class EFun")
    o.print("{")
    o.indent_inc()
    auto_methods:set[_AutoMethod] = set()
    o.print(f"#region const")
    o.print()
    o.print(f"/// <summary>All valid expression functions</summary>")
    o.print(f"public static EFunFunctions FUNCTIONS {{ get; }} = new(", end = '')
    if len(functions) > 0:
        o.print("\n[")
        o.indent_inc()
        for function in functions:
            o.print(f"new(EFunFunctionId.{function.name}, new(", end = '')
            if len(function.overloads) > 0:
                o.print("\n[")
                o.indent_inc()
                for overload in function.overloads:
                    # Begin overload
                    if isinstance(overload, _fun.FunctionBoolOverload):
                        o.print("new EFunBoolOverload<", end = '')
                    else:
                        o.print("new EFunOverload<", end = '')
                    for i in range(len(overload.params)):
                        if i > 0: o.print(", ", end = '')
                        o.print(overload.params[i], end = '')
                    if isinstance(overload, _fun.FunctionBoolOverload):
                        o.print(">(")
                    else:
                        o.print(f", {overload.rettype}>(")
                    o.indent_inc()
                    # Name
                    o.print(f"EFunFunctionId.{overload.name}", end = '')
                    # Functions
                    if isinstance(overload, _fun.FunctionBoolOverload):
                        # Invoker
                        o.print(", ", end = '')
                        o.print(overload.invoker.src.method.outer_type.name, end = '')
                        o.print(f".{overload.invoker.src.name}", end = '')
                    elif isinstance(overload, _fun.FunctionStdOverload):
                        # Invoker
                        o.print(", ", end = '')
                        o.print(overload.invoker.src.method.outer_type.name, end = '')
                        o.print(f".{overload.invoker.src.name}", end = '')
                        # Return
                        o.print(", ", end = '')
                        if overload.getter is not None:
                            o.print(overload.getter.src.method.outer_type.name, end = '')
                            o.print(f".{overload.getter.src.name}", end = '')
                        else:
                            auto_method = _AutoMethod(overload.rettype, len(overload.params))
                            auto_methods.add(auto_method)
                            o.print(auto_method.get_name(), end = '')
                    elif isinstance(overload, _fun.FunctionDbgOverload):
                        # Debug
                        o.print(", ", end = '')
                        o.print(overload.debug.src.method.outer_type.name, end = '')
                        o.print(f".{overload.debug.src.name}", end = '')
                    # Parameters
                    for param in overload.params:
                        o.print(", ")
                        o.print(_fun.PARAMCONSTRS[param], end = '')
                    o.print()
                    # End overload
                    o.indent_dec()
                    o.print("),")
                o.indent_dec()
                o.print("])),")
            else:
                o.print("[])),")
        o.indent_dec()
        o.print("]);")
    else:
        o.print("[]);")
    o.print()
    o.print(f"#endregion")
    o.print()
    o.print(f"#region helper methods")
    o.print()
    for auto_method in auto_methods:
        o.print(f"private static EType {auto_method.get_name()}(", end = '')
        o.print("ExprRules rules", end = '')
        for i in range(auto_method.num_params):
            o.print(f", ENodeValueType input{i:02d}", end = '')
        o.print(f") => EType.{auto_method.rettype[1:]};")
    o.print()
    o.print(f"#endregion")
    o.indent_dec()
    o.print("}")
    o.indent_dec()
    o.print("}")
    o.print()
    o.print("#pragma warning restore IDE0047")
