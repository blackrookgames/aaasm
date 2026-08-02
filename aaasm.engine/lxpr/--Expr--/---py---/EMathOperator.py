from collections.abc import\
    Iterable as _Iterable

class MathOp:
    """ Represents a mathematical operator """

    #region init

    def __init__(self, name:str, human:str, symbol:str, unary:bool):
        self.__name = name
        self.__human = human
        self.__symbol = symbol
        self.__unary = unary

    #endregion

    #region properties

    @property
    def name(self):
        """ Name """
        return self.__name
    
    @property
    def human(self):
        """ Human-readable name """
        return self.__human

    @property
    def symbol(self):
        """ Common symbol """
        return self.__symbol
    
    @property
    def unary(self):
        """ Whether or not this is a unary operator as opposed to a binary operator """
        return self.__unary

    #endregion

class MathOps:
    """ Represents a collection of mathematical operators """

    #region init

    def __init__(self, src:_Iterable):
        self.__items:dict[str, MathOp] = {}
        for item in src:
            if item.name in self.__items: continue
            self.__items[item.name] = item

    #endregion

    #region operators

    def __len__(self):
        return len(self.__items)
    
    def __iter__(self):
        for item in self.__items.values():
            yield item
    
    def __contains__(self, name:str):
        return name in self.__items
    
    def __getitem__(self, name:str):
        try:
            return self.__items[name]
        except:
            if name in self.__items: raise
        raise KeyError("Could not find an item of the specified name.")

    #endregion

MATHOPS = MathOps([\
    MathOp("Imm", "Immediate", '#', True),\
    MathOp("Add", "Addition", '+', False),\
    MathOp("Sub", "Subtraction", '-', False),\
    MathOp("Mul", "Multiplication", '*', False),\
    MathOp("Div", "Division", '/', False),\
    MathOp("Mod", "Modulus", '%', False),\
    MathOp("Neg", "Negation", '-', True),\
    MathOp("BitAnd", "Bitwise-AND", '&', False),\
    MathOp("BitOr", "Bitwise-OR", '|', False),\
    MathOp("BitXor", "Bitwise-XOR", '^', False),\
    MathOp("BitNot", "Bitwise-NOT", '~', True),\
    MathOp("ShiftL", "Left-shift", '<<', False),\
    MathOp("ShiftR", "Signed right-shift", '>>', False),\
    MathOp("ShiftRU", "Unsigned right-shift", '>>>', False),\
    MathOp("ByteLo", "Lo-byte", '<', True),\
    MathOp("ByteHi", "Hi-byte", '>', True),\
    MathOp("Equ", "Equality", '==', False),\
    MathOp("Neq", "Inequality", '!=', False),\
    MathOp("Lss", "Less-than", '<', False),\
    MathOp("Leq", "Less-than-or-equal-to", '<=', False),\
    MathOp("Gtr", "Greater-than", '>', False),\
    MathOp("Geq", "Greater-than-or-equal-to", '>=', False),\
    MathOp("BoolAnd", "Boolean-AND", '&&', False),\
    MathOp("BoolOr", "Boolean-OR", '||', False),\
    MathOp("BoolNot", "Boolean-NOT", '!', True)])
""" Mathematical operators """