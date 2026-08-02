from .CSCode import *
from .CSCodeAccess import *
from .CSCodeAccessible import *
from .CSCodeAccessInfo import *
from .CSCodeConstructor import *
from .CSCodeField import *
from .CSCodeMember import *
from .CSCodeMembers import *
from .CSCodeMethod import *
from .CSCodeMethodOverload import *
from .CSCodeNamespace import *
from .CSCodeParameter import *
from .CSCodeParameters import *
from .CSCodeProperty import *
from .CSCodeType import *
from .CSCodeTypeKind import *
from .CSCodeTypeMember import *
from .CSRoughNode import *
from .CSRoughNodeTree import *

# The C# can only parse a few things:
# - Namespaces
# - Classes
# - Structs
# - Interfaces
# - Constructors
# - Fields
# - Properties (doesn't parse accessor info)
# - Methods
# 
# How to parse a source:
# tree = cs.CSRoughNodeTree(bytes(source_content))
# code = cs.CSCode.parse(tree)