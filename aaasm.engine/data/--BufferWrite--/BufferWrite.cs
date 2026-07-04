using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aaasm.engine.data
{
    /// <summary>Represents a writable data buffer</summary>
    public partial class BufferWrite : IReadOnlyList<byte>
    {
        #region init

        /// <summary>Initializer for <see cref="BufferWrite"/></summary>
        public BufferWrite()
        {
            f_Data = [];
            f_Position = 0;
            f_End = f_Position == f_Data.Count;
        }

        /// <summary>Writes <see cref="BufferWrite"/> data to a stream</summary>
        /// <param name="stream">Stream to write to</param>
        /// <returns>Created <see cref="BufferWrite"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support writing
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     Stream has already been disposed
        /// </exception>
        /// <exception cref="EndOfStreamException">
        ///     Unexpected end of stream
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred
        /// </exception>
        public void ToStream(Stream stream)
        {
            io.StreamUtil.ThrowIfCantWrite(stream);
            io.StreamUtil.ThrowIfCantSeek(stream);
            try
            {
                var data = Enumerable.ToArray(f_Data);
                stream.Position = 0;
                stream.Write(data);
            }
            catch (ObjectDisposedException e) { throw e; }
            catch (EndOfStreamException e) { throw e; }
            catch (IOException e) { throw e; }
        }

        #endregion
        
        #region IReadOnlyList

        /// <summary>Gets or sets the byte at the specified index</summary>
        /// <param name="index">Index of byte</param>
        /// <returns>Byte value</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is out of range
        /// </exception>
        public byte this[int index]
        {
            get
            {
                try
                { return f_Data[index]; }
                catch when (index < 0 || index >= f_Data.Count)
                { throw new ArgumentOutOfRangeException(nameof(index)); }
            }
            set
            {
                try
                { f_Data[index] = value; }
                catch when (index < 0 || index >= f_Data.Count)
                { throw new ArgumentOutOfRangeException(nameof(index)); }
            }
        }

        /// <summary>Gets an enumerator through the buffer</summary>
        /// <returns>Enumerator through the buffer</returns>
        public IEnumerator<byte> GetEnumerator() => f_Data.GetEnumerator();

        int IReadOnlyCollection<byte>.Count => f_Data.Count;

        IEnumerator IEnumerable.GetEnumerator() => f_Data.GetEnumerator();

        #endregion
        
        #region fields

        private readonly List<byte> f_Data;

        private int f_Position;
        private bool f_End;

        #endregion

        #region properties

        /// <summary>Length of buffer</summary>
        public int Length => f_Data.Count;

        /// <summary>Total number of bytes the internal data structure can hold without resizing</summary>
        public int Capacity => f_Data.Capacity;

        /// <summary>Position of the writer</summary>
        public int Position => f_Position;

        /// <summary>Whether or not writer has reached the end of the buffer</summary>
        public bool End => f_End;

        #endregion
        
        #region helper methods

        /// <summary>
        ///     Assume
        ///     <list type="bullet">
        ///         <item><paramref name="position"/> &gt;=0</item>
        ///         <item><paramref name="position"/> &lt;=<see cref="f_Data"/>.Count</item>
        ///     </list>
        /// </summary>
        private void MM_SetPosition(int position)
        {
            f_Position = position;
            f_End = f_Position == f_Data.Count;
        }

        #endregion
        
        #region methods

        /// <summary>Sets the capacity to the length of the buffer</summary>
        public void TrimExcess()
        {
            f_Data.TrimExcess();
        }

        /// <summary>Ensures that the capacity is at least the specified minimum</summary>
        /// <param name="capacity">Minimum capacity</param>
        /// <returns>New capacity</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="capacity"/> is less than zero
        /// </exception>
        public int EnsureCapacity(int capacity)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(capacity, 0);
            return f_Data.EnsureCapacity(capacity);
        }

        /// <summary>Sets the length of the buffer</summary>
        /// <param name="length">New length</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length"/> is less than zero
        /// </exception>
        public void SetLength(int length)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(length, 0);
            // Set length
            if (f_Data.Count < length)
                f_Data.AddRange(Enumerable.Repeat((byte)0, length - f_Data.Count));
            else if (f_Data.Count > length)
                f_Data.RemoveRange(length, f_Data.Count - length);
            // Fix position
            if (f_Position > f_Data.Count) MM_SetPosition(f_Data.Count);
        }

        /// <summary>Sets the position of the writer</summary>
        /// <param name="position">New position of writer</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="position"/> is out of range
        /// </exception>
        public void SetPosition(int position)
        {
            if (position < 0 || position > f_Data.Count)
                throw new ArgumentOutOfRangeException(nameof(position));
            MM_SetPosition(position);
        }

        #endregion
    }
}
