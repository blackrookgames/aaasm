__all__ = ['ColUtil']

from collections.abc import\
    Generator as _Generator,\
    Iterable as _Iterable
from typing import\
    Any as _Any,\
    Type as _Type,\
    TypeVar as _TypeVar

T = _TypeVar('T')

class ColUtil:
    """ Utility for handling collections """

    @staticmethod
    def iter_cast(t:_Type[T], collection:_Iterable[_Any])->\
            _Generator[T, _Any, None]:
        """
        Iterates thru the specified collection, casting each item to the specified target type

        :param t: Target type
        :param collection: Collection to iterate thru
        """
        for item in collection: yield item

    @staticmethod
    def iter_multi[T](*collections:_Iterable[T]):
        """
        Iterates thru multiple collections as if they were a single collection

        :param collections: Collections to iterate thru
        """
        for collection in collections:
            for item in collection:
                yield item