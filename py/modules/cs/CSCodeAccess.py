__all__ = ['CSCodeAccess']

from enum import\
    auto as _auto,\
    Enum as _Enum

class CSCodeAccess(_Enum):
    """ Represents a C# access modifier """
    PUBLIC = _auto()
    PRIVATE = _auto()
    PROTECTED = _auto()
    INTERNAL = _auto()
    PRIVATE_PROTECTED = _auto()
    PROTECTED_INTERNAL = _auto()
    FILE = _auto()