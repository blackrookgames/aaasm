__all__ = ['_CSCodeMergable']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    Generic as _Generic,\
    TypeVar as _TypeVar,\
    cast as _cast

T = _TypeVar('T')

class _CSCodeMergable(_Generic[T]):
    """ 
    Represents a "mergable" C# element\n
    Some referenced data (such as source code) may not be copied over
    """

    #region abstract methods

    def _i_merge(self, other:T, force_new:bool) -> T:
        raise NotImplementedError()

    #endregion