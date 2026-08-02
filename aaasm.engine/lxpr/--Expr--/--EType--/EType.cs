using System;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression value type</summary>
    public abstract partial class EType : IEquatable<EType>
    {
        #region init

        private protected EType(
            ETypeNameId nameId, 
            ETypeFlags flags,
            int roughSize, 
            int length, 
            EType? elementType, 
            ImmNullArray<EType> elementTypes)
        {
            f_NameId = nameId;
            f_Flags = flags;
            f_RoughSize = roughSize;
            f_Length = length;
            f_ElementType = elementType;
            f_ElementTypes = elementTypes;
        }
       
        /// <summary>Creates an array type</summary>
        /// <param name="elementType">Contained element type</param>
        /// <param name="length">Number of elements in array</param>
        /// <return>Created type</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elementType"/> is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length"/> is negative
        /// </exception>
        public static ETypeArray Array(EType elementType, int length) =>
            new(elementType, length);
        
        /// <summary>Creates a tuple type</summary>
        /// <param name="elementTypes">Contained element types</param>
        /// <return>Created type</return>
        public static ETypeTuple Tuple(ImmNullArray<EType> elementTypes) =>
            new(elementTypes);
            
        /// <summary>Creates an immediate type</summary>
        /// <param name="elementType">Contained element type</param>
        /// <return>Created type</return>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elementType"/> is null
        /// </exception>
        public static ETypeImmediate Immediate(EType elementType) =>
            new(elementType);

        #endregion

        #region const

        /// <summary>8-bit unsigned integer</summary>
        public static ETypeU8 U8 => ETypeU8.TYPE;

        /// <summary>8-bit signed integer</summary>
        public static ETypeI8 I8 => ETypeI8.TYPE;

        /// <summary>16-bit unsigned integer</summary>
        public static ETypeU16 U16 => ETypeU16.TYPE;

        /// <summary>16-bit signed integer</summary>
        public static ETypeI16 I16 => ETypeI16.TYPE;

        /// <summary>32-bit unsigned integer</summary>
        public static ETypeU32 U32 => ETypeU32.TYPE;

        /// <summary>32-bit signed integer</summary>
        public static ETypeI32 I32 => ETypeI32.TYPE;

        /// <summary>64-bit unsigned integer</summary>
        public static ETypeU64 U64 => ETypeU64.TYPE;

        /// <summary>64-bit signed integer</summary>
        public static ETypeI64 I64 => ETypeI64.TYPE;

        /// <summary>32-bit floating-point decimal</summary>
        public static ETypeF32 F32 => ETypeF32.TYPE;

        /// <summary>64-bit floating-point decimal</summary>
        public static ETypeF64 F64 => ETypeF64.TYPE;

        #endregion
        
        #region fields

        private readonly ETypeNameId f_NameId;
        private readonly ETypeFlags f_Flags;
        private readonly int f_RoughSize;

        private readonly int f_Length;
        private readonly EType? f_ElementType;
        private readonly ImmNullArray<EType> f_ElementTypes;

        #endregion
        
        #region properties

        /// <summary>Name ID</summary>
        public ETypeNameId NameId => f_NameId;

        /// <summary>Flags</summary>
        public ETypeFlags Flags => f_Flags;

        /// <summary>
        ///     Type of elements contained<br/>
        ///     Meaningless if <see cref="NameId"/> does not equal 
        ///     <see cref="ETypeNameId.ARRAY"/> or 
        ///     <see cref="ETypeNameId.IMMEDIATE"/>
        /// </summary>
        public EType? ElementType => f_ElementType;

        /// <summary>
        ///     Types for each element contained<br/>
        ///     Meaningless if <see cref="NameId"/> does not equal 
        ///     <see cref="ETypeNameId.TUPLE"/>
        /// </summary>
        public ImmNullArray<EType> ElementTypes => f_ElementTypes;

        /// <summary>
        ///     Number of elements contained<br/>
        ///     Meaningless if <see cref="NameId"/> does not equal 
        ///     <see cref="ETypeNameId.ARRAY"/> or 
        ///     <see cref="ETypeNameId.TUPLE"/> or 
        ///     <see cref="ETypeNameId.IMMEDIATE"/>
        /// </summary>
        /// <remarks>
        ///     If <see cref="NameId"/> equals <see cref="ETypeNameId.IMMEDIATE"/>, 
        ///     this will always return 1.
        /// </remarks>
        public int Length => f_Length;

        #endregion
        
        #region helper methods

        private bool MM_Equals(EType? other)
        {
            if (other is null)
                return false;
            if (f_NameId != other.f_NameId)
                return false;
            if (f_RoughSize != other.f_RoughSize)
                return false;
            if (f_Length != other.f_Length)
                return false;
            if (!MM_Equals(f_ElementType, other.f_ElementType))
                return false;
            if (f_ElementTypes.Length != other.f_ElementTypes.Length)
                return false;
            for (int i = 0; i < f_ElementTypes.Length; ++i)
            {
                if (!f_ElementTypes[i].MM_Equals(other.f_ElementTypes[i]))
                    return false;
            }
            return true;
        }

        private static bool MM_Equals(EType? a, EType? b)
        {
            if (a is null) return b is null;
            return a.MM_Equals(b);
        }

        #endregion
        
        #region methods

        /// <summary>Computes the size of the type</summary>
        /// <returns>Size in bytes</returns>
        public int GetSize()
        {
            var size = f_RoughSize;
            if (f_ElementType is not null)
                size += f_ElementType.GetSize() * f_Length;
            foreach (var type in f_ElementTypes)
                size += type.GetSize();
            return size;
        }

        /// <summary>Checks whether or not this is a collection type</summary>
        /// <returns>Whether or not this is a collection type</returns>
        public bool IsCollection() => (f_Flags & ETypeFlags.COLLECTION) != ETypeFlags.NONE;

        /// <summary>Checks whether or not this is a numeric type</summary>
        /// <returns>Whether or not this is a numeric type</returns>
        public bool IsNumber() => (f_Flags & ETypeFlags.NUMBER) != ETypeFlags.NONE;

        /// <summary>Checks whether or not this is a integer type</summary>
        /// <returns>Whether or not this is a integer type</returns>
        public bool IsInteger() => IsNumber() && (f_Flags & ETypeFlags.INTEGER) != ETypeFlags.NONE;

        /// <summary>Checks whether or not this is a floating-point type</summary>
        /// <returns>Whether or not this is a floating-point type</returns>
        public bool IsFloat() => IsNumber() && (f_Flags & ETypeFlags.INTEGER) == ETypeFlags.NONE;

        #endregion

        #region operators

        public static bool operator ==(EType? a, EType? b) => MM_Equals(a, b);
        public static bool operator !=(EType? a, EType? b) => !MM_Equals(a, b);

        #endregion

        #region object

        /// <summary>Generates a string representation of the expression value type</summary>
        /// <returns>Generated string</returns>
        public sealed override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="EType"/> 
        ///     and is equal to the current <see cref="EType"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="EType"/> 
        ///     and is equal to the current <see cref="EType"/>; 
        ///     false otherwise
        /// </returns>
        public sealed override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not EType other) return false;
            return MM_Equals(other);
        }

        /// <summary>Computes a hash code for the current <see cref="EType"/></summary>
        /// <returns>Hash code for the current <see cref="EType"/></returns>
        public sealed override int GetHashCode()
        {
            int hash = (int)f_NameId & 0xFF;
            if (f_ElementType is not null)
            {
                hash |= ((int)f_ElementType.f_NameId & 0xFF) << 8;
            }
            else if (f_ElementTypes.Length > 0)
            {
                hash |= ((int)f_ElementTypes[0].f_NameId & 0xFF) << 8;
                switch (f_ElementTypes.Length)
                {
                    case 1:
                        break;
                    case 2:
                        hash |= ((int)f_ElementTypes[1].f_NameId & 0xFF) << 16;
                        break;
                    default:
                        var inc = f_ElementTypes.Length / 3;
                        hash |= 
                            (((int)f_ElementTypes[inc].f_NameId & 0xFF) << 16) |
                            (((int)f_ElementTypes[inc * 2].f_NameId & 0xFF) << 24);
                        break;
                }
            }
            return hash;
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks whether or not the current <see cref="EType"/> is equal to another <see cref="EType"/>
        /// </summary>
        /// <param name="other">Other <see cref="EType"/></param>
        /// <returns>
        ///     Whether or not the current <see cref="EType"/> is equal to <paramref name="other"/>
        /// </returns>
        public bool Equals(EType? other) => MM_Equals(other);

        #endregion
    }
}
