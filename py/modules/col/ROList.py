__all__ = ['ROList']

from typing import\
    Generic as _Generic,\
    TypeVar as _TypeVar

T = _TypeVar('T')

class ROList(_Generic[T]):
    """ Represents read-only access to a list """

    #region init

    def __init__(self, list:list[T]):
        """
        Initializer for ROList

        :param list: Actual list
        """
        self.__list = list

    #endregion

    #region operators
    
    def __iter__(self):
        for item in self.__list: yield item

    def __len__(self):
        return len(self.__list)
    
    def __getitem__(self, index:int):
        if index < 0 or index >= len(self.__list):
            raise IndexError("Index is out of range.")
        return self.__list[index]
    
    def __contains__(self, item):
        return item in self.__list

    #endregion