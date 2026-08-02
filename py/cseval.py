import sys
sys.dont_write_bytecode = True

from pathlib import Path
_filedir = Path(__file__).resolve().parent
sys.path.append(str(_filedir.joinpath("modules")))

from io import StringIO
from typing import Callable

import col
import cs
import help

#region helper

def str_accessible(a:cs.CSCodeAccessible):
    with StringIO() as w:
        w.write(a.access.name.lower().replace('_', ' '))
        if a.is_static: w.write(" static")
        if a.is_abstract: w.write(" abstract")
        if a.is_partial: w.write(" partial")
        if a.is_readonly: w.write(" readonly")
        return w.getvalue()

def str_parameters(p:cs.CSCodeParameters):
    with StringIO() as w:
        w.write('(')
        i = 0
        for parameter in p:
            if i > 0: w.write(", ")
            if parameter.is_ref: w.write("ref ")
            if parameter.is_out: w.write("out ")
            w.write(parameter.type)
        w.write(')')
        return w.getvalue()

def str_typeconstraints(tc:col.ImmDict[str, col.ImmSet[str]]):
    with StringIO() as w:
        for _type, _constraints in tc.iter_items():
            w.write(f"where {_type}:")
            i = 0
            for constraint in _constraints:
                if i > 0: w.write(',')
                w.write(f" {constraint}")
                i += 1
        return w.getvalue()

#endregion

#region print

def print_indent(o:help.Outputter, action:Callable[[help.Outputter], None]):
    o.indent_inc()
    try: action(o)
    finally: o.indent_dec()

def print_namespace(o:help.Outputter, ns:cs.CSCodeNamespace):
    def action(o:help.Outputter):
        nonlocal ns
        for _type in ns.types:
            print_type(o, _type)
        pass
    o.print(f"namespace {ns.name}")
    print_indent(o, action)

def print_type(o:help.Outputter, t:cs.CSCodeType):
    def action(o:help.Outputter):
        nonlocal t
        for _type in t.nested_types:
            print_type(o, _type)
        for constructor in t.constructors:
            print_constructor(o, constructor)
        for member in t.members:
            if isinstance(member, cs.CSCodeField):
                print_field(o, member)
                continue
            if isinstance(member, cs.CSCodeProperty):
                print_property(o, member)
                continue
            if isinstance(member, cs.CSCodeMethod):
                print_method(o, member)
                continue
    o.print(str_accessible(t), end = '')
    if t.is_ref: o.print(" ref", end = '')
    o.print(f" {t.kind.name.lower()}", end = '')
    o.print(f" {t.name}", end = '')
    if len(t.base) > 0:
        i = 0
        for base in t.base:
            o.print(", " if (i > 0) else ": ", end = '')
            o.print(base, end = '')
            i += 1
    o.print(f" {str_typeconstraints(t.typeconstraints)}", end = '')
    o.print()
    print_indent(o, action)

def print_constructor(o:help.Outputter, c:cs.CSCodeConstructor):
    o.print(f"{str_accessible(c)} {c.type.name}{str_parameters(c.parameters)}")

def print_field(o:help.Outputter, f:cs.CSCodeField):
    o.print(f"{str_accessible(f)} {f.return_type} {f.name}")

def print_property(o:help.Outputter, p:cs.CSCodeProperty):
    o.print(f"{str_accessible(p)} {p.return_type} {p.name}")

def print_method(o:help.Outputter, m:cs.CSCodeMethod):
    for overload in m.overloads:
        o.print(f"{str_accessible(overload)} {overload.return_type}", end = '')
        o.print(f" {overload.name}{str_parameters(overload.parameters)}", end = '')
        o.print(f" {str_typeconstraints(overload.typeconstraints)}", end = '')
        o.print()

#endregion

def main():
    if len(sys.argv) <= 1:
        if len(sys.argv) > 0:
            print(sys.argv[0], end = '')
        else:
            print("cseval", end = '')
        print(" <source0> [<source1> ...]")
        print("Performs basic evaluation of a C# source code file")
        return 0
    # Load source
    try:
        srcs = []
        for i in range(1, len(sys.argv)):
            with open(sys.argv[i], 'r') as f:
                srcs.append(bytes(f.read(), f.encoding))
    except Exception as e:
        print("UNEXPECTED ERROR:", file = sys.stderr)
        print(e, file = sys.stderr)
        return 1
    # Evaluate
    code = cs.CSCode.parse(*[cs.CSRoughNodeTree(src) for src in srcs])
    # Print
    o = help.Outputter()
    for ns in code.namespaces:
        print_namespace(o, ns)
    for t in code.types:
        print_type(o, t)
    # Success!!!
    return 0

if __name__ == '__main__':
    sys.exit(main())