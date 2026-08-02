__all__ = ['CSCodeMembers']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    Type as _Type,\
    TypeVar as _TypeVar

from col import\
    KeyedCollection as _KeyedCollection,\
    RODict as _RODict
from .CSCodeMember import\
    CSCodeMember as _CSCodeMember

T = _TypeVar('T', bound = _CSCodeMember)

class CSCodeMembers(_KeyedCollection[str, T]):
    """ Represents a collection of C# source code members """

    #region init

    def __init__(self, member_type:_Type[T], items:_Iterable[T]):
        self.__f_items:dict[str, T] = {}
        self.__f__items:_RODict[str, T] = _RODict(self.__f_items)
        for item in items:
            if item.name in self.__f_items: continue
            self.__f_items[item.name] = item
        
    #endregion

    #region KeyedCollection

    @property
    def _dict(self): return self.__f__items

    #endregion