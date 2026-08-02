__all__ = ['CSCodeConstructor']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    cast as _cast,\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
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
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._AnalUtil import _AnalUtil
from ._Analyzer import _Analyzer
from ._CSCodeCopyable import _CSCodeCopyable

if _TYPE_CHECKING:
    from .CSCodeType import\
        CSCodeType as _CSCodeType

class CSCodeConstructor(_CSCodeAccessible, \
        _CSCodeCopyable['CSCodeConstructor']):
    """ Represents a C# constructor """

    #region init

    def __init__(self, f:'__Fields'):
        super().__init__(f.access_info)
        self.__f = f
        self.__type = _cast('_CSCodeType', None)

    #endregion

    #region _primary, _try_parse, _cleanup

    @classmethod
    def _primary(cls, srcs:_ImmList[_CSRoughNode], parameters:_CSCodeParameters):
        f = cls.__Fields()
        f.access_info = _CSCodeAccessInfo._create(access = _CSCodeAccess.PUBLIC)
        f.attributes = _ImmList([])
        f.parameters = parameters
        return cls(f)

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            f = cls.__Fields()
            # Is this a constructor declaration?
            if not analyzer.valid():
                return None
            if analyzer.current.type != 'constructor_declaration':
                return None
            inner_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            # Extract attributes
            f.attributes = _AnalUtil.attributes_parse(inner_analyzer)
            # Extract modifiers
            f.access_info = _CSCodeAccessInfo._parse(inner_analyzer, _CSCodeAccess.PRIVATE)
            # Extract identifier (assume it's the name of the type)
            if not inner_analyzer.valid():
                return None
            if inner_analyzer.current.type != 'identifier':
                return None
            inner_analyzer.seek_f()
            # Extract parameters
            result = _CSCodeParameters._try_parse(inner_analyzer)
            if result is None:
                return None
            f.parameters = result
            # Success!!!
            return cls(f)
        return analyzer.parse_wrapper(_func)

    @classmethod
    def _cleanup(cls, input:_Iterable['CSCodeConstructor'], force_new:bool):
        def _duplicate(a:CSCodeConstructor, b:CSCodeConstructor):
            if a.is_static != b.is_static: # Static constructors are different
                return False
            if not a.parameters._equals(b.parameters):
                return False
            return True
        output:list[CSCodeConstructor] = []
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
        access_info:_CSCodeAccessInfo
        attributes:_ImmList[str]
        parameters:_CSCodeParameters

    #endregion

    #region properties

    @property
    def attributes(self):
        """ Attributes """
        return self.__f.attributes

    @property
    def parameters(self):
        """ Parameters """
        return self.__f.parameters

    @property
    def type(self):
        """ Type of C# object being constructed """
        return self.__type

    #endregion

    #region internal methods

    def _i_type(self, value:'_CSCodeType'):
        """ Also accessed by CSCodeType """
        self.__type = value

    #endregion
    
    #region CSCodeCopyable

    def _i_copy(self):
        f = self.__Fields()
        f.access_info = self.__f.access_info
        f.attributes = self.__f.attributes
        f.parameters = self.__f.parameters
        return type(self)(f)

    #endregion