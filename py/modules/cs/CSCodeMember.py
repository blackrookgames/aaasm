__all__ = ['CSCodeMember']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    cast as _cast,\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

if _TYPE_CHECKING:
    from .CSCode import\
        CSCode as _CSCode

class CSCodeMember:
    """ Represents a C# source code member """

    #region init

    def __init__(self, name:str):
        self.__code = _cast('_CSCode', None)
        self.__name = name

    #endregion

    #region const

    __NO_CHILD_MEMBERS = _ImmList['CSCodeMember']([])

    #endregion

    #region properties

    @property
    def code(self) -> '_CSCode':
        """ Source code """
        return self.__code

    @property
    def name(self):
        """ Name """
        return self.__name

    #endregion

    #region virtual properties

    @property
    def _i_child_members(self) -> _Iterable['CSCodeMember']:
        """ Also accessed by CSCode """
        return self.__NO_CHILD_MEMBERS

    #endregion

    #region internal methods

    def _i_code(self, value:'_CSCode'):
        """ Also accessed by CSCode """
        self.__code = value

    #endregion