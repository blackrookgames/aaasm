__all__ = ['PathUtil']

from pathlib import\
    Path as _Path
from typing import\
    Callable as _Callable

class PathUtil:
    """ Utility for path-related operations """

    @staticmethod
    def get_parent(path:_Path):
        """
        Gets the parent directory of the specified path

        :param path: Input path
        :return: Full path of parent directory (or None if input path is a root)
        """
        parent = path.resolve().parent.resolve()
        if parent == path: return None
        return parent

    @classmethod
    def find_parent(cls, path:_Path, match:_Callable[[_Path], bool]):
        """
        Searches for a parent directory the matches the specified predicate

        :param path: Input path
        :param match: Predicate for checking parent directories
        :return: Path of matching parent (or None if no parent matched)
        """
        parent = cls.get_parent(path)
        while parent is not None:
            if match(parent): return parent
            parent = cls.get_parent(parent)
        return None

    @classmethod
    def find_parent_name(cls, path:_Path, name:str):
        """
        Searches for a parent directory with the specified name

        :param path: Input path
        :param name: Target parent name
        :return: Found parent (or None if no parent has the specified name)
        """
        return cls.find_parent(path, lambda parent: parent.name == name)

    @staticmethod
    def get_extension(path:_Path):
        """
        Gets the file extension of the specified path

        :param path: Input path
        :return: File extension of path (including leading dot)
        """
        index = path.name.rfind('.')
        if index < 0: return ""
        return path.name[index:]

    @staticmethod
    def change_extension(path:_Path, newext:str):
        """
        Changes the file extension of the path

        :param path: Input path
        :param newext: New file extension
        :return: Path with modified file extension
        """
        index = path.name.rfind('.')
        if index < 0: index = len(path.name)
        return path.parent.joinpath(path.name[:index] + newext)

