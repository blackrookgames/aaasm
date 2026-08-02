using System;

using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.lxpr
{
    public static partial class EFunFunc
    {
        #region helper methods

        #region ToBool

        private static bool MM_ToBool(EValue arg,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            try
            {
                return arg.Type.BoolConv().ToBool(arg);
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(arg, param);
                throw;
            }
        }

        #endregion

        #region ThrowIfDifferentTypes

        private static void MM_ThrowIfDifferentTypes(EType a, EType b)
        {
            if (a == b) return;
            throw new EValueException("Arguments must be of the same type.");
        }

        private static void MM_ThrowIfDifferentTypes<T>(T a, T b, Func<T, EType> getType,
            [CallArgExp(nameof(a))] string? aParam = null,
            [CallArgExp(nameof(b))] string? bParam = null)
        {
            try
            {
                MM_ThrowIfDifferentTypes(getType(a), getType(b));
            }
            catch
            {
                ArgumentNullException.ThrowIfNull(a, aParam);
                ArgumentNullException.ThrowIfNull(b, bParam);
                throw;
            }
        }

        private static void MM_ThrowIfDifferentTypes(ENodeValueType a, ENodeValueType b,
            [CallArgExp(nameof(a))] string? aParam = null,
            [CallArgExp(nameof(b))] string? bParam = null)
        { MM_ThrowIfDifferentTypes(a, b, i => i.Type, aParam, bParam); }

        private static void MM_ThrowIfDifferentTypes(EValue a, EValue b,
            [CallArgExp(nameof(a))] string? aParam = null,
            [CallArgExp(nameof(b))] string? bParam = null)
        { MM_ThrowIfDifferentTypes(a, b, i => i.Type, aParam, bParam); }

        private static void MM_ThrowIfDifferentTypes(IENumber a, IENumber b,
            [CallArgExp(nameof(a))] string? aParam = null,
            [CallArgExp(nameof(b))] string? bParam = null)
        { MM_ThrowIfDifferentTypes(a, b, i => i.Type, aParam, bParam); }

        private static void MM_ThrowIfDifferentTypes(IEInteger a, IEInteger b,
            [CallArgExp(nameof(a))] string? aParam = null,
            [CallArgExp(nameof(b))] string? bParam = null)
        { MM_ThrowIfDifferentTypes(a, b, i => i.Type, aParam, bParam); }

        private static void MM_ThrowIfDifferentTypes(IECollection a, IECollection b,
            [CallArgExp(nameof(a))] string? aParam = null,
            [CallArgExp(nameof(b))] string? bParam = null)
        { MM_ThrowIfDifferentTypes(a, b, i => i.Type, aParam, bParam); }

        #endregion

        #region ThrowIfIndexOOR

        private static void MM_ThrowIfIndexOOR(int length, int index)
        {
            if (index >= 0 && index < length) return;
            throw new EValueException("Index is out of range.");
        }

        #endregion

        #endregion
    }
}