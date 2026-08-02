import sys
sys.dont_write_bytecode = True

from pathlib import Path
_filedir = Path(__file__).resolve().parent
sys.path.append(str(_filedir.joinpath("modules")))

from cs import CSRoughNode, CSRoughNodeTree

def main():
    if len(sys.argv) <= 1:
        if len(sys.argv) > 0:
            print(sys.argv[0], end = '')
        else:
            print("cstree", end = '')
        print(" <source>")
        print("Prints a rough syntax tree of a C# source code file")
        return 0
    try:
        with open(sys.argv[1], 'r') as f:
            tree = CSRoughNodeTree(bytes(f.read(), f.encoding))
            def print_node(node:CSRoughNode, indent:str = ''):
                print(f"{indent}{node.type}")
                for child in node.children:
                    print_node(child, indent = "    " + indent)
            print_node(tree.root)
    except Exception as e:
        print("UNEXPECTED ERROR:", file = sys.stderr)
        print(e, file = sys.stderr)
        return 1
    return 0

if __name__ == '__main__':
    sys.exit(main())