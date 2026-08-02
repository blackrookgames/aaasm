__all__ = ['ROSet']

from typing import \
    Set as _Set,\
    TypeVar as _TypeVar

T = _TypeVar('T')

class ROSet(_Set[T]):
    """ Represents read-only access to a set """

    #region init

    def __init__(self, src:set[T]):
        """
        Initializer for ROSet

        :param src: Source set
        """
        self.__src = src

    #endregion

    #region operators

    def __len__(self):
        return len(self.__src)

    def __iter__(self):
        for _name in self.__src: yield _name

    def __contains__(self, key:object):
        return key in self.__src

    #endregion