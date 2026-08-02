__all__ = ['CSCodeType']

from collections.abc import\
    Iterable as _Iterable
from typing import\
    cast as _cast,\
    TYPE_CHECKING as _TYPE_CHECKING

from col import\
    ColUtil as _ColUtil,\
    ImmDict as _ImmDict,\
    ImmList as _ImmList,\
    ImmSet as _ImmSet

from .CSCodeAccess import\
    CSCodeAccess as _CSCodeAccess
from .CSCodeAccessible import\
    CSCodeAccessible as _CSCodeAccessible
from .CSCodeAccessInfo import\
    CSCodeAccessInfo as _CSCodeAccessInfo
from .CSCodeConstructor import\
    CSCodeConstructor as _CSCodeConstructor
from .CSCodeField import\
    CSCodeField as _CSCodeField
from .CSCodeMember import\
    CSCodeMember as _CSCodeMember
from .CSCodeMembers import\
    CSCodeMembers as _CSCodeMembers
from .CSCodeMethod import\
    CSCodeMethod as _CSCodeMethod
from .CSCodeParameters import\
    CSCodeParameters as _CSCodeParameters
from .CSCodeProperty import\
    CSCodeProperty as _CSCodeProperty
from .CSCodeTypeMember import\
    CSCodeTypeMember as _CSCodeTypeMember
from .CSRoughNode import\
    CSRoughNode as _CSRoughNode
from .CSCodeTypeKind import\
    CSCodeTypeKind as _CSCodeTypeKind

from ._Analyzer import _Analyzer
from ._AnalUtil import _AnalUtil
from ._CSCodeCopyable import _CSCodeCopyable
from ._CSCodeMergable import _CSCodeMergable

if _TYPE_CHECKING:
    from .CSCodeNamespace import\
        CSCodeNamespace as _CSCodeNamespace

