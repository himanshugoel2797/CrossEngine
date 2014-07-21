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
    public static class Cg
    {
        #region Fields

        private static readonly object PadLock = new object();

        #endregion Fields

        #region Constructors

        static Cg()
        {
            DefaultMatrixOrder = MatrixOrder.RowMajor;
        }

        #endregion Constructors

        #region Delegates

        /// <summary>
        ///    
        /// </summary>
        // typedef void (*CGerrorHandlerFunc)(CGcontext context, CGerror err, void *data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CgErrorHandlerFuncDelegate(IntPtr context, ErrorType err, IntPtr data);

        #endregion Delegates

        #region Events

        public static event EventHandler<ErrorEventArgs> Error
        {
            add
            {
                lock (PadLock)
                {
                    if (error == null)
                    {
                        NativeMethods.cgSetErrorCallback(OnError);
                    }

                    error += value;
                }
            }

            remove
            {
                lock (PadLock)
                {
                    error -= value;

                    if (error == null)
                    {
                        NativeMethods.cgSetErrorCallback(null);
                    }
                }
            }
        }

        private static event EventHandler<ErrorEventArgs> error;

        #endregion Events

        #region Properties

        #region Public Static Properties

        public static MatrixOrder DefaultMatrixOrder
        {
            get;
            set;
        }

        public static LockingPolicy LockingPolicy
        {
            get
            {
                return NativeMethods.cgGetLockingPolicy();
            }

            set
            {
                NativeMethods.cgSetLockingPolicy(value);
            }
        }

        public static CasePolicy SemanticCasePolicy
        {
            get
            {
                return NativeMethods.cgGetSemanticCasePolicy();
            }

            set
            {
                NativeMethods.cgSetSemanticCasePolicy(value);
            }
        }

        public static IEnumerable<ProfileType> SupportedProfiles
        {
            get
            {
                int count = Cg.SupportedProfilesCount;
                for (int i = 0; i < count; i++)
                {
                    yield return Cg.GetSupportedProfile(i);
                }
            }
        }

        public static int SupportedProfilesCount
        {
            get
            {
                return NativeMethods.cgGetNumSupportedProfiles();
            }
        }

        #endregion Public Static Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static Behavior GetBehavior(string behaviorString)
        {
            return NativeMethods.cgGetBehavior(behaviorString);
        }

        public static string GetBehavior(Behavior behavior)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetBehaviorString(behavior));
        }

        public static Domain GetDomain(string domainString)
        {
            return NativeMethods.cgGetDomain(domainString);
        }

        public static string GetDomain(Domain domain)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetDomainString(domain));
        }

        public static int GetEnum(string enumString)
        {
            return NativeMethods.cgGetEnum(enumString);
        }

        public static string GetEnum(int @enum)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetEnumString(@enum));
        }

        public static string GetError(ErrorType error)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetErrorString(error));
        }

        public static ErrorType GetError()
        {
            return NativeMethods.cgGetError();
        }

        public static CgErrorHandlerFuncDelegate GetErrorHandler(IntPtr data)
        {
            return NativeMethods.cgGetErrorHandler(data);
        }

        public static ErrorType GetFirstError()
        {
            return NativeMethods.cgGetFirstError();
        }

        public static string GetLastErrorString(out ErrorType error)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetLastErrorString(out error));
        }

        public static ParameterType GetMatrixSize(ParameterType type, out int nrows, out int ncols)
        {
            return NativeMethods.cgGetMatrixSize(type, out nrows, out ncols);
        }

        public static ParameterClass GetParameterClassEnum(string pString)
        {
            return NativeMethods.cgGetParameterClassEnum(pString);
        }

        public static string GetParameterClassString(ParameterClass pc)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetParameterClassString(pc));
        }

        public static ParameterType GetParentType(ParameterType type, int index)
        {
            return NativeMethods.cgGetParentType(type, index);
        }

        public static int GetParentTypesCount(ParameterType type)
        {
            return NativeMethods.cgGetNumParentTypes(type);
        }

        public static ProfileType GetProfile(string profile)
        {
            return NativeMethods.cgGetProfile(profile);
        }

        public static string GetProfile(ProfileType profile)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetProfileString(profile));
        }

        public static Domain GetProfileDomain(ProfileType profile)
        {
            return NativeMethods.cgGetProfileDomain(profile);
        }

        public static bool GetProfileProperty(ProfileType profile, Query query)
        {
            return NativeMethods.cgGetProfileProperty(profile, query);
        }

        public static ProfileType GetProfileSibling(ProfileType profile, Domain domain)
        {
            return NativeMethods.cgGetProfileSibling(profile, domain);
        }

        public static int GetProgramBufferMaxIndex(ProfileType profile)
        {
            return NativeMethods.cgGetProgramBufferMaxIndex(profile);
        }

        public static int GetProgramBufferMaxSize(ProfileType profile)
        {
            return NativeMethods.cgGetProgramBufferMaxSize(profile);
        }

        public static ResourceType GetResource(string resourceName)
        {
            return NativeMethods.cgGetResource(resourceName);
        }

        public static string GetResource(ResourceType resource)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetResourceString(resource));
        }

        public static string GetString(CgAll sname)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetString(sname));
        }

        public static ProfileType GetSupportedProfile(int index)
        {
            return NativeMethods.cgGetSupportedProfile(index);
        }

        public static ParameterType GetType(string typeString)
        {
            return NativeMethods.cgGetType(typeString);
        }

        public static string GetType(ParameterType type)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetTypeString(type));
        }

        public static ParameterType GetTypeBase(ParameterType type)
        {
            return NativeMethods.cgGetTypeBase(type);
        }

        public static ParameterClass GetTypeClass(ParameterType type)
        {
            return NativeMethods.cgGetTypeClass(type);
        }

        public static bool GetTypeSizes(ParameterType type, out int nrows, out int ncols)
        {
            return NativeMethods.cgGetTypeSizes(type, out nrows, out ncols);
        }

        public static bool IsInterfaceType(ParameterType type)
        {
            return NativeMethods.cgIsInterfaceType(type);
        }

        public static bool IsParentType(ParameterType parent, int child)
        {
            return NativeMethods.cgIsParentType(parent, child);
        }

        public static bool IsProfileSupported(ProfileType profile)
        {
            return NativeMethods.cgIsProfileSupported(profile);
        }

        public static void SetErrorHandler(CgErrorHandlerFuncDelegate func, IntPtr data)
        {
            NativeMethods.cgSetErrorHandler(func, data);
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static void OnError()
        {
            if (error != null)
            {
                error(null, new ErrorEventArgs(Cg.GetError()));
            }
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}