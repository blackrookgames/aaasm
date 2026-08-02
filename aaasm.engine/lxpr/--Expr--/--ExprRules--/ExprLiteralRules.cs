using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents rules regarding expression literal values</summary>
    public partial class ExprLiteralRules
    {
        #region init

        /// <summary>Initializer for <see cref="ExprLiteralRules"/></summary>
        /// <param name="init">Initialization arguments</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="init"/> is null
        /// </exception>
        public ExprLiteralRules(ExprLiteralRulesInit init)
        {
            try
            {
                f_Parser = new(init);
                Bin = init.Bin;
                Hex = init.Hex;
                DefaultDecimal = init.DefaultDecimal;
                CharType = init.CharType;
                ParseSingleQuote = init.ParseSingleQuote;
                ParseDoubleQuote = init.ParseDoubleQuote;
                ArrayBrackets = init.ArrayBrackets;
                ElementSep = init.ElementSep;
            }
            catch when (init is null)
            {
                throw new ArgumentNullException(nameof(init));
            }
        }

        #endregion

        #region fields

        private readonly Parser f_Parser;

        #endregion

        #region properties

        /// <summary>Acceptable binary notations</summary>
        [InitParam(value: """ new([ExprNumNotation.C_BIN]) """)]
        public ImmNullArray<ExprNumNotation> Bin { get; }

        /// <summary>Acceptable hexadecimal notations</summary>
        [InitParam(value: """ new([ExprNumNotation.C_HEX]) """)]
        public ImmNullArray<ExprNumNotation> Hex { get; }

        /// <summary>Default type for decimal literals</summary>
        [InitParam(value: """ ExprIntType.I32 """)]
        public ExprIntType DefaultDecimal { get; }

        /// <summary>Type for representing string characters</summary>
        [InitParam(value: """ ExprIntType.U8 """)]
        public ExprIntType CharType { get; }

        /// <summary>How single-quotation marks should be parsed as a quoted block</summary>
        [InitParam(value: "ExprQuoteType.CHARACTER")]
        public ExprQuoteType ParseSingleQuote { get; }

        /// <summary>How double-quotation marks should be parsed as a quoted block</summary>
        [InitParam(value: "ExprQuoteType.STRING")]
        public ExprQuoteType ParseDoubleQuote { get; }

        /// <summary>Brackets used for array or tuple literals</summary>
        [InitParam(value: """ BracketPair.SQUARE """)]
        public BracketPair<Str>? ArrayBrackets { get; }

        /// <summary>Symbol for separating elements in an array or tuple literals</summary>
        [InitParam(value: """ (CIStr)"," """)]
        public Str? ElementSep { get; }

        #endregion

        #region methods

        /// <summary>Attempts to parse the token as a literal</summary>
        /// <param name="token">Input token</param>
        /// <param name="result">Result</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="token"/> is null
        /// </exception>
        /// <exception cref="BadSrcException">
        ///     <paramref name="token"/> contains invalid literal data
        /// </exception>
        public bool Run(RoughToken token, [MaybeNullWhen(false)] out EValue result)
        {
            return f_Parser.Run(token, out result);
        }

        /// <summary>Checks whether or not the specified expression value is a character</summary>
        /// <param name="value">Expression value to check</param>
        /// <returns>Whether or not the specified expression value is a character</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="value"/> is null
        /// </exception>
        public bool IsChar(EValue value)
        {
            return f_Parser.IsChar(value);
        }
        
        /// <summary>Checks whether or not the specified expression value is a string</summary>
        /// <param name="value">Expression value to check</param>
        /// <returns>Whether or not the specified expression value is a string</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="value"/> is null
        /// </exception>
        public bool IsString(EValue value)
        {
            return f_Parser.IsString(value);
        }
        
        /// <summary>Attempts to get the string value of the specified expression value</summary>
        /// <param name="value">Expression value</param>
        /// <param name="result">Resulting C# string</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="value"/> is null
        /// </exception>
        public bool TryString(EValue value, [MaybeNullWhen(false)] out string result)
        {
            try
            {
                if (f_Parser.IsString(value))
                {
                    using StringWriter w = new();
                    foreach (var c in (EArray)value)
                    { if (((IEInteger)c).TryChar(out var cc)) w.Write(cc); }
                    result = w.ToString();
                    return true;
                }
                else
                {
                    result = default;
                    return false;
                }
            }
            catch when (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        #endregion
    }
}
