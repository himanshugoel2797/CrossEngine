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
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public abstract class WrapperObject : IDisposable
    {
        #region Constructors

        protected WrapperObject(IntPtr handle, bool ownsHandle)
        {
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentException("handle is invalid", "handle");
            }

            this.OwnsHandle = ownsHandle;
            this.Handle = handle;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="WrapperObject"/> is reclaimed by garbage collection.
        /// </summary>
        ~WrapperObject()
        {
            this.Dispose(false);
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the handle.
        /// </summary>
        /// <value>The handle.</value>
        public IntPtr Handle
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the WrapperObject owns the handle.
        /// </summary>
        public bool OwnsHandle
        {
            get;
            private set;
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(WrapperObject left, WrapperObject right)
        {
            if (ReferenceEquals(left, null) && !ReferenceEquals(right, null))
            {
                return true;
            }

            if (ReferenceEquals(right, null) && !ReferenceEquals(left, null))
            {
                return true;
            }

            if (ReferenceEquals(right, null) && ReferenceEquals(left, null))
            {
                return false;
            }

            return !left.Equals(right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(WrapperObject left, WrapperObject right)
        {
            if (ReferenceEquals(left, null) && !ReferenceEquals(right, null))
            {
                return false;
            }

            if (ReferenceEquals(right, null) && !ReferenceEquals(left, null))
            {
                return false;
            }

            if (ReferenceEquals(right, null) && ReferenceEquals(left, null))
            {
                return true;
            }

            return left.Equals(right);
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Dispose(true);
            this.Handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public bool Equals(WrapperObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return this.Handle == obj.Handle;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return (obj is WrapperObject && this.Equals((WrapperObject)obj));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Handle.GetHashCode();
        }

        #endregion Public Methods

        #region Protected Static Methods

        protected static IEnumerable<T> Enumerate<T>(Func<T> first, Func<T, T> next)
            where T : WrapperObject
        {
            T t = first();
            while (t != null)
            {
                yield return t;
                t = next(t);
            }
        }

        #endregion Protected Static Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion Protected Methods

        #endregion Methods
    }
}