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

    public sealed class Effect : WrapperObject
    {
        #region Constructors

        public Effect(IntPtr handle, bool ownsHandle)
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

        public Context Context
        {
            get
            {
                return new Context(NativeMethods.cgGetEffectContext(this.Handle), false);
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstEffectAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
            }
        }

        public Parameter FirstLeafParameter
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstLeafEffectParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
            }
        }

        public Parameter FirstParameter
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstEffectParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
            }
        }

        public Technique FirstTechnique
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstTechnique(this.Handle);
                return ptr == IntPtr.Zero ? null : new Technique(ptr, false);
            }
        }

        public bool IsEffect
        {
            get
            {
                return NativeMethods.cgIsEffect(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetEffectName(this.Handle));
            }

            set
            {
                NativeMethods.cgSetEffectName(this.Handle, value);
            }
        }

        public Effect NextEffect
        {
            get
            {
                var ptr = NativeMethods.cgGetNextEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new Effect(ptr, false);
            }
        }

        public IEnumerable<Parameter> Parameters
        {
            get
            {
                return Enumerate(() => this.FirstParameter, t => t.NextParameter);
            }
        }

        public IEnumerable<Technique> Techniques
        {
            get
            {
                return Enumerate(() => this.FirstTechnique, t => t.NextTechnique);
            }
        }

        public int UserTypesCount
        {
            get
            {
                return NativeMethods.cgGetNumUserTypes(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static Effect Create(Context context, string code, params string[] args)
        {
            return context.CreateEffect(code, args);
        }

        public static Effect CreateFromFile(Context context, string filename, params string[] args)
        {
            return context.CreateEffectFromFile(filename, args);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Effect Copy()
        {
            var ptr = NativeMethods.cgCopyEffect(this.Handle);
            return ptr == IntPtr.Zero ? null : new Effect(ptr, true);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = NativeMethods.cgCreateEffectAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, true);
        }

        public Parameter CreateParameterArray(string name, ParameterType type, int length)
        {
            var ptr = NativeMethods.cgCreateEffectParameterArray(this.Handle, name, type, length);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, true);
        }

        public Parameter CreateParameterMultiDimArray(string name, ParameterType type, int dim, int[] lengths)
        {
            var ptr = NativeMethods.cgCreateEffectParameterMultiDimArray(this.Handle, name, type, dim, lengths);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, true);
        }

        public Program CreateProgram(ProfileType profile, string entry, params string[] args)
        {
            Utils.CheckArgs(ref args);
            var ptr = NativeMethods.cgCreateProgramFromEffect(this.Handle, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new Program(ptr, true);
        }

        public Technique CreateTechnique(string name)
        {
            var ptr = NativeMethods.cgCreateTechnique(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Technique(ptr, true);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = NativeMethods.cgGetNamedEffectAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
        }

        public Parameter GetNamedParameter(string name)
        {
            var ptr = NativeMethods.cgGetNamedEffectParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public Technique GetNamedTechnique(string name)
        {
            var ptr = NativeMethods.cgGetNamedTechnique(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Technique(ptr, false);
        }

        public Parameter GetNamedUniformBuffer(string blockName)
        {
            var ptr = NativeMethods.cgGetNamedEffectUniformBuffer(this.Handle, blockName);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public ParameterType GetNamedUserType(string name)
        {
            return NativeMethods.cgGetNamedUserType(this.Handle, name);
        }

        public Parameter GetParameterBySemantic(string name)
        {
            var ptr = NativeMethods.cgGetEffectParameterBySemantic(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public ParameterType GetUserType(int index)
        {
            return NativeMethods.cgGetUserType(this.Handle, index);
        }

        public void SetLastListing(string listing)
        {
            NativeMethods.cgSetLastListing(this.Handle, listing);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.OwnsHandle && this.Handle != IntPtr.Zero && this.IsEffect)
            {
                NativeMethods.cgDestroyEffect(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}