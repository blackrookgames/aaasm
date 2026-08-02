using System;
using System.Collections;
using System.Collections.Generic;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a case-insensitive string</summary>
    /// <param name="src">Source </param>
    public class CIStr(string? src) : Str(MM_ToUpper(src))
    {
        #region helper methods

        private static string? MM_ToUpper(string? input)
        {
            if (input is null) return null;
            char[] chars = new char[input.Length];
            for (int i = 0; i < input.Length; ++i)
            {
                var c = input[i];
                chars[i] = (c >= 'a' && c <= 'z') ? ((char)(c - 0x20)) : c;
            }
            return new(chars);
        }

        #endregion

        #region operators

        public static explicit operator CIStr(string src) => new(src);

        #endregion

        #region CIStr

        private protected override bool PP_IgnoreCase => true;

        private protected override Str MM_Create(string? src) => new CIStr(src);

        #endregion
    }
}