
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a collection of mathematical operator information</summary>
    public class EMathOperatorInfos : IKeyedCollection<EMathOperator, EMathOperatorInfo>
    {
        #region init

        internal EMathOperatorInfos(IEnumerable<EMathOperatorInfo> src)
        {
            f_Operators = [];
            foreach (var item in src) f_Operators.Add(item.Operator, item);
        }

        #endregion

        #region fields

        private readonly Dictionary<EMathOperator, EMathOperatorInfo> f_Operators;

        #endregion

        #region IKeyedCollection
        
        /// <summary>Number of operators in collection</summary>
        public int Count => f_Operators.Count;

        /// <summary>Attempts to retrieve information about the specified operator</summary>
        /// <param name="op">Operator</param>
        /// <param name="info">Information about the operator</param>
        /// <returns>Whether or not successful</returns>
        public bool TryGet(EMathOperator op, [MaybeNullWhen(false)] out EMathOperatorInfo info)
        {
            return f_Operators.TryGetValue(op, out info);
        }

        /// <summary>Gets an enumerator thru the operators</summary>
        /// <returns>Enumerator thru the operators</returns>
        public IEnumerator<EMathOperatorInfo> GetEnumerator()
        {
            return f_Operators.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return f_Operators.Values.GetEnumerator();
        }

        #endregion
    }
}
