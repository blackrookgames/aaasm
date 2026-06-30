using System;
using static System.Buffers.Binary.BinaryPrimitives;
using System.IO;

namespace aaasm.engine.data
{
    public partial class BufferRead
    {
        #region nested

        private delegate T ReadFunc<T>(ReadOnlySpan<byte> span);

        #endregion

        #region helper methods

        private bool MM_TryRead<T>(int size, ReadFunc<T> binRead, out T result)
        {
            int end = f_Position + size;
            if (end <= f_Data.Length)
            {
                result = binRead(new(f_Data, f_Position, size));
                MM_SetPosition(end);
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        #endregion

        #region TryRead

        #region TryRead

        /// <summary>Attempts to read from the stream</summary>
        /// <param name="output">Output array</param>
        /// <returns>Whether or not successful</returns>
        /// <exception cref="ArgumentNullException"><paramref name="output"/> is null</exception>
        public bool TryRead(byte[] output)
        {
            ArgumentNullException.ThrowIfNull(output);
            var end = f_Position + output.Length;
            if (end > f_Data.Length) return false;
            Array.Copy(f_Data, f_Position, output, 0, output.Length);
            MM_SetPosition(end);
            return true;
        }

        #endregion

        #region TryReadUInt8

        /// <summary>Attempts to read an 8-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt8(out byte result)
        {
            if (!f_End)
            {
                result = f_Data[f_Position];
                MM_SetPosition(f_Position + 1);
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        #endregion

        #region TryReadInt8

        /// <summary>Attempts to read an 8-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt8(out sbyte result)
        {
            if (!f_End)
            {
                result = (sbyte)f_Data[f_Position];
                MM_SetPosition(f_Position + 1);
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        #endregion

        #region TryReadUInt16

        /// <summary>Attempts to read a 16-bit unsigned integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt16(bool big, out ushort result) =>
            big ? TryReadUInt16B(out result) : TryReadUInt16L(out result);

        /// <summary>Attempts to read a little-endian 16-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt16L(out ushort result) =>
            MM_TryRead(2, ReadUInt16LittleEndian, out result);

        /// <summary>Attempts to read a big-endian 16-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt16B(out ushort result) =>
            MM_TryRead(2, ReadUInt16BigEndian, out result);

        #endregion

        #region TryReadInt16

        /// <summary>Attempts to read a 16-bit signed integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt16(bool big, out short result) =>
            big ? TryReadInt16B(out result) : TryReadInt16L(out result);

        /// <summary>Attempts to read a little-endian 16-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt16L(out short result) =>
            MM_TryRead(2, ReadInt16LittleEndian, out result);

        /// <summary>Attempts to read a big-endian 16-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt16B(out short result) =>
            MM_TryRead(2, ReadInt16BigEndian, out result);

        #endregion

        #region TryReadUInt32

        /// <summary>Attempts to read a 32-bit unsigned integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt32(bool big, out uint result) =>
            big ? TryReadUInt32B(out result) : TryReadUInt32L(out result);

        /// <summary>Attempts to read a little-endian 32-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt32L(out uint result) =>
            MM_TryRead(4, ReadUInt32LittleEndian, out result);

        /// <summary>Attempts to read a big-endian 32-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt32B(out uint result) =>
            MM_TryRead(4, ReadUInt32BigEndian, out result);

        #endregion

        #region TryReadInt32

        /// <summary>Attempts to read a 32-bit signed integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt32(bool big, out int result) =>
            big ? TryReadInt32B(out result) : TryReadInt32L(out result);

        /// <summary>Attempts to read a little-endian 32-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt32L(out int result) =>
            MM_TryRead(4, ReadInt32LittleEndian, out result);

        /// <summary>Attempts to read a big-endian 32-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt32B(out int result) =>
            MM_TryRead(4, ReadInt32BigEndian, out result);

        #endregion

        #region TryReadUInt64

        /// <summary>Attempts to read a 64-bit unsigned integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt64(bool big, out ulong result) =>
            big ? TryReadUInt64B(out result) : TryReadUInt64L(out result);

        /// <summary>Attempts to read a little-endian 64-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt64L(out ulong result) =>
            MM_TryRead(8, ReadUInt64LittleEndian, out result);

        /// <summary>Attempts to read a big-endian 64-bit unsigned integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadUInt64B(out ulong result) =>
            MM_TryRead(8, ReadUInt64BigEndian, out result);

        #endregion

        #region TryReadInt64

        /// <summary>Attempts to read a 64-bit signed integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt64(bool big, out long result) =>
            big ? TryReadInt64B(out result) : TryReadInt64L(out result);

        /// <summary>Attempts to read a little-endian 64-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt64L(out long result) =>
            MM_TryRead(8, ReadInt64LittleEndian, out result);

        /// <summary>Attempts to read a big-endian 64-bit signed integer from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadInt64B(out long result) =>
            MM_TryRead(8, ReadInt64BigEndian, out result);

        #endregion

        #region TryReadSingle

        /// <summary>Attempts to read a single-precision floating-point from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadSingle(bool big, out float result) =>
            big ? TryReadSingleB(out result) : TryReadSingleL(out result);

        /// <summary>Attempts to read a little-endian single-precision floating-point from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadSingleL(out float result) =>
            MM_TryRead(4, ReadSingleLittleEndian, out result);

        /// <summary>Attempts to read a big-endian single-precision floating-point from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadSingleB(out float result) =>
            MM_TryRead(4, ReadSingleBigEndian, out result);

        #endregion

        #region TryReadDouble

        /// <summary>Attempts to read a double-precision floating-point from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadDouble(bool big, out double result) =>
            big ? TryReadDoubleB(out result) : TryReadDoubleL(out result);

        /// <summary>Attempts to read a little-endian double-precision floating-point from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadDoubleL(out double result) =>
            MM_TryRead(8, ReadDoubleLittleEndian, out result);

        /// <summary>Attempts to read a big-endian double-precision floating-point from the stream</summary>
        /// <param name="result">Read value</param>
        /// <returns>Whether or not successful</returns>
        public bool TryReadDoubleB(out double result) =>
            MM_TryRead(8, ReadDoubleBigEndian, out result);

        #endregion

        #endregion

        #region DefRead

        #region DefReadUInt8

        /// <summary>
        ///     Attempts to read an 8-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public byte DefReadUInt8(byte def = 0)
        { if (TryReadUInt8(out var result)) return result; else return def; }

        #endregion

        #region DefReadInt8

        /// <summary>
        ///     Attempts to read an 8-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public sbyte DefReadInt8(sbyte def = 0)
        { if (TryReadInt8(out var result)) return result; else return def; }

        #endregion

        #region DefReadUInt16

        /// <summary>
        ///     Attempts to read a 16-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public ushort DefReadUInt16(bool big, ushort def = 0) =>
            big ? DefReadUInt16B(def) : DefReadUInt16L(def);

        /// <summary>
        ///     Attempts to read a little-endian 16-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public ushort DefReadUInt16L(ushort def = 0)
        { if (TryReadUInt16L(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian 16-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public ushort DefReadUInt16B(ushort def = 0)
        { if (TryReadUInt16B(out var result)) return result; else return def; }

        #endregion

        #region DefReadInt16

        /// <summary>
        ///     Attempts to read a 16-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public short DefReadInt16(bool big, short def = 0) =>
            big ? DefReadInt16B(def) : DefReadInt16L(def);

        /// <summary>
        ///     Attempts to read a little-endian 16-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public short DefReadInt16L(short def = 0)
        { if (TryReadInt16L(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian 16-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public short DefReadInt16B(short def = 0)
        { if (TryReadInt16B(out var result)) return result; else return def; }

        #endregion

        #region DefReadUInt32

        /// <summary>
        ///     Attempts to read a 32-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public uint DefReadUInt32(bool big, uint def = 0) =>
            big ? DefReadUInt32B(def) : DefReadUInt32L(def);

        /// <summary>
        ///     Attempts to read a little-endian 32-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public uint DefReadUInt32L(uint def = 0)
        { if (TryReadUInt32L(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian 32-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public uint DefReadUInt32B(uint def = 0)
        { if (TryReadUInt32B(out var result)) return result; else return def; }

        #endregion

        #region DefReadInt32

        /// <summary>
        ///     Attempts to read a 32-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public int DefReadInt32(bool big, int def = 0) =>
            big ? DefReadInt32B(def) : DefReadInt32L(def);

        /// <summary>
        ///     Attempts to read a little-endian 32-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public int DefReadInt32L(int def = 0)
        { if (TryReadInt32L(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian 32-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public int DefReadInt32B(int def = 0)
        { if (TryReadInt32B(out var result)) return result; else return def; }

        #endregion

        #region DefReadUInt64

        /// <summary>
        ///     Attempts to read a 64-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public ulong DefReadUInt64(bool big, ulong def = 0) =>
            big ? DefReadUInt64B(def) : DefReadUInt64L(def);

        /// <summary>
        ///     Attempts to read a little-endian 64-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public ulong DefReadUInt64L(ulong def = 0)
        { if (TryReadUInt64L(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian 64-bit unsigned integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public ulong DefReadUInt64B(ulong def = 0)
        { if (TryReadUInt64B(out var result)) return result; else return def; }

        #endregion

        #region DefReadInt64

        /// <summary>
        ///     Attempts to read a 64-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public long DefReadInt64(bool big, long def = 0) =>
            big ? DefReadInt64B(def) : DefReadInt64L(def);

        /// <summary>
        ///     Attempts to read a little-endian 64-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public long DefReadInt64L(long def = 0)
        { if (TryReadInt64L(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian 64-bit signed integer from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public long DefReadInt64B(long def = 0)
        { if (TryReadInt64B(out var result)) return result; else return def; }

        #endregion

        #region DefReadSingle

        /// <summary>
        ///     Attempts to read a single-precision floating-point from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public float DefReadSingle(bool big, float def = 0) =>
            big ? DefReadSingleB(def) : DefReadSingleL(def);

        /// <summary>
        ///     Attempts to read a little-endian single-precision floating-point from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public float DefReadSingleL(float def = 0)
        { if (TryReadSingleL(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian single-precision floating-point from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public float DefReadSingleB(float def = 0)
        { if (TryReadSingleB(out var result)) return result; else return def; }

        #endregion

        #region DefReadDouble

        /// <summary>
        ///     Attempts to read a double-precision floating-point from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public double DefReadDouble(bool big, double def = 0) =>
            big ? DefReadDoubleB(def) : DefReadDoubleL(def);

        /// <summary>
        ///     Attempts to read a little-endian double-precision floating-point from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public double DefReadDoubleL(double def = 0)
        { if (TryReadDoubleL(out var result)) return result; else return def; }

        /// <summary>
        ///     Attempts to read a big-endian double-precision floating-point from the stream.
        ///     If read fails, a default value is returned.
        /// </summary>
        /// <param name="def">Value to return if read fails</param>
        /// <returns>Read value (or <paramref name="def"/> if read fails)</returns>
        public double DefReadDoubleB(double def = 0)
        { if (TryReadDoubleB(out var result)) return result; else return def; }

        #endregion

        #endregion

        #region Read

        #region Read

        /// <summary>Reads from the stream</summary>
        /// <param name="buffer">Output buffer</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null</exception>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public void Read(byte[] buffer)
        {
            if (TryRead(buffer)) return;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadUInt8

        /// <summary>Reads an 8-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public byte ReadUInt8()
        {
            if (TryReadUInt8(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadInt8

        /// <summary>Reads an 8-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public sbyte ReadInt8()
        {
            if (TryReadInt8(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadUInt16

        /// <summary>Reads a 16-bit unsigned integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public ushort ReadUInt16(bool big) =>
            big ? ReadUInt16B() : ReadUInt16L();

        /// <summary>Reads a little-endian 16-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public ushort ReadUInt16L()
        {
            if (TryReadUInt16L(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian 16-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public ushort ReadUInt16B()
        {
            if (TryReadUInt16B(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadInt16

        /// <summary>Reads a 16-bit signed integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public short ReadInt16(bool big) =>
            big ? ReadInt16B() : ReadInt16L();

        /// <summary>Reads a little-endian 16-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public short ReadInt16L()
        {
            if (TryReadInt16L(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian 16-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public short ReadInt16B()
        {
            if (TryReadInt16B(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadUInt32

        /// <summary>Reads a 32-bit unsigned integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public uint ReadUInt32(bool big) =>
            big ? ReadUInt32B() : ReadUInt32L();

        /// <summary>Reads a little-endian 32-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public uint ReadUInt32L()
        {
            if (TryReadUInt32L(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian 32-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public uint ReadUInt32B()
        {
            if (TryReadUInt32B(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadInt32

        /// <summary>Reads a 32-bit signed integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public int ReadInt32(bool big) =>
            big ? ReadInt32B() : ReadInt32L();

        /// <summary>Reads a little-endian 32-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public int ReadInt32L()
        {
            if (TryReadInt32L(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian 32-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public int ReadInt32B()
        {
            if (TryReadInt32B(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadUInt64

        /// <summary>Reads a 64-bit unsigned integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public ulong ReadUInt64(bool big) =>
            big ? ReadUInt64B() : ReadUInt64L();

        /// <summary>Reads a little-endian 64-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public ulong ReadUInt64L()
        {
            if (TryReadUInt64L(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian 64-bit unsigned integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public ulong ReadUInt64B()
        {
            if (TryReadUInt64B(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadInt64

        /// <summary>Reads a 64-bit signed integer from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public long ReadInt64(bool big) =>
            big ? ReadInt64B() : ReadInt64L();

        /// <summary>Reads a little-endian 64-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public long ReadInt64L()
        {
            if (TryReadInt64L(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian 64-bit signed integer from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public long ReadInt64B()
        {
            if (TryReadInt64B(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadSingle

        /// <summary>Reads a single-precision floating-point from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public float ReadSingle(bool big) =>
            big ? ReadSingleB() : ReadSingleL();

        /// <summary>Reads a little-endian single-precision floating-point from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public float ReadSingleL()
        {
            if (TryReadSingleL(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian single-precision floating-point from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public float ReadSingleB()
        {
            if (TryReadSingleB(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #region ReadDouble

        /// <summary>Reads a double-precision floating-point from the stream</summary>
        /// <param name="big">Whether or not data is stored in big-endian</param>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public double ReadDouble(bool big) =>
            big ? ReadDoubleB() : ReadDoubleL();

        /// <summary>Reads a little-endian double-precision floating-point from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public double ReadDoubleL()
        {
            if (TryReadDoubleL(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        /// <summary>Reads a big-endian double-precision floating-point from the stream</summary>
        /// <returns>Read value</returns>
        /// <exception cref="EndOfDataException">Unexpected end of data</exception>
        public double ReadDoubleB()
        {
            if (TryReadDoubleB(out var result)) return result;
            throw new EndOfStreamException("Unexpected end of stream.");
        }

        #endregion

        #endregion
    }
}
