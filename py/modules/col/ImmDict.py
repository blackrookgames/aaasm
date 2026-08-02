__all__ = ['ImmDict']

from collections.abc import\
    Iterable as _Iterable
from typing import \
    Generic as _Generic,\
    TypeVar as _TypeVar

from .RODict import\
    RODict as _RODict

TKey = _TypeVar('TKey')
TValue = _TypeVar('TValue')

class ImmDict(_Generic[TKey, TValue]):
    """ Represents an immutable dictionary """

    #region init

    def __init__(self, src:_Iterable[tuple[TKey, TValue]]):
        """
        Initializer for ImmDict

        :param src: Source dictionary
        """
        self.__f_dict:dict[TKey, TValue] = {}
        self.__f__dict = _RODict(self.__f_dict)
        for key, val in src: self.__f_dict[key] = val

    #endregion

    #region operators

    def __len__(self):
        return len(self.__f_dict)

    def __getitem__(self, key:TKey):
        try: return self.__f_dict[key]
        except:
            if key in self.__f_dict: raise
        raise KeyError("Could not find the specified key.")
    
    def __iter__(self):
        for _name in self.__f_dict: yield _name

    def __contains__(self, key:TKey):
        return key in self.__f_dict

    #endregion

    #region properties

    @property
    def readonly(self):
        """ Exposes the ImmDict as an RODict """
        return self.__f__dict

    #endregion

    #region methods

    def iter_items(self):
        """ Iterates thru all items in the dictionary """
        for _item in self.__f_dict.items(): yield _item

    def iter_keys(self):
        """ Iterates thru all keys in the dictionary """
        for _key in self.__f_dict.keys(): yield _key

    def iter_values(self):
        """ Iterates thru all values in the dictionary """
        for _value in self.__f_dict.values(): yield _value

    def items(self):
        """
        Retrieves a copy of all items in the dictionary
        
        :return: List of all items in the dictionary
        """
        return [_item for _item in self.iter_items()]

    def keys(self):
        """
        Retrieves a copy of all keys in the dictionary
        
        :return: List of all keys in the dictionary
        """
        return [_key for _key in self.iter_keys()]

    def values(self):
        """
        Retrieves a copy of all values in the dictionary
        
        :return: List of all values in the dictionary
        """
        return [_value for _value in self.iter_values()]
        
    def find_value(self, key:TKey):
        """
        Searches the dictionary for the value of the specified key

        :param key: Key
        :return: Value of found key (or None if key could not be found)
        """
        if key in self.__f_dict:
            return self.__f_dict[key]
        return None
    
    def find_key(self, value:TValue):
        """
        Searches the dictionary for the key with the specified value

        :param value: Value
        :return: Key with the specified value (or None if no key has the specified value)
        """
        for _k, _v in self.__f_dict.items():
            if _v == value: return _k
        return None

    #endregion