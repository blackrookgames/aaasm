__all__ = ['Outputter']

from collections.abc import\
    Iterable as _Iterable
from io import\
    StringIO as _StringIO

class Outputter:
    """ Represents a handler for outputting to the terminal """

    #region init

    def __init__(self, indent:int = 0, indent_unit = "    "):
        """
        Initializer for Outputter

        :param indent:
            Indentation
        :param indent_unit:
            Indentation unit
        """
        self.__indent = max(0, indent)
        self.__indent_unit = indent_unit
        self.__column = 0

    #endregion

    #region properties

    @property
    def indent(self):
        """ Indentation """
        return self.__indent
    @indent.setter
    def indent(self, value:int):
        self.__indent = max(0, value)
    
    @property
    def indent_unit(self):
        """ Indentation unit """
        return self.__indent_unit

    #endregion

    #region helper methods

    @classmethod
    def create_str(cls, args:_Iterable):
        with _StringIO() as w:
            space = False
            for arg in args:
                if space: w.write(' ')
                w.write(arg)
                space = True
            return w.getvalue()

    #endregion

    #region methods

    def indent_inc(self):
        """ Increase indentation """
        self.__indent += 1

    def indent_dec(self):
        """ Decrease indentation """
        if self.__indent > 0:
            self.__indent -= 1
    
    def print(self, *args, **kwargs):
        """ Prints to the terminal """
        end = '\n' if ('end' not in kwargs) else kwargs['end']
        content = self.create_str(args) + end
        i = 0
        while i < len(content):
            c = content[i]
            linefeed = False
            if c == '\n':
                linefeed = True
                i += 2 if ((i + 1) < len(content) and content[i + 1] == '\r') else 1
            elif c == '\r':
                linefeed = True
                i += 2 if ((i + 1) < len(content) and content[i + 1] == '\n') else 1
            else:
                i += 1
            if linefeed:
                print()
                self.__column = 0
            else:
                if self.__column == 0:
                    indent = self.__indent_unit * self.__indent
                    print(indent, end = '')
                    self.__column = len(indent)
                print(c, end = '')
                self.__column += 1

    #endregion