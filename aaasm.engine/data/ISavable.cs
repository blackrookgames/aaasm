using System;
using System.IO;
using System.Threading.Tasks;

namespace aaasm.engine.data
{
    /// <summary>Represents an object with savable data</summary>
    public interface ISavable
    {
        #region abstract methods

        /// <summary>Saves data to a buffer</summary>
        /// <param name="buffer">Writable buffer</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="buffer"/> is null
        /// </exception>
        public void Save(BufferWrite buffer);

        #endregion

        #region methods

        /// <summary>Saves data to a stream</summary>
        /// <param name="stream">Stream to write to</param>
        /// <returns>Created <see cref="BufferWrite"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="stream"/> does not support writing
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
        public void Save(Stream stream)
        {
            try { var buffer = new BufferWrite(); Save(buffer); buffer.ToStream(stream); }
            catch (ArgumentNullException e) { throw e; }
            catch (ArgumentException e) { throw e; }
            catch (ObjectDisposedException e) { throw e; }
            catch (EndOfStreamException e) { throw e; }
            catch (IOException e) { throw e; }
        }

        #endregion
    }
}
