import re as _re

from pathlib import\
    Path as _Path

from col import\
    ROList as _ROList
from cs import\
    CSCode as _CSCode,\
    CSCodeProperty as _CSCodeProperty,\
    CSRoughNode as _CSRoughNode,\
    CSRoughNodeTree as _CSRoughNodeTree
from csutil import\
    CSStrUtil as _CSStrUtil
from help import\
    Outputter as _Outputter

class _Attr:
    def __init__(self, src:str):
        self.__name = ""
        self.__args = _ROList[str]([])
        # Create node tree
        tree = _CSRoughNodeTree(bytes(f"[{src}] class Test {{}}", 'utf8')) # Dummy class
        # Look for attribute node
        def _get_node(parent:_CSRoughNode, target_type:str):
            for child in parent.children:
                if child.type != target_type:
                    continue
                return child
            return None
        attr_node = _get_node(tree.root, "class_declaration")
        if attr_node is None: return
        attr_node = _get_node(attr_node, "attribute_list")
        if attr_node is None: return
        attr_node = _get_node(attr_node, "attribute")
        if attr_node is None: return
        # Look for indentifier
        identifier = _get_node(attr_node, "identifier")
        if identifier is None: return
        if identifier.text is None: return
        self.__name = identifier.text.decode()
        # Look for attribute arguments
        arglist = _get_node(attr_node, "attribute_argument_list")
        if arglist is None: return
        # Extract arguments
        args:list[str] = []
        for child in arglist.children:
            if child.type != "attribute_argument": continue
            if child.text is None: continue
            args.append(child.text.decode())
        self.__args = _ROList(args)
    @property
    def name(self): return self.__name
    @property
    def args(self): return self.__args

class _InitParamsAttr:
    def __init__(self, attr:_Attr):
        self.__name = None
        self.__type = None
        self.__value = None
        self.__set = True
        # Look thru arguments
        def _arg_str(argument):
            _argument = _CSStrUtil.try_parse(argument)
            if _argument is None: return None
            return _argument.strip()
        def _arg_bool(argument):
            if not isinstance(argument, str):
                return False
            return argument.upper() == "TRUE"
        for arg in attr.args:
            # Can is be parsed?
            arg_match = _re.fullmatch("(\\s*)(\\w*)(\\s*:\\s*)(.*?)(\\s*)", arg)
            if arg_match is None: continue
            parameter = arg_match[2]
            argument = arg_match[4]
            # Yes!
            match parameter:
                case 'name':
                    self.__name = _arg_str(argument)
                case 'type':
                    self.__type = _arg_str(argument)
                case 'value':
                    self.__value = _arg_str(argument)
                case 'set':
                    self.__set = _arg_bool(argument)
        # Success!!!
        return
    @property
    def name(self): return self.__name
    @property
    def type(self): return self.__type
    @property
    def value(self): return self.__value
    @property
    def set(self): return self.__set

def run(name:str, src:_Path):
    # Open source
    with open(src, 'r') as f:
        srctree = _CSRoughNodeTree(bytes(f.read(), f.encoding))
        srccode = _CSCode.parse(srctree)
    # Find type
    type = None
    if len(srccode.namespaces) > 0:
        for namespace in srccode.namespaces:
            if len(namespace.types) == 0:
                continue
            for _type in namespace.types:
                type = _type
                break
            break
    if type is None:
        if len(srccode.types) == 0:
            return
        for _type in srccode.types:
            type = _type
            break
    assert type is not None
    # Find usings
    usings = [node.text.decode()\
        for node in srctree.root.children\
        if node.type == 'using_directive' and node.text is not None]
    # Find properties
    properties:list[tuple[_CSCodeProperty, _InitParamsAttr]] = []
    for property in type.members:
        if not isinstance(property, _CSCodeProperty):
            continue
        # Find InitParam attribute
        attribute = None
        for _rawattr in property.attributes:
            # Parse attribute
            _attr = _Attr(_rawattr)
            if _attr.name != 'InitParam':
                continue
            attribute = _InitParamsAttr(_attr)
            break
        if attribute is None:
            continue
        # Add to properties
        properties.append((property, attribute))
    # Print
    o = _Outputter()
    # Print header
    if len(usings) > 0:
        for using in usings:
            o.print(using)
        o.print()
    if type.namespace is not None:
        o.print(f"namespace {type.namespace.name}")
        o.print("{")
        o.indent_inc()
    # Print body
    o.print(f"/// <summary>Represents initialization parameters for <see cref=\"{type.name}\"/></summary>")
    o.print(f"public class {name}")
    o.print("{")
    o.indent_inc()
    for i in range(len(properties)):
        property, attribute = properties[i]
        if i > 0: o.print()
        o.print(f"/// <inheritdoc cref=\"{type.name}.{property.name}\"/>")
        o.print(f"public ", end = '')
        # Type
        if attribute.type is not None:
            o.print(f"{attribute.type} ", end = '')
        else:
            o.print(f"{property.return_type} ", end = '')
        # Name
        if attribute.name is not None:
            o.print(f"{attribute.name} ", end = '')
        else:
            o.print(f"{property.name} ", end = '')
        # Get/Set
        o.print("{ get; ", end = '')
        if attribute.set: o.print("set; ", end = '')
        o.print("}", end = '')
        # Value
        if attribute.value is not None:
            o.print(f" = {attribute.value};", end = '')
        # Next
        o.print()
    o.indent_dec()
    o.print("}")
    # Print footer
    if type.namespace is not None:
        o.indent_dec()
        o.print("}")
    # Success!!!
    return