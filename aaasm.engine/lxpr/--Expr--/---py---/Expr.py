from enum import\
    auto as _auto,\
    Enum as _Enum

from col import\
    RODict as _RODict

class TypeKind(_Enum):
    UNSIGNED = _auto()
    SIGNED = _auto()
    FLOAT = _auto()

class Type:

    #region init

    def __init__(self,\
            suffix:str = "",\
            desc:str = "",\
            name:str = "",\
            cstype:str = "",\
            cstype_method:str = "",\
            numbytes:int = 0,\
            kind:TypeKind = TypeKind.UNSIGNED,\
            maskminmax:tuple[int, int, int] = (0, 0, 0),\
            mathtype:None|str = None,\
            signtype:None|str = None):
        self.__suffix = suffix
        self.__desc = desc
        self.__name = name
        self.__cstype = cstype
        self.__cstype_method = cstype_method
        self.__numbytes = numbytes
        self.__kind = kind
        self.__mask, self.__min, self.__max = maskminmax
        self.__mathtype = self.__suffix if (mathtype is None) else mathtype
        self.__signtype = self.__suffix if (signtype is None) else signtype

    #endregion

    #region properties

    @property
    def suffix(self): return self.__suffix

    @property
    def desc(self): return self.__desc

    @property
    def name(self): return self.__name

    @property
    def cstype(self): return self.__cstype

    @property
    def cstype_method(self): return self.__cstype_method

    @property
    def numbytes(self): return self.__numbytes

    @property
    def kind(self): return self.__kind

    @property
    def mask(self): return self.__mask

    @property
    def min(self): return self.__min

    @property
    def max(self): return self.__max
    
    @property
    def mathtype(self): return self.__mathtype
    
    @property
    def signtype(self): return self.__signtype

    #endregion

    #region methods

    def get_mathtype(self):
        global ALL_TYPES
        return ALL_TYPES[self.__mathtype]

    def get_signtype(self):
        global ALL_TYPES
        return ALL_TYPES[self.__signtype]

    #endregion

def _maskminmax(numbytes:int, signed:bool):
    _mask = (1 << (numbytes * 8)) - 1
    _min = 0
    _max = _mask
    if signed:
        _min = -((_mask + 1) >> 1)
        _max += _min
    return _mask, _min, _max

ALL_TYPES:_RODict[str, Type] = _RODict({\
    'U8': Type(\
        suffix = "U8",\
        name = "8-bit unsigned integer",\
        desc = "Represents an 8-bit unsigned integer",\
        cstype = "byte",\
        cstype_method = "ToByte",\
        numbytes = 1,\
        kind = TypeKind.UNSIGNED,\
        maskminmax = _maskminmax(1, False),\
        mathtype = 'I32',\
        signtype = 'I8'),\
    'I8': Type(\
        suffix = "I8",\
        name = "8-bit signed integer",\
        desc = "Represents an 8-bit signed integer",\
        cstype = "sbyte",\
        cstype_method = "ToSbyte",\
        numbytes = 1,\
        kind = TypeKind.SIGNED,\
        maskminmax = _maskminmax(1, True),\
        mathtype = 'I32'),\
    'U16': Type(\
        suffix = "U16",\
        name = "16-bit unsigned integer",\
        desc = "Represents an 16-bit unsigned integer",\
        cstype = "ushort",\
        cstype_method = "ToUshort",\
        numbytes = 2,\
        kind = TypeKind.UNSIGNED,\
        maskminmax = _maskminmax(2, False),\
        mathtype = 'I32',\
        signtype = 'I16'),\
    'I16': Type(\
        suffix = "I16",\
        name = "16-bit signed integer",\
        desc = "Represents an 16-bit signed integer",\
        cstype = "short",\
        cstype_method = "ToShort",\
        numbytes = 2,\
        kind = TypeKind.SIGNED,\
        maskminmax = _maskminmax(2, True),\
        mathtype = 'I32'),\
    'U32': Type(\
        suffix = "U32",\
        name = "32-bit unsigned integer",\
        desc = "Represents an 32-bit unsigned integer",\
        cstype = "uint",\
        cstype_method = "ToUint",\
        numbytes = 4,\
        kind = TypeKind.UNSIGNED,\
        maskminmax = _maskminmax(4, False),\
        signtype = 'I32'),\
    'I32': Type(\
        suffix = "I32",\
        name = "32-bit signed integer",\
        desc = "Represents an 32-bit signed integer",\
        cstype = "int",\
        cstype_method = "ToInt",\
        numbytes = 4,\
        kind = TypeKind.SIGNED,\
        maskminmax = _maskminmax(4, True)),\
    'U64': Type(\
        suffix = "U64",\
        name = "64-bit unsigned integer",\
        desc = "Represents an 64-bit unsigned integer",\
        cstype = "ulong",\
        cstype_method = "ToUlong",\
        numbytes = 8,\
        kind = TypeKind.UNSIGNED,\
        maskminmax = _maskminmax(8, False),\
        signtype = 'I64'),\
    'I64': Type(\
        suffix = "I64",\
        name = "64-bit signed integer",\
        desc = "Represents an 64-bit signed integer",\
        cstype = "long",\
        cstype_method = "ToLong",\
        numbytes = 8,\
        kind = TypeKind.SIGNED,\
        maskminmax = _maskminmax(8, True)),\
    'F32': Type(\
        suffix = "F32",\
        name = "32-bit floating-point decimal",\
        desc = "Represents a 32-bit floating-point decimal",\
        cstype = "float",\
        cstype_method = "ToFloat",\
        numbytes = 4,\
        kind = TypeKind.FLOAT),\
    'F64': Type(\
        suffix = "F64",\
        name = "64-bit floating-point decimal",\
        desc = "Represents a 64-bit floating-point decimal",\
        cstype = "double",\
        cstype_method = "ToDouble",\
        numbytes = 8,\
        kind = TypeKind.FLOAT),\
    'I128': Type(\
        suffix = "I128",\
        cstype = "Int128",\
        cstype_method = "ToInt128",\
        numbytes = 16,\
        kind = TypeKind.SIGNED,\
        maskminmax = _maskminmax(16, True)),\
})

