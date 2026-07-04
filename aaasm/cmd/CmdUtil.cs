using System;
using System.IO;
using cmdaxe;
using aaasm.engine.io;

namespace aaasm.cmd
{
    /// <summary>Command utility</summary>
    public static class CmdUtil
    {
        #region NormalizePath

        /// <summary>Creates a normalized version of the specified path</summary>
        /// <param name="path">Path to normalize</param>
        /// <param name="basePath">Base path</param>
        /// <returns>Normalized path</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="CommandException">
        ///     An error occurred
        /// </exception>
        public static NormalPath NormalizePath(string path, NormalPath? basePath = null)
        {
            ArgumentNullException.ThrowIfNull(path);
            try
            { return new(path, basePath); }
            catch (Exception e)
            { throw new CommandException(e.Message); }
        }

        #endregion

        #region FileOpenRead, FileOpenWrite

        /// <summary>Creates a file stream for reading</summary>
        /// <param name="path">Path of input file</param>
        /// <returns>Created stream</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="CommandException">
        ///     An error occurred
        /// </exception>
        public static Stream FileOpenRead(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            try { return FileUtil.OpenRead(path); }
            catch (Exception e) { throw new CommandException(e.Message); }
        }

        /// <summary>Creates a file stream for writing</summary>
        /// <param name="path">Path of output file</param>
        /// <returns>Created stream</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null
        /// </exception>
        /// <exception cref="CommandException">
        ///     An error occurred
        /// </exception>
        public static Stream FileOpenWrite(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            try { return FileUtil.OpenWrite(path); }
            catch (Exception e) { throw new CommandException(e.Message); }
        }

        #endregion
    }
}