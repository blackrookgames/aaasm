using System;
using System.Runtime.CompilerServices;

namespace aaasm.engine.help
{
    /// <summary>Utility for argument-related operations</summary>
    public static class ArgUtil
    {
        #region ThrowIfInvalid

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> 
        ///     if <paramref name="arg"/> is not valid
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <param name="paramName">Name of parameter</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="arg"/> is not valid
        /// </exception>
        public static void ThrowIfInvalid(SubRange arg, int min, int max,
            [CallerArgumentExpression(nameof(arg))] string? paramName = null)
        {
            if (arg.Beg >= min && arg.Len >= 0 && (arg.Beg + arg.Len) <= max)
                return;
            throw new ArgumentException("Range is not valid.", paramName);
        }

        #endregion

        #region ThrowIfOOR, ThrowIfOOREx

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="arg"/> 
        ///     is less than <paramref name="min"/> or greater than <paramref name="max"/>
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <param name="paramName">Name of parameter</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="arg"/> is out of range
        /// </exception>
        public static void ThrowIfOOR(int arg, int min, int max,
            [CallerArgumentExpression(nameof(arg))] string? paramName = null)
        {
            if (arg >= min && arg <= max) return;
            throw new ArgumentOutOfRangeException(paramName);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="arg"/> 
        ///     is less than <paramref name="min"/> or greater than or equal to <paramref name="max"/>
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <param name="paramName">Name of parameter</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="arg"/> is out of range
        /// </exception>
        public static void ThrowIfOOREx(int arg, int min, int max,
            [CallerArgumentExpression(nameof(arg))] string? paramName = null)
        {
            if (arg >= min && arg < max) return;
            throw new ArgumentOutOfRangeException(paramName);
        }

        #endregion

        #region RangeBegEnd

        /// <summary>Determines the absolute beginning and ending point of a range argument</summary>
        /// <param name="arg">Range argument</param>
        /// <param name="len">Reference length</param>
        /// <param name="paramName">Name of parameter</param>
        /// <returns>Absolute beginning and ending point</returns>
        /// <exception cref="ArgumentException">
        ///     Range is not valid
        /// </exception>
        public static (int beg, int end) RangeBegEnd(Range arg, int len,
            [CallerArgumentExpression(nameof(arg))] string? paramName = null)
        {
            var beg = arg.Start.IsFromEnd ? (len - arg.Start.Value) : arg.Start.Value;
            var end = arg.End.IsFromEnd ? (len - arg.End.Value) : arg.End.Value;
            if (beg < 0 || beg > len || end < 0 || end > len || beg > end)
                throw new ArgumentException("Range is not valid.", paramName);
            return (beg, end);
        }

        #endregion
    }
}