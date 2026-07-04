using System;
using cmdaxe;
using aaasm.engine.io;

namespace aaasm.cmd
{
    public static class ParseFuncs
    {
        /*
        [ParseFunc(typeof(UserMacro), "macro definition")]
        public static bool ParseUserMacro(string input, out object? result)
        {
            var equals = input.IndexOf('=');
            if (equals >= 0)
                result = new UserMacro(input[..equals], input[(equals + 1)..]);
            else
                result = new UserMacro(input, null);
            return true;
        }
        */

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