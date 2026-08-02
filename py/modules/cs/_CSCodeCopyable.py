__all__ = ['_CSCodeCopyable']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    Generic as _Generic,\
    TypeVar as _TypeVar,\
    cast as _cast

T = _TypeVar('T')

class _CSCodeCopyable(_Generic[T]):
    """ 
    Represents a "copyable" C# element\n
    Some referenced data (such as source code) may not be copied over
    """

    #region abstract methods

    def _i_copy(self) -> T:
        raise NotImplementedError()

    #endregion

    #region methods

    @classmethod
    def _i_copy_multi(cls, input:_Iterable[T]):
        return (_cast(_CSCodeCopyable[T], item)._i_copy() for item in input)

    #endregion