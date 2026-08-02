using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a tuple</summary>
    public class ETuple : EValue, IECollection
    {
        #region init

        /// <summary>Initializer for <see cref="ETuple"/></summary>
        /// <param name="elements">Elements in tuple</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="elements"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="elements"/> contains one or more null elements
        /// </exception>
        public ETuple(IEnumerable<EValue> elements)
        {
            f_Items = [..MM_Validate(elements)];
            f_Type = new ETypeTuple(new(from item in f_Items select item.Type));
        }
        
        #endregion

        #region fields

        private readonly EType f_Type;
        private readonly EValue[] f_Items;

        #endregion

        #region helper methods

        private static IEnumerable<EValue> MM_Validate(
            IEnumerable<EValue> elements,
            [CallerArgumentExpression(nameof(elements))] string? elementsParam = null)
        {
            ArgumentNullException.ThrowIfNull(elements, elementsParam);
            foreach (var element in elements)
            {
                if (element is null)
                {
                    throw new ArgumentException(
                        "Collection contains one or more null elements.", 
                        elementsParam);
                }
                yield return element;
            }
        }

        #endregion

        #region EValue

        /// <inheritdoc/>
        public override EType Type => f_Type;

        /// <inheritdoc/>
        private protected override string MM_ToString(ExprRules? exprRules)
        {
            string oBkt, cBkt;
            if (exprRules is not null && exprRules.Literals.ArrayBrackets is not null)
            {
                oBkt = (string)exprRules.Literals.ArrayBrackets.Open;
                cBkt = (string)exprRules.Literals.ArrayBrackets.Close;
            }
            else
            {
                oBkt = "[";
                cBkt = "]";
            }
            using StringWriter w = new();
            w.Write(oBkt);
            for (int i = 0; i < f_Items.Length; ++i)
            {
                if (i > 0) w.Write(", ");
                w.Write(f_Items[i]);
            }
            w.Write(cBkt);
            return w.ToString();
        }

        /// <inheritdoc/>
        private protected override bool MM_Equals(EValue other)
        {
            if (f_Type != other.Type)
                return false;
            var _other = (ETuple)other;
            if (f_Items.Length != _other.f_Items.Length)
                return false;
            for (int i = 0; i < f_Items.Length; ++i)
            {
                if (f_Items[i] != _other.f_Items[i])
                    return false;
            }
            return true;
        }

        /// <inheritdoc/>
        private protected override int MM_GetHashCode()
        {
            switch (f_Items.Length)
            {
                case 0: return 0;
                case 1: return 0xFF & f_Items[0].GetHashCode();
                case 2: return (0xFF & f_Items[0].GetHashCode()) |
                    ((0xFF & f_Items[1].GetHashCode()) << 8);
                case 3: return (0xFF & f_Items[0].GetHashCode()) |
                    ((0xFF & f_Items[1].GetHashCode()) << 8) |
                    ((0xFF & f_Items[2].GetHashCode()) << 16);
            }
            int inc = f_Items.Length / 4;
            return (0xFF & f_Items[0].GetHashCode()) |
                ((0xFF & f_Items[inc].GetHashCode()) << 8) |
                ((0xFF & f_Items[inc * 2].GetHashCode()) << 16) |
                ((0xFF & f_Items[inc * 3].GetHashCode()) << 24);
        }

        #endregion

        #region IECollection

        /// <summary>Number of elements in tuple</summary>
        public int Length => f_Items.Length;

        /// <summary>Gets the element at the specified index</summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element at the specified index</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public EValue this[int index]
        {
            get
            {
                try
                { return f_Items[index]; }
                catch when (index < 0 || index >= f_Items.Length)
                { throw new IndexOutOfRangeException(nameof(index)); }
            }
        }

        /// <summary>Gets an enumerator thru the tuple</summary>
        /// <returns>Enumerator thru the tuple</returns>
        public IEnumerator<EValue> GetEnumerator() => ColUtil.ArrayEnumerator(f_Items);

        int IReadOnlyCollection<EValue>.Count => f_Items.Length;

        IEnumerator IEnumerable.GetEnumerator() => ColUtil.ArrayEnumerator(f_Items);

        #endregion
    }
}
