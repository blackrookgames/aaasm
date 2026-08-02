using System;
using System.IO;
using System.Linq;
using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region DBG_CHR
        
        internal static string DBG_CHR_d(ExprContext context, IEInteger input)
        {
            return input.GetChar(context.Rules);
        }

        internal static string DBG_CHR_d(ExprContext context, IECollection input)
        {
            string str(EValue _input)
            {
                if (_input is IEInteger integer)
                {
                    return integer.GetChar(context.Rules);
                }
                if (_input is IECollection collection)
                {
                    using StringWriter w = new();
                    foreach (var item in collection) w.Write(str(item));
                    return w.ToString();
                }
                throw new EValueException($"Cannot get a character representation of {_input.Type.GetName()}.");
            }
            return str((EValue)input);
        }

        #endregion
        
        #region DBG_DEC
        
        internal static string DBG_DEC_d(ExprContext context, IENumber input)
        {
            return input.DebugDec();
        }

        internal static string DBG_DEC_d(ExprContext context, IECollection input)
        {
            static string str(EValue _input)
            {
                if (_input is IENumber number)
                {
                    return number.DebugDec();
                }
                if (_input is IECollection collection)
                {
                    using StringWriter w = new();
                    foreach (var item in collection) w.Write(str(item));
                    return w.ToString();
                }
                throw new EValueException($"Cannot get a decimal representation of {_input.Type.GetName()}.");
            }
            return str((EValue)input);
        }

        #endregion
        
        #region DBG_BIN
        
        internal static string DBG_BIN_d(ExprContext context, IEInteger input)
        {
            return input.DebugBin();
        }

        internal static string DBG_BIN_d(ExprContext context, IECollection input)
        {
            static string str(EValue _input)
            {
                if (_input is IEInteger integer)
                {
                    return integer.DebugBin();
                }
                if (_input is IECollection collection)
                {
                    using StringWriter w = new();
                    foreach (var item in collection) w.Write(str(item));
                    return w.ToString();
                }
                throw new EValueException($"Cannot get a decimal representation of {_input.Type.GetName()}.");
            }
            return str((EValue)input);
        }

        #endregion
        
        #region DBG_HEX
        
        internal static string DBG_HEX_d(ExprContext context, IEInteger input)
        {
            return input.DebugHex();
        }

        internal static string DBG_HEX_d(ExprContext context, IECollection input)
        {
            static string str(EValue _input)
            {
                if (_input is IEInteger integer)
                {
                    return integer.DebugHex();
                }
                if (_input is IECollection collection)
                {
                    using StringWriter w = new();
                    foreach (var item in collection) w.Write(str(item));
                    return w.ToString();
                }
                throw new EValueException($"Cannot get a decimal representation of {_input.Type.GetName()}.");
            }
            return str((EValue)input);
        }

        #endregion

        #region DBG_TYPE

        internal static string DBG_TYPE_d(ExprContext context, EValue input)
        {
            return input.Type.ToString(context);
        }

        #endregion
    }
}

