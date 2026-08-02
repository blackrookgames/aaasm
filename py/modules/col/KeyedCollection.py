__all__ = ['KeyedCollection']

from typing import\
    Generic as _Generic,\
    TypeVar as _TypeVar

from .RODict import\
    RODict as _RODict

TKey = _TypeVar('TKey')
TItem = _TypeVar('TItem')

class KeyedCollection(_Generic[TKey, TItem]):
    """ Represents a collection of keyed items """

    #region operators

    def __len__(self):
        return len(self._dict)

    def __getitem__(self, key:TKey):
        try: 
            return self._dict[key]
        except:
            if key in self._dict: raise
        raise KeyError("Could not find the specified key.")
    
    def __iter__(self):
        for _item in self._dict.iter_values():
            yield _item

    def __contains__(self, key:TKey):
        return key in self._dict

    #endregion

    #region abstract properties

    @property
    def _dict(self) -> _RODict[TKey, TItem]:
        """ Underlying dictionary """
        raise NotImplementedError()

    #endregion