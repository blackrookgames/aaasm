from collections.abc import\
    Iterable as _Iterable,\
    Set as _Set
from io import\
    StringIO as _StringIO

from col import\
    ColUtil as _ColUtil,\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet
from help import\
    StrUtil as _StrUtil

from .CSRoughNode import\
    CSRoughNode as _CSRoughNode

from ._Analyzer import _Analyzer

class _AnalUtil:
    """ Analysis utility """

    #region attributes

    @staticmethod
    def attributes_parse(analyzer:_Analyzer):
        """
        Parses the next nodes as attributes\n
        Parsing continues until a non-attribute node is found.

        :param analyzer: Analyzer
        :return: List of parsed attributes
        """
        attributes:list[str] = []
        while analyzer.valid() and analyzer.current.type == 'attribute_list':
            attr_analyzer = _Analyzer(analyzer.current)
            while attr_analyzer.valid():
                if attr_analyzer.current.type == 'attribute':
                    text = attr_analyzer.current_text(keep_ws = True)
                    if text is not None:
                        attributes.append(text)
                attr_analyzer.seek_f()
            analyzer.seek_f()
        return _ImmList(attributes)

    #endregion

    #region name

    @staticmethod
    def name_try_parse(analyzer:_Analyzer) -> None | tuple[str, _ImmSet[str]]:
        """
        Attempts to parse as a name, including any type parameters.\n
        If parsing succeeds, the analyzer is incremented accordingly.

        :param analyzer: Analyzer
        :rtype: None | tuple[str, ImmSet[str]]
        :return: If successful, the name (including the type parameters) and a collection of type parameters
        """
        def func(analyzer:_Analyzer):
            with _StringIO() as w:
                # Is this an explicit interface specifier?
                if not analyzer.valid():
                    return None
                if analyzer.current.type == 'explicit_interface_specifier':
                    text = analyzer.current_text()
                    if text is not None:
                        w.write(text)
                    analyzer.seek_f()
                # Is this an identifier?
                if not analyzer.valid():
                    return None
                if analyzer.current.type != 'identifier':
                    return None
                text = analyzer.current_text()
                if text is None:
                    return None
                w.write(text)
                analyzer.seek_f()
                # Are there type parameters?
                typeparams = _ImmSet[str]([])
                if analyzer.valid():
                    if analyzer.current.type == 'type_parameter_list':
                        _typeparams = set[str]()
                        tp_analyzer = _Analyzer(analyzer.current)
                        while tp_analyzer.valid():
                            if tp_analyzer.current.type == 'type_parameter':
                                text = tp_analyzer.current_text()
                                if text is not None: _typeparams.add(text)
                            tp_analyzer.seek_f()
                        typeparams = _ImmSet(_typeparams)
                        analyzer.seek_f()
                if len(typeparams) > 0:
                    w.write('<')
                    i = 0
                    for typeparam in typeparams:
                        if i > 0: w.write(',')
                        w.write(typeparam)
                        i += 1
                    w.write('>')
                # Success!!!
                return w.getvalue(), typeparams
        return analyzer.parse_wrapper(func)

    #endregion

    #region typeconstraints

    @staticmethod
    def typeconstraints_parse(analyzer:_Analyzer):
        """
        Parses the next nodes as type constraints\n
        Parsing continues until a non-attribute node is found.

        :param analyzer: Analyzer
        :return: Dictionary of parsed type constraints, 
        """
        constraints:dict[str, _ImmSet[str]] = {}
        while analyzer.valid() and analyzer.current.type == 'type_parameter_constraints_clause':
            tp_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            # Where
            if not tp_analyzer.valid(): continue
            if tp_analyzer.current.type != 'where': continue
            # Identifier
            if not tp_analyzer.seek_f(): continue
            if tp_analyzer.current.type != 'identifier': continue
            text = tp_analyzer.current_text()
            if text is None: continue
            type_name = text
            # Constraints
            type_constraints = set[str]()
            while tp_analyzer.seek_f():
                if tp_analyzer.current.type != 'type_parameter_constraint': continue
                text = tp_analyzer.current_text()
                if text is None: continue
                type_constraints.add(text)
            # Add to dictionary
            constraints[type_name] = _ImmSet(type_constraints)
        return _ImmDict(constraints.items())

    @staticmethod
    def typeconstraints_cleanup(input:_Iterable[tuple[str, _ImmSet[str]]]):
        output:dict[str, _ImmSet[str]] = {}
        for type, input_constraints in input:
            if type in output:
                output_constraints = _ImmSet(_ColUtil.iter_multi(output[type], input_constraints))
            else:
                output_constraints = input_constraints
            output[type] = output_constraints
        return _ImmDict(output.items())

    #endregion

    #region rettype

    @staticmethod
    def rettype_try_parse(analyzer:_Analyzer) -> None | tuple[str, bool]:
        """
        Attempts to parse as a return type.\n
        If parsing succeeds, the analyzer is incremented accordingly.

        :param analyzer: Analyzer
        :rtype: None | tuple[str, bool]
        :return: If successful, the type name and whether or not the ref keyword was used
        """
        def func(analyzer:_Analyzer):
            def _try_parse(node:_CSRoughNode):
                VALID = [\
                    'identifier',\
                    'predefined_type',\
                    'generic_name',\
                    'tuple_type',\
                    'array_type',\
                    'nullable_type']
                if node.type not in VALID: return None
                if node.text is None: return None
                return _StrUtil.remove_ws(node.text.decode())
            if not analyzer.valid():
                return None
            current = analyzer.current
            analyzer.seek_f()
            if current.type == 'ref_type':
                ref_analyzer = _Analyzer(current)
                # Extract ref
                if not ref_analyzer.valid():
                    return None
                if ref_analyzer.current.type != 'ref':
                    return None
                if not ref_analyzer.seek_f():
                    return None
                # Extract name
                name = _try_parse(ref_analyzer.current)
                return None if (name is None) else (name, True)
            else:
                # Extract name
                name = _try_parse(current)
                return None if (name is None) else (name, False)
        return analyzer.parse_wrapper(func)

    #endregion