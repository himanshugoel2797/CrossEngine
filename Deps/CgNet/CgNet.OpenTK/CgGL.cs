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
namespace CgNet.GL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using OpenTK;

    public static class CgGL
    {
        #region Properties

        #region Public Static Properties

        public static IEnumerable<ProfileType> SupportedProfiles
        {
            get
            {
                foreach (var profile in Cg.SupportedProfiles)
                {
                    if (profile.IsProfileSupported())
                    {
                        yield return profile;
                    }
                }
            }
        }

        #endregion Public Static Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static GlslVersion DetectGLSLVersion()
        {
            return NativeMethods.cgGLDetectGLSLVersion();
        }

        public static void DisableProfile(this ProfileType profile)
        {
            NativeMethods.cgGLDisableProfile(profile);
        }

        public static void EnableProfile(this ProfileType profile)
        {
            NativeMethods.cgGLEnableProfile(profile);
        }

        public static GlslVersion GetGLSLVersion(string version)
        {
            return NativeMethods.cgGLGetGLSLVersion(version);
        }

        public static string GetGLSLVersionString(GlslVersion version)
        {
            return NativeMethods.cgGLGetGLSLVersionString(version);
        }

        /// <summary>
        /// Gets the latest profile for a profile class.
        /// </summary>
        /// <param name="profileClass">The class of profile that will be returned.</param>
        /// <returns>Returns a profile enumerant for the latest profile of the given class. Returns CG_PROFILE_UNKNOWN if no appropriate profile is available or an error occurs.</returns>
        public static ProfileType GetLatestProfile(this ProfileClass profileClass)
        {
            return NativeMethods.cgGLGetLatestProfile(profileClass);
        }

        public static string[] GetOptimalOptions(this ProfileType profile)
        {
            return Utils.IntPtrToStringArray(NativeMethods.cgGLGetOptimalOptions(profile));
        }

        public static bool IsProfileSupported(this ProfileType profile)
        {
            return NativeMethods.cgGLIsProfileSupported(profile);
        }

        public static void SetDebugMode(bool debug)
        {
            NativeMethods.cgGLSetDebugMode(debug);
        }

        public static void SetOptimalOptions(this ProfileType profile)
        {
            NativeMethods.cgGLSetOptimalOptions(profile);
        }

        public static void UnbindProgram(this ProfileType profile)
        {
            NativeMethods.cgGLUnbindProgram(profile);
        }

        #endregion Public Static Methods

        #region Internal Static Methods

        internal static T GetMatrixParameter<T>(IntPtr param, MatrixOrder order)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(new T(), GCHandleType.Pinned);

            try
            {
                if (typeof(T) == typeof(Matrix4d))
                {
                    switch (order)
                    {
                        case MatrixOrder.ColumnMajor:
                            NativeMethods.cgGLGetMatrixParameterdc(param, handle.AddrOfPinnedObject());
                            break;
                        case MatrixOrder.RowMajor:
                            NativeMethods.cgGLGetMatrixParameterdr(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(Matrix4))
                {
                    switch (order)
                    {
                        case MatrixOrder.ColumnMajor:
                            NativeMethods.cgGLGetMatrixParameterfc(param, handle.AddrOfPinnedObject());
                            break;
                        case MatrixOrder.RowMajor:
                            NativeMethods.cgGLGetMatrixParameterfr(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

                return (T)handle.Target;
            }
            finally
            {
                handle.Free();
            }
        }

        internal static T[] GetMatrixParameterArray<T>(IntPtr param, int offset, int nelements, MatrixOrder order)
            where T : struct
        {
            var retValue = new T[nelements];
            GCHandle g = GCHandle.Alloc(retValue, GCHandleType.Pinned);

            try
            {
                if (typeof(T) == typeof(Matrix4))
                {
                    switch (order)
                    {
                        case MatrixOrder.ColumnMajor:
                            NativeMethods.cgGLGetMatrixParameterArrayfc(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        case MatrixOrder.RowMajor:
                            NativeMethods.cgGLGetMatrixParameterArrayfr(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(Matrix4d))
                {
                    switch (order)
                    {
                        case MatrixOrder.ColumnMajor:
                            NativeMethods.cgGLGetMatrixParameterArraydc(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        case MatrixOrder.RowMajor:
                            NativeMethods.cgGLGetMatrixParameterArraydr(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

                return retValue;
            }
            finally
            {
                g.Free();
            }
        }

        internal static void SetMatrixParameter(IntPtr param, Matrix4d matrix, MatrixOrder order)
        {
            switch (order)
            {
                case MatrixOrder.ColumnMajor:
                    NativeMethods.cgGLSetMatrixParameterdc(param, ref matrix);
                    break;
                case MatrixOrder.RowMajor:
                    NativeMethods.cgGLSetMatrixParameterdr(param, ref matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        internal static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4d[] matrices, MatrixOrder order)
        {
            switch (order)
            {
                case MatrixOrder.ColumnMajor:
                    NativeMethods.cgGLSetMatrixParameterArraydc(param, offset, nelements, matrices);
                    break;
                case MatrixOrder.RowMajor:
                    NativeMethods.cgGLSetMatrixParameterArraydr(param, offset, nelements, matrices);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        internal static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4[] matrices, MatrixOrder order)
        {
            switch (order)
            {
                case MatrixOrder.ColumnMajor:
                    NativeMethods.cgGLSetMatrixParameterArrayfc(param, offset, nelements, matrices);
                    break;
                case MatrixOrder.RowMajor:
                    NativeMethods.cgGLSetMatrixParameterArrayfr(param, offset, nelements, matrices);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}