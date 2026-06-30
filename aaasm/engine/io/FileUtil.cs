using System;
using System.IO;

namespace aaasm.engine.io
{
    public static class FileUtil
    {
        #region OpenRead/OpenWrite

        /// <summary>Opens a file for reading</summary>
        /// <param name="path">Path to file</param>
        /// <returns>Created stream</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     .NET Framework and .NET Core versions older than 2.1: 
        ///     <paramref name="path"/> is a zero-length string, contains only white space, or contains one or more invalid characters. 
        ///     You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined maximum length.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The specified path is invalid, (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        ///     <paramref name="path"/> specified a directory.
        ///     <br/>or<br/>
        ///     The caller does not have the required permission.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     The file specified in <paramref name="path"/> was not found.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="path"/> is in an invalid format.
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static FileStream OpenRead(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            return new FileStream(path, 
                FileMode.Open, 
                FileAccess.Read, 
                FileShare.None);
        }

        /// <summary>Opens a file for writing</summary>
        /// <param name="path">Path to file</param>
        /// <returns>Created stream</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     .NET Framework and .NET Core versions older than 2.1: 
        ///     <paramref name="path"/> is a zero-length string, contains only white space, or contains one or more invalid characters. 
        ///     You can query for invalid characters by using the GetInvalidPathChars() method.
        /// </exception>
        /// <exception cref="PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined maximum length.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The specified path is invalid, (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        ///     The caller does not have the required permission.
        ///     <br/>or<br/>
        ///     <paramref name="path"/> specified a read-only file or directory..
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="path"/> is in an invalid format.
        /// </exception>
        /// <exception cref="IOException">
        ///     An I/O error occurred.
        /// </exception>
        public static FileStream OpenWrite(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            return new FileStream(path,
                File.Exists(path) ? FileMode.Truncate : FileMode.Create,
                FileAccess.Write,
                FileShare.None);
        }
    
        #endregion
    }
}