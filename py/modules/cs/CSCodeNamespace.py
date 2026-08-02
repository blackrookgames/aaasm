__all__ = ['CSCodeNamespace']

from collections.abc import\
    Iterable as _Iterable
from typing import Any

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
from .CSCodeType import\
    CSCodeType as _CSCodeType
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._Analyzer import _Analyzer
from ._CSCodeCopyable import _CSCodeCopyable
from ._CSCodeMergable import _CSCodeMergable

class CSCodeNamespace(_CSCodeMember,\
        _CSCodeCopyable['CSCodeNamespace'],\
        _CSCodeMergable['CSCodeNamespace']):
    """ Represents a C# namespace """

    #region init

    def __init__(self, f:'__Fields'):
        super().__init__(f.name)
        self.__f = f
        self.__child_members = _ImmList(_ColUtil.iter_cast(_CSCodeMember, self.__f.types))
        # Fix types
        for type in self.__f.types:
            type._i_namespace(self)

    #endregion

    #region _try_parse, _cleanup

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer, ns_prefix:str):
        def _func(analyzer:_Analyzer):
            nonlocal ns_prefix
            f = cls.__Fields()
            def __name(analyzer:_Analyzer, stop_at_type:None|str):
                nonlocal ns_prefix, f
                f.name = ns_prefix
                while analyzer.valid():
                    if stop_at_type is not None:
                        if analyzer.current.type == stop_at_type:
                            break
                    found_name =\
                        analyzer.current.type == 'qualified_name' or\
                        analyzer.current.type == 'identifier'
                    if not found_name:
                        analyzer.seek_f()
                        continue
                    text = analyzer.current_text()
                    if text is None:
                        continue
                    f.name = f.name + text
                    break
            def __analyze(analyzer:_Analyzer):
                nonlocal f
                # Get types
                f_types:list[_CSCodeType] = []
                while analyzer.valid():
                    # Type?
                    result = _CSCodeType._try_parse(analyzer, _CSCodeAccess.INTERNAL)
                    if result is not None:
                        f_types.append(result)
                        continue
                    # Anything else?
                    analyzer.seek_f()
                # Success!!!
                f.types = _CSCodeType._cleanup(f_types, False)
            if not analyzer.valid():
                return None
            elif analyzer.current.type == 'namespace_declaration':
                inner_analyzer = _Analyzer(analyzer.current)
                analyzer.seek_f()
                # Get name
                __name(inner_analyzer, 'declaration_list')
                # Find declaration list
                if not inner_analyzer.seek_f_type('declaration_list'):
                    return None
                # Continue analysis
                __analyze(_Analyzer(inner_analyzer.current))
            elif analyzer.current.type == 'file_scoped_namespace_declaration':
                # Get name
                __name(_Analyzer(analyzer.current), None)
                # Continue analysis
                analyzer.seek_f()
                __analyze(analyzer)
            else:
                return None
            return cls(f)
        return analyzer.parse_wrapper(_func)

    @classmethod
    def _cleanup(cls, input:_Iterable['CSCodeNamespace'], force_new:bool):
        output:dict[str, CSCodeNamespace] = {}
        for input_item in input:
            if input_item.name in output:
                output_item = output[input_item.name]._i_merge(input_item, force_new)
            elif force_new:
                output_item = input_item._i_copy()
            else:
                output_item = input_item
            output[output_item.name] = output_item
        return _CSCodeMembers(CSCodeNamespace, output.values())

    #endregion

    #region fields

    class __Fields:
        name:str
        types:_CSCodeMembers[_CSCodeType]

    #endregion

    #region properties

    @property
    def types(self):
        """ Type declarations """
        return self.__f.types

    #endregion
    
    #region CSCodeMember

    @property
    def _i_child_members(self):
        return self.__child_members

    #endregion

    #region CSCodeCopyable

    def _i_copy(self):
        f = self.__Fields()
        f.name = self.__f.name
        f.types = _CSCodeMembers(_CSCodeType, _CSCodeType._i_copy_multi(self.__f.types))
        return type(self)(f)

    #endregion

    #region CSCodeMergable

    def _i_merge(self, other: 'CSCodeNamespace', force_new: bool):
        f = self.__Fields()
        f.name = self.__f.name
        f.types = _CSCodeType._cleanup(_ColUtil.iter_multi(\
            self.__f.types, other.__f.types),\
            force_new)
        return type(self)(f)

    #endregion