TYPES:_RODict[str, Type] = _RODict({\
    'U8': ALL_TYPES['U8'],\
    'I8': ALL_TYPES['I8'],\
    'U16': ALL_TYPES['U16'],\
    'I16': ALL_TYPES['I16'],\
    'U32': ALL_TYPES['U32'],\
    'I32': ALL_TYPES['I32'],\
    'U64': ALL_TYPES['U64'],\
    'I64': ALL_TYPES['I64'],\
    'F32': ALL_TYPES['F32'],\
    'F64': ALL_TYPES['F64']})

INT_TYPES:_RODict[str, Type] = _RODict({\
    'U8': ALL_TYPES['U8'],\
    'I8': ALL_TYPES['I8'],\
    'U16': ALL_TYPES['U16'],\
    'I16': ALL_TYPES['I16'],\
    'U32': ALL_TYPES['U32'],\
    'I32': ALL_TYPES['I32'],\
    'U64': ALL_TYPES['U64'],\
    'I64': ALL_TYPES['I64']})

_ORDER = ['I8', 'U8', 'I16', 'U16', 'I32', 'U32', 'I64', 'U64', 'I128']

def get_type(suffix:str):
    """
    Finds the type with the specified suffix

    :param suffix: Suffix
    :return: Found type
    :raises Exception: Type could not be found
    """
    if suffix in ALL_TYPES: return ALL_TYPES[suffix]
    raise Exception(f"Unknown type: {suffix}")

def convert(_from:Type, _to:Type, input:str) -> str:
    """
    Creates conversion code

    :param _from: Input type
    :param _to: Output type
    :param input: Input value
    """
    if _from.cstype == _to.cstype:
        return input
    if _from.kind == TypeKind.FLOAT:
        if _to.kind != TypeKind.FLOAT:
            return convert(get_type('I64'), _to, f"((long){input})")
        return f"(({_to.cstype}){input})"
    if _to.kind == TypeKind.FLOAT:
        return input
    if _from.numbytes > _to.numbytes:
        return f"unchecked(({_to.cstype})({input} & {_to.mask}))"
    if _from.min >= _to.min and _from.max <= _to.max:
        return input
    return f"unchecked(({_to.cstype}){input})"

def dominant_type(a:Type, b:Type):
    """
    Determines which of the two types is the "dominant" type

    :param a: Input type A
    :param b: Input type B
    :return: "Dominant" type
    """
    if a.suffix == b.suffix:
        return a
    if a.kind == TypeKind.FLOAT:
        if b.kind != TypeKind.FLOAT:
            return a
        if a.numbytes > b.numbytes:
            return a
        return b
    if b.kind == TypeKind.FLOAT:
        return b
    if a.numbytes > b.numbytes:
        return a
    if a.numbytes < b.numbytes:
        return b
    if a.kind == TypeKind.UNSIGNED:
        return a
    return b

def common_type(a:Type, b:Type):
    """
    Finds a type that can represent any value of the two input types

    :param a: Input type A
    :param b: Input type B
    :return: Found type
    :raises Exception: Type A and Type B cannot be used together
    """
    for suffix in _ORDER:
        type = ALL_TYPES[suffix]
        if a.min < type.min or a.max > type.max:
            continue
        if b.min < type.min or b.max > type.max:
            continue
        return type
    raise Exception(f"Invalid: {a.suffix} and {b.suffix}")