using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using static System.Buffers.Binary.BinaryPrimitives;

namespace aaasm.engine.data
{
    /// <summary>Represents a readable data buffer</summary>
    public partial class BufferRead : IReadOnlyList<byte>
    {
        #region init

        /// <summary>
        ///     Assume
        ///     <list type="bullet">
        ///         <item><paramref name="data"/> is not null</item>
        ///     </list>
        /// </summary>
        private BufferRead(byte[] data)
        {
            f_Data = data;
            f_Position = 0;
            f_End = f_Data.Length == 0;
        }
        
        /// <summary>Creates a <see cref="BufferRead"/> using data from a stream</summary>
        /// <param name="stream">Stream to read from</param>
        /// <returns>Created <see cref="BufferRead"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support reading
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
        public static BufferRead FromStream(Stream stream)
        {
            io.StreamUtil.ThrowIfCantRead(stream);
            io.StreamUtil.ThrowIfCantSeek(stream);
            try
            {
                var data = new byte[stream.Length];
                stream.Position = 0;
                stream.ReadExactly(data);
                return new(data);
            }
            catch (ObjectDisposedException e) { throw e; }
            catch (EndOfStreamException e) { throw e; }
            catch (IOException e) { throw e; }
        }

        #endregion

        #region IReadOnlyList

        /// <summary>Gets the byte at the specified index</summary>
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
                catch when (index < 0 || index >= f_Data.Length)
                { throw new ArgumentOutOfRangeException(nameof(index)); }
            }
        }

        /// <summary>Gets an enumerator through the buffer</summary>
        /// <returns>Enumerator through the buffer</returns>
        public IEnumerator<byte> GetEnumerator() => (IEnumerator<byte>)f_Data.GetEnumerator();

        int IReadOnlyCollection<byte>.Count => f_Data.Length;

        IEnumerator IEnumerable.GetEnumerator() => f_Data.GetEnumerator();

        #endregion
        
        #region fields

        private readonly byte[] f_Data;

        private int f_Position;
        private bool f_End;

        #endregion
        
        #region properties

        /// <summary>Length of buffer</summary>
        public int Length => f_Data.Length;

        /// <summary>Position of the reader</summary>
        public int Position => f_Position;

        /// <summary>Whether or not reader has reached the end of the buffer</summary>
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
            f_End = f_Position == f_Data.Length;
        }

        #endregion
        
        #region methods

        /// <summary>Sets the position of the reader</summary>
        /// <param name="position">New position of reader</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="position"/> is out of range
        /// </exception>
        public void SetPosition(int position)
        {
            if (position < 0 || position > f_Data.Length)
                throw new ArgumentOutOfRangeException(nameof(position));
            MM_SetPosition(position);
        }

        #endregion
    }
}
