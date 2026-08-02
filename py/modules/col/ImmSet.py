__all__ = ['ImmSet']

from collections.abc import\
    Iterable as _Iterable
from typing import \
    Set as _Set,\
    TypeVar as _TypeVar

from .ROSet import\
    ROSet as _ROSet

T = _TypeVar('T')

class ImmSet(_Set[T]):
    """ Represents an immutable set """

    #region init

    def __init__(self, src:_Iterable[T]):
        """
        Initializer for ImmSet

        :param src: Source set
        """
        self.__f_items:set[T] = set()
        self.__f__items = _ROSet(self.__f_items)
        for item in src: self.__f_items.add(item)

    #endregion

    #region operators

    def __len__(self):
        return len(self.__f_items)

    def __iter__(self):
        for _name in self.__f_items: yield _name

    def __contains__(self, key:object):
        return key in self.__f_items

    #endregion

    #region properties

    @property
    def readonly(self):
        """ Exposes the ImmSet as an ROSet """
        return self.__f__items

    #endregion