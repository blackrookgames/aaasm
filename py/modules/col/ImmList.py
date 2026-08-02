__all__ = ['ImmList']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    Generic as _Generic,\
    TypeVar as _TypeVar

from .ROList import\
    ROList as _ROList

T = _TypeVar('T')

class ImmList(_Generic[T]):
    """ Represents an immutable list """

    #region init

    def __init__(self, src:_Iterable[T]):
        """
        Initializer for ImmList

        :param items: List items
        """
        self.__f_items = [item for item in src]
        self.__f__items = _ROList(self.__f_items)

    #endregion

    #region operators
    
    def __iter__(self):
        for item in self.__f_items: yield item

    def __len__(self):
        return len(self.__f_items)
    
    def __getitem__(self, index:int):
        if index < 0 or index >= len(self.__f_items):
            raise IndexError("Index is out of range.")
        return self.__f_items[index]
    
    def __contains__(self, item):
        return item in self.__f_items

    #endregion

    #region properties

    @property
    def readonly(self):
        """ Exposes the ImmList as an ROList """
        return self.__f__items

    #endregion