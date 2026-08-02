__all__ = ['CSCodeField']

from collections.abc import\
    Iterable as _Iterable
from io import\
    StringIO as _StringIO
from typing import\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSCodeAccess import\
    CSCodeAccess as _CSCodeAccess
from .CSCodeAccessible import\
    CSCodeAccessible as _CSCodeAccessible
from .CSCodeAccessInfo import\
    CSCodeAccessInfo as _CSCodeAccessInfo
from .CSCodeTypeMember import\
    CSCodeTypeMember as _CSCodeTypeMember
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._AnalUtil import _AnalUtil
from ._Analyzer import _Analyzer

if _TYPE_CHECKING:
    from .CSCodeType import\
        CSCodeType as _CSCodeType

class CSCodeField(_CSCodeTypeMember, _CSCodeAccessible):
    """ Represents a C# field """

    #region init

    def __init__(self, f:'__Fields'):
        _CSCodeTypeMember.__init__(self, f.name)
        _CSCodeAccessible.__init__(self, f.access_info)
        self.__f = f

    #endregion

    #region _try_parse

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            # Is this a field declaration?
            if not analyzer.valid():
                return None
            if analyzer.current.type != 'field_declaration':
                return None
            inner_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            # Extract attributes
            f_attributes = _AnalUtil.attributes_parse(inner_analyzer)
            # Extract modifiers
            f_access_info = _CSCodeAccessInfo._parse(inner_analyzer, _CSCodeAccess.PRIVATE)
            # Extract variables
            fields:list[CSCodeField] = []
            if inner_analyzer.valid() and inner_analyzer.current.type == 'variable_declaration':
                var_analyzer = _Analyzer(inner_analyzer.current)
                # Extract return type
                rettype = _AnalUtil.rettype_try_parse(var_analyzer)
                if rettype is None:
                    return None
                f_return_type, f_is_ref = rettype
                # Extract variables
                while var_analyzer.valid():
                    if var_analyzer.current.type == 'variable_declarator':
                        varid_analyzer = _Analyzer(var_analyzer.current)
                        with _StringIO() as w:
                            while varid_analyzer.valid():
                                if varid_analyzer.current.type == "=":
                                    break
                                text = varid_analyzer.current_text()
                                if text is not None:
                                    w.write(text)
                                varid_analyzer.seek_f()
                            f_name = w.getvalue()
                        if len(f_name) > 0:
                            f = cls.__Fields()
                            f.name = f_name
                            f.access_info = f_access_info
                            f.attributes = f_attributes
                            f.return_type = f_return_type
                            f.is_ref = f_is_ref
                            fields.append(cls(f))
                    var_analyzer.seek_f()
            # Success!!!
            return _ImmList(fields)
        return analyzer.parse_wrapper(_func)

    #endregion

    #region fields

    class __Fields:
        name:str
        access_info:_CSCodeAccessInfo
        attributes:_ImmList[str]
        return_type:str
        is_ref:bool

    #endregion

    #region properties

    @property
    def attributes(self):
        """ Attributes """
        return self.__f.attributes

    @property
    def return_type(self):
        """ Return type """
        return self.__f.return_type

    @property
    def is_ref(self):
        """ Whether or not the ref keyword is used """
        return self.__f.is_ref

    #endregion

    #region CSCodeTypeMember

    def _p_merge(self, other:_CSCodeTypeMember, force_new:bool):
        return self._p_copy() if force_new else self

    def _p_copy(self):
        f = self.__Fields()
        f.name = self.__f.name
        f.access_info = self.__f.access_info
        f.attributes = self.__f.attributes
        f.return_type = self.__f.return_type
        f.is_ref = self.__f.is_ref
        return type(self)(f)

    #endregion