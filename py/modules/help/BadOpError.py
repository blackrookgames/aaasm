__all__ = ['BadOpError']

class BadOpError(Exception):
    """ Raised when attempting to perform an invalid operation """
    
    @classmethod
    def cannot_init_directly(cls, type:type):
        """
        Creates an BadOpError indicating an objects of the specified type cannot be initialized directly

        :param type: Type
        :return: Created BadOpError
        """
        return cls(f"{type.__name__} objects cannot be initialized directly.")