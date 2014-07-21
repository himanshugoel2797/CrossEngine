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
    using System.Runtime.InteropServices;

    public sealed class StateAssignment : WrapperObject
    {
        #region Constructors

        public StateAssignment(IntPtr handle, bool ownsHandle)
            : base(handle, ownsHandle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public Parameter ConnectedParameter
        {
            get
            {
                var ptr = NativeMethods.cgGetConnectedStateAssignmentParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
            }
        }

        public int DependentParametersCount
        {
            get
            {
                return NativeMethods.cgGetNumDependentStateAssignmentParameters(this.Handle);
            }
        }

        public int DependentProgramArrayParametersCount
        {
            get
            {
                return NativeMethods.cgGetNumDependentProgramArrayStateAssignmentParameters(this.Handle);
            }
        }

        public int Index
        {
            get
            {
                return NativeMethods.cgGetStateAssignmentIndex(this.Handle);
            }
        }

        public bool IsStateAssignment
        {
            get
            {
                return NativeMethods.cgIsStateAssignment(this.Handle);
            }
        }

        public StateAssignment NextStateAssignment
        {
            get
            {
                var ptr = NativeMethods.cgGetNextStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new StateAssignment(ptr, false);
            }
        }

        public Pass Pass
        {
            get
            {
                var ptr = NativeMethods.cgGetStateAssignmentPass(this.Handle);
                return ptr == IntPtr.Zero ? null : new Pass(ptr, false);
            }
        }

        public State State
        {
            get
            {
                var ptr = NativeMethods.cgGetStateAssignmentState(this.Handle);
                return ptr == IntPtr.Zero ? null : new State(ptr, false);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public bool[] GetBoolValues()
        {
            int count;
            var values = NativeMethods.cgGetBoolStateAssignmentValues(this.Handle, out count);
            return Utils.IntPtrToBoolArray(values, count);
        }

        public Parameter GetDependentParameter(int index)
        {
            var ptr = NativeMethods.cgGetDependentStateAssignmentParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public Parameter GetDependentProgramArrayParameter(int index)
        {
            var ptr = NativeMethods.cgGetDependentProgramArrayStateAssignmentParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public float[] GetFloatValues()
        {
            int nVals;
            return NativeMethods.cgGetFloatStateAssignmentValues(this.Handle, out nVals);
        }

        public int[] GetIntValues()
        {
            int nVals;
            return NativeMethods.cgGetIntStateAssignmentValues(this.Handle, out nVals);
        }

        public Program GetProgramValue()
        {
            var ptr = NativeMethods.cgGetProgramStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr, false);
        }

        public Parameter GetSamplerParameter()
        {
            var ptr = NativeMethods.cgGetSamplerStateAssignmentParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public State GetSamplerState()
        {
            var ptr = NativeMethods.cgGetSamplerStateAssignmentState(this.Handle);
            return ptr == IntPtr.Zero ? null : new State(ptr, false);
        }

        public Parameter GetSamplerStateAssignmentValue()
        {
            var ptr = NativeMethods.cgGetSamplerStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public string GetStringValue()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetStringStateAssignmentValue(this.Handle));
        }

        public Parameter GetTextureStateAssignmentValue()
        {
            var ptr = NativeMethods.cgGetTextureStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr, false);
        }

        public bool Set(float value)
        {
            return NativeMethods.cgSetFloatStateAssignment(this.Handle, value);
        }

        public bool Set(int value)
        {
            return NativeMethods.cgSetIntStateAssignment(this.Handle, value);
        }

        public bool Set(bool value)
        {
            return NativeMethods.cgSetBoolStateAssignment(this.Handle, value);
        }

        public bool Set(string value)
        {
            return NativeMethods.cgSetStringStateAssignment(this.Handle, value);
        }

        public bool Set(float[] value)
        {
            return NativeMethods.cgSetFloatArrayStateAssignment(this.Handle, value);
        }

        public bool Set(int[] value)
        {
            return NativeMethods.cgSetIntArrayStateAssignment(this.Handle, value);
        }

        public bool Set(bool[] value)
        {
            return NativeMethods.cgSetBoolArrayStateAssignment(this.Handle, value);
        }

        public void SetLastListing(string listing)
        {
            NativeMethods.cgSetLastListing(this.Handle, listing);
        }

        public bool SetProgram(Program program)
        {
            return NativeMethods.cgSetProgramStateAssignment(this.Handle, program.Handle);
        }

        public bool SetSampler(Parameter param)
        {
            return NativeMethods.cgSetSamplerStateAssignment(this.Handle, param.Handle);
        }

        public bool SetTexture(Parameter param)
        {
            return NativeMethods.cgSetTextureStateAssignment(this.Handle, param.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}