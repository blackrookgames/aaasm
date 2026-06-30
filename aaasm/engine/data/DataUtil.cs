using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using aaasm.engine.io;

namespace aaasm.engine.data
{
    /// <summary>Data utility</summary>
    public static class DataUtil
    {
        #region ReadSource

        /// <summary>Reads source data</summary>
        /// <param name="stream">Stream read from</param>
        /// <param name="srcpath">Path of original source file</param>
        /// <returns>Lines of source data</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support reading
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static SrcStr[] ReadSource(Stream stream, NormalPath srcpath)
        {
            StreamUtil.ThrowIfCantRead(stream);
            StreamUtil.ThrowIfCantSeek(stream);
            var rawLines = StreamUtil.ReadAllLines(stream);
            var lines = new SrcStr[rawLines.Length];
            for (int y = 0; y < rawLines.Length; ++y)
            {
                var rawLine = rawLines[y];
                var lineChars = new SrcStrChar[rawLine.Length];
                for (int x = 0; x < lineChars.Length; ++x)
                    lineChars[x] = new(rawLine[x], new (srcpath, y + 1, x + 1));
                lines[y] = new (lineChars);
            }
            return lines;
        }
        
        /// <summary>Reads source data</summary>
        /// <param name="stream">Stream read from</param>
        /// <returns>Lines of source data</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support reading
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static SrcStr[] ReadSource(Stream stream)
        {
            StreamUtil.ThrowIfCantRead(stream);
            // Determine source path
            NormalPath srcpath = null;
            if (stream is FileStream fileStream)
                srcpath = new(fileStream.Name);
            // Read source
            return ReadSource(stream, srcpath);
        }
        
        #endregion
    }
}