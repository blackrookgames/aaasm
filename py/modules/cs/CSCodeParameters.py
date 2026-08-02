__all__ = ['CSCodeParameters']

from col import\
    ImmList as _ImmList

from .CSCodeParameter import\
    CSCodeParameter as _CSCodeParameter

from ._Analyzer import _Analyzer

class CSCodeParameters:
    """ Represents C# parameters """

    #region init

    def __init__(self, f:'__Fields'):
        self.__f = f

    #endregion

    #region _try_parse, _equals

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer):
        def _func(analyzer:_Analyzer):
            f = cls.__Fields()
            # Is this a parameter list?
            if not analyzer.valid():
                return None
            if analyzer.current.type != 'parameter_list':
                return None
            # Parse parameters
            f_parameters:list[_CSCodeParameter] = []
            par_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            while par_analyzer.valid():
                result = _CSCodeParameter._try_parse(par_analyzer)
                if result is not None:
                    f_parameters.append(result)
                par_analyzer.seek_f()
            f.parameters = _ImmList(f_parameters)
            # Success!!!
            return cls(f)
        return analyzer.parse_wrapper(_func)

    def _equals(self, other:'CSCodeParameters'):
        """ See CSCodeParameter._equals to see how the parameters are checked """
        if len(self.__f.parameters) != len(other.__f.parameters):
            return False
        for i in range(len(other.__f.parameters)):
            if self.__f.parameters[i]._equals(other.__f.parameters[i]):
                continue
            return False
        return True

    #endregion

    #region operators

    def __len__(self):
        return len(self.__f.parameters)

    def __iter__(self):
        for parameter in self.__f.parameters:
            yield parameter
    
    def __getitem__(self, index:int):
        try:
            return self.__f.parameters[index]
        except:
            if index >= 0 and index < len(self.__f.parameters): raise
        raise IndexError("Index is out of range.")
    
    def __contains__(self, item:object):
        return item in self.__f.parameters

    #endregion

    #region fields

    class __Fields:
        parameters:_ImmList[_CSCodeParameter]

    #endregion