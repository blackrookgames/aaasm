using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using aaasm.engine.io;

namespace aaasm.engine.lxpr
{
    public partial class ExprContext
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

        private bool MM_SearchForPath(EValue input, Func<string, bool> exists, 
            [MaybeNullWhen(false)] out NormalPath path)
        {
            try
            {
                var raw = GetString(input);
                path = default;
                if (Path.IsPathFullyQualified(raw))
                {
                    var potpath = MM_Wrap(() => new NormalPath(raw));
                    if (!exists(potpath)) return false;
                    path = potpath; return true;
                }
                else
                {
                    for (int i = f_Params.SearchDirectories.Length - 1; i >= 0; --i)
                    {
                        var potpath = MM_Wrap(() => new NormalPath(raw, f_Params.SearchDirectories[i]));
                        if (!exists(potpath)) continue;
                        path = potpath; return true;
                    }
                    return false;
                }
            }
            catch when (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
        }

        #endregion

        #region GetString

        /// <summary>Obtains a C# string value from the specified expression value</summary>
        /// <param name="input">Input value</param>
        /// <returns>Objtained C# string</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Failed to obtain C# string value from <paramref name="input"/>
        /// </exception>
        public string GetString(EValue input)
        {
            try
            {
                if (f_Rules.Literals.TryString(input, out var rawpath)) return rawpath;
                throw new EValueException($"Cannot obtain string value from {input.Type.GetName()}.");
            }
            catch when (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
        }

        #endregion

        #region ParsePath

        /// <summary>Parses the expression value as a file path</summary>
        /// <param name="input">Input value</param>
        /// <param name="basePath">Base path</param>
        /// <returns>Generated file path</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     Failed to parse <paramref name="input"/> as a file path
        /// </exception>
        public NormalPath ParsePath(EValue input, NormalPath? basePath = null)
        {
            NormalPath func()
            {
                var raw = GetString(input);
                return new(raw, basePath: basePath);
            }
            try
            { return MM_Wrap(func); }
            catch when (input is null)
            { throw new ArgumentNullException(nameof(input)); }
        }

        #endregion

        #region SearchForFile, SearchForDirectory

        /// <summary>
        ///     Searches the search directories 
        ///     for a file that matches the specified input path
        /// </summary>
        /// <param name="input">Input path</param>
        /// <param name="path">Found path</param>
        /// <returns>Whether or not a path was found</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public bool SearchForFile(EValue input, [MaybeNullWhen(false)] out NormalPath path)
        {
            return MM_SearchForPath(input, File.Exists, out path);
        }

        /// <summary>
        ///     Searches the search directories 
        ///     for a directory that matches the specified input path
        /// </summary>
        /// <param name="input">Input path</param>
        /// <param name="path">Found path</param>
        /// <returns>Whether or not a path was found</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     An error occurred
        /// </exception>
        public bool SearchForDirectory(EValue input, [MaybeNullWhen(false)] out NormalPath path)
        {
            return MM_SearchForPath(input, Directory.Exists, out path);
        }

        #endregion

        #region GetFile, GetDirectory
        
        /// <summary>
        ///     Uses the search directories to retrieve 
        ///     a file that matches the specified input path; 
        ///     if no such file exists, an <see cref="EValueException"/> is thrown
        /// </summary>
        /// <param name="input">Input path</param>
        /// <returns>Found path</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     No such file exists
        ///     <br/>or<br/>
        ///     An error occurred while searching
        /// </exception>
        public NormalPath GetFile(EValue input)
        {
            if (MM_SearchForPath(input, File.Exists, out var path)) return path;
            throw new EValueException($"Could not find the file \"{GetString(input)}\".");
        }

        /// <summary>
        ///     Uses the search directories to retrieve 
        ///     a directory that matches the specified input path
        ///     if no such directory exists, an <see cref="EValueException"/> is thrown
        /// </summary>
        /// <param name="input">Input path</param>
        /// <returns>Found path</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="input"/> is null
        /// </exception>
        /// <exception cref="EValueException">
        ///     No such directory exists
        ///     <br/>or<br/>
        ///     An error occurred while searching
        /// </exception>
        public NormalPath GetDirectory(EValue input)
        {
            if (MM_SearchForPath(input, Directory.Exists, out var path)) return path;
            throw new EValueException($"Could not find the directory \"{GetString(input)}\".");
        }

        #endregion
    }
}