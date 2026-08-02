__all__ = ['CSCodeMethodOverload']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    cast as _cast,\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSCodeAccess import\
    CSCodeAccess as _CSCodeAccess
from .CSCodeAccessible import\
    CSCodeAccessible as _CSCodeAccessible
from .CSCodeAccessInfo import\
    CSCodeAccessInfo as _CSCodeAccessInfo
from .CSCodeParameters import\
    CSCodeParameters as _CSCodeParameters
from .CSCodeTypeMember import\
    CSCodeTypeMember as _CSCodeTypeMember
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._AnalUtil import _AnalUtil
from ._Analyzer import _Analyzer
from ._CSCodeCopyable import _CSCodeCopyable

if _TYPE_CHECKING:
    from .CSCodeMethod import\
        CSCodeMethod as _CSCodeMethod

class CSCodeMethodOverload(_CSCodeAccessible,\
        _CSCodeCopyable['CSCodeMethodOverload']):
    """ Represents a C# method overload """

    #region init

    def __init__(self, f:'__Fields'):
        super().__init__(f.access_info)
        self.__f = f
        self.__method = _cast('_CSCodeMethod', None) # This will be changed by method

    #endregion

    #region _try_parse, _cleanup, _copy

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            f = cls.__Fields()
            # Is this a method declaration?
            if not analyzer.valid():
                return None
            if analyzer.current.type != 'method_declaration':
                return None
            inner_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            # Extract attributes
            f.attributes = _AnalUtil.attributes_parse(inner_analyzer)
            # Extract modifiers
            f.access_info = _CSCodeAccessInfo._parse(inner_analyzer, _CSCodeAccess.PRIVATE)
            # Extract return type
            rettype = _AnalUtil.rettype_try_parse(inner_analyzer)
            if rettype is None:
                return None
            f.return_type, f.is_ref = rettype
            # Extract name
            result = _AnalUtil.name_try_parse(inner_analyzer)
            if result is None:
                return None
            f.name, f.typeparams = result
            # Extract parameters
            result = _CSCodeParameters._try_parse(inner_analyzer)
            if result is None:
                return None
            f.parameters = result
            # Extract type parameter constraints
            f.typeconstraints = _AnalUtil.typeconstraints_parse(inner_analyzer)
            # Success!!!
            return cls(f)
        return analyzer.parse_wrapper(_func)

    @classmethod
    def _cleanup(cls, input:_Iterable['CSCodeMethodOverload'], force_new:bool):
        def _duplicate(a:CSCodeMethodOverload, b:CSCodeMethodOverload):
            if not a.parameters._equals(b.parameters):
                return False
            return True
        output:list[CSCodeMethodOverload] = []
        for input_item in input:
            is_duplicate = False
            for output_item in output:
                if not _duplicate(input_item, output_item):
                    continue
                is_duplicate = True
                break
            if is_duplicate:
                continue
            if not force_new: output.append(input_item)
            else: output.append(input_item._i_copy())
        return _ImmList(output)

    #endregion

    #region fields

    class __Fields:
        name:str
        access_info:_CSCodeAccessInfo
        attributes:_ImmList[str]
        return_type:str
        is_ref:bool
        typeparams:_ImmSet[str]
        typeconstraints:_ImmDict[str, _ImmSet[str]]
        parameters:_CSCodeParameters

    #endregion

    #region properties

    @property
    def method(self):
        """ Method """
        return self.__method

    @property
    def name(self):
        """ Name """
        return self.__f.name

    @property
    def typeparams(self):
        """ Type parameters """
        return self.__f.typeparams

    @property
    def attributes(self):
        """ Attributes """
        return self.__f.attributes

    @property
    def return_type(self):
        """ Return type """
        return self.__f.return_type

    @property
    def typeconstraints(self):
        """ Type parameter constraints """
        return self.__f.typeconstraints

    @property
    def parameters(self):
        """ Parameters """
        return self.__f.parameters

    @property
    def is_ref(self):
        """ Whether or not the ref keyword is used """
        return self.__f.is_ref

    #endregion

    #region internal

    def _i_method(self, value:'_CSCodeMethod'):
        """ Also accessed by CSCodeMethod """
        self.__method = value

    #endregion
    
    #region CSCodeCopyable

    def _i_copy(self):
        f = self.__Fields()
        f.name = self.__f.name
        f.access_info = self.__f.access_info
        f.attributes = self.__f.attributes
        f.return_type = self.__f.return_type
        f.is_ref = self.__f.is_ref
        f.typeparams = self.__f.typeparams
        f.typeconstraints = self.__f.typeconstraints
        f.parameters = self.__f.parameters
        return type(self)(f)

    #endregion