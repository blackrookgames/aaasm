__all__ = ['CSRoughNodeTree']

import tree_sitter as _ts
import tree_sitter_c_sharp as _ts_cs

from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

_LANGUAGE = _ts.Language(_ts_cs.language())
_PARSER = _ts.Parser(_LANGUAGE)

class CSRoughNodeTree:
    """ Represents a rough node tree """

    #region init

    def __init__(self, src:bytes):
        parsed = _PARSER.parse(src)
        # Initialize init variable
        self._init = False
        # root
        self.__root = _CSRoughNode(self, None, -1, parsed.root_node)
        # Mark as initialized
        # This will prevent people from trying to create nodes directly and referencing this tree
        self._init = True

    #endregion

    #region properties

    @property
    def root(self):
        """ Root node """
        return self.__root

    #endregion