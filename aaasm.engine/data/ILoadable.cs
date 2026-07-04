using System;
using System.IO;

namespace aaasm.engine.data
{
    /// <summary>Represents an object with loadable data</summary>
    public interface ILoadable
    {
        #region protected methods

        /// <exception cref="ArgumentNullException">
        ///     <paramref name="resetAction"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="loadAction"/> is null
        ///     <br/>or<br/>
        ///     <paramref name="buffer"/> is null
        /// </exception>
        /// <exception cref="EndOfDataException">
        ///     Unexpected end of data
        /// </exception>
        /// <exception cref="BadDataException">
        ///     Bad data was found
        /// </exception>
        protected static void MM_Wrapper(
            Action resetAction, Action<BufferRead> loadAction, BufferRead buffer)
        {
            ArgumentNullException.ThrowIfNull(resetAction);
            ArgumentNullException.ThrowIfNull(loadAction);
            ArgumentNullException.ThrowIfNull(buffer);
            // Reset first
            resetAction();
            // Then load
            try { loadAction(buffer); }
            // If load fails, call reset again
            catch (BadDataException e) { resetAction(); throw e; } 
            catch (EndOfDataException e) { resetAction(); throw e; } 
        }

        #endregion

        #region abstract methods

        /// <summary>Loads data from a buffer</summary>
        /// <param name="buffer">Readable buffer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="buffer"/> is null
        /// </exception>
        /// <exception cref="EndOfDataException">
        ///     Unexpected end of data
        /// </exception>
        /// <exception cref="BadDataException">
        ///     Bad data was found
        /// </exception>
        public void Load(BufferRead buffer);

        #endregion

        #region methods

        /// <summary>Loads data from a stream</summary>
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
        public void Load(Stream stream)
        {
            try { var buffer = BufferRead.FromStream(stream); Load(buffer); }
            catch (ArgumentNullException e) { throw e; }
            catch (ArgumentException e) { throw e; }
            catch (ObjectDisposedException e) { throw e; }
            catch (EndOfStreamException e) { throw e; }
            catch (IOException e) { throw e; }
        }

        #endregion
    }
}
