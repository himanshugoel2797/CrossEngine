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

    public sealed class Pass : WrapperObject
    {
        #region Constructors

        public Pass(IntPtr handle, bool ownsHandle)
            : base(handle, ownsHandle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public IEnumerable<Annotation> Annotations
        {
            get
            {
                return Enumerate(() => this.FirstAnnotation, t => t.NextAnnotation);
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstPassAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
            }
        }

        public StateAssignment FirstStateAssignment
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new StateAssignment(ptr, false);
            }
        }

        public bool IsPass
        {
            get
            {
                return NativeMethods.cgIsPass(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetPassName(this.Handle));
            }
        }

        public Pass NextPass
        {
            get
            {
                var ptr = NativeMethods.cgGetNextPass(this.Handle);

                return ptr == IntPtr.Zero ? null : new Pass(ptr, false);
            }
        }

        public Technique Technique
        {
            get
            {
                var ptr = NativeMethods.cgGetPassTechnique(this.Handle);

                return ptr == IntPtr.Zero ? null : new Technique(ptr, false);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static Pass Create(Technique technique, string name)
        {
            return technique.CreatePass(name);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = NativeMethods.cgCreatePassAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, true);
        }

        public StateAssignment CreateSamplerStateAssignment(State state)
        {
            var ptr = NativeMethods.cgCreateSamplerStateAssignment(this.Handle, state.Handle);
            return ptr == IntPtr.Zero ? null : new StateAssignment(ptr, true);
        }

        public StateAssignment CreateStateAssignment(State state)
        {
            var ptr = NativeMethods.cgCreateStateAssignment(this.Handle, state.Handle);
            return ptr == IntPtr.Zero ? null : new StateAssignment(ptr, true);
        }

        public StateAssignment CreateStateAssignmentIndex(State state, int index)
        {
            var ptr = NativeMethods.cgCreateStateAssignmentIndex(this.Handle, state.Handle, index);
            return ptr == IntPtr.Zero ? null : new StateAssignment(ptr, true);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = NativeMethods.cgGetNamedPassAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
        }

        public StateAssignment GetNamedStateAssignment(string name)
        {
            var ptr = NativeMethods.cgGetNamedStateAssignment(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new StateAssignment(ptr, false);
        }

        public Program GetProgram(Domain domain)
        {
            var ptr = NativeMethods.cgGetPassProgram(this.Handle, domain);
            return ptr == IntPtr.Zero ? null : new Program(ptr, false);
        }

        public void ResetState()
        {
            NativeMethods.cgResetPassState(this.Handle);
        }

        public void SetLastListing(string listing)
        {
            NativeMethods.cgSetLastListing(this.Handle, listing);
        }

        public void SetState()
        {
            NativeMethods.cgSetPassState(this.Handle);
        }

        public void UpdateParameters(Pass pass)
        {
            NativeMethods.cgUpdatePassParameters(this.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}