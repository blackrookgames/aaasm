using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a label reference</summary>
    public class ELabelNode : ENode
    {
        #region init

        internal ELabelNode(ExprRules rules, LexToken source, string name, EType @return) : 
            base(rules, source, new(@return), ImmNullArray<ENode>.EMPTY)
        {
            f_Name = name;
        }

        #endregion

        #region fields

        private readonly string f_Name;

        #endregion

        #region properties

        /// <summary>Label name</summary>
        public string Name => f_Name;

        #endregion

        #region IExpr

        /// <inheritdoc/>
        public override EValue Compute(ExprContext context)
        {
            try
            {
                if (context.Preprocess)
                    throw new BadSrcException("Cannot reference labels during preprocessing.", Source.RefPnt);
                // TODO: Implement
                throw new NotImplementedException();
            }
            catch when (context is null)
            { throw new ArgumentNullException(nameof(context)); }
        }

        #endregion
    }
}
