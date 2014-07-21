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
    using System.Runtime.InteropServices;
    using System.Security;

    internal static class NativeMethods
    {
        #region Fields

        private const string CgD3D9NativeLibrary = "cgD3D9.dll";
        private const CallingConvention Convention = CallingConvention.Cdecl;

        #endregion Fields

        #region Methods

        #region Internal Static Methods

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9BindProgram(CGprogram prog);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9BindProgram(IntPtr prog);

        //CGD3D9DLL_API void CGD3D9ENTRY cgD3D9EnableDebugTracing(CGbool enable);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgD3D9EnableDebugTracing([MarshalAs(UnmanagedType.Bool)] bool enable);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9EnableParameterShadowing(CGprogram prog, CGbool enable);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9EnableParameterShadowing(IntPtr prog, [MarshalAs(UnmanagedType.Bool)] bool enable);

        //CGD3D9DLL_API IDirect3DDevice9 * CGD3D9ENTRY cgD3D9GetDevice(void);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgD3D9GetDevice();

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9GetLastError(void);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9GetLastError();

        //CGD3D9DLL_API CGprofile CGD3D9ENTRY cgD3D9GetLatestPixelProfile(void);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern ProfileType cgD3D9GetLatestPixelProfile();

        //CGD3D9DLL_API CGprofile CGD3D9ENTRY cgD3D9GetLatestVertexProfile(void);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern ProfileType cgD3D9GetLatestVertexProfile();

        //CGD3D9DLL_API CGbool CGD3D9ENTRY cgD3D9GetManageTextureParameters(CGcontext ctx);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgD3D9GetManageTextureParameters(IntPtr ctx);

        //CGD3D9DLL_API const char ** CGD3D9ENTRY cgD3D9GetOptimalOptions(CGprofile profile);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgD3D9GetOptimalOptions(ProfileType profile);

        //CGD3D9DLL_API IDirect3DBaseTexture9 * CGD3D9ENTRY cgD3D9GetTextureParameter(CGparameter param);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgD3D9GetTextureParameter(IntPtr param);

        //CGD3D9DLL_API CGbool CGD3D9ENTRY cgD3D9GetVertexDeclaration(CGprogram prog, D3DVERTEXELEMENT9 decl[MAXD3DDECLLENGTH]);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgD3D9GetVertexDeclaration(IntPtr program, SlimDX.Direct3D9.VertexElement[] decl);

        //CGD3D9DLL_API CGbool CGD3D9ENTRY cgD3D9IsParameterShadowingEnabled(CGprogram prog);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgD3D9IsParameterShadowingEnabled(IntPtr program);

        //CGD3D9DLL_API CGbool CGD3D9ENTRY cgD3D9IsProfileSupported(CGprofile profile);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgD3D9IsProfileSupported(ProfileType profile);

        //CGD3D9DLL_API CGbool CGD3D9ENTRY cgD3D9IsProgramLoaded(CGprogram prog);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgD3D9IsProgramLoaded(IntPtr program);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9LoadProgram(CGprogram prog, CGbool paramShadowing, DWORD assemFlags);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9LoadProgram(IntPtr prog, [MarshalAs(UnmanagedType.Bool)] bool paramShadowing, uint assemFlags);

        //CGD3D9DLL_API void CGD3D9ENTRY cgD3D9RegisterStates(CGcontext ctx);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgD3D9RegisterStates(IntPtr ctx);

        //CGD3D9DLL_API BYTE CGD3D9ENTRY cgD3D9ResourceToDeclUsage(CGresource resource);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern byte cgD3D9ResourceToDeclUsage(ResourceType resource);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetDevice(IDirect3DDevice9 *pDevice);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetDevice(IntPtr pDevice);

        //CGD3D9DLL_API void CGD3D9ENTRY cgD3D9SetManageTextureParameters(CGcontext ctx, CGbool flag);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgD3D9SetManageTextureParameters(IntPtr ctx, [MarshalAs(UnmanagedType.Bool)] bool flag);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetSamplerState(CGparameter param, D3DSAMPLERSTATETYPE type, DWORD value);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetSamplerState(IntPtr param, SlimDX.Direct3D9.SamplerState type, uint value);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetTexture(CGparameter param, IDirect3DBaseTexture9 *tex);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetTexture(IntPtr param, IntPtr tex);

        //CGD3D9DLL_API void CGD3D9ENTRY cgD3D9SetTextureParameter(CGparameter param, IDirect3DBaseTexture9 *tex);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgD3D9SetTextureParameter(IntPtr param, IntPtr tex);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetTextureWrapMode(CGparameter param, DWORD value);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetTextureWrapMode(IntPtr param, uint value);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetUniform(CGparameter param, const void *floats);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetUniform(IntPtr param, float[] floats);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetUniformArray(CGparameter param, DWORD offset, DWORD numItems, const void *values);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetUniformArray(IntPtr param, uint offset, uint numItems, IntPtr values);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetUniformMatrix(CGparameter param, const D3DMATRIX *matrix);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetUniformMatrix(IntPtr param, SlimDX.Matrix matrix);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9SetUniformMatrixArray(CGparameter param, DWORD offset, DWORD numItems, const D3DMATRIX *matrices);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9SetUniformMatrixArray(IntPtr param, uint offset, uint numItems, SlimDX.Matrix[] matrices);

        //CGD3D9DLL_API const char * CGD3D9ENTRY cgD3D9TranslateCGerror(CGerror error);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgD3D9TranslateCGerror(ErrorType error);

        //CGD3D9DLL_API const char * CGD3D9ENTRY cgD3D9TranslateHRESULT(HRESULT hr);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgD3D9TranslateHRESULT(int hr);

        //CGD3D9DLL_API DWORD CGD3D9ENTRY cgD3D9TypeToSize(CGtype type);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern uint cgD3D9TypeToSize(ParameterType type);

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9UnbindProgram(CGprogram prog);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9UnbindProgram(IntPtr prog);

        //CGD3D9DLL_API void CGD3D9ENTRY cgD3D9UnloadAllPrograms(void);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgD3D9UnloadAllPrograms();

        //CGD3D9DLL_API HRESULT CGD3D9ENTRY cgD3D9UnloadProgram(CGprogram prog);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgD3D9UnloadProgram(IntPtr prog);

        //CGD3D9DLL_API CGbool CGD3D9ENTRY cgD3D9ValidateVertexDeclaration(CGprogram prog, const D3DVERTEXELEMENT9 *decl);
        [DllImport(CgD3D9NativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgD3D9ValidateVertexDeclaration(IntPtr program, SlimDX.Direct3D9.VertexElement[] decl);

        #endregion Internal Static Methods

        #endregion Methods
    }
}