/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */
namespace CgNet.GL
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    internal static class NativeMethods
    {
        #region Fields

        private const string CgGLNativeLibrary = "cgGL.dll";
        private const CallingConvention Convention = CallingConvention.Cdecl;

        #endregion Fields

        #region Methods

        #region Public Static Methods

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGLCreateBufferFromObject(IntPtr handle, OpenTK.Graphics.OpenGL.BufferUsageHint flags, [MarshalAs(UnmanagedType.Bool)] bool manageObject);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern GlslVersion cgGLDetectGLSLVersion();

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern GlslVersion cgGLGetContextGLSLVersion(IntPtr handle);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGLGetContextOptimalOptions(IntPtr handle, ProfileType profile);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetContextGLSLVersion(IntPtr handle, GlslVersion version);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetContextOptimalOptions(IntPtr handle, ProfileType profile);

        #endregion Public Static Methods

        #region Internal Static Methods

        /// <summary>
        /// Bind the program to the current OpenGL API state.
        /// </summary>
        /// <param name="program">
        /// Handle to the program to bind.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLBindProgram(IntPtr program);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGLCreateBuffer(IntPtr context, int size, IntPtr data, OpenTK.Graphics.OpenGL.BufferUsageHint bufferUsage);

        /// <summary>
        ///     Disables a vertex attribute in OpenGL state.
        /// </summary>
        /// <param name="param">Parameter to disable.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLDisableClientState(IntPtr param);

        /// <summary>
        /// Disables the selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile to disable.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLDisableProfile(ProfileType profile);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLDisableProgramProfiles(IntPtr program);

        /// <summary>
        /// Disables the texture unit associated with the given texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLDisableTextureParameter(IntPtr param);

        /// <summary>
        ///     Enables a vertex attribute in OpenGL state.
        /// </summary>
        /// <param name="param">Parameter to enable.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLEnableClientState(IntPtr param);

        /// <summary>
        /// Enables the selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile to enable.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLEnableProfile(ProfileType profile);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLEnableProgramProfiles(IntPtr program);

        /// <summary>
        /// Enables (binds) the texture unit associated with the given texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLEnableTextureParameter(IntPtr param);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgGLGetBufferObject(IntPtr buffer);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern GlslVersion cgGLGetGLSLVersion(string version);

        //const char * cgGLGetGLSLVersionString( CGGLglslversion version );
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern string cgGLGetGLSLVersionString(GlslVersion version);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern ProfileType cgGLGetLatestProfile(ProfileClass profileType);

        /// <summary>
        /// Retreives the manage texture parameters flag from a context
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgGLGetManageTextureParameters(IntPtr context);

        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterArraydc(IntPtr param, int offset, int nelements, IntPtr matrices);

        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterArraydr(IntPtr param, int offset, int nelements, IntPtr matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterArrayfc(IntPtr param, int offset, int nelements, IntPtr matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterArrayfr(IntPtr param, int offset, int nelements, IntPtr matrices);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterdc(IntPtr param, IntPtr matrix);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterdr(IntPtr param, IntPtr matrix);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterfc(IntPtr param, IntPtr matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetMatrixParameterfr(IntPtr param, IntPtr matrix);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention, CharSet = CharSet.Ansi)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGLGetOptimalOptions(ProfileType profile);

        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter1d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter1f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter2d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter2f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter3d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter3f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter4d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameter4f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray1d(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray1f(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray2d(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray2f(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray3d(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray3f(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray4d(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLGetParameterArray4f(IntPtr param, int offset, int nelements, [Out] IntPtr values);

        /// <summary>
        /// Returns the program's ID.
        /// </summary>
        /// <param name="program">
        /// Handle to the program.
        /// </param>
        /// <returns>
        /// Program's ID.
        /// </returns>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgGLGetProgramID(IntPtr program);

        /// <summary>
        /// Retreives the OpenGL enumeration for the texture unit associated with the texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// It can be one of the GL_TEXTURE#_ARB if valid.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgGLGetTextureEnum(IntPtr param);

        /// <summary>
        /// Retreives the value of a texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern int cgGLGetTextureParameter(IntPtr param);

        /// <summary>
        /// Checks if the profile is supported.
        /// </summary>
        /// <param name="profile">
        /// The profile to check the support of.
        /// </param>
        /// <returns>
        /// Returns true if the profile is supported.
        /// </returns>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern bool cgGLIsProfileSupported(ProfileType profile);

        /// <summary>
        /// Returns true if the specified program is loaded.
        /// </summary>
        /// <param name="program">
        /// Handle to the program.
        /// </param>
        /// <returns>
        /// True if the specified program is loaded.
        /// </returns>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern bool cgGLIsProgramLoaded(IntPtr program);

        /// <summary>
        /// Loads program to OpenGL pipeline
        /// </summary>
        /// <param name="program">
        /// Handle to the program to load.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLLoadProgram(IntPtr program);

        /// <summary>
        ///
        /// </summary>
        // CGGLDLL_API void cgGLRegisterStates(CGcontext);
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLRegisterStates(IntPtr context);

        //CGGL_API void CGGLENTRY cgGLSetDebugMode( CGbool debug );
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetDebugMode([MarshalAs(UnmanagedType.Bool)] bool debug);

        /// <summary>
        /// Enables or disables the automatic texture management for the given rendering context.
        /// <remarks>
        /// Use CG_TRUE or CG_FALSE to enable/disable automatic texture management.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetManageTextureParameters(IntPtr context, bool flag);

        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterArraydc(IntPtr param, int offset, int nelements, [In] Matrix4d[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterArraydr(IntPtr param, int offset, int nelements, [In] Matrix4d[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterArrayfc(IntPtr param, int offset, int nelements, [In] Matrix4[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterArrayfr(IntPtr param, int offset, int nelements, [In] Matrix4[] matrices);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterdc(IntPtr param, ref Matrix4d matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterdr(IntPtr param, ref Matrix4d matrix);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterfc(IntPtr param, ref Matrix4 matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetMatrixParameterfr(IntPtr param, ref Matrix4 matrix);

        /// <summary>
        /// Sets the best compiler options available by card, driver and selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetOptimalOptions(ProfileType profile);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter1d(IntPtr param, double x);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter1dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter1f(IntPtr param, float x);

        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter1fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter1fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter2d(IntPtr param, double x, double y);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter2dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter2dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter2f(IntPtr param, float x, float y);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter2fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter2fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter3d(IntPtr param, double x, double y, double z);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter3dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter3dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter3f(IntPtr param, float x, float y, float z);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter3fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter3fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter4d(IntPtr param, double x, double y, double z, double w);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter4dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter4dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter4f(IntPtr param, float x, float y, float z, float w);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter4fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameter4fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray1d(IntPtr param, int offset, int nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray1d(IntPtr param, int offset, int nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray1f(IntPtr param, int offset, int nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray1f(IntPtr param, int offset, int nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray2d(IntPtr param, int offset, int nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray2d(IntPtr param, int offset, int nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray2f(IntPtr param, int offset, int nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray2f(IntPtr param, int offset, int nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray3d(IntPtr param, int offset, int nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray3d(IntPtr param, int offset, int nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray3f(IntPtr param, int offset, int nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray3f(IntPtr param, int offset, int nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray4d(IntPtr param, int offset, int nelements, [In] Matrix4d[] values);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray4d(IntPtr param, int offset, int nelements, [In] double[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray4f(IntPtr param, int offset, int nelements, [In] Matrix4[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterArray4f(IntPtr param, int offset, int nelements, [In] float[] values);

        /// <summary>
        /// Sets parameter with attribute array.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="fsize">Number of coordinates per vertex.</param>
        /// <param name="type">Data type of each coordinate.</param>
        /// <param name="stride">Specifies the byte offset between consecutive vertices. If stride is 0 the array is assumed to be tightly packed.</param>
        /// <param name="pointer">The pointer to the first coordinate in the vertex array.</param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetParameterPointer(IntPtr param, int fsize, DataType type, int stride, [In] IntPtr pointer);

        /// <summary>
        /// Sets the values of the parameter to a matrix in the OpenGL state.
        /// </summary>
        /// <param name="param">
        /// Parameter that will be set.
        /// </param>
        /// <param name="matrix">
        /// Which matrix should be retreived from the OpenGL state.
        /// </param>
        /// <param name="transform">
        /// Optional transformation that will be aplied to the OpenGL state matrix before it is retreived to the parameter.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetStateMatrixParameter(IntPtr param, MatrixType matrix, MatrixTransform transform);

        /// <summary>
        /// Sets texture object to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetTextureParameter(IntPtr param, int texobj);

        /// <summary>
        ///
        /// </summary>
        // CGGLDLL_API void cgGLSetupSampler(CGparameter param, GLuint texobj);
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLSetupSampler(IntPtr param, int texobj);

        /// <summary>
        /// Unbinds the program bound in a profile.
        /// </summary>
        /// <param name="profile">
        /// Handle to the profile to unbind programs from.
        /// </param>
        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLUnbindProgram(ProfileType profile);

        [DllImport(CgGLNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        internal static extern void cgGLUnloadProgram(IntPtr program);

        #endregion Internal Static Methods

        #endregion Methods
    }
}