class CSCodeType(_CSCodeMember, _CSCodeAccessible,\
        _CSCodeCopyable['CSCodeType'],\
        _CSCodeMergable['CSCodeType']):
    """ Represents a C# type declaration """

    #region init

    def __init__(self, f:'__Fields'):
        _CSCodeMember.__init__(self, f.name)
        _CSCodeAccessible.__init__(self, f.access_info)

        self.__f = f
        self.__child_members = _ImmList(_ColUtil.iter_multi(\
            _ColUtil.iter_cast(_CSCodeMember, self.__f.nested_types),\
            _ColUtil.iter_cast(_CSCodeMember, self.__f.members)))
        self.__namespace:'None|_CSCodeNamespace' = None
        self.__outer_type:None|CSCodeType = None
        # Fix nested types
        for nested_type in self.__f.nested_types:
            nested_type.__outer_type = self
        # Fix constructors
        for constructor in self.__f.constructors:
            constructor._i_type(self)
        # Fix members
        for member in self.__f.members:
            member._i_outer_type(self)

    #endregion

    #region _try_parse, _cleanup, _copy

    @classmethod
    def _try_parse(cls, analyzer:_Analyzer, default_access:_CSCodeAccess):
        def _func(analyzer:_Analyzer):
            nonlocal default_access
            f = cls.__Fields()
            f_nested_types:list[CSCodeType] = []
            f_members:list[_CSCodeTypeMember] = []
            f_constructors:list[_CSCodeConstructor] = []
            # Is this the declaration of a class, struct, or interface?
            VALID_DECLARATION_TYPES = [\
                'class_declaration',\
                'struct_declaration',\
                'interface_declaration']
            if not analyzer.valid():
                return None
            if analyzer.current.type not in VALID_DECLARATION_TYPES:
                return None
            inner_analyzer = _Analyzer(analyzer.current)
            analyzer.seek_f()
            # Extract attributes
            f.attributes = _AnalUtil.attributes_parse(inner_analyzer)
            # Extract modifiers
            f.access_info = _CSCodeAccessInfo._parse(inner_analyzer, default_access)
            # Extract kind
            f.is_ref = False
            while True:
                if not inner_analyzer.valid():
                    return None
                if inner_analyzer.current.type == 'class':
                    f.kind = _CSCodeTypeKind.CLASS
                    break
                if inner_analyzer.current.type == 'struct':
                    f.kind = _CSCodeTypeKind.STRUCT
                    break
                if inner_analyzer.current.type == 'interface':
                    f.kind = _CSCodeTypeKind.INTERFACE
                    break
                if inner_analyzer.current.type == 'ref':
                    f.is_ref = True
                inner_analyzer.seek_f()
            # Extract name
            if not inner_analyzer.seek_f_type('identifier'):
                return None
            result = _AnalUtil.name_try_parse(inner_analyzer)
            if result is None:
                return None
            f.name, f.typeparams = result
            # Extract primary constructor
            if inner_analyzer.valid():
                _srcs = _ImmList([inner_analyzer.current])
                result = _CSCodeParameters._try_parse(inner_analyzer)
                if result is not None:
                    f_constructors.append(_CSCodeConstructor._primary(_srcs, result))
            # Extract base
            f.base = _ImmSet([])
            if inner_analyzer.valid():
                if inner_analyzer.current.type == 'base_list':
                    base = set[str]()
                    base_analyzer = _Analyzer(inner_analyzer.current)
                    while base_analyzer.valid():
                        if base_analyzer.current.type not in ":,":
                            text = base_analyzer.current_text()
                            if text is not None: base.add(text)
                        base_analyzer.seek_f()
                    inner_analyzer.seek_f()
                    f.base = _ImmSet(base)
            # Extract type parameter constraints
            f.typeconstraints = _AnalUtil.typeconstraints_parse(inner_analyzer)
            # Extract body
            if inner_analyzer.seek_f_type('declaration_list'):
                body_analyzer = _Analyzer(inner_analyzer.current)
                # Get types
                while body_analyzer.valid():
                    # Type?
                    result = CSCodeType._try_parse(body_analyzer, _CSCodeAccess.PRIVATE)
                    if result is not None:
                        f_nested_types.append(result)
                        continue
                    # Method?
                    result = _CSCodeMethod._try_parse(body_analyzer)
                    if result is not None:
                        f_members.append(result)
                        continue
                    # Property?
                    result = _CSCodeProperty._try_parse(body_analyzer)
                    if result is not None:
                        f_members.append(result)
                        continue
                    # Fields?
                    result = _CSCodeField._try_parse(body_analyzer)
                    if result is not None:
                        for field in result:
                            f_members.append(field)
                        continue
                    # Constructor?
                    result = _CSCodeConstructor._try_parse(body_analyzer)
                    if result is not None:
                        f_constructors.append(result)
                        continue
                    # Anything else?
                    body_analyzer.seek_f()
            # Success!!!
            f.nested_types = CSCodeType._cleanup(f_nested_types, False)
            f.members = _CSCodeTypeMember._cleanup(f_members, False)
            f.constructors = _CSCodeConstructor._cleanup(f_constructors, False)
            return cls(f)
        return analyzer.parse_wrapper(_func)

    @classmethod
    def _cleanup(cls, input:_Iterable['CSCodeType'], force_new:bool):
        output:dict[str, CSCodeType] = {}
        for input_item in input:
            if input_item.name in output:
                output_item = output[input_item.name]._i_merge(input_item, force_new)
            elif force_new:
                output_item = input_item._i_copy()
            else:
                output_item = input_item
            output[output_item.name] = output_item
        return _CSCodeMembers(CSCodeType, output.values())

    #endregion

    #region fields

    class __Fields:
        name:str
        typeparams:_ImmSet[str]
        typeconstraints:_ImmDict[str, _ImmSet[str]]
        attributes:_ImmList[str]
        access_info:_CSCodeAccessInfo
        is_ref:bool
        kind:_CSCodeTypeKind
        base:_ImmSet[str]
        nested_types:_CSCodeMembers['CSCodeType']
        constructors:_ImmList[_CSCodeConstructor]
        members:_CSCodeMembers[_CSCodeTypeMember]

    #endregion

    #region properties

    @property
    def namespace(self):
        """ Namespace """
        return self.__namespace

    @property
    def outer_type(self):
        """ Outer type; if not None, this means the current type is nested within the outer type """
        return self.__outer_type

    @property
    def typeparams(self):
        """ Type parameters """
        return self.__f.typeparams

    @property
    def typeconstraints(self):
        """ Type parameter constraints """
        return self.__f.typeconstraints

    @property
    def attributes(self):
        """ Attributes """
        return self.__f.attributes

    @property
    def kind(self):
        """ What kind of type is this """
        return self.__f.kind

    @property
    def is_ref(self):
        """ Whether or not the ref keyword was used """
        return self.__f.is_ref

    @property
    def base(self):
        """ Base type information """
        return self.__f.base

    @property
    def nested_types(self):
        """ Nested types """
        return self.__f.nested_types

    @property
    def constructors(self):
        """ Constructors """
        return self.__f.constructors

    @property
    def members(self):
        """ Members """
        return self.__f.members

    #endregion

    #region internal methods

    def _i_namespace(self, value:'_CSCodeNamespace'):
        """ Also accessed by CSCodeNamespace """
        self.__namespace = value

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
        f.typeparams = self.__f.typeparams
        f.typeconstraints = self.__f.typeconstraints
        f.attributes = self.__f.attributes
        f.access_info = self.__f.access_info
        f.is_ref = self.__f.is_ref
        f.kind = self.__f.kind
        f.base = self.__f.base
        f.nested_types = _CSCodeMembers(CSCodeType, CSCodeType._i_copy_multi(self.__f.nested_types))
        f.constructors = _ImmList(_CSCodeConstructor._i_copy_multi(self.__f.constructors))
        f.members = _CSCodeMembers(_CSCodeTypeMember, _CSCodeTypeMember._i_copy_multi(self.__f.members))
        return type(self)(f)

    #endregion

    #region CSCodeMergable

    def _i_merge(self, other: 'CSCodeType', force_new: bool):
        f = self.__Fields()
        f = self.__Fields()
        # Name
        f.name = self.__f.name
        # Type parameters (the type parameters should be reflected in the name)
        f.typeparams = self.__f.typeparams
        # Type constraints
        f.typeconstraints = _AnalUtil.typeconstraints_cleanup(_ColUtil.iter_multi(\
            self.__f.typeconstraints.iter_items(),\
            other.__f.typeconstraints.iter_items()))
        # Attributes
        f.attributes = _ImmList(_ColUtil.iter_multi(\
            self.__f.attributes,\
            other.__f.attributes))
        # Access info
        f.access_info = _CSCodeAccessInfo._merge(\
            self.__f.access_info,\
            other.__f.access_info)
        # ref
        f.is_ref = self.__f.is_ref or other.__f.is_ref
        # Kind
        f.kind = _CSCodeTypeKind(min(self.__f.kind.value, other.__f.kind.value))
        # Base
        f.base = _ImmSet(_ColUtil.iter_multi(\
            self.__f.base,\
            other.__f.base))
        # Nested types
        f.nested_types = self._cleanup(_ColUtil.iter_multi(\
            self.__f.nested_types,\
            other.__f.nested_types),\
            force_new)
        # Constructors
        f.constructors = _CSCodeConstructor._cleanup(_ColUtil.iter_multi(\
            self.__f.constructors,\
            other.__f.constructors),\
            force_new)
        # Members
        f.members = _CSCodeTypeMember._cleanup(_ColUtil.iter_multi(\
            self.__f.members,\
            other.__f.members),\
            force_new)
        # Success!!!
        return type(self)(f)

    #endregion