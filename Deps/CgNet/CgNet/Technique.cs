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

    public sealed class Technique : WrapperObject
    {
        #region Constructors

        public Technique(IntPtr handle, bool ownsHandle)
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

        public Effect Effect
        {
            get
            {
                var ptr = NativeMethods.cgGetTechniqueEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new Effect(ptr, false);
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstTechniqueAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
            }
        }

        public Pass FirstPass
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstPass(this.Handle);
                return ptr == IntPtr.Zero ? null : new Pass(ptr, false);
            }
        }

        public bool IsTechnique
        {
            get
            {
                return NativeMethods.cgIsTechnique(this.Handle);
            }
        }

        public bool IsValidated
        {
            get
            {
                return NativeMethods.cgIsTechniqueValidated(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetTechniqueName(this.Handle));
            }
        }

        public Technique NextTechnique
        {
            get
            {
                var ptr = NativeMethods.cgGetNextTechnique(this.Handle);
                return ptr == IntPtr.Zero ? null : new Technique(ptr, false);
            }
        }

        public IEnumerable<Pass> Passes
        {
            get
            {
                return Enumerate(() => this.FirstPass, t => t.NextPass);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static Technique Create(Effect effect, string name)
        {
            return effect.CreateTechnique(name);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = NativeMethods.cgCreateTechniqueAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, true);
        }

        public Pass CreatePass(string name)
        {
            var ptr = NativeMethods.cgCreatePass(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Pass(ptr, true);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = NativeMethods.cgGetNamedTechniqueAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
        }

        public Pass GetNamedPass(string name)
        {
            var ptr = NativeMethods.cgGetNamedPass(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Pass(ptr, false);
        }

        public void SetLastListing(string listing)
        {
            NativeMethods.cgSetLastListing(this.Handle, listing);
        }

        public bool Validate()
        {
            return NativeMethods.cgValidateTechnique(this.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}