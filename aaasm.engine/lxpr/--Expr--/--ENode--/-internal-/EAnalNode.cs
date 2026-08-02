using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>
    ///     This class only exists to allow instances of <see cref="LexToken"/> 
    ///     to be grouped with instances of <see cref="ENode"/>
    /// </summary>
    /// <param name="rules">Node rules</param>
    /// <param name="source">Unanalyzed token</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="rules"/> is null
    ///     <br/>or<br/>
    ///     <paramref name="source"/> is null
    /// </exception>
    internal class EAnalNode(ExprRules rules, LexToken source) : 
        ENode(ArgUtil.NotNull(rules), ArgUtil.NotNull(source), default!, ImmNullArray<ENode>.EMPTY)
    {
        #region ENode

        /// <summary>Throws a <see cref="NotImplementedException"/></summary>
        public override EValue Compute(ExprContext context) => throw new NotImplementedException();

        #endregion
    }
}
