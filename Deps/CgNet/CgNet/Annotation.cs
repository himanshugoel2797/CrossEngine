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
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Annotation : WrapperObject
    {
        #region Constructors

        public Annotation(IntPtr handle, bool ownsHandle)
            : base(handle, ownsHandle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        /// <summary>
        /// Gets the number of effect parameters on which an annotation depends.
        /// </summary>
        public int DependentParametersCount
        {
            get
            {
                return NativeMethods.cgGetNumDependentAnnotationParameters(this.Handle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is a valid annotation.
        /// </summary>
        public bool IsAnnotation
        {
            get
            {
                return NativeMethods.cgIsAnnotation(this.Handle);
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetAnnotationName(this.Handle));
            }
        }

        /// <summary>
        /// Gets the next annotation.
        /// </summary>
        public Annotation NextAnnotation
        {
            get
            {
                var ptr = NativeMethods.cgGetNextAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public ParameterType Type
        {
            get
            {
                return NativeMethods.cgGetAnnotationType(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the values from a boolean-valued annotation.
        /// </summary>
        /// <returns>Returns an array of bool values.</returns>
        public bool[] GetBoolValues()
        {
            int count;
            var values = NativeMethods.cgGetBoolAnnotationValues(this.Handle, out count);
            return Utils.IntPtrToBoolArray(values, count);
        }

        /// <summary>
        /// Get one of the parameters that an annotation's value depends on.
        /// </summary>
        /// <param name="index">The index of the parameter to return.</param>
        /// <returns>Returns the selected dependent annotation on success.</returns>
        public Parameter GetDependentParameter(int index)
        {
            var ptr = NativeMethods.cgGetDependentAnnotationParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        /// <summary>
        /// Get the values from a float-valued annotation.
        /// </summary>
        /// <returns>Returns an array of float values.</returns>
        public float[] GetFloatValues()
        {
            int nvalues;
            return NativeMethods.cgGetFloatAnnotationValues(this.Handle, out nvalues);
        }

        /// <summary>
        /// Get the values from a integer-valued annotation.
        /// </summary>
        /// <returns>Returns an array of integer values.</returns>
        public int[] GetIntValues()
        {
            int nvalues;
            return NativeMethods.cgGetIntAnnotationValues(this.Handle, out nvalues);
        }

        /// <summary>
        /// Get a string-valued annotation's value.
        /// </summary>
        /// <returns>Returns a string contained by the annotation. </returns>
        public string GetStringValue()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetStringAnnotationValue(this.Handle));
        }

        /// <summary>
        /// Get the values from a string-valued annotation.
        /// </summary>
        /// <returns>Returns an array of string values.</returns>
        public string[] GetStringValues()
        {
            int nvalues;
            var ptr = NativeMethods.cgGetStringAnnotationValues(this.Handle, out nvalues);
            if (nvalues == 0)
            {
                return null;
            }

            unsafe
            {
                var byteArray = (byte**)ptr;
                var lines = new List<string>();
                var buffer = new List<byte>();

                for (int i = 0; i < nvalues; i++)
                {
                    byte* b = *byteArray;
                    for (;;)
                    {
                        if (*b == '\0')
                        {
                            char[] cc = Encoding.ASCII.GetChars(buffer.ToArray());
                            lines.Add(new string(cc));
                            buffer.Clear();
                            break;
                        }

                        buffer.Add(*b);
                        b++;
                    }

                    byteArray++;
                }

                return lines.ToArray();
            }
        }

        /// <summary>
        /// Set the value of an annotation.
        /// </summary>
        /// <param name="value">The value to which the annotation will be set.</param>
        /// <returns>Returns <c>true</c> if it succeeds in setting the annotation; <c>false</c> otherwise.</returns>
        public bool Set(int value)
        {
            return NativeMethods.cgSetIntAnnotation(this.Handle, value);
        }

        /// <summary>
        /// Set the value of an annotation.
        /// </summary>
        /// <param name="value">The value to which the annotation will be set.</param>
        /// <returns>Returns <c>true</c> if it succeeds in setting the annotation; <c>false</c> otherwise.</returns>
        public bool Set(float value)
        {
            return NativeMethods.cgSetFloatAnnotation(this.Handle, value);
        }

        /// <summary>
        /// Set the value of an annotation.
        /// </summary>
        /// <param name="value">The value to which the annotation will be set.</param>
        /// <returns>Returns <c>true</c> if it succeeds in setting the annotation; <c>false</c> otherwise.</returns>
        public bool Set(string value)
        {
            return NativeMethods.cgSetStringAnnotation(this.Handle, value);
        }

        /// <summary>
        /// Set the value of an annotation.
        /// </summary>
        /// <param name="value">The value to which the annotation will be set.</param>
        /// <returns>Returns <c>true</c> if it succeeds in setting the annotation; <c>false</c> otherwise.</returns>
        public bool Set(bool value)
        {
            return NativeMethods.cgSetBoolAnnotation(this.Handle, value);
        }

        #endregion Public Methods

        #endregion Methods
    }
}