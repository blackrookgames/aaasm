__all__ = ['FileUtil']

from pathlib import\
    Path as _Path

from .IOError import\
    IOError as _IOError

class FileUtil:
    """ Utility for file-related operations """

    #region read_all_bytes, write_all_bytes

    @classmethod
    def read_all_bytes(cls, path:str|_Path):
        """
        Reads all byte data in a file

        :param path: File path
        :return: Byte data in file
        :raise IOError: An I/O error occurred
        """
        try:
            with open(path, 'rb') as f:
                return f.read()
        except Exception as e:
            error = _IOError(e)
        raise error
    
    @classmethod
    def write_all_bytes(cls, path:str|_Path, data:bytes):
        """
        Writes bytes data to a file

        :param path: File path
        :param data: Byte data
        :raise IOError: An I/O error occurred
        """
        try:
            with open(path, 'wb') as f:
                f.write(data)
            return
        except Exception as e:
            error = _IOError(e)
        raise error
        
    #endregion

    #region read_all_text, write_all_text

    @classmethod
    def read_all_text(cls, path:str|_Path):
        """
        Reads all text data in a file

        :param path: File path
        :return: Byte data in file
        :raise IOError: An I/O error occurred
        """
        try:
            with open(path, 'r') as f:
                return f.read()
        except Exception as e:
            error = _IOError(e)
        raise error
    
    @classmethod
    def write_all_text(cls, path:str|_Path, data:str):
        """
        Writes text data to a file

        :param path: File path
        :param data: Byte data
        :raise IOError: An I/O error occurred
        """
        try:
            with open(path, 'w') as f:
                f.write(data)
            return
        except Exception as e:
            error = _IOError(e)
        raise error
        
    #endregion