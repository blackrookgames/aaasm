using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace aaasm.engine.io
{
    /// <summary>Utility for I/O related operations</summary>
    public static class StreamUtil
    {
        #region ThrowIf

        /// <summary>Throws an exception if the specified stream does not support reading</summary>
        /// <param name="argument">Stream argument</param>
        /// <param name="paramName">Parameter name</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="argument"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="argument"/> does not support reading
        /// </exception>
        public static void ThrowIfCantRead(
            Stream argument, 
            [CallerArgumentExpression(nameof(argument))] string paramName = null)
        {
            try { if (argument.CanRead) return; }
            catch when (argument is null) { throw new ArgumentNullException(paramName); }
            throw new ArgumentException("Stream does not support reading.", paramName);
        }

        /// <summary>Throws an exception if the specified stream does not support writing</summary>
        /// <param name="argument">Stream argument</param>
        /// <param name="paramName">Parameter name</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="argument"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="argument"/> does not support writing
        /// </exception>
        public static void ThrowIfCantWrite(
            Stream argument, 
            [CallerArgumentExpression(nameof(argument))] string paramName = null)
        {
            try { if (argument.CanWrite) return; }
            catch when (argument is null) { throw new ArgumentNullException(paramName); }
            throw new ArgumentException("Stream does not support writing.", paramName);
        }

        /// <summary>Throws an exception if the specified stream does not support seeking</summary>
        /// <param name="argument">Stream argument</param>
        /// <param name="paramName">Parameter name</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="argument"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="argument"/> does not support seeking
        /// </exception>
        public static void ThrowIfCantSeek(
            Stream argument, 
            [CallerArgumentExpression(nameof(argument))] string paramName = null)
        {
            try { if (argument.CanSeek) return; }
            catch when (argument is null) { throw new ArgumentNullException(paramName); }
            throw new ArgumentException("Stream does not support seeking.", paramName);
        }

        #endregion

        #region ReadAllLines/WriteAllLines

        private static string[] MM_ReadAllLines(Stream stream,
            bool defEncoding, Encoding encoding)
        {
            IEnumerable<string> read()
            {
                stream.Position = 0;
                using var r = defEncoding ?
                    new StreamReader(stream, encoding) :
                    new StreamReader(stream);
                while (!r.EndOfStream) yield return new (r.ReadLine());
            }
            ThrowIfCantRead(stream);
            ThrowIfCantSeek(stream);
            if (defEncoding) ArgumentNullException.ThrowIfNull(encoding);
            try { return [..read()]; }
            catch (OutOfMemoryException e) { throw e; }
            catch (IOException e) { throw e; }
        }

        private static void MM_WriteAllLines(Stream stream, IEnumerable<string> lines,
            bool defEncoding, Encoding encoding)
        {
            ThrowIfCantWrite(stream);
            ThrowIfCantSeek(stream);
            if (defEncoding) ArgumentNullException.ThrowIfNull(encoding);
            try
            {
                stream.Position = 0;
                using var w = defEncoding ? 
                    new StreamWriter(stream, encoding) : 
                    new StreamWriter(stream);
                if (lines is not null)
                {
                    foreach (var line in lines)
                        w.WriteLine(line);
                }
            }
            catch (IOException e) { throw e; }
        }

        /// <summary>Reads all lines from the specified stream</summary>
        /// <param name="stream">Stream read from</param>
        /// <returns>Lines of source data</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support reading
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     Insufficient memory
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static string[] ReadAllLines(Stream stream) =>
            MM_ReadAllLines(stream, false, null);

        /// <summary>Reads all lines from the specified stream</summary>
        /// <param name="stream">Stream read from</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Lines of source data</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="encoding"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support reading
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     Insufficient memory
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static string[] ReadAllLines(Stream stream, Encoding encoding) =>
            MM_ReadAllLines(stream, true, encoding);

        /// <summary>Writes all lines to the specified stream</summary>
        /// <param name="stream">Stream write to</param>
        /// <param name="lines">Lines of source data</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support writing
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static void WriteAllLines(Stream stream, IEnumerable<string> lines) =>
            MM_WriteAllLines(stream, lines, false, null);

        /// <summary>Writes all lines to the specified stream</summary>
        /// <param name="stream">Stream write to</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="lines">Lines of source data</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="encoding"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support writing
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static void WriteAllLines(Stream stream, Encoding encoding, IEnumerable<string> lines) =>
            MM_WriteAllLines(stream, lines, true, encoding);

        #endregion
    }
}