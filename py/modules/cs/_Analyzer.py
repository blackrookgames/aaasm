from typing import\
    Callable as _Callable,\
    TypeVar as _TypeVar,\
    cast as _cast

from help import\
    BadOpError as _BadOpError,\
    StrUtil as _StrUtil

from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

T = _TypeVar('T')
_ParseWrapperFunc = _Callable[['_Analyzer'], None|T]

class _Analyzer:
    """ Represents an analyzer of rough nodes """

    #region init

    def __init__(self, parent:_CSRoughNode):
        """
        Initializer for _Analyzer

        :param parent: Parent node
        """
        self.__parent = parent
        self.__position = 0
        self.__update_current()

    #endregion

    #region operators

    def __len__(self):
        return len(self.__parent.children)
    
    def __iter__(self):
        for child in self.__parent.children:
            yield child

    def __getitem__(self, index:int):
        try:
            return self.__parent.children[index]
        except:
            if index >= 0 and index < len(self.__parent.children):
                raise
        raise IndexError("Index is out of range.")

    #endregion

    #region properties

    @property
    def parent(self):
        """ Parent node """
        return self.__parent
    
    @property
    def position(self):
        """ Current position within child nodes """
        return self.__position
    @position.setter
    def position(self, value:int):
        if self.__position == value: return
        self.__position = value
        self.__update_current()

    @property
    def current(self):
        """
        Current child node

        :raise _BadOpError: Current position is not valid
        """
        if self.__current is not None: return self.__current
        raise _BadOpError("Current position is not valid.")

    #endregion

    #region helper methods

    def __update_current(self):
        self.__current = None if (not self.valid())\
            else self.__parent.children[self.__position]

    def __seek_until(self, condition:_Callable[[_CSRoughNode], bool], inc:int):
        while self.valid():
            if condition(_cast(_CSRoughNode, self.__current)): return True
            self.position += inc # Use position, NOT __position
        return False

    #endregion

    #region methods
    
    def parse_wrapper(self, call:_ParseWrapperFunc[T]):
        """
        Wrapper for try parse operations\n
        If parsing fails the analyzer position is returned to the position before the operation was called

        :param call: Try parse operation
        :return: Parse result (None indicates the parsing failed)
        """
        restore = self.position
        result = None
        try:
            result = call(self)
        finally:
            if result is None: self.position = restore # Use position, NOT __position
        return result

    def current_text(self, keep_ws:bool = False):
        """
        Retrieves the text of the current node, removing whitespace
        
        :param keep_ws: Whether or not to keep the whitespace
        :return: Text of current node (or None if node does not contain text)
        :raise _BadOpError: Current position is not valid
        """
        text = self.current.text # Use current, NOT __current
        if text is None: return None
        if keep_ws: return text.decode()
        return _StrUtil.remove_ws(text.decode())

    def valid(self):
        """
        Checks if or not the current position is valid

        :return: Whether or not the current position is valid
        """
        return self.__position >= 0 and self.__position < len(self.__parent.children)
    
    #endregion

    #region seek
    
    def seek_f(self):
        """
        Moves to the next position

        :return: Whether or not the new position is valid
        """
        self.position += 1 # Use position, NOT __position
        return self.valid()

    def seek_b(self):
        """
        Moves to the previous position

        :return: Whether or not the new position is valid
        """
        self.position -= 1 # Use position, NOT __position
        return self.valid()

    def seek_f_until(self, condition:_Callable[[_CSRoughNode], bool]):
        """
        Moves forward until either:
        - The analyzer finds a node that satisfies the specified condition
        - The analyzer position becomes invalid

        :param condition: Condition to satisfy
        :return: Whether or not the analyzer found a node that satisfies the condition
        """
        return self.__seek_until(condition, 1)

    def seek_b_until(self, condition:_Callable[[_CSRoughNode], bool]):
        """
        Moves backward until either:
        - The analyzer finds a node that satisfies the specified condition
        - The analyzer position becomes invalid

        :param condition: Condition to satisfy
        :return: Whether or not the analyzer found a node that satisfies the condition
        """
        return self.__seek_until(condition, -1)

    def seek_f_type(self, type:str):
        """
        Moves forward until either:
        - The analyzer finds a node of the specified type
        - The analyzer position becomes invalid

        :param type: Type of node to seek
        :return: Whether or not the analyzer found a node of the specified type
        """
        return self.seek_f_until(lambda node: node.type == type)

    def seek_b_type(self, type:str):
        """
        Moves backward until either:
        - The analyzer finds a node of the specified type
        - The analyzer position becomes invalid

        :param type: Type of node to seek
        :return: Whether or not the analyzer found a node of the specified type
        """
        return self.seek_b_until(lambda node: node.type == type)

    #endregion