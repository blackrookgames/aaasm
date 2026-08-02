using System;
using cmdaxe;
using aaasm.engine.io;
using aaasm.engine.lxpr;

namespace aaasm.cmd
{
    public static class ParseFuncs
    {
        [ParseFunc(typeof(MacroDef), "macro definition")]
        public static bool ParseMacroDef(string input, out object? result)
        {
            var equals = input.IndexOf('=');
            if (equals >= 0)
                result = new MacroDef(input[..equals], input[(equals + 1)..]);
            else
                result = new MacroDef(input, null);
            return true;
        }

        [ParseFunc(typeof(NormalPath), "path")]
        public static bool ParseNormalPath(string input, out object? result)
        {
            try
            {
                result = new NormalPath(input);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}