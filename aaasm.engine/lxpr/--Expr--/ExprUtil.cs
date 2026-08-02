using System;
using System.IO;
using System.Text;
using aaasm.engine.io;

namespace aaasm.engine.lxpr
{
    /// <summary>Utility for handling expression values</summary>
    public static class ExprUtil
    {
        #region helper methods

        private static void MM_Wrap(Action action)
        {
            try
            { action(); }
            catch (EValueException e)
            { throw e; }
            catch (Exception e)
            { throw new EValueException(e.Message); }
        }

        private static T MM_Wrap<T>(Func<T> func)
        {
            try
            { return func(); }
            catch (EValueException e)
            { throw e; }
            catch (Exception e)
            { throw new EValueException(e.Message); }
        }

        #endregion

        #region GetParentDir

        /// <summary>Gets the parent directory of the specified path</summary>
        /// <param name="path">Input path</param>
        /// <returns>Parent directory of <see cref="path"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static NormalPath GetParentDir(string path)
        {
            try
            {
                try
                { return MM_Wrap(() => new NormalPath(Path.GetDirectoryName(path)!)); }
                catch when (path is null)
                { throw new ArgumentNullException(nameof(path)); }
            }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
        }

        #endregion

        #region FileOpenRead, FileOpenWrite

        /// <summary>Creates a file stream for reading</summary>
        /// <param name="path">Path of input file</param>
        /// <returns>Created stream</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static Stream FileOpenRead(string path)
        {
            try
            { return MM_Wrap(() => FileUtil.OpenRead(path)); }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
        }

        /// <summary>Creates a file stream for writing</summary>
        /// <param name="path">Path of output file</param>
        /// <returns>Created stream</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static Stream FileOpenWrite(string path)
        {
            try
            { return MM_Wrap(() => FileUtil.OpenWrite(path)); }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
        }

        #endregion

        #region ReadAllText, WriteAllText

        /// <summary>Reads all text from the specified stream</summary>
        /// <param name="stream">Stream to read from</param>
        /// <returns>Text</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support reading
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static string ReadAllText(Stream stream) =>
            MM_Wrap(() => StreamUtil.ReadAllText(stream));

        /// <summary>Reads all text from the specified stream</summary>
        /// <param name="stream">Stream to read from</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Text</returns>
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
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static string ReadAllText(Stream stream, Encoding encoding) =>
            MM_Wrap(() => StreamUtil.ReadAllText(stream, encoding));

        /// <summary>Reads all text from a file</summary>
        /// <param name="path">Path of file to read from</param>
        /// <returns>Text</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static string ReadAllText(string path)
        {
            try
            {
                using var f = ExprUtil.FileOpenRead(path);
                return ReadAllText(f);
            }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
        }

        /// <summary>Reads all text from a file</summary>
        /// <param name="path">Path of file to read from</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Text</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="encoding"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static string ReadAllText(string path, Encoding encoding)
        {
            try
            {
                using var f = ExprUtil.FileOpenRead(path);
                return ReadAllText(f, encoding);
            }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
            catch when (encoding is null)
            { throw new ArgumentNullException(nameof(encoding)); }
        }

        /// <summary>Writes all text to the specified stream</summary>
        /// <param name="stream">Stream to write to</param>
        /// <param name="text">Source data</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support writing
        ///     <br/>or<br/>
        ///     <paramref name="stream"/> does not support seeking
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static void WriteAllText(Stream stream, string? text) =>
            MM_Wrap(() => StreamUtil.WriteAllText(stream, text));

        /// <summary>Writes all text to the specified stream</summary>
        /// <param name="stream">Stream to write to</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="text">Source data</param>
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
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static void WriteAllText(Stream stream, Encoding encoding, string? text) =>
            MM_Wrap(() => StreamUtil.WriteAllText(stream, encoding, text));

        /// <summary>Writes all text to a file</summary>
        /// <param name="path">Path of file to write to</param>
        /// <param name="text">Source data</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static void WriteAllText(string path, string? text)
        {
            try
            {
                using var f = ExprUtil.FileOpenWrite(path);
                WriteAllText(f, text);
            }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
        }

        /// <summary>Writes all text to a file</summary>
        /// <param name="path">Path of file to write to</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="text">Source data</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="encoding"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public static void WriteAllText(string path, Encoding encoding, string? text)
        {
            try
            {
                using var f = ExprUtil.FileOpenWrite(path);
                WriteAllText(f, encoding, text);
            }
            catch when (path is null)
            { throw new ArgumentNullException(nameof(path)); }
            catch when (encoding is null)
            { throw new ArgumentNullException(nameof(encoding)); }
        }

        #endregion
    }
}
