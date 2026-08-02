__all__ = ['CSCodeAccessInfo']

from .CSCodeAccess import\
    CSCodeAccess as _CSCodeAccess

from ._Analyzer import _Analyzer

class CSCodeAccessInfo:
    """ Represents a C# access information """

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f
    
    #endregion

    #region _create, _parse, _merge

    @classmethod
    def _create(cls,\
            access:_CSCodeAccess = _CSCodeAccess.PRIVATE,\
            is_static:bool = False,\
            is_abstract:bool = False,\
            is_partial:bool = False,\
            is_readonly:bool = False):
        f = cls.__Fields()
        f.access = access
        f.is_static = is_static
        f.is_abstract = is_abstract
        f.is_partial = is_partial
        f.is_readonly = is_readonly
        return cls(f)

    @classmethod
    def _parse(cls, analyzer:_Analyzer, default_access:_CSCodeAccess):
        f = cls.__Fields()
        # Get modifiers
        modifiers:set[str] = set()
        while analyzer.valid() and analyzer.current.type == 'modifier':
            text = analyzer.current_text()
            if text is not None:
                modifiers.add(text)
            analyzer.seek_f()
        # Access level
        if 'public' in modifiers:
            f.access = _CSCodeAccess.PUBLIC
        elif 'private' in modifiers:
            f.access = _CSCodeAccess.PRIVATE_PROTECTED\
                if ('protected' in modifiers)\
                else _CSCodeAccess.PRIVATE
        elif 'protected' in modifiers:
            f.access = _CSCodeAccess.PROTECTED_INTERNAL\
                if ('internal' in modifiers)\
                else _CSCodeAccess.INTERNAL
        elif 'internal' in modifiers:
            f.access = _CSCodeAccess.INTERNAL
        elif 'file' in modifiers:
            f.access = _CSCodeAccess.FILE
        else:
            f.access = default_access
        # static
        f.is_static = 'static' in modifiers
        # abstract
        f.is_abstract = 'abstract' in modifiers
        # partial
        f.is_partial = 'partial' in modifiers
        # readonly
        f.is_readonly = 'readonly' in modifiers
        # Success!!!
        return cls(f)

    @classmethod
    def _merge(cls, a:'CSCodeAccessInfo', b:'CSCodeAccessInfo'):
        f = cls.__Fields()
        f.access = _CSCodeAccess(min(a.__f.access.value, b.__f.access.value))
        f.is_static = a.__f.is_static or b.__f.is_static
        f.is_abstract = a.__f.is_abstract or b.__f.is_abstract
        f.is_partial = a.__f.is_partial or b.__f.is_partial
        f.is_readonly = a.__f.is_readonly or b.__f.is_readonly
        return cls(f)

    #endregion

    #region fields

    class __Fields:
        access:_CSCodeAccess
        is_static:bool
        is_abstract:bool
        is_partial:bool
        is_readonly:bool

    #endregion

    #region properties

    @property
    def access(self):
        """ Access level """
        return self.__f.access

    @property
    def is_static(self):
        """ Whether or not this is static """
        return self.__f.is_static

    @property
    def is_abstract(self):
        """ Whether or not this is abstract """
        return self.__f.is_abstract

    @property
    def is_partial(self):
        """ Whether or not this is a partial declaration """
        return self.__f.is_partial

    @property
    def is_readonly(self):
        """ Whether or not this is read-only """
        return self.__f.is_readonly

    #endregion