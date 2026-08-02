__all__ = ['CSRoughNode']

from collections.abc import\
    Sequence as _Sequence
from tree_sitter import\
    Node as _Node
from typing import\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
    ImmList as _ImmList
from help import\
    BadOpError as _BadOpError

if _TYPE_CHECKING:
    from .CSRoughNodeTree import\
        CSRoughNodeTree as _CSRoughNodeTree

class CSRoughNode:
    """ Represents a rough node """

    #region init

    def __init__(self, tree:'_CSRoughNodeTree', parent:'None|CSRoughNode', index:int, src:_Node):
        """ Do NOT initialize directly """
        if tree._init or (parent is not None and parent._init):
            raise _BadOpError.cannot_init_directly(type(self))
        # Initialize init variable
        self._init = False
        # type, text
        self.__type = src.type
        self.__text = src.text
        # tree, parent, index, children
        self.__tree = tree
        self.__parent = parent
        self.__index = index
        self.__children = _ImmList(self.__init_children(self, src.children))
        # Mark as initialized
        # This will prevent people from trying to create nodes directly and specifying this node as the parent
        self._init = True

    #endregion

    #region properties

    @property
    def type(self):
        """ Tree-Sitter node type """
        return self.__type

    @property
    def text(self):
        """ Raw text """
        return self.__text

    @property
    def tree(self):
        """ Tree """
        return self.__tree

    @property
    def parent(self):
        """ Parent """
        return self.__parent

    @property
    def index(self):
        """ Index among siblings (-1 means the node does not have a parent) """
        return self.__index

    @property
    def children(self):
        """ Children """
        return self.__children

    #endregion

    #region private methods

    @classmethod
    def __init_children(cls, parent:'CSRoughNode', src_children:_Sequence[_Node]):
        for i in range(len(src_children)):
            yield cls(parent.__tree, parent, i, src_children[i])

    #endregion