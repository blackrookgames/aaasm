using System;
using aaasm.engine.data;

namespace aaasm.engine.lxpr
{
    /// <summary>Common bracket pairs</summary>
    public static class BracketPair
    {
        #region const

        /// <summary>Curly brackets { }</summary>
        public static BracketPair<Str> CURLY { get; } = new((CIStr)"{", (CIStr)"}");

        /// <summary>Square brackets [ ]</summary>
        public static BracketPair<Str> SQUARE { get; } = new((CIStr)"[", (CIStr)"]");

        /// <summary>Round brackets ( )</summary>
        public static BracketPair<Str> ROUND { get; } = new((CIStr)"(", (CIStr)")");

        #endregion
    }

    /// <summary>Represents a bracket pair</summary>
    public class BracketPair<T> : IEquatable<BracketPair<T>>
    {
        #region init

        /// <summary>Initializer for <see cref="BracketPair{T}"/></summary>
        /// <param name="open">Open bracket</param>
        /// <param name="close">Close bracket</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="open"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="close"/> is null
        /// </exception>
        public BracketPair(T open, T close)
        {
            if (open is null)
                throw new ArgumentNullException(nameof(open));
            if (close is null)
                throw new ArgumentNullException(nameof(close));
            f_Open = open;
            f_Close = close;
        }

        #endregion

        #region fields

        private readonly T f_Open;
        private readonly T f_Close;

        #endregion

        #region properties

        /// <summary>Open bracket</summary>
        public T Open => f_Open;

        /// <summary>Close bracket</summary>
        public T Close => f_Close;

        #endregion

        #region helper methods

        private static bool MM_BracketsEqual(T a, T b)
        {
            if (a is null) return b is null;
            return a.Equals(b);
        }

        private bool MM_Equals(BracketPair<T> other)
        {
            return MM_BracketsEqual(f_Open, other.f_Open) && MM_BracketsEqual(f_Close, other.f_Close);
        }

        private static bool MM_Equal(BracketPair<T>? a, BracketPair<T>? b)
        {
            if (a is null) return b is null;
            if (b is null) return false;
            return a.MM_Equals(b);
        }

        #endregion

        #region object

        /// <summary>Creates a string representation of the <see cref="BracketPair{T}"/></summary>
        /// <returns>Created string</returns>
        public override string ToString()
        {
            return $"({f_Open}, {f_Close})";
        }

        /// <summary>
        ///     Checks if the specified object is a <see cref="BracketPair{T}"/> 
        ///     and is equal to the current <see cref="BracketPair{T}"/>
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>
        ///     True if <paramref name="obj"/> is a <see cref="BracketPair{T}"/> 
        ///     and is equal to the current <see cref="BracketPair{T}"/>; 
        ///     false otherwise
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not BracketPair<T> other) return false;
            return MM_Equals(other);
        }

        /// <summary>Computes a hash code for the current <see cref="BracketPair{T}"/></summary>
        /// <returns>Hash code for the current <see cref="BracketPair{T}"/></returns>
        public override int GetHashCode()
        {
            if (f_Open is null) return 0;
            return f_Open.GetHashCode();
        }

        #endregion

        #region IEquatable

        /// <summary>
        ///     Checks if the current <see cref="BracketPair{T}"/> 
        ///     is equal to another <see cref="BracketPair{T}"/>
        /// </summary>
        /// <param name="other">Other <see cref="BracketPair{T}"/></param>
        /// <returns>
        ///     Whether or not the current <see cref="BracketPair{T}"/> 
        ///     is equal to <paramref name="other"/>
        /// </returns>
        public bool Equals(BracketPair<T>? other)
        {
            if (other is null) return false;
            return MM_Equals(other);
        }
    
        #endregion

        #region operators

        public static bool operator ==(BracketPair<T>? a, BracketPair<T>? b) => MM_Equal(a, b);
        public static bool operator !=(BracketPair<T>? a, BracketPair<T>? b) => !MM_Equal(a, b);

        #endregion
    }
}
