__all__ = ['CSCodeAccessible']

from .CSCodeAccessInfo import\
    CSCodeAccessInfo as _CSCodeAccessInfo

class CSCodeAccessible:
    """ Represents a C# source code member with access information """

    #region init

    def __init__(self, info:_CSCodeAccessInfo):
        self.__info = info

    #endregion

    #region properties

    @property
    def access(self):
        """ Access level """
        return self.__info.access

    @property
    def is_static(self):
        """ Whether or not this is static """
        return self.__info.is_static

    @property
    def is_abstract(self):
        """ Whether or not this is abstract """
        return self.__info.is_abstract

    @property
    def is_partial(self):
        """ Whether or not this is a partial declaration """
        return self.__info.is_partial

    @property
    def is_readonly(self):
        """ Whether or not the readonly keyword was used """
        return self.__info.is_readonly

    #endregion