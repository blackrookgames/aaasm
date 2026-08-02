using System;
using System.Collections;
using System.Collections.Generic;
using aaasm.engine.col;
using CallArgExpAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace aaasm.engine.help
{
    /// <summary>Utility for argument-related operations</summary>
    public static class ArgUtil
    {
        #region ThrowIfNullItems

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> 
        ///     if <paramref name="arg"/> one or more null elements
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="param">Name of parameter</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="arg"/> contains null elements
        /// </exception>
        public static void ThrowIfNullItems(IEnumerable arg,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            try
            {
                if (!ColUtil.AnyNull(arg)) return;
                throw new ArgumentException("Collection cannot contain null elements.", param);
            }
            catch when (arg is null)
            {
                throw new ArgumentNullException(param); 
            }
        }

        #endregion

        #region ThrowIfInvalid

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> 
        ///     if <paramref name="arg"/> is not valid
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <param name="param">Name of parameter</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="arg"/> is not valid
        /// </exception>
        public static void ThrowIfInvalid(SubRange arg, int min, int max,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            if (arg.Beg >= min && arg.Len >= 0 && (arg.Beg + arg.Len) <= max)
                return;
            throw new ArgumentException("Range is not valid.", param);
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
        /// <param name="param">Name of parameter</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="arg"/> is out of range
        /// </exception>
        public static void ThrowIfOOR(int arg, int min, int max,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            if (arg >= min && arg <= max) return;
            throw new ArgumentOutOfRangeException(param);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="arg"/> 
        ///     is less than <paramref name="min"/> or greater than or equal to <paramref name="max"/>
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <param name="param">Name of parameter</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="arg"/> is out of range
        /// </exception>
        public static void ThrowIfOOREx(int arg, int min, int max,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            if (arg >= min && arg < max) return;
            throw new ArgumentOutOfRangeException(param);
        }

        #endregion

        #region RangeBegEnd

        /// <summary>Determines the absolute beginning and ending point of a range argument</summary>
        /// <param name="arg">Range argument</param>
        /// <param name="len">Reference length</param>
        /// <param name="param">Name of parameter</param>
        /// <returns>Absolute beginning and ending point</returns>
        /// <exception cref="ArgumentException">
        ///     Range is not valid
        /// </exception>
        public static (int beg, int end) RangeBegEnd(Range arg, int len,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            var beg = arg.Start.IsFromEnd ? (len - arg.Start.Value) : arg.Start.Value;
            var end = arg.End.IsFromEnd ? (len - arg.End.Value) : arg.End.Value;
            if (beg < 0 || beg > len || end < 0 || end > len || beg > end)
                throw new ArgumentException("Range is not valid.", param);
            return (beg, end);
        }

        #endregion
        
        #region NotNull

        /// <summary>
        ///     Checks the argument to ensure it's not null;
        ///     if it is, an <see cref="ArgumentNullException"/> is thrown
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="param">Name of parameter</param>
        /// <returns>Argument value</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        public static T NotNull<T>(T arg,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            ArgumentNullException.ThrowIfNull(arg, param);
            return arg;
        }

        #endregion

        #region NoNullItems

        /// <summary>
        ///     Enumerates thru <paramref name="arg"/>; 
        ///     if a null element is found, an <see cref="ArgumentException"/> is thrown
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <param name="param">Name of parameter</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="arg"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="arg"/> contains null elements
        /// </exception>
        public static IEnumerable NoNullItems(IEnumerable arg,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            // Get enumerator
            IEnumerator enumerator;
            try
            { enumerator = arg.GetEnumerator(); }
            catch when (arg is null)
            { throw new ArgumentNullException(param); }
            // Enumerate
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current is not null) { yield return current; continue; }
                throw new ArgumentException("Collection cannot contain null elements.", param);
            }
        }

        /// <inheritdoc cref="NoNullItems(IEnumerable, string?)"/>
        public static IEnumerable<T> NoNullItems<T>(IEnumerable<T> arg,
            [CallArgExp(nameof(arg))] string? param = null)
        {
            // Get enumerator
            IEnumerator<T> enumerator;
            try
            { enumerator = arg.GetEnumerator(); }
            catch when (arg is null)
            { throw new ArgumentNullException(param); }
            // Enumerate
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current is not null) { yield return current; continue; }
                throw new ArgumentException("Collection cannot contain null elements.", param);
            }
        }

        #endregion
    }
}