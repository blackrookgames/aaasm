__all__ = ['CSCodeProperty']

from collections.abc import\
    Iterable as _Iterable
from typing import\
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
from .CSCodeTypeMember import\
    CSCodeTypeMember as _CSCodeTypeMember
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._AnalUtil import _AnalUtil
from ._Analyzer import _Analyzer

if _TYPE_CHECKING:
    from .CSCodeType import\
        CSCodeType as _CSCodeType

class CSCodeProperty(_CSCodeTypeMember, _CSCodeAccessible):
    """ Represents a C# property """

    #region init

    def __init__(self, f:'__Fields'):
        _CSCodeTypeMember.__init__(self, f.name)
        _CSCodeAccessible.__init__(self, f.access_info)
        self.__f = f

    #endregion

    #region _try_parse

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            f = cls.__Fields()
            # Is this a property declaration?
            if not analyzer.valid():
                return None
            if analyzer.current.type != 'property_declaration':
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
            f.name = result[0]
            # Success!!!
            return cls(f)
        return analyzer.parse_wrapper(_func)

    #endregion

    #region fields

    class __Fields:
        name:str
        access_info:_CSCodeAccessInfo
        attributes:_ImmList[str]
        return_type:str
        is_ref:bool

    #endregion

    #region properties

    @property
    def attributes(self):
        """ Attributes """
        return self.__f.attributes

    @property
    def return_type(self):
        """ Return type """
        return self.__f.return_type

    @property
    def is_ref(self):
        """ Whether or not the ref keyword is used """
        return self.__f.is_ref

    #endregion

    #region CSCodeTypeMember

    def _p_merge(self, other:_CSCodeTypeMember, force_new:bool):
        return self._p_copy() if force_new else self

    def _p_copy(self):
        f = self.__Fields()
        f.name = self.__f.name
        f.access_info = self.__f.access_info
        f.attributes = self.__f.attributes
        f.return_type = self.__f.return_type
        return type(self)(f)

    #endregion