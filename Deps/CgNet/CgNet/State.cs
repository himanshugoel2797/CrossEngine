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

    public sealed class State : WrapperObject
    {
        #region Constructors

        public State(IntPtr handle, bool ownsHandle)
            : base(handle, ownsHandle)
        {
        }

        #endregion Constructors

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool CallbackDelegate(IntPtr cGstateassignment);

        #endregion Delegates

        #region Properties

        #region Public Properties

        public Context Context
        {
            get
            {
                var ptr = NativeMethods.cgGetStateContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new Context(ptr, false);
            }
        }

        public int EnumerantsCount
        {
            get
            {
                return NativeMethods.cgGetNumStateEnumerants(this.Handle);
            }
        }

        public bool IsState
        {
            get
            {
                return NativeMethods.cgIsState(this.Handle);
            }
        }

        public ProfileType LatestProfile
        {
            get
            {
                return NativeMethods.cgGetStateLatestProfile(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetStateName(this.Handle));
            }
        }

        public State NextState
        {
            get
            {
                var ptr = NativeMethods.cgGetNextState(this.Handle);
                return ptr == IntPtr.Zero ? null : new State(ptr, false);
            }
        }

        public CallbackDelegate ResetCallback
        {
            get
            {
                return NativeMethods.cgGetStateResetCallback(this.Handle);
            }
        }

        public CallbackDelegate SetCallback
        {
            get
            {
                return NativeMethods.cgGetStateSetCallback(this.Handle);
            }
        }

        public ParameterType Type
        {
            get
            {
                return NativeMethods.cgGetStateType(this.Handle);
            }
        }

        public CallbackDelegate ValidateCallback
        {
            get
            {
                return NativeMethods.cgGetStateValidateCallback(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static State Create(Context context, string name, ParameterType type)
        {
            return context.CreateState(name, type);
        }

        public static State CreateArrayState(Context context, string name, ParameterType type, int elementCount)
        {
            return context.CreateArrayState(name, type, elementCount);
        }

        #endregion Public Static Methods

        #region Public Methods

        public void AddEnumerant(string name, int value)
        {
            IntPtr state = this.Handle;
            NativeMethods.cgAddStateEnumerant(state, name, value);
        }

        public bool CallResetCallback()
        {
            IntPtr stateassignment = this.Handle;
            return NativeMethods.cgCallStateResetCallback(stateassignment);
        }

        public bool CallSetCallback()
        {
            IntPtr stateassignment = this.Handle;
            return NativeMethods.cgCallStateSetCallback(stateassignment);
        }

        public bool CallValidateCallback()
        {
            IntPtr stateassignment = this.Handle;
            return NativeMethods.cgCallStateValidateCallback(stateassignment);
        }

        public string GetEnumerant(int index, out int value)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetStateEnumerant(this.Handle, index, out value));
        }

        public string GetEnumerantName(int index)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetStateEnumerantName(this.Handle, index));
        }

        public int GetEnumerantValue(string name)
        {
            return NativeMethods.cgGetStateEnumerantValue(this.Handle, name);
        }

        public void SetCallbacks(CallbackDelegate set, CallbackDelegate reset, CallbackDelegate validate)
        {
            NativeMethods.cgSetStateCallbacks(this.Handle, set, reset, validate);
        }

        public void SetLatestProfile(ProfileType profile)
        {
            NativeMethods.cgSetStateLatestProfile(this.Handle, profile);
        }

        #endregion Public Methods

        #endregion Methods
    }
}