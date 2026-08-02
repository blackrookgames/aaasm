using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using aaasm.engine.col;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    public partial class ExprLiteralRules
    {
        public partial class Parser
        {
            #region nested

            private delegate bool TryParseRaw<T>(string s, [MaybeNullWhen(false)] out T result);
            private delegate bool TryParseFunc(string s, [MaybeNullWhen(false)] out EValue result);

            private readonly struct TryParseFuncs(
                TryParseRaw<byte> tryUInt8, TryParseRaw<sbyte> tryInt8,
                TryParseRaw<ushort> tryUInt16, TryParseRaw<short> tryInt16,
                TryParseRaw<uint> tryUInt32, TryParseRaw<int> tryInt32,
                TryParseRaw<ulong> tryUInt64, TryParseRaw<long> tryInt64)
            {
                #region fields

                private readonly TryParseRaw<byte> f_TryUInt8 = tryUInt8;
                private readonly TryParseRaw<sbyte> f_TryInt8 = tryInt8;
                private readonly TryParseRaw<ushort> f_TryUInt16 = tryUInt16;
                private readonly TryParseRaw<short> f_TryInt16 = tryInt16;
                private readonly TryParseRaw<uint> f_TryUInt32 = tryUInt32;
                private readonly TryParseRaw<int> f_TryInt32 = tryInt32;
                private readonly TryParseRaw<ulong> f_TryUInt64 = tryUInt64;
                private readonly TryParseRaw<long> f_TryInt64 = tryInt64;

                #endregion

                #region methods

                public bool TryUInt8(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryUInt8(s, out var raw)) goto fail;
                    result = new EU8(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryInt8(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryInt8(s, out var raw)) goto fail;
                    result = new EI8(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryUInt16(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryUInt16(s, out var raw)) goto fail;
                    result = new EU16(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryInt16(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryInt16(s, out var raw)) goto fail;
                    result = new EI16(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryUInt32(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryUInt32(s, out var raw)) goto fail;
                    result = new EU32(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryInt32(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryInt32(s, out var raw)) goto fail;
                    result = new EI32(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryUInt64(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryUInt64(s, out var raw)) goto fail;
                    result = new EU64(raw); return true;
                    fail: result = default; return false;
                }

                public bool TryInt64(string s, [MaybeNullWhen(false)] out EValue result)
                {
                    if (s.Length == 0) goto fail; // Make sure string is not empty
                    if (!f_TryInt64(s, out var raw)) goto fail;
                    result = new EI64(raw); return true;
                    fail: result = default; return false;
                }

                #endregion
            }

            private readonly struct PrefixesSuffixes
            {
                #region init

                public PrefixesSuffixes(ImmNullArray<ExprNumNotation> notations)
                {
                    List<Str> prefixes = [];
                    List<Str> suffixes = [];
                    List<(Str, Str)> presuffs = [];
                    foreach (var notation in notations)
                    {
                        if (notation.Prefix is not null)
                        {
                            if (notation.Suffix is not null)
                            {
                                presuffs.Add((notation.Prefix, notation.Suffix));
                            }
                            else
                            {
                                prefixes.Add(notation.Prefix);
                            }
                        }
                        else if (notation.Suffix is not null)
                        {
                            suffixes.Add(notation.Suffix);
                        }
                    }
                    Prefixes = [..prefixes];
                    Suffixes = [..suffixes];
                    PreSuffs = [..presuffs];
                }

                #endregion

                #region properties
                
                public readonly Str[] Prefixes;
                public readonly Str[] Suffixes;
                public readonly (Str prefix, Str suffix)[] PreSuffs;

                #endregion
            }

            #endregion

            #region init

            /// <summary>Initializer for <see cref="Parser"/></summary>
            /// <param name="rules">Rules for identifying literals</param>
            /// <exception cref="ArgumentNullException">
            ///     <paramref name="rules"/> is null
            /// </exception>
            public Parser(ExprLiteralRulesInit init)
            {
                try
                {
                    // Strings
                    f_ParseSingleQuote = init.ParseSingleQuote;
                    f_ParseDoubleQuote = init.ParseDoubleQuote;
                    f_CharType = init.CharType.Type();
                    f_CharFunc = CHARFUNCS[init.CharType];
                    // Bin, Hex
                    f_Bin = new(init.Bin);
                    f_Hex = new(init.Hex);
                    // Decimal parse order
                    f_DecParseOrder = [.. MM_DecParseOrder(init.DefaultDecimal)];
                }
                catch when (init is null)
                { throw new ArgumentNullException(nameof(init)); }
            }

            #endregion

            #region static

            static Parser()
            {
                TRYPARSE_BIN = new(
                    num.BinParse.TryUInt8, num.BinParse.TryInt8, 
                    num.BinParse.TryUInt16, num.BinParse.TryInt16, 
                    num.BinParse.TryUInt32, num.BinParse.TryInt32, 
                    num.BinParse.TryUInt64, num.BinParse.TryInt64);
                TRYPARSE_HEX = new(
                    num.HexParse.TryUInt8, num.HexParse.TryInt8, 
                    num.HexParse.TryUInt16, num.HexParse.TryInt16, 
                    num.HexParse.TryUInt32, num.HexParse.TryInt32, 
                    num.HexParse.TryUInt64, num.HexParse.TryInt64);
                TRYPARSE_DEC = new(
                    byte.TryParse, sbyte.TryParse, 
                    ushort.TryParse, short.TryParse, 
                    uint.TryParse, int.TryParse, 
                    ulong.TryParse, long.TryParse);
                DECPARSEFUNCS = new([
                    new(ExprIntType.I8, TRYPARSE_DEC.TryInt8),
                    new(ExprIntType.U8, TRYPARSE_DEC.TryUInt8),
                    new(ExprIntType.I16, TRYPARSE_DEC.TryInt16),
                    new(ExprIntType.U16, TRYPARSE_DEC.TryUInt16),
                    new(ExprIntType.I32, TRYPARSE_DEC.TryInt32),
                    new(ExprIntType.U32, TRYPARSE_DEC.TryUInt32),
                    new(ExprIntType.I64, TRYPARSE_DEC.TryInt64),
                    new(ExprIntType.U64, TRYPARSE_DEC.TryUInt64),]);
                CHARFUNCS = new([
                    new(ExprIntType.U8, c => new EU8(unchecked((byte)(MM_ValidateChar(c, 0xFF) & 255)))),
                    new(ExprIntType.I8, c => new EI8(unchecked((sbyte)(MM_ValidateChar(c, 0xFF) & 255)))),
                    new(ExprIntType.U16, c => new EU16(unchecked((ushort)(MM_ValidateChar(c, 0xFFFF) & 65535)))),
                    new(ExprIntType.I16, c => new EI16(unchecked((short)(MM_ValidateChar(c, 0xFFFF) & 65535)))),
                    new(ExprIntType.U32, c => new EU32(c)),
                    new(ExprIntType.I32, c => new EI32(c)),
                    new(ExprIntType.U64, c => new EU64(c)),
                    new(ExprIntType.I64, c => new EI64(c)),
                ]);
            }

            private static readonly TryParseFuncs TRYPARSE_BIN;
            private static readonly TryParseFuncs TRYPARSE_HEX;
            private static readonly TryParseFuncs TRYPARSE_DEC;
            
            private static readonly ImmNullDict<ExprIntType, TryParseFunc> DECPARSEFUNCS;

            private static readonly ImmNullDict<ExprIntType, Func<char, EValue>> CHARFUNCS;

            #endregion

            #region fields

            private readonly ExprQuoteType f_ParseSingleQuote;
            private readonly ExprQuoteType f_ParseDoubleQuote;
            private readonly EType f_CharType;
            private readonly Func<char, EValue> f_CharFunc;

            private readonly PrefixesSuffixes f_Hex;
            private readonly PrefixesSuffixes f_Bin;

            private readonly TryParseFunc[] f_DecParseOrder;

            #endregion

            #region helper methods

            private static T MM_ValidateChar<T>(T c, T mask)
                where T: struct, IEquatable<T>, IBitwiseOperators<T, T, T>, IShiftOperators<T, int, T>
            {
                // Does character fit completely in mask?
                if ((c & (~mask)).Equals(default)) return c;
                // No! Determine the bit size.
                int bitSize = 0;
                while (!c.Equals(default))
                {
                    ++bitSize;
                    c >>>= 1;
                }
                int standardBS = 1 << (int)Math.Ceiling(Math.Log2(((bitSize + 7) / 8) * 8));
                throw new BadSrcException($"{standardBS}-bit characters are not supported.");
            }

            private static bool MM_TryParseSingle(string s, [MaybeNullWhen(false)] out EValue result)
            {
                if (float.TryParse(s, out var raw))
                { result = new EF32(raw); return true; }
                else
                { result = default; return false; }
            }
            
            private static bool MM_TryParseDouble(string s, [MaybeNullWhen(false)] out EValue result)
            {
                if (double.TryParse(s, out var raw))
                { result = new EF64(raw); return true; }
                else
                { result = default; return false; }
            }

            private static IEnumerable<TryParseFunc> MM_DecParseOrder(ExprIntType @default)
            {
                var iter = DECPARSEFUNCS.GetEnumerator();
                // Find default
                while (iter.MoveNext())
                {
                    var current = iter.Current;
                    if (current.Key != @default) continue;
                    yield return current.Value;
                    break;
                }
                // Yield subsequent
                while (iter.MoveNext())
                {
                    yield return iter.Current.Value;
                }
                // Yield floating points
                yield return MM_TryParseSingle;
                yield return MM_TryParseDouble;
            }

            private static bool MM_ParseLiteral(
                int bitsPerDigit,
                TryParseFuncs funcs,
                PrefixesSuffixes prefixesSuffixes,
                RoughToken token,
                [MaybeNullWhen(false)] out EValue result)
            {
                bool tryParse(string s, [MaybeNullWhen(false)] out EValue r)
                {
                    int bits = s.Length * bitsPerDigit;
                    if (bits > 32) return funcs.TryUInt64(s, out r);
                    if (bits > 16) return funcs.TryUInt32(s, out r);
                    if (bits > 8) return funcs.TryUInt16(s, out r);
                    return funcs.TryUInt8(s, out r);
                }
                var raw = token.RawData.Raw;
                // Prefixes/Suffixes
                foreach (var (prefix, suffix) in prefixesSuffixes.PreSuffs)
                {
                    if (!raw.StartsWith(prefix))
                        continue;
                    if (!raw.EndsWith(suffix))
                        continue;
                    int beg = prefix.Length;
                    int end = raw.Length - suffix.Length;
                    return tryParse((string)raw[beg..end], out result);
                }
                // Suffixes
                foreach (var suffix in prefixesSuffixes.Suffixes)
                {
                    if (!raw.EndsWith(suffix))
                        continue;
                    int end = raw.Length - suffix.Length;
                    return tryParse((string)raw[..end], out result);
                }
                // Prefixes
                foreach (var prefix in prefixesSuffixes.Prefixes)
                {
                    if (!raw.StartsWith(prefix))
                        continue;
                    int beg = prefix.Length;
                    return tryParse((string)raw[beg..], out result);
                }
                // Fail
                result = default;
                return false;
            }

            private bool MM_ParseDecimal(
                RoughToken token,
                [MaybeNullWhen(false)] out EValue result)
            {
                foreach (var tryParse in f_DecParseOrder)
                {
                    if (tryParse((string)token.RawData.Raw, out result))
                        return true;
                }
                result = default;
                return false;
            }

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
                try
                {
                    // Is it a string or character?
                    if (token.Quoted)
                    {
                        string data = (string)(
                            (token.RawData.Length >= 2) ? 
                            token.RawData.Raw[1..^1] : 
                            token.RawData.Raw);
                        var parseAsChar = token.QuoteChar switch
                        {
                            '\'' => f_ParseSingleQuote == ExprQuoteType.CHARACTER,
                            '\"' => f_ParseDoubleQuote == ExprQuoteType.CHARACTER,
                            _ => false,
                        };
                        if (parseAsChar)
                        {
                            if (data.Length != 1) throw new BadSrcException(
                                "Invalid character literal", token.RefPnt);
                            result = f_CharFunc(data[0]);
                        }
                        else
                        {
                            EValue[] values = new EValue[data.Length];
                            for (int i = 0; i < values.Length; ++i)
                                values[i] = f_CharFunc(data[i]);
                            result = new EArray(f_CharType, values);
                        }
                        return true;
                    }
                    // No! Is it a number?
                    if (MM_ParseLiteral(1, TRYPARSE_BIN, f_Bin, token, out result))
                        return true;
                    if (MM_ParseLiteral(4, TRYPARSE_HEX, f_Hex, token, out result))
                        return true;
                    if (MM_ParseDecimal(token, out result))
                        return true;
                    // No!
                    result = default;
                    return false;
                }
                catch when (token is null)
                { throw new ArgumentNullException(nameof(token)); }
            }

            /// <summary>Checks whether or not the specified expression value is a character</summary>
            /// <param name="value">Expression value to check</param>
            /// <returns>Whether or not the specified expression value is a character</returns>
            /// <exception cref="ArgumentNullException">
            ///     <paramref name="value"/> is null
            /// </exception>
            public bool IsChar(EValue value)
            {
                try
                { return value.Type == f_CharType; }
                catch when (value is null)
                { throw new ArgumentNullException(nameof(value)); }
            }
            
            /// <summary>Checks whether or not the specified expression value is a string</summary>
            /// <param name="value">Expression value to check</param>
            /// <returns>Whether or not the specified expression value is a string</returns>
            /// <exception cref="ArgumentNullException">
            ///     <paramref name="value"/> is null
            /// </exception>
            public bool IsString(EValue value)
            {
                try
                { return value.Type.NameId == ETypeNameId.ARRAY && value.Type.ElementType == f_CharType; }
                catch when (value is null)
                { throw new ArgumentNullException(nameof(value)); }
            }

            #endregion
        }
    }
}
