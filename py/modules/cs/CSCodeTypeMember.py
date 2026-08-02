__all__ = ['CSCodeTypeMember']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    cast as _cast,\
    TYPE_CHECKING as _TYPE_CHECKING

from .CSCodeMember import\
    CSCodeMember as _CSCodeMember
from .CSCodeMembers import\
    CSCodeMembers as _CSCodeMembers

from ._CSCodeCopyable import _CSCodeCopyable
from ._CSCodeMergable import _CSCodeMergable

if _TYPE_CHECKING:
    from .CSCodeType import\
        CSCodeType as _CSCodeType

class CSCodeTypeMember(_CSCodeMember,\
        _CSCodeCopyable['CSCodeTypeMember'],\
        _CSCodeMergable['CSCodeTypeMember']):
    """ Represents a member of a C# type """

    #region init

    def __init__(self,\
            name:str):
        super().__init__(name)
        self.__outer_type = _cast('_CSCodeType', None)

    #endregion

    #region _cleanup, _copy

    @classmethod
    def _cleanup(cls, input:_Iterable['CSCodeTypeMember'], force_new:bool):
        output:dict[str, CSCodeTypeMember] = {}
        for input_item in input:
            if input_item.name in output:
                output_item = output[input_item.name]._i_merge(input_item, force_new)
            elif force_new:
                output_item = input_item._i_copy()
            else:
                output_item = input_item
            output[output_item.name] = output_item
        return _CSCodeMembers(CSCodeTypeMember, output.values())

    @classmethod
    def _copy(cls, input:_Iterable['CSCodeTypeMember']):
        """ Code and outer type information are not copied """
        return _CSCodeMembers(CSCodeTypeMember, (item._p_copy() for item in input))

    #endregion

    #region properties

    @property
    def outer_type(self):
        """ Outer type """
        return self.__outer_type

    #endregion

    #region internal methods

    def _i_outer_type(self, value:'_CSCodeType'):
        """ Also accessed by CSCodeType """
        self.__outer_type = value

    #endregion

    #region abstract methods

    def _p_merge(self, other:'CSCodeTypeMember', force_new:bool) -> 'CSCodeTypeMember':
        raise NotImplementedError

    def _p_copy(self) -> 'CSCodeTypeMember':
        """ Code reference and type reference are not copied """
        raise NotImplementedError()

    #endregion
    
    #region CSCodeCopyable

    def _i_copy(self):
        return self._p_copy()

    #endregion

    #region CSCodeMergable

    def _i_merge(self, other: 'CSCodeTypeMember', force_new: bool):
        return self._p_merge(other, force_new)

    #endregion