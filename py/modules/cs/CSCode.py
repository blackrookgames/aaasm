__all__ = ['CSCode']

from collections.abc import\
    Iterable as _Iterable
from dataclasses import\
    dataclass as _dataclass

from col import\
    ColUtil as _ColUtil,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSCodeAccess import\
    CSCodeAccess as _CSCodeAccess
from .CSCodeMember import\
    CSCodeMember as _CSCodeMember
from .CSCodeMembers import\
    CSCodeMembers as _CSCodeMembers
from .CSCodeNamespace import\
    CSCodeNamespace as _CSCodeNamespace
from .CSCodeType import\
    CSCodeType as _CSCodeType
from .CSRoughNodeTree import\
    CSRoughNodeTree as _CSRoughNodeTree
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._Analyzer import _Analyzer

class CSCode:
    """ Represents C# source code """

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f
        # Set as code
        def _set_code(member:_CSCodeMember):
            nonlocal self
            member._i_code(self)
            for child in member._i_child_members:
                _set_code(child)
        for member in self.namespaces:
            _set_code(member)
        for member in self.types:
            _set_code(member)

    #endregion

    #region parse, merge
    
    @classmethod
    def __parse(cls, src:_CSRoughNodeTree):
        f = cls.__Fields()
        # Extract namespaces and types
        f_namespaces:list[_CSCodeNamespace] = []
        f_types:list[_CSCodeType] = []
        def _extract(ns_prefix:str, analyzer:_Analyzer, look4types:bool = False):
            nonlocal f_namespaces, f_types
            while analyzer.valid():
                current = analyzer.current
                # Namespace?
                result = _CSCodeNamespace._try_parse(analyzer, ns_prefix)
                if result is not None:
                    f_namespaces.append(result)
                    # Look for declaration list
                    inner_analyzer = _Analyzer(current)
                    if inner_analyzer.seek_f_type('declaration_list'):
                        _extract(result.name + '.', _Analyzer(inner_analyzer.current))
                        continue
                    # Must be a file-scoped namespace
                    fs_analyzer = _Analyzer(analyzer.parent)
                    fs_analyzer.position = current.index + 1
                    _extract(result.name + '.', fs_analyzer)
                    continue
                # Type?
                if look4types:
                    result = _CSCodeType._try_parse(analyzer, _CSCodeAccess.INTERNAL)
                    if result is not None:
                        f_types.append(result)
                # Anything else?
                analyzer.seek_f()
        _extract('', _Analyzer(src.root), True)
        # Success!!!
        f.namespaces = _CSCodeNamespace._cleanup(f_namespaces, False)
        f.types = _CSCodeType._cleanup(f_types, False)
        return cls(f)
    
    @classmethod
    def parse(cls, *srcs:_CSRoughNodeTree):
        if len(srcs) == 0:
            f = cls.__Fields()
            f.namespaces = _CSCodeMembers(_CSCodeNamespace, [])
            f.types = _CSCodeMembers(_CSCodeType, [])
            return cls(f)
        code = cls.__parse(srcs[0])
        for i in range(1, len(srcs)):
            code = code.merge(cls.__parse(srcs[i]))
        return code

    def merge(self, other:'CSCode'):
        f = self.__Fields()
        f.namespaces = _CSCodeNamespace._cleanup(\
            _ColUtil.iter_multi(self.__f.namespaces, other.__f.namespaces),\
            True)
        f.types = _CSCodeType._cleanup(\
            _ColUtil.iter_multi(self.__f.types, other.__f.types),\
            True)
        return type(self)(f)

    #endregion

    #region fields

    class __Fields:
        namespaces:_CSCodeMembers[_CSCodeNamespace]
        types:_CSCodeMembers[_CSCodeType]

    #endregion

    #region properties

    @property
    def namespaces(self):
        """ Namespaces """
        return self.__f.namespaces

    @property
    def types(self):
        """ Top-level type declarations """
        return self.__f.types

    #endregion