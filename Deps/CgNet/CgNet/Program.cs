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

    public sealed class Program : WrapperObject
    {
        #region Constructors

        public Program(IntPtr handle, bool ownsHandle)
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
                var ptr = NativeMethods.cgGetProgramContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new Context(ptr, false);
            }
        }

        public Domain Domain
        {
            get
            {
                return NativeMethods.cgGetProgramDomain(this.Handle);
            }
        }

        public int DomainsCount
        {
            get
            {
                return NativeMethods.cgGetNumProgramDomains(this.Handle);
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstProgramAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
            }
        }

        public ProgramInput Input
        {
            get
            {
                return NativeMethods.cgGetProgramInput(this.Handle);
            }
        }

        public bool IsCompiled
        {
            get
            {
                return NativeMethods.cgIsProgramCompiled(this.Handle);
            }
        }

        public bool IsProgram
        {
            get
            {
                return NativeMethods.cgIsProgram(this.Handle);
            }
        }

        public Program NextProgram
        {
            get
            {
                var ptr = NativeMethods.cgGetNextProgram(this.Handle);
                return ptr == IntPtr.Zero ? null : new Program(ptr, false);
            }
        }

        public string[] Options
        {
            get
            {
                return Utils.IntPtrToStringArray(NativeMethods.cgGetProgramOptions(this.Handle));
            }
        }

        public ProgramOutput Output
        {
            get
            {
                return NativeMethods.cgGetProgramOutput(this.Handle);
            }
        }

        public int OutputVertices
        {
            get
            {
               return NativeMethods.cgGetProgramOutputVertices(this.Handle);
            }

            set
            {
                 NativeMethods.cgSetProgramOutputVertices(this.Handle, value);
            }
        }

        public ProfileType Profile
        {
            get
            {
                return NativeMethods.cgGetProgramProfile(this.Handle);
            }

            set
            {
                NativeMethods.cgSetProgramProfile(this.Handle, value);
            }
        }

        public ProgramType Type
        {
            get;
            internal set;
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

        public static Program Combine(params Program[] programs)
        {
            var buf = new IntPtr[programs.Length];
            for (int i = 0; i < programs.Length; i++)
            {
                buf[i] = programs[i].Handle;
            }

            var ptr = NativeMethods.cgCombinePrograms(buf.Length, buf);
            return ptr == IntPtr.Zero ? null : new Program(ptr, true);
        }

        public static Program Create(Context context, ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            return context.CreateProgram(type, source, profile, entry, args);
        }

        public static Program CreateFromEffect(Effect effect, ProfileType profile, string entry, params string[] args)
        {
            return effect.CreateProgram(profile, entry, args);
        }

        public static Program CreateFromFile(Context context, ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            return context.CreateProgramFromFile(type, file, profile, entry, args);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Program Combine(Program exe1)
        {
            var ptr = NativeMethods.cgCombinePrograms2(this.Handle, exe1.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr, true);
        }

        public void Compile()
        {
            NativeMethods.cgCompileProgram(this.Handle);
        }

        public Program Copy()
        {
            var ptr = NativeMethods.cgCopyProgram(this.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr, true);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = NativeMethods.cgCreateProgramAnnotation(this.Handle, name, type);
            return new Annotation(ptr, true);
        }

        public float[] Evaluate(int ncomps, int nx, int ny, int nz)
        {
            var retValue = new float[ncomps * nx * ny * nz];
            NativeMethods.cgEvaluateProgram(this.Handle, retValue, ncomps, nx, ny, nz);
            return retValue;
        }

        public Buffer GetBuffer(int bufferIndex)
        {
            var ptr = NativeMethods.cgGetProgramBuffer(this.Handle, bufferIndex);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr, false);
        }

        public ProfileType GetDomainProfile(int index)
        {
            return NativeMethods.cgGetProgramDomainProfile(this.Handle, index);
        }

        public Program GetDomainProgram(int index)
        {
            var ptr = NativeMethods.cgGetProgramDomainProgram(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Program(ptr, false);
        }

        public Parameter GetFirstLeafParameter(NameSpace nameSpace)
        {
            var ptr = NativeMethods.cgGetFirstLeafParameter(this.Handle, nameSpace);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public Parameter GetFirstParameter(NameSpace nameSpace)
        {
            var ptr = NativeMethods.cgGetFirstParameter(this.Handle, nameSpace);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = NativeMethods.cgGetNamedProgramAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr, false);
        }

        public Parameter GetNamedParameter(NameSpace nameSpace, string name)
        {
            var ptr = NativeMethods.cgGetNamedProgramParameter(this.Handle, nameSpace, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public Parameter GetNamedParameter(string parameter)
        {
            var ptr = NativeMethods.cgGetNamedParameter(this.Handle, parameter);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public Parameter GetNamedUniformBuffer(string blockName)
        {
            var ptr = NativeMethods.cgGetNamedProgramUniformBuffer(this.Handle, blockName);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public ParameterType GetNamedUserType(string name)
        {
            return NativeMethods.cgGetNamedUserType(this.Handle, name);
        }

        public string GetString(SourceType sourceType)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetProgramString(this.Handle, sourceType));
        }

        public ParameterType GetUserType(int index)
        {
            return NativeMethods.cgGetUserType(this.Handle, index);
        }

        public void SetBuffer(int bufferIndex, Buffer buffer)
        {
            NativeMethods.cgSetProgramBuffer(this.Handle, bufferIndex, buffer.Handle);
        }

        public void SetLastListing(string listing)
        {
            NativeMethods.cgSetLastListing(this.Handle, listing);
        }

        public void SetPassProgramParameters()
        {
            NativeMethods.cgSetPassProgramParameters(this.Handle);
        }

        public void UpdateParameters()
        {
            NativeMethods.cgUpdateProgramParameters(this.Handle);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        protected override void Dispose(bool disposing)
        {
            if (this.OwnsHandle && this.Handle != IntPtr.Zero && this.IsProgram)
            {
                NativeMethods.cgDestroyProgram(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}