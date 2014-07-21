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
namespace CgNet.D3D9
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using ParameterType = CgNet.ParameterType;

    using ResourceType = CgNet.ResourceType;

    using SlimDX;
    using SlimDX.Direct3D9;

    public static class CgD3D9
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

        public static void EnableDebugTracing(bool enable)
        {
            NativeMethods.cgD3D9EnableDebugTracing(enable);
        }

        public static Device GetDevice()
        {
            return Device.FromPointer(NativeMethods.cgD3D9GetDevice());
        }

        public static int GetLastError()
        {
            return NativeMethods.cgD3D9GetLastError();
        }

        public static ProfileType GetLatestPixelProfile()
        {
            return NativeMethods.cgD3D9GetLatestPixelProfile();
        }

        public static ProfileType GetLatestVertexProfile()
        {
            return NativeMethods.cgD3D9GetLatestVertexProfile();
        }

        public static string[] GetOptimalOptions(this ProfileType profile)
        {
            return Utils.IntPtrToStringArray(NativeMethods.cgD3D9GetOptimalOptions(profile));
        }

        public static bool IsProfileSupported(this ProfileType profile)
        {
            return NativeMethods.cgD3D9IsProfileSupported(profile);
        }

        public static DeclarationUsage ResourceTypeToDeclarationUsage(this ResourceType resourceType)
        {
            return (DeclarationUsage)NativeMethods.cgD3D9ResourceToDeclUsage(resourceType);
        }

        public static int SetDevice(Device device)
        {
            return NativeMethods.cgD3D9SetDevice(device != null ? device.ComPointer : IntPtr.Zero);
        }

        public static string TranslateCgError(ErrorType error)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgD3D9TranslateCGerror(error));
        }

        public static string TranslateResult(Result result)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgD3D9TranslateHRESULT(result.Code));
        }

        public static int TypeToSize(this ParameterType type)
        {
            return (int)NativeMethods.cgD3D9TypeToSize(type);
        }

        public static void UnloadAllPrograms()
        {
            NativeMethods.cgD3D9UnloadAllPrograms();
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}