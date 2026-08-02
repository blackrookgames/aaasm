__all__ = ['CSCodeTypeKind']

from enum import\
    auto as _auto,\
    Enum as _Enum

class CSCodeTypeKind(_Enum):
    """ Represents a C# type kind """
    CLASS = _auto()
    STRUCT = _auto()
    INTERFACE = _auto()