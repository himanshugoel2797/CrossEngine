/*
 CgNet v1.0
 Copyright (c) 2010 - 2013 Tobias Bohnen

 Permission is hereby granted, free of charge, to any person obtaining a copy of this
 software and associated documentation files (the "Software"), to deal in the Software
 without restriction, including without limitation the rights to use, copy, modify, merge,
 publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 to whom the Software is furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all copies or
 substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 DEALINGS IN THE SOFTWARE.
 */
namespace CgNet
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Buffer : WrapperObject
    {
        #region Constructors

        public Buffer(IntPtr handle, bool ownsHandle)
            : base(handle, ownsHandle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public bool IsBuffer
        {
            get
            {
                return NativeMethods.cgIsBuffer(this.Handle);
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public int Size
        {
            get
            {
                return NativeMethods.cgGetBufferSize(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Create a buffer object managed by the runtime.
        /// </summary>
        /// <param name="context">The context to which the new buffer will be added.</param>
        /// <param name="size">The length in bytes of the buffer to create.</param>
        /// <param name="data">Pointer to inital buffer data. NULL will fill the buffer with zero.</param>
        /// <param name="bufferUsage">Indicates the intended usage method of the buffer.</param>
        /// <returns>Returns a Buffer on success.</returns>
        public static Buffer Create(Context context, int size, IntPtr data, BufferUsage bufferUsage)
        {
            return new Buffer(NativeMethods.cgCreateBuffer(context.Handle, size, data, bufferUsage), true);
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Map buffer into application's address space.
        /// </summary>
        /// <param name="access">An enumerant indicating the operations the client may perform on the data store through the pointer while the buffer data is mapped.</param>
        /// <returns>Returns a pointer through which the application can read or write the buffer's data store.</returns>
        public IntPtr Map(BufferAccess access)
        {
            return NativeMethods.cgMapBuffer(this.Handle, access);
        }

        /// <summary>
        /// Resize and completely update a buffer object.
        /// </summary>
        /// <param name="size">Specifies a new size for the buffer object. Zero for size means use the existing size of the buffer as the effective size.</param>
        /// <param name="data">Pointer to the data to copy into the buffer. The number of bytes to copy is determined by the size parameter.</param>
        public void SetData(int size, IntPtr data)
        {
            NativeMethods.cgSetBufferData(this.Handle, size, data);
        }

        /// <summary>
        /// Partially update a Cg buffer object.
        /// </summary>
        /// <param name="offset">Buffer offset in bytes of the beginning of the partial update.</param>
        /// <param name="size">Number of buffer bytes to be updated. Zero means no update.</param>
        /// <param name="data">Pointer to the start of the data being copied into the buffer.</param>
        public void SetSubData(int offset, int size, IntPtr data)
        {
            NativeMethods.cgSetBufferSubData(this.Handle, offset, size, data);
        }

        /// <summary>
        /// Unmap buffer from application's address space.
        /// </summary>
        public void Unmap()
        {
            NativeMethods.cgUnmapBuffer(this.Handle);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.OwnsHandle && this.Handle != IntPtr.Zero)
            {
                NativeMethods.cgDestroyBuffer(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}