__all__ = ['CSCodeParameter']

from col import\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._AnalUtil import _AnalUtil
from ._Analyzer import _Analyzer

class CSCodeParameter:
    """ Represents a C# parameter """

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f

    #endregion

    #region _try_parse, _equals

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            f = cls.__Fields()
            # Is this a parameter?
            if not analyzer.valid():
                return None
            if analyzer.current.type != 'parameter':
                return None
            inner_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            # Extract attributes
            f.attributes = _AnalUtil.attributes_parse(inner_analyzer)
            # Extract modifiers
            f.is_out = False
            f.is_ref = False
            while True:
                if not inner_analyzer.valid():
                    return None
                if inner_analyzer.current.type != 'modifier':
                    break
                match inner_analyzer.current_text():
                    case 'out': f.is_out = True
                    case 'ref': f.is_ref = True
                inner_analyzer.seek_f()
            # Extract type
            f_type = _AnalUtil.rettype_try_parse(inner_analyzer)
            if f_type is None:
                return None
            f.type = f_type[0]
            # Extract name
            if not inner_analyzer.seek_f_type('identifier'):
                return None
            text = inner_analyzer.current_text()
            if text is None:
                return None
            f.name = text
            # Success!!!
            return cls(f)
        return analyzer.parse_wrapper(_func)

    def _equals(self, other:'CSCodeParameter'):
        """
        This method considers the following:
        - type
        - is_out
        - is_ref
        """
        if self.__f.type != other.__f.type: return False
        if self.__f.is_out != other.__f.is_out: return False
        if self.__f.is_ref != other.__f.is_ref: return False
        return True

    #endregion

    #region fields

    class __Fields:
        name:str
        type:str
        attributes:_ImmList[str]
        is_out:bool
        is_ref:bool

    #endregion

    #region properties

    @property
    def name(self):
        """ Name """
        return self.__f.name

    @property
    def type(self):
        """ Type """
        return self.__f.type

    @property
    def attributes(self):
        """ Attributes """
        return self.__f.attributes

    @property
    def is_out(self):
        """ Whether or not the 'out' modifier is specified """
        return self.__f.is_out

    @property
    def is_ref(self):
        """ Whether or not the refmodifier is specified """
        return self.__f.is_ref

    #endregion