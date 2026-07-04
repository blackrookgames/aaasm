using System;
using static System.Buffers.Binary.BinaryPrimitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace aaasm.engine.data
{
    public partial class BufferWrite
    {
        #region nested

        private delegate void WriteFunc<T>(Span<byte> span, T value);

        #endregion

        #region fields

        private readonly byte[] f_Span = new byte[8];

        #endregion

        #region helper methods

        private Span<byte> MM_Span2() => new(f_Span, 0, 2);
        private Span<byte> MM_Span4() => new(f_Span, 0, 4);
        private Span<byte> MM_Span8() => new(f_Span, 0, 8);

        private void MM_Write<T>(
            int size, WriteFunc<T> writeFunc, Span<byte> span, T value)
        {
            var end = f_Position + size;
            if (end > f_Data.Count) f_Data.AddRange(Enumerable.Repeat<byte>(0, end - f_Data.Count));
            writeFunc(span, value);
            for (int i = 0; i < size; ++i) f_Data[f_Position + i] = span[i];
            MM_SetPosition(end);
        }

        #endregion

        #region methods

        #region Write

        /// <summary>Writes to the stream</summary>
        /// <param name="buffer">Buffer containing data to write</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null</exception>
        public void Write(byte[] buffer)
        {
            ArgumentNullException.ThrowIfNull(buffer);
            var end = f_Position + buffer.Length;
            if (end <= f_Position)
            {
                for (int i = 0; i < buffer.Length; ++i) f_Data[f_Position + i] = buffer[i];
            }
            else
            {
                var mid = f_Data.Count - f_Position;
                for (int i = 0; i < mid; ++i) f_Data[f_Position + i] = buffer[i];
                f_Data.AddRange(new ArraySegment<byte>(buffer, mid, buffer.Length - mid));
            }
            MM_SetPosition(end);
        }

        #endregion

        #region WriteUInt8

        /// <summary>Writes an 8-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt8(byte value)
        {
            if (f_End) f_Data.Add(value);
            else f_Data[f_Position] = value;
            MM_SetPosition(f_Position + 1);
        }

        #endregion

        #region WriteInt8

        /// <summary>Writes an 8-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt8(sbyte value)
        {
            if (f_End) f_Data.Add((byte)value);
            else f_Data[f_Position] = (byte)value;
            MM_SetPosition(f_Position + 1);
        }

        #endregion

        #region WriteUInt16

        /// <summary>Writes a 16-bit unsigned integer to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteUInt16(bool big, ushort value)
        { if (big) WriteUInt16B(value); else WriteUInt16L(value); }

        /// <summary>Writes a little-endian 16-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt16L(ushort value) =>
            MM_Write(2, WriteUInt16LittleEndian, MM_Span2(), value);

        /// <summary>Writes a big-endian 16-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt16B(ushort value) =>
            MM_Write(2, WriteUInt16BigEndian, MM_Span2(), value);

        #endregion

        #region WriteInt16

        /// <summary>Writes a 16-bit signed integer to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteInt16(bool big, short value)
        { if (big) WriteInt16B(value); else WriteInt16L(value); }

        /// <summary>Writes a little-endian 16-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt16L(short value) =>
            MM_Write(2, WriteInt16LittleEndian, MM_Span2(), value);

        /// <summary>Writes a big-endian 16-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt16B(short value) =>
            MM_Write(2, WriteInt16BigEndian, MM_Span2(), value);

        #endregion

        #region WriteUInt32

        /// <summary>Writes a 32-bit unsigned integer to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteUInt32(bool big, uint value)
        { if (big) WriteUInt32B(value); else WriteUInt32L(value); }

        /// <summary>Writes a little-endian 32-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt32L(uint value) =>
            MM_Write(4, WriteUInt32LittleEndian, MM_Span4(), value);

        /// <summary>Writes a big-endian 32-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt32B(uint value) =>
            MM_Write(4, WriteUInt32BigEndian, MM_Span4(), value);

        #endregion

        #region WriteInt32

        /// <summary>Writes a 32-bit signed integer to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteInt32(bool big, int value)
        { if (big) WriteInt32B(value); else WriteInt32L(value); }

        /// <summary>Writes a little-endian 32-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt32L(int value) =>
            MM_Write(4, WriteInt32LittleEndian, MM_Span4(), value);

        /// <summary>Writes a big-endian 32-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt32B(int value) =>
            MM_Write(4, WriteInt32BigEndian, MM_Span4(), value);

        #endregion

        #region WriteUInt64

        /// <summary>Writes a 64-bit unsigned integer to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteUInt64(bool big, ulong value)
        { if (big) WriteUInt64B(value); else WriteUInt64L(value); }

        /// <summary>Writes a little-endian 64-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt64L(ulong value) =>
            MM_Write(8, WriteUInt64LittleEndian, MM_Span8(), value);

        /// <summary>Writes a big-endian 64-bit unsigned integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteUInt64B(ulong value) =>
            MM_Write(8, WriteUInt64BigEndian, MM_Span8(), value);

        #endregion

        #region WriteInt64

        /// <summary>Writes a 64-bit signed integer to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteInt64(bool big, long value)
        { if (big) WriteInt64B(value); else WriteInt64L(value); }

        /// <summary>Writes a little-endian 64-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt64L(long value) =>
            MM_Write(8, WriteInt64LittleEndian, MM_Span8(), value);

        /// <summary>Writes a big-endian 64-bit signed integer to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteInt64B(long value) =>
            MM_Write(8, WriteInt64BigEndian, MM_Span8(), value);

        #endregion

        #region WriteSingle

        /// <summary>Writes a single-precision floating-point to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteSingle(bool big, float value)
        { if (big) WriteSingleB(value); else WriteSingleL(value); }

        /// <summary>Writes a little-endian single-precision floating-point to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteSingleL(float value) =>
            MM_Write(4, WriteSingleLittleEndian, MM_Span4(), value);

        /// <summary>Writes a big-endian single-precision floating-point to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteSingleB(float value) =>
            MM_Write(4, WriteSingleBigEndian, MM_Span4(), value);

        #endregion

        #region WriteDouble

        /// <summary>Writes a double-precision floating-point to the stream</summary>
        /// <param name="big">Whether or not to store data in big-endian</param>
        /// <param name="value">Read value</param>
        public void WriteDouble(bool big, double value)
        { if (big) WriteDoubleB(value); else WriteDoubleL(value); }

        /// <summary>Writes a little-endian double-precision floating-point to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteDoubleL(double value) =>
            MM_Write(8, WriteDoubleLittleEndian, MM_Span8(), value);

        /// <summary>Writes a big-endian double-precision floating-point to the stream</summary>
        /// <param name="value">Read value</param>
        public void WriteDoubleB(double value) =>
            MM_Write(8, WriteDoubleBigEndian, MM_Span8(), value);

        #endregion

        #endregion
    }
}
