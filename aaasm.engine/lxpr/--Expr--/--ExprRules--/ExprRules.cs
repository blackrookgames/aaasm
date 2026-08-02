using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.data;
using aaasm.engine.help;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents rules for expressions</summary>
    public class ExprRules
    {
        #region init

        /// <summary>Initializer for <see cref="ExprRules"/></summary>
        /// <param name="init">Initialization arguments</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="init"/> is null
        /// </exception>
        public ExprRules(ExprRulesInit init)
        {
            try
            {
                Literals = new(init.Literals);
                Math = new(init.Math);
                FuncBrackets = init.FuncBrackets;
                FuncArgSep = init.FuncArgSep;
                FuncIds = init.FuncIds;
                Boolean = init.Boolean;
                Label = init.Label;
                LabelBranchSymbol = init.LabelBranchSymbol;
            }
            catch when (init is null)
            {
                throw new ArgumentNullException(nameof(init));
            }
        }

        #endregion

        #region const

        /// <summary>Commonly used function IDs</summary>
        public static ImmNullDict<Str, EFunFunctionId> COMMON_FUNCIDS { get; }= new([
            .. from id in Enum.GetValues<EFunFunctionId>()
            select new KeyValuePair<Str, EFunFunctionId>((CIStr)id.ToString(), id)]);

        #endregion

        #region properties

        /// <summary>Rules for parsing literal values</summary>
        [InitParam(type: "ExprLiteralRulesInit", value: """ new() """, set: false)]
        public ExprLiteralRules Literals { get; }

        /// <summary>Rules for mathematical operations</summary>
        [InitParam(type: "ExprMathRulesInit", value: """ new() """, set: false)]
        public ExprMathRules Math { get; }

        /// <summary>Brackets used during a function call</summary>
        [InitParam(value: "BracketPair.ROUND")]
        public BracketPair<Str>? FuncBrackets { get; }
        
        /// <summary>Symbol for separating function arguments</summary>
        [InitParam(value: """ (CIStr)"," """)]
        public Str? FuncArgSep { get; }

        /// <summary>Function identifiers</summary>
        [InitParam(value: "ExprRules.COMMON_FUNCIDS")]
        public ImmNullDict<Str, EFunFunctionId> FuncIds { get; }

        /// <summary>Type for representing booleans</summary>
        [InitParam(value: "ExprIntType.U8")]
        public ExprIntType Boolean { get; }

        /// <summary>Type for representing label addresses</summary>
        [InitParam(value: "ExprIntType.U32")]
        public ExprIntType Label { get; }

        /// <summary>Symbol for "label branching"</summary>
        [InitParam(value: """ (CIStr)"." """)]
        public Str? LabelBranchSymbol { get; }

        #endregion

        #region methods

        /// <summary>Checks whether or not the specified string is a valid label declaration</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the specified string is a valid label declaration</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public bool IsValidLabelDeclaration(Str s)
        {
            try
            {
                Str[] subs = [..s.Split(LabelBranchSymbol)];
                // These are not okay
                // .
                // ..
                // this.
                // this..
                if (subs.Length == 0 || subs[^1].Length == 0)
                    return false;
                // These are okay:
                // this
                // .this
                // ..this
                int pos = 0;
                while (pos < (subs.Length - 1))
                {
                    // These are not okay:
                    // this.
                    // .this..is
                    // ..this.is..not
                    // this.is.not.okay..
                    if (subs[pos++].Length > 0)
                        return false;
                }
                // OK
                return true;
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        /// <summary>Checks whether or not the specified string is a valid label reference</summary>
        /// <param name="s">String to check</param>
        /// <returns>Whether or not the specified string is a valid label reference</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="s"/> is null
        /// </exception>
        public bool IsValidLabelReference(Str s)
        {
            try
            {
                bool foundWord = false;
                foreach (var sub in s.Split(LabelBranchSymbol))
                {
                    // These are okay:
                    // this
                    // this.is
                    // this.is.okay
                    // .is
                    // ..okay
                    if (sub.Length > 0)
                    {
                        foundWord = true;
                        if (sub.StartsWithDigit())
                            return false;
                        if (!sub.IsWord())
                            return false;
                    }
                    // These are not okay:
                    // this.
                    // this..is
                    // this.is..not
                    // this.is.not.okay..
                    else if (foundWord)
                    {
                        return false;
                    }
                }
                // Nor is this okay:
                // .
                if (!foundWord)
                {
                    return false;
                }
                // OK
                return true;
            }
            catch when (s is null)
            { throw new ArgumentNullException(nameof(s)); }
        }

        #endregion
    }
}
