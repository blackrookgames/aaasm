from dataclasses import\
    dataclass as _dataclass

from col import\
    ROList as _ROList

@_dataclass(frozen = True)
class PreCmd:
    """ Represents information about of preprocessor command """
    name:str
    """ Command name """
    desc:str
    """ Command description """

PRECMDS:_ROList[PreCmd] = _ROList([\
    PreCmd('ECHO', "Prints information to the console"),\
    PreCmd('INCLUDE', "Include code from another file"),\
    PreCmd('DEFINE', "Define a macro"),\
    PreCmd('UNDEF', "Undefines a macro"),\
    PreCmd('IF', "Start of an if..else block"),\
    PreCmd('ELSE', "Start of an else block"),\
    PreCmd('ELIF', "Start of an else-if block"),\
    PreCmd('ENDIF', "End of an if..else block"),\
    PreCmd('IFDEF', "Checks if a macro is defined"),\
    PreCmd('IFNDEF', "Checks if a macro is not defined"),\
    PreCmd('ELIFDEF', "Checks if a macro is defined, if previous conditions were false"),\
    PreCmd('ELIFNDEF', "Checks if a macro is not defined, if previous conditions were false")])