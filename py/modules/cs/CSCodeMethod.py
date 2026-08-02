__all__ = ['CSCodeMethod']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
    ColUtil as _ColUtil,\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSCodeAccess import\
    CSCodeAccess as _CSCodeAccess
from .CSCodeAccessInfo import\
    CSCodeAccessInfo as _CSCodeAccessInfo
from .CSCodeMethodOverload import\
    CSCodeMethodOverload as _CSCodeMethodOverload
from .CSCodeTypeMember import\
    CSCodeTypeMember as _CSCodeTypeMember
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._AnalUtil import _AnalUtil
from ._Analyzer import _Analyzer

if _TYPE_CHECKING:
    from .CSCodeType import\
        CSCodeType as _CSCodeType

class CSCodeMethod(_CSCodeTypeMember):
    """ Represents a C# method """

    #region init

    def __init__(self, f:'__Fields'):
        super().__init__(f.name)
        self.__f = f
        # Fix overloads
        for overload in self.__f.overloads:
            overload._i_method(self)

    #endregion

    #region _try_parse, _code

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            result = _CSCodeMethodOverload._try_parse(analyzer)
            if result is None: return None
            f = cls.__Fields()
            f.name = result.name
            f.overloads = _ImmList([result])
            return cls(f)
        return analyzer.parse_wrapper(_func)

    #endregion

    #region fields

    class __Fields:
        name:str
        overloads:_ImmList[_CSCodeMethodOverload]

    #endregion

    #region properties

    @property
    def overloads(self):
        """ Overloads """
        return self.__f.overloads

    #endregion

    #region CSCodeTypeMember

    def _p_merge(self, other:_CSCodeTypeMember, force_new:bool):
        if not isinstance(other, CSCodeMethod):
            return self._p_copy() if force_new else self
        f = self.__Fields()
        f.name = self.__f.name
        f.overloads = _CSCodeMethodOverload._cleanup(_ColUtil.iter_multi(\
            self.__f.overloads, other.__f.overloads),\
            force_new)
        return type(self)(f)

    def _p_copy(self):
        f = self.__Fields()
        f.name = self.__f.name
        f.overloads = _ImmList(_CSCodeMethodOverload._i_copy_multi(self.__f.overloads))
        return type(self)(f)

    #endregion