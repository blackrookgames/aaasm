from io import StringIO

from help import Outputter

o = Outputter()
o.print(f"")
o.print(f"using System;")
o.print(f"")
o.print(f"namespace aaasm.engine.help")
o.print(f"{{")
o.print(f"    public static partial class FuncUtil")
o.print(f"    {{")
o.indent = 2
for i in range(16):
    # Type params
    with StringIO() as w:
        w.write("<")
        for j in range(i): w.write(f"T{j}, ")
        w.write("TReturn>")
        t = w.getvalue()
    # Print
    o.print(f"public static Func{t}")
    o.print(f"    Cast{i}{t}(")
    o.print(f"    Func{t} func) => func;")
o.indent = 0
o.print(f"    }}")
o.print(f"}}")