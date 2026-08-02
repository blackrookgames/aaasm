from collections.abc import\
    Iterable as _Iterable
from pathlib import\
    Path as _Path

import cs as _cs

from col import\
    ColUtil as _ColUtil,\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet
from ioutil import\
    FileUtil as _FileUtil
from help import\
    StrUtil as _StrUtil

CS_NAMESPACE = "aaasm.engine.lxpr"
CS_CLASS = "EFunFunc"

#region types

IMPLICIT_TYPES = _ImmSet([\
    'EU8', 'EU16', 'EU32', 'EU64',\
    'EI8', 'EI16', 'EI32', 'EI64',\
    'EF32', 'EF64', ]) 
""" GetReturnFunc can be implied """

EXPLICIT_TYPES = _ImmSet([\
    'EArray', 'ETuple', 'EImmediate', ]) 
""" A method for GetReturnFunc must be defined """

ABSTRACT_TYPES = _ImmSet([\
    'EValue', 'IECollection', 'IENumber', 'IEInteger', ])
""" Base types; like EXPLICIT_TYPES, these also require a method for GetReturnFunc """

LITERAL_TYPE = 'int'
""" Used for as a literal modifier; cannot be given as a return type """

RETURN_IMPLICIT = _ImmSet(IMPLICIT_TYPES)
"""
Return types where GetReturnFunc is implied; 
includes IMPLICIT_TYPES
"""

RETURN_EXPLICIT = _ImmSet(_ColUtil.iter_multi(EXPLICIT_TYPES, ABSTRACT_TYPES))
""" 
Return types that must be accompanied with a GetReturnFunc method; 
includes EXPLICIT_TYPES and ABSTRACT_TYPES
"""

RETURN_BOOLEAN = _ImmSet(['bool'])
""" Boolean return types """

RETURN_VALID = _ImmSet(_ColUtil.iter_multi(RETURN_IMPLICIT, RETURN_EXPLICIT, RETURN_BOOLEAN))
""" All valid return types """

PARAM_TYPE = _ImmSet(_ColUtil.iter_multi(IMPLICIT_TYPES, EXPLICIT_TYPES))
""" Parameter types represented with an EFunTypeParam """

PARAM_FLAG = _ImmSet(ABSTRACT_TYPES)
""" Parameter types represented with an EFunFlagParam """

PARAM_LITMOD = _ImmSet([LITERAL_TYPE])
""" Parameter types represented with an EFunLitModParam """

PARAM_VALID = _ImmSet(_ColUtil.iter_multi(PARAM_TYPE, PARAM_FLAG, PARAM_LITMOD))
""" All valid parameter types """

PARAMCONSTRS = _ImmDict(_ColUtil.iter_multi(\
    (( t, f"(new EFunTypeParam(ETypeNameId.{t.upper()[1:]}))") for t in PARAM_TYPE), [\
    ('EValue', "(new EFunFlagParam(ETypeFlags.NONE))"),\
    ('IECollection', "(new EFunFlagParam(ETypeFlags.COLLECTION))"),\
    ('IENumber', "(new EFunFlagParam(ETypeFlags.NUMBER))"),\
    ('IEInteger', "(new EFunFlagParam(ETypeFlags.INTEGER))"),\
    ('int', "EFunLitModParam.PARAM"),]))
""" Parameter constructors  """

_EXCLUDE_PREFIX = "MM_"

_SPECIAL_GETTER = '_r'
_SPECIAL_DEBUG = '_d'
_SPECIALS = _ImmSet([ _SPECIAL_GETTER, _SPECIAL_DEBUG, ])

_DEBUG_DUMMY_RETTYPE = 'EU8'

#endregion

#region nested

class FunctionParams:
    """ Represents the parameters of an aaasm function"""

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f

    @classmethod
    def try_parse(cls, params:_Iterable[str]|_Iterable[_cs.CSCodeParameter]):
        global PARAM_VALID
        f = cls.__Fields()
        f.params = []
        for param in params:
            if isinstance(param, str):
                if param not in PARAM_VALID:
                    return None
                f.params.append(param)
            else:
                if param.is_ref:
                    return None
                if param.is_out:
                    return None
                if param.type not in PARAM_VALID:
                    return None
                f.params.append(param.type)
        return cls(f)

    #endregion

    #region operators

    def __len__(self):
        return len(self.__f.params)

    def __iter__(self):
        for param in self.__f.params:
            yield param

    def __getitem__(self, index:int):
        try:
            return self.__f.params[index]
        except:
            if index >= 0 and index < len(self.__f.params): raise
        raise IndexError("Index is out of range.")

    def __eq__(self, other:object):
        return self.__eq(other)
    
    def __ne__(self, other:object):
        return not self.__eq(other)

    def __hash__(self):
        return len(self.__f.params)

    #endregion

    #region fields

    class __Fields:
        params:list[str]

    #endregion

    #region helper methods

    def __eq(self, other:object):
        if not isinstance(other, FunctionParams):
            return False
        if len(self.__f.params) != len(other.__f.params):
            return False
        for i in range(len(self.__f.params)):
            if self.__f.params[i] != other.__f.params[i]:
                return False
        return True
    
    #endregion
    
class FunctionInvoker:
    """ Represents the actual invoker of an aaasm function"""

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f

    @classmethod
    def try_parse(cls, src:_cs.CSCodeMethodOverload):
        global RETURN_VALID, PARAM_VALID
        f = cls.__Fields()
        f.src = src
        # Check name
        for special in _SPECIALS:
            if src.name.find(special) >= 0:
                return None
        f.name = src.name
        # Check return 
        if src.return_type not in RETURN_VALID:
            return None
        f.rettype = src.return_type
        # Check first C# parameter
        if len(src.parameters) == 0:
            return None
        if src.parameters[0].type != 'ExprContext':
            return None
        # Check parameters
        f_params = FunctionParams.try_parse(\
            src.parameters[i]\
            for i in range(1, len(src.parameters)))
        if f_params is None:
            return None
        f.params = f_params
        # Success!!!
        return cls(f)

    #endregion

    #region fields

    class __Fields:
        src:_cs.CSCodeMethodOverload
        name:str
        rettype:str
        params:FunctionParams

    #endregion

    #region properties

    @property
    def src(self):
        return self.__f.src

    @property
    def name(self):
        """ Name """
        return self.__f.name

    @property
    def rettype(self):
        """ Return type """
        return self.__f.rettype

    @property
    def params(self):
        """ Parameters """
        return self.__f.params

    #endregion

class FunctionGetter:
    """ Represents the return getter of an aaasm function"""

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f

    @classmethod
    def try_parse(cls, src:_cs.CSCodeMethodOverload):
        global RETURN_VALID, PARAM_VALID, _SPECIAL_GETTER
        NP_SEP = _SPECIAL_GETTER + '_'
        f = cls.__Fields()
        f.src = src
        # Check C# return 
        if src.return_type != 'EType':
            return None
        # Check C# parameters
        if len(src.parameters) == 0:
            return None
        if src.parameters[0].type != 'ExprRules':
            return None
        for i in range(1, len(src.parameters)):
            param = src.parameters[i]
            if param.is_ref:
                return None
            if param.is_out:
                return None
            if param.type != 'ENodeValueType':
                return None
        # Extract name and parameter
        params_count = len(src.parameters) - 1
        name_end = src.name.find(NP_SEP)
        if name_end < 0: return None
        f.name = src.name[:name_end]
        f_params = FunctionParams.try_parse(\
            param\
            for param in src.name[(name_end + len(NP_SEP)):].split('_'))
        if f_params is None:
            return None
        if len(f_params) != params_count:
            return None
        f.params = f_params
        # Success!!!
        return cls(f)

    #endregion

    #region fields

    class __Fields:
        src:_cs.CSCodeMethodOverload
        name:str
        params:FunctionParams

    #endregion

    #region properties

    @property
    def src(self):
        return self.__f.src

    @property
    def name(self):
        """ Name """
        return self.__f.name

    @property
    def params(self):
        """ Parameters """
        return self.__f.params

    #endregion

class FunctionDebug:
    """ Represents the debugger of an aaasm function"""

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f

    @classmethod
    def try_parse(cls, src:_cs.CSCodeMethodOverload):
        global RETURN_VALID, PARAM_VALID, _SPECIAL_DEBUG
        f = cls.__Fields()
        f.src = src
        # Check name
        if not src.name.endswith(_SPECIAL_DEBUG):
            return None
        f.name = src.name[:-len(_SPECIAL_DEBUG)]
        # Check C# return 
        if src.return_type != 'string':
            return None
        # Check first C# parameter
        if len(src.parameters) == 0:
            return None
        if src.parameters[0].type != 'ExprContext':
            return None
        # Check parameters
        f_params = FunctionParams.try_parse(\
            src.parameters[i]\
            for i in range(1, len(src.parameters)))
        if f_params is None:
            return None
        f.params = f_params
        # Success!!!
        return cls(f)

    #endregion

    #region fields

    class __Fields:
        src:_cs.CSCodeMethodOverload
        name:str
        params:FunctionParams

    #endregion

    #region properties

    @property
    def src(self):
        return self.__f.src

    @property
    def name(self):
        """ Name """
        return self.__f.name

    @property
    def params(self):
        """ Parameters """
        return self.__f.params

    #endregion

class FunctionOverload:
    """ Represents an aaasm function overload """

    #region init

    def __init__(self, name:str, params:FunctionParams, rettype:str):
        self.__name = name
        self.__params = params
        self.__rettype = rettype

    #endregion

    #region properties

    @property
    def name(self):
        """ Function name """
        return self.__name

    @property
    def params(self):
        """ Parameters """
        return self.__params

    @property
    def rettype(self):
        """ Return type """
        return self.__rettype

    #endregion

class FunctionStdOverload(FunctionOverload):
    """ Represents an aaasm function standard overload """

    #region init

    def __init__(self, invoker:FunctionInvoker, getter:None|FunctionGetter):
        super().__init__(invoker.name, invoker.params, invoker.rettype)
        def _mismatch():
            nonlocal invoker, getter
            if getter is None:
                return False
            if invoker.name != getter.name:
                return True
            if invoker.params != getter.params:
                return True
            return False
        if _mismatch():
            raise ValueError("C# methods do not match.")
        self.__invoker = invoker
        self.__getter = getter

    #endregion

    #region properties

    @property
    def invoker(self):
        """ Invoker """
        return self.__invoker

    @property
    def getter(self):
        """ Return getter """
        return self.__getter

    #endregion

class FunctionBoolOverload(FunctionOverload):
    """ Represents an aaasm function boolean overload """

    #region init

    def __init__(self, invoker:FunctionInvoker):
        super().__init__(invoker.name, invoker.params, invoker.rettype)
        self.__invoker = invoker

    #endregion

    #region properties

    @property
    def invoker(self):
        """ Invoker """
        return self.__invoker

    #endregion

class FunctionDbgOverload(FunctionOverload):
    """ Represents an aaasm function debug overload """

    #region init

    def __init__(self, debug:FunctionDebug):
        global _DEBUG_DUMMY_RETTYPE
        super().__init__(debug.name, debug.params, _DEBUG_DUMMY_RETTYPE)
        self.__debug = debug

    #endregion

    #region properties

    @property
    def debug(self):
        """ Debugger """
        return self.__debug

    #endregion

class Function:
    """ Represents an aaasm function """

    #region init

    def __init__(self, name:str, overloads:_Iterable[FunctionOverload]):
        self.__name = name
        self.__overloads = _ImmList(overloads)
        for overload in self.__overloads:
            if overload.name == self.__name:
                continue
            raise ValueError("One or more overloads do not have the correct name.")

    #endregion

    #region properties

    @property
    def name(self):
        """ Name """
        return self.__name

    @property
    def overloads(self):
        """ Overloads """
        return self.__overloads

    #endregion

#endregion

#region helper

def _cs_source(dir:_Path):
    trees:list[_cs.CSRoughNodeTree] = []
    def _loop(dir:_Path):
        global CS_PARSER
        nonlocal trees
        for path in dir.iterdir():
            if path.is_dir():
                _loop(path)
                continue
            if not path.name.endswith(".cs"):
                continue
            trees.append(_cs.CSRoughNodeTree(_FileUtil.read_all_bytes(path)))
    _loop(dir)
    return _cs.CSCode.parse(*trees)

#endregion

#region get_functions

def get_functions(dir:_Path) -> list[Function]:
    """
    Retrieves aaasm functions

    :param dir: Directory to search thru
    :return: List of aaasm functions
    """
    global CS_NAMESPACE, CS_CLASS
    source = _cs_source(dir)
    # Get namespace
    if CS_NAMESPACE not in source.namespaces:
        return []
    namespace = source.namespaces[CS_NAMESPACE]
    # Get class
    if CS_CLASS not in namespace.types:
        return []
    classs = namespace.types[CS_CLASS]
    # Go thru method overloads
    invokers:list[FunctionInvoker] = []
    getters:list[FunctionGetter] = []
    debugs:list[FunctionDebug] = []
    for method in classs.members:
        if not isinstance(method, _cs.CSCodeMethod):
            continue
        for overload in method.overloads:
            # Should overload be considered?
            if overload.name.startswith(_EXCLUDE_PREFIX):
                continue
            # Function invoker
            parsed = FunctionInvoker.try_parse(overload)
            if parsed is not None:
                invokers.append(parsed)
                continue
            # Function return getter
            parsed = FunctionGetter.try_parse(overload)
            if parsed is not None:
                getters.append(parsed)
                continue
            # Function debugger
            parsed = FunctionDebug.try_parse(overload)
            if parsed is not None:
                debugs.append(parsed)
                continue
    # Compute aaasm function overloads
    overloads:list[FunctionOverload] = []
    for invoker in invokers:
        getter = None
        for _getter in getters:
            if _getter.name != invoker.name:
                continue
            if _getter.params != invoker.params:
                continue
            getter = _getter
        if invoker.rettype in RETURN_BOOLEAN:
            overloads.append(FunctionBoolOverload(invoker))
        else:
            if getter is None and invoker.rettype in RETURN_EXPLICIT:
                continue
            overloads.append(FunctionStdOverload(invoker, getter))
    for debug in debugs:
        overloads.append(FunctionDbgOverload(debug))
    # Compute aaasm functions
    functions_overloads:dict[str, list[FunctionOverload]] = {}
    for overload in overloads:
        if overload.name in functions_overloads:
            function_overloads = functions_overloads[overload.name]
        else:
            function_overloads:list[FunctionOverload] = []
            functions_overloads[overload.name] = function_overloads
        function_overloads.append(overload)
    functions = [Function(_name, _overloads)\
        for _name, _overloads in functions_overloads.items()]
    # Success!!!
    return functions

#endregion