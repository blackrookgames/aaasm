using System;
using System.Collections.Generic;
using aaasm.engine.col;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression</summary>
    public partial class Expr
    {
        #region init

        private Expr(ENode root)
        {
            f_Root = root;
        }

        /// <summary>Analyzes the source tokens</summary>
        /// <param name="tokens">Source tokens</param>
        /// <param name="rules">Expression rules</param>
        /// <param name="failRefPnt">Reference point to use for throwing certain exceptions</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="tokens"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="rules"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     One or more elements in <paramref name="tokens"/> are null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     Invalid data was found
        /// </exception>
        public static Expr Analyze(IEnumerable<LexToken> tokens, ExprRules rules,
            RefPnt? failRefPnt = null)
        {
            try
            {
                return new(ENode.Analyze(tokens, new(rules), 
                    failRefPnt: failRefPnt));
            }
            catch
            {
                ArgUtil.ThrowIfNullItems(tokens);
                ArgumentNullException.ThrowIfNull(rules);
                throw;
            }
        }

        #endregion

        #region fields

        private readonly ENode f_Root;

        #endregion

        #region properties

        /// <summary>Root node</summary>
        public ENode Root => f_Root;

        /// <summary>Return type</summary>
        public EType Return => f_Root.Return.Type;

        #endregion

        #region private methods



        #endregion

        #region methods

        /// <summary>Computes a value</summary>
        /// <returns>Computation result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     An error occurred.
        /// </exception>
        public EValue Compute(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            return f_Root.Compute(context);
        }

        /// <summary>Performs a debug computation</summary>
        /// <returns>Computation result</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     An error occurred.
        /// </exception>
        public string Debug(ExprContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            return f_Root.Debug(context);
        }

        #endregion
    }
}
