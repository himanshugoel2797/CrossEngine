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
namespace CgNet
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    ///     Cg core runtime binding for .NET, implementing Cg 1.4.1.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in cg.dll or libcg.so.
    /// </remarks>
    internal static class NativeMethods
    {
        #region Fields

        internal const int CgFalse = 0;
        internal const int CgTrue = 1;

        private const string CgNativeLibrary = "cg.dll";
        private const CallingConvention Convention = CallingConvention.Cdecl;

        #endregion Fields

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CgIncludeCallbackFunc(IntPtr context, string filename);

        /// <summary>
        ///
        /// </summary>
        // typedef void (*CGerrorCallbackFunc)(void);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CgErrorCallbackFuncDelegate();

        #endregion Delegates

        #region Methods

        #region Public Static Methods

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgAddStateEnumerant(IntPtr state, string name, int value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgCallStateResetCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgCallStateSetCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgCallStateValidateCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCombinePrograms(int n, IntPtr[] progs);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCombinePrograms2(IntPtr exe1, IntPtr exe2);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCombinePrograms3(IntPtr exe1, IntPtr exe2, IntPtr exe3);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCombinePrograms4(IntPtr exe1, IntPtr exe2, IntPtr exe3, IntPtr exe4);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCombinePrograms5(IntPtr exe1, IntPtr exe2, IntPtr exe3, IntPtr exe4, IntPtr exe5);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgCompileProgram(IntPtr prog);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgConnectParameter(IntPtr from, IntPtr to);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCopyEffect(IntPtr effect);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCopyProgram(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateArraySamplerState(IntPtr context, string name, ParameterType type, int nelems);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateArrayState(IntPtr context, string name, ParameterType type, int nelems);

        // CG_API CGbuffer CGENTRY cgCreateBuffer(CGcontext context, int size, const void *data, CGbufferusage bufferUsage);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateBuffer(IntPtr context, int size, IntPtr data, BufferUsage bufferUsage);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateContext();

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffect(IntPtr context, string code, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffectAnnotation(IntPtr effect, string name, ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffectFromFile(IntPtr context, string filename, string[] args);

        //CG_API CGparameter CGENTRY cgCreateEffectParameter(CGeffect effect, const char *name, CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffectParameter(IntPtr context, string name, ParameterType type);

        //CG_API CGparameter CGENTRY cgCreateEffectParameterArray(CGeffect effect, const char *name, CGtype type, int length);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffectParameterArray(IntPtr effect, string name, ParameterType type, int length);

        //CG_API CGparameter CGENTRY cgCreateEffectParameterMultiDimArray(CGeffect effect, const char *name, CGtype type, int dim, const int *lengths);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffectParameterMultiDimArray(IntPtr effect, string name, ParameterType type, int dim, int[] lengths);

        //CG_API CGobj CGENTRY cgCreateObj(CGcontext context, CGenum program_type, const char *source, CGprofile profile, const char **args);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateObj(IntPtr context, ProgramType programType, string source, ProfileType profile, string[] args);

        //CG_API CGobj CGENTRY cgCreateObjFromFile(CGcontext context, CGenum program_type, const char *source_file, CGprofile profile, const char **args);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateObjFromFile(IntPtr context, ProgramType programType, string sourceFile, ProfileType profile, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameter(IntPtr context, ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameterAnnotation(IntPtr param, string name, ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameterArray(IntPtr context, ParameterType type, int length);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameterMultiDimArray(IntPtr context, ParameterType type, int dim, [In] int[] lengths);

        //CG_API CGpass CGENTRY cgCreatePass(CGtechnique tech, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreatePass(IntPtr tech, string name);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreatePassAnnotation(IntPtr pass, string name, ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgram(IntPtr context, ProgramType type, string source, ProfileType profile, string entry, string[] args);

        // CG_API CGannotation CGENTRY cgCreateProgramAnnotation(CGprogram program, const char *name, CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgramAnnotation(IntPtr annotation, string name, ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgramFromEffect(IntPtr effect, ProfileType profile, string entry, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgramFromFile(IntPtr context, ProgramType type, string file, ProfileType profile, string entry, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateSamplerState(IntPtr context, string name, ParameterType type);

        //CG_API CGstateassignment CGENTRY cgCreateSamplerStateAssignment(CGparameter param, CGstate state);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateSamplerStateAssignment(IntPtr pass, IntPtr state);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateState(IntPtr context, string name, ParameterType type);

        //CG_API CGstateassignment CGENTRY cgCreateStateAssignment(CGpass pass, CGstate state);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateStateAssignment(IntPtr pass, IntPtr state);

        //CG_API CGstateassignment CGENTRY cgCreateStateAssignmentIndex(CGpass pass, CGstate state, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateStateAssignmentIndex(IntPtr pass, IntPtr state, int index);

        //CG_API CGtechnique CGENTRY cgCreateTechnique(CGeffect effect, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateTechnique(IntPtr effect, string name);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateTechniqueAnnotation(IntPtr tech, string name, ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyBuffer(IntPtr buffer);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyContext(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyEffect(IntPtr effect);

        //    CG_API void CGENTRY cgDestroyObj(CGobj obj);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyObj(IntPtr obj);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyParameter(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyProgram(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgDisconnectParameter(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgEvaluateProgram(IntPtr prog, float[] f, int ncomps, int nx, int ny, int nz);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetAnnotationName(IntPtr annotation);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetAnnotationType(IntPtr annotation);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArrayDimension(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetArrayParameter(IntPtr aparam, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArraySize(IntPtr param, int dimension);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArrayTotalSize(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetArrayType(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern AutoCompileMode cgGetAutoCompile(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Behavior cgGetBehavior(string behaviorString);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetBehaviorString(Behavior behavior);

        // const CGbool * cgGetBoolAnnotationValues( CGannotation ann, int * nvalues );
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetBoolAnnotationValues(IntPtr annotation, out int nvalues);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [Obsolete]
        public static extern int[] cgGetBooleanAnnotationValues(IntPtr annotation, out int[] nvalues);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetBoolStateAssignmentValues(IntPtr stateassignment, out int nVals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetBufferSize(IntPtr buffer);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern CgIncludeCallbackFunc cgGetCompilerIncludeCallback(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetConnectedParameter(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetConnectedStateAssignmentParameter(IntPtr sa);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetConnectedToParameter(IntPtr param, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Behavior cgGetContextBehavior(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetDependentAnnotationParameter(IntPtr annotation, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetDependentProgramArrayStateAssignmentParameter(IntPtr sa, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetDependentStateAssignmentParameter(IntPtr stateassignment, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Domain cgGetDomain(string domainString);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetDomainString(Domain domain);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEffectContext(IntPtr effect);

        //        CG_API const char * CGENTRY cgGetEffectName(CGeffect effect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEffectName(IntPtr effect);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEffectParameterBuffer(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetEffectParameterBySemantic(CGeffect, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEffectParameterBySemantic(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumString"></param>
        /// <returns></returns>
        // CGDLL_API CGenum cgGetEnum(const char *enum_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetEnum(string enumString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetEnumString(CGenum en);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEnumString(int en);

        /// <summary>
        ///    Returns an error enum if an error has occured in the last Cg method call.
        /// </summary>
        /// <returns>Error enum.</returns>
        //CGDLL_API CGerror cgGetError(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ErrorType cgGetError();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGerrorCallbackFunc cgGetErrorCallback(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern CgErrorCallbackFuncDelegate cgGetErrorCallback();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // CGDLL_API CGerrorHandlerFunc cgGetErrorHandler(void **data);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Cg.CgErrorHandlerFuncDelegate cgGetErrorHandler(IntPtr data);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetErrorString(ErrorType error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstDependentParameter(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstDependentParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetFirstEffect(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstEffect(IntPtr context);

        //CG_API CGannotation CGENTRY cgGetFirstEffectAnnotation(CGeffect effect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstEffectAnnotation(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstEffectParameter(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstEffectParameter(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGerror cgGetFirstError(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ErrorType cgGetFirstError();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstLeafEffectParameter(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstLeafEffectParameter(IntPtr effect);

        /// <summary>
        ///    Used to get the first leaf parameter from the specified program.
        /// </summary>
        /// <remarks>
        ///    Leaf params read into params that are structs as well, eliminating the need to explictly
        ///    determine if the param is a struct or other type.
        /// </remarks>
        /// <param name="program">
        ///    Handle to the program to query.
        /// </param>
        /// <param name="nameSpace">
        ///    Namespace in which to query for the params (usually CG_PROGRAM).
        /// </param>
        /// <returns>
        ///    Handle to the first Cg parameter in the specified program.
        /// </returns>
        // CGDLL_API CGparameter cgGetFirstLeafParameter(CGprogram prog, CGenum name_space);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstLeafParameter(IntPtr program, NameSpace nameSpace);

        /// <summary>
        /// Gets the first parameter in specified program.
        /// </summary>
        /// <param name="prog">The program to retreive the first program from.</param>
        /// <param name="nameSpace">Namespace of the parameter to iterate through.</param>
        /// <returns>First parameter in specified program.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstParameter(IntPtr prog, NameSpace nameSpace);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstParameterAnnotation(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstParameterAnnotation(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetFirstPass(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstPass(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstPassAnnotation(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstPassAnnotation(IntPtr pass);

        /// <summary>
        ///     Gets the first program in a context.
        /// </summary>
        /// <param name="context">
        ///     The context to retreive first program from.
        /// </param>
        /// <returns>
        ///     The program or null if no programs available.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstProgram(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstProgramAnnotation(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetFirstSamplerState(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstSamplerState(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetFirstSamplerStateAssignment(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstSamplerStateAssignment(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetFirstState(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstState(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetFirstStateAssignment(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstStateAssignment(IntPtr pass);

        /// <summary>
        /// Gets the first child parameter in a struct parameter.
        /// </summary>
        /// <param name="param">The struct parameter to get child parameter from.</param>
        /// <returns>First child parameter in specified struct parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstStructParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetFirstTechnique(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstTechnique(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstTechniqueAnnotation(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstTechniqueAnnotation(IntPtr technique);

        //CGparameter cgGetFirstUniformBufferParameter( CGparameter param );
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstUniformBufferParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const float *cgGetFloatAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern float[] cgGetFloatAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const float *cgGetFloatStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern float[] cgGetFloatStateAssignmentValues(IntPtr stateassignment, out int nVals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetIntAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int[] cgGetIntAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetIntStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int[] cgGetIntStateAssignmentValues(IntPtr stateassignment, out int nVals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetLastErrorString(out ErrorType error);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetLastListing(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern LockingPolicy cgGetLockingPolicy();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterdc(CGparameter param, double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterdc(IntPtr param, double[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterdr(CGparameter param, double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterdr(IntPtr param, double[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterfc(CGparameter param, float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterfc(IntPtr param, float[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterfr(CGparameter param, float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterfr(IntPtr param, float[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameteric(CGparameter param, int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameteric(IntPtr param, int[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterir(CGparameter param, int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterir(IntPtr param, int[] matrix);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern MatrixOrder cgGetMatrixParameterOrder(IntPtr param);

        //CG_API void CGENTRY cgGetMatrixSize(CGtype type, int *nrows, int *ncols);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetMatrixSize(ParameterType type, out int nrows, out int ncols);

        //CG_API CGeffect CGENTRY cgGetNamedEffect(CGcontext context, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedEffect(IntPtr context, string name);

        //CG_API CGannotation CGENTRY cgGetNamedEffectAnnotation(CGeffect effect, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedEffectAnnotation(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedEffectParameter(CGeffect, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedEffectParameter(IntPtr effect, string name);

        //CGparameter cgGetNamedEffectUniformBuffer( CGeffect effect,       const char * blockName );
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedEffectUniformBuffer(IntPtr effect, string blockName);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedParameter(IntPtr program, string parameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedParameterAnnotation(CGparameter, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedParameterAnnotation(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetNamedPass(CGtechnique, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedPass(IntPtr technique, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedPassAnnotation(CGpass, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedPassAnnotation(IntPtr pass, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedProgramAnnotation(CGprogram, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedProgramAnnotation(IntPtr prog, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedProgramParameter(CGprogram prog,  CGenum name_space,  const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedProgramParameter(IntPtr prog, NameSpace nameSpace, string name);

        //CGparameter cgGetNamedProgramUniformBuffer ( CGeffect program,       const char * blockName );
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedProgramUniformBuffer(IntPtr program, string blockName);

        // CGDLL_API CGstate cgGetNamedSamplerState(CGcontext, string name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedSamplerState(IntPtr context, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNamedSamplerStateAssignment(CGparameter, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedSamplerStateAssignment(IntPtr param, string name);

        // CGDLL_API CGstate cgGetNamedState(CGcontext, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedState(IntPtr context, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNamedStateAssignment(CGpass, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedStateAssignment(IntPtr pass, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedStructParameter(CGparameter param, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedStructParameter(IntPtr param, string name);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedSubParameter(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetNamedTechnique(CGeffect, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedTechnique(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedTechniqueAnnotation(CGtechnique, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedTechniqueAnnotation(IntPtr technique, string name);

        //CGparameter cgGetNamedUniformBufferParameter( CGparameter param,  const char * name );
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedUniformBufferParameter(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetNamedUserType(CGhandle handle, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetNamedUserType(IntPtr handle, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNextAnnotation(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextAnnotation(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetNextEffect(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextEffect(IntPtr effect);

        /// <summary>
        ///    Gets a handle to the leaf parameter directly following the specified param.
        /// </summary>
        /// <param name="currentParam">Current Cg parameter.</param>
        /// <returns>Handle to the next param after the current program, null if the current is the last param.</returns>
        // CGDLL_API CGparameter cgGetNextLeafParameter(CGparameter current);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextLeafParameter(IntPtr currentParam);

        /// <summary>
        /// Iterates to next parameter in program.
        /// </summary>
        /// <param name="currentParam">The current parameter.</param>
        /// <returns>The next parameter in the program's internal sequence of parameters.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextParameter(IntPtr currentParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetNextPass(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextPass(IntPtr pass);

        /// <summary>
        ///     Iterate trough programs in a context.
        /// </summary>
        /// <param name="current">
        ///     Current program.
        /// </param>
        /// <returns>
        ///     Next program in context's internal sequence of programs.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextProgram(IntPtr current);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNextState(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextState(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNextStateAssignment(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextStateAssignment(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetNextTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextTechnique(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumConnectedToParameters(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumConnectedToParameters(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumDependentAnnotationParameters(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumDependentAnnotationParameters(IntPtr annotation);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumDependentProgramArrayStateAssignmentParameters(IntPtr sa);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumDependentStateAssignmentParameters(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumDependentStateAssignmentParameters(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumParentTypes(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumParentTypes(ParameterType type);

        //CG_API int CGENTRY cgGetNumProgramDomains(CGprogram program);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumProgramDomains(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumStateEnumerants(IntPtr state);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumSupportedProfiles();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumUserTypes(CGhandle handle);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumUserTypes(IntPtr handle);

        /// <summary>
        /// Gets a parameter's base resource.
        /// </summary>
        /// <param name="param">Parameter to retreive base resource from</param>
        /// <returns>Base resource of a given parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ResourceType cgGetParameterBaseResource(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParameterBaseType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetParameterBaseType(IntPtr param);

        //  CG_API int CGENTRY cgGetParameterBufferIndex(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterBufferIndex(IntPtr param);

        // CG_API int CGENTRY cgGetParameterBufferOffset(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterBufferOffset(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameterclass cgGetParameterClass(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterClass cgGetParameterClass(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterClass cgGetParameterClassEnum(string pString);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterClassString(ParameterClass pc);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterColumns(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterColumns(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGcontext cgGetParameterContext(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterContext(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDefaultValuedc(IntPtr param, int nelements, double[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDefaultValuedr(IntPtr param, int nelements, double[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDefaultValuefc(IntPtr param, int nelements, float[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDefaultValuefr(IntPtr param, int nelements, float[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDefaultValueic(IntPtr param, int nelements, int[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDefaultValueir(IntPtr param, int nelements, int[] vals);

        /// <summary>
        ///    Gets the direction of this parameter, i.e. CG_IN, CG_OUT, CG_INOUT.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's direction.</returns>
        // CGDLL_API CGenum cgGetParameterDirection(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterDirection cgGetParameterDirection(IntPtr param);

        //CG_API CGeffect CGENTRY cgGetParameterEffect(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterEffect(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterIndex(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterIndex(IntPtr param);

        /// <summary>
        ///    Gets the name of the specified program.
        /// </summary>
        /// <param name="param">Handle to the program to query.</param>
        /// <returns>IntPtr that must be converted to an Ansi string via Marshal.PtrToStringAnsi.</returns>
        // CGDLL_API const char *cgGetParameterName(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterName(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParameterNamedType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetParameterNamedType(IntPtr param);

        /// <summary>
        /// Returns an integer that represents the position of a parameter when it was declared within the Cg program.
        /// </summary>
        /// <param name="param">Parameter to retreive it's ordinal number.</param>
        /// <returns>Parameter's ordinal number.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterOrdinalNumber(IntPtr param);

        /// <summary>
        /// Gets program that specified parameter belongs to.
        /// </summary>
        /// <param name="param">Parameter to retreive it's parent program.</param>
        /// <returns>A program given parameter belongs to.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterProgram(IntPtr param);

        /// <summary>
        /// Gets a parameter's resource.
        /// </summary>
        /// <param name="param">Parameter to retreive resource from</param>
        /// <returns>Resource of a given parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ResourceType cgGetParameterResource(IntPtr param);

        /// <summary>
        ///    Retrieves the index of the specifed parameter according to its type and variability.
        /// </summary>
        /// <remarks>
        ///    For example, if the resource for a given parameter is CG_TEXCOORD7,
        ///    cgGetParameterResourceIndex() returns 7.  Also, for uniform params, it equates
        ///    to the constant index that will be used in the resulting program.
        /// </remarks>
        /// <param name="param">
        ///    Handle of the param to query.
        /// </param>
        /// <returns>
        ///    Index of the specified parameter according to its type and variability.
        /// </returns>
        // CGDLL_API unsigned long cgGetParameterResourceIndex(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern uint cgGetParameterResourceIndex(IntPtr param);

        //CG_API const char * CGENTRY cgGetParameterResourceName(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterResourceName(IntPtr param);

        //CG_API long CGENTRY cgGetParameterResourceSize(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterResourceSize(IntPtr param);

        // CG_API CGtype CGENTRY cgGetParameterResourceType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetParameterResourceType(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterRows(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterRows(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterSemantic(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterSettingMode cgGetParameterSettingMode(IntPtr context);

        /// <summary>
        ///    Gets the data type of the specified parameter.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's data type.</returns>
        // CGDLL_API CGtype cgGetParameterType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetParameterType(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuedc(CGparameter param, int n, double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterValuedc(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuedr(CGparameter param, int n, double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterValuedr(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuefc(CGparameter param, int n, float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterValuefc(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuefr(CGparameter param, int n, float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterValuefr(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValueic(CGparameter param, int n, int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterValueic(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValueir(CGparameter param, int n, int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterValueir(IntPtr param, int n, int[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [Obsolete]
        public static extern double[] cgGetParameterValues(IntPtr param, int valueType, int[] nvalues);

        /// <summary>
        ///    Gets the variability of the specified param (i.e, uniform, varying, etc).
        /// </summary>
        /// <param name="param">Handle of the program to query.</param>
        /// <returns>Enum stating the variability of the program.</returns>
        // CGDLL_API CGenum cgGetParameterVariability(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Variability cgGetParameterVariability(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParentType(CGtype type, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetParentType(ParameterType type, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetPassName(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetPassName(IntPtr pass);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetPassProgram(IntPtr pass, Domain domain);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetPassTechnique(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetPassTechnique(IntPtr pass);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProfileType cgGetProfile(string profile);

        // CG_API CGdomain CGENTRY cgGetProfileDomain(CGprofile profile);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Domain cgGetProfileDomain(ProfileType profile);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgGetProfileProperty(ProfileType profile, Query query);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProfileType cgGetProfileSibling(ProfileType profile, Domain domain);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProfileString(ProfileType profile);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramBuffer(IntPtr program, int bufferIndex);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetProgramBufferMaxIndex(ProfileType profile);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetProgramBufferMaxSize(ProfileType profile);

        /// <summary>
        ///     Gets a programs parent context.
        /// </summary>
        /// <param name="prog">
        ///     Program to retreive context from.
        /// </param>
        /// <returns>
        ///     The context a given program belongs to.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramContext(IntPtr prog);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Domain cgGetProgramDomain(IntPtr program);

        //CG_API CGprofile CGENTRY cgGetProgramDomainProfile(CGprogram program, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProfileType cgGetProgramDomainProfile(IntPtr program, int index);

        //CG_API CGprogram CGENTRY cgGetProgramDomainProgram(CGprogram program, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramDomainProgram(IntPtr program, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProgramInput cgGetProgramInput(IntPtr program);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <returns></returns>
        // CGDLL_API char const * const *cgGetProgramOptions(CGprogram prog);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramOptions(IntPtr prog);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProgramOutput cgGetProgramOutput(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetProgramOutputVertices(IntPtr program);

        /// <summary>
        ///     Gets the profile enumeration of the program.
        /// </summary>
        /// <param name="prog">
        ///     Specifies the program.
        /// </param>
        /// <returns>
        ///     The profile enumeration or CG_PROFILE_UNKNOWN if compilation failed.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProfileType cgGetProgramProfile(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGprogram cgGetProgramStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        ///     Gets the specified source from the program.
        /// </summary>
        /// <param name="program">
        ///     Handle to the Cg program.
        /// </param>
        /// <param name="sourceType">
        ///     Type of source to pull, whether original or compiled, etc.
        /// </param>
        /// <returns>
        ///     IntPtr to the string data.  Must be converted using Marshal.PtrToStringAnsi.
        /// </returns>
        // CGDLL_API const char *cgGetProgramString(CGprogram prog, CGenum pname);
        [DllImport(CgNativeLibrary, CallingConvention = Convention, CharSet = CharSet.Auto)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramString(IntPtr program, SourceType sourceType);

        /// <summary>
        /// Gets the resource enumerant assigned to a resource name.
        /// </summary>
        /// <param name="resourceName">Resource's name.</param>
        /// <returns>Resource enumerant.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ResourceType cgGetResource(string resourceName);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetResourceString(ResourceType resource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetSamplerStateAssignmentParameter(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetSamplerStateAssignmentParameter(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetSamplerStateAssignmentState(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetSamplerStateAssignmentState(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetSamplerStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetSamplerStateAssignmentValue(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern CasePolicy cgGetSemanticCasePolicy();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetStateAssignmentIndex(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetStateAssignmentIndex(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetStateAssignmentPass(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateAssignmentPass(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetStateAssignmentState(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateAssignmentState(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateContext(IntPtr state);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateEnumerant(IntPtr state, int index, out int value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateEnumerantName(IntPtr state, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetStateEnumerantValue(CGstate, const char*)
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int cgGetStateEnumerantValue(IntPtr state, string name);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProfileType cgGetStateLatestProfile(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStateName(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateName(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateResetCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern State.CallbackDelegate cgGetStateResetCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateSetCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern State.CallbackDelegate cgGetStateSetCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetStateType(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetStateType(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateValidateCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern State.CallbackDelegate cgGetStateValidateCallback(IntPtr state);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetString(CgAll sname);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringAnnotationValue(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStringAnnotationValue(IntPtr annotation);

        //CG_API const char * const * CGENTRY cgGetStringAnnotationValues(CGannotation ann, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStringAnnotationValues(IntPtr ann, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringParameterValue(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStringParameterValue(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStringStateAssignmentValue(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ProfileType cgGetSupportedProfile(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetTechniqueEffect(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetTechniqueEffect(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetTechniqueName(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetTechniqueName(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetTextureStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetTextureStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetType(const char *type_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetType(string typeString);

        //CG_API CGtype CGENTRY cgGetTypeBase(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetTypeBase(ParameterType type);

        //CG_API CGparameterclass CGENTRY cgGetTypeClass(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterClass cgGetTypeClass(ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgGetTypeSizes(ParameterType type, out int nrows, out int ncols);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetTypeString(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetTypeString(ParameterType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern string cgGetUniformBufferBlockName(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetUniformBufferParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetUserType(CGhandle handle, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern ParameterType cgGetUserType(IntPtr handle, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsAnnotation(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsAnnotation(IntPtr annotation);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool cgIsBuffer(IntPtr buffer);

        /// <summary>
        ///     Given the specified context handle, returns true if it is a valid Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle of the context to check.
        /// </param>
        /// <returns>
        ///     CG_TRUE if valid, CG_FALSE otherwise.
        /// </returns>
        // CGDLL_API CGbool cgIsContext(CGcontext context);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsContext(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsEffect(CGeffect effect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsEffect(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsInterfaceType(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsInterfaceType(ParameterType type);

        /// <summary>
        /// Determines if parameter is valid Cg parameter object.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <returns>CG_TRUE ig parameter is valid Cg parameter object.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParameterGlobal(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsParameterGlobal(IntPtr param);

        /// <summary>
        ///    Queries whether the specified program will be used in the final compiled program.
        /// </summary>
        /// <remarks>
        ///    The compiler may ignore parameters that are not actually used within the program.
        /// </remarks>
        /// <param name="param">Handle to the Cg parameter.</param>
        /// <returns>True if the param is being used, false if not.</returns>
        // CGDLL_API CGbool cgIsParameterReferenced(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsParameterReferenced(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParameterUsed(CGparameter param, CGhandle handle);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsParameterUsed(IntPtr param, IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParentType(CGtype parent, CGtype child);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsParentType(ParameterType parent, int child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsPass(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsPass(IntPtr pass);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool cgIsProfileSupported(ProfileType profile);

        /// <summary>
        ///     Determine if a program handle references a Cg program object.
        /// </summary>
        /// <param name="prog">
        ///     The program handle.
        /// </param>
        /// <returns>
        ///     CG_TRUE if prog references a valid program object.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsProgram(IntPtr prog);

        /// <summary>
        ///     Determines if a program has been compiled.
        /// </summary>
        /// <param name="prog">
        ///     Specifies the program.
        /// </param>
        /// <returns>
        ///     CG_TRUE if specified program has been compiled.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsProgramCompiled(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsState(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsState(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsStateAssignment(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsStateAssignment(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsTechnique(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsTechniqueValidated(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgIsTechniqueValidated(IntPtr technique);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgMapBuffer(IntPtr buffer, BufferAccess access);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        // CGDLL_API void cgResetPassState(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgResetPassState(IntPtr pass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="size"></param>
        // CGDLL_API void cgSetArraySize(CGparameter param, int size);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetArraySize(IntPtr param, int size);

        /// <summary>
        /// 
        /// </summary>
        // CGDLL_API void cgSetAutoCompile(CGcontext context, CGenum flag);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetAutoCompile(IntPtr context, AutoCompileMode flag);

        //CG_API CGbool CGENTRY cgSetBoolAnnotation(CGannotation ann, CGbool value);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetBoolAnnotation(IntPtr annotation, [MarshalAs(UnmanagedType.Bool)] bool value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetBoolArrayStateAssignment(IntPtr stateassignment, bool[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetBoolStateAssignment(IntPtr stateassignment, [MarshalAs(UnmanagedType.Bool)] bool value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetBufferData(IntPtr buffer, int size, IntPtr data);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetBufferSubData(IntPtr buffer, int offset, int size, IntPtr data);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetCompilerIncludeCallback(IntPtr context, CgIncludeCallbackFunc func);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetCompilerIncludeFile(IntPtr context, string name, string filename);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetCompilerIncludeString(IntPtr context, string name, string source);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetContextBehavior(IntPtr context, Behavior behavior);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetEffectName(IntPtr effect, string name);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetEffectParameterBuffer(IntPtr param, IntPtr buffer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        // CGDLL_API void cgSetErrorCallback(CGerrorCallbackFunc func);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetErrorCallback(CgErrorCallbackFuncDelegate func);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="data"></param>
        // CGDLL_API void cgSetErrorHandler(CGerrorHandlerFunc func, void *data);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetErrorHandler(Cg.CgErrorHandlerFuncDelegate func, IntPtr data);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetFloatAnnotation(IntPtr ann, float value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetFloatArrayStateAssignment(IntPtr stateassignment, float[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetFloatStateAssignment(IntPtr stateassignment, float value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetIntAnnotation(IntPtr ann, int value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetIntArrayStateAssignment(IntPtr stateassignment, int[] vals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetIntStateAssignment(IntPtr stateassignment, int value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="listing"></param>
        // CGDLL_API void cgSetLastListing(CGhandle handle, const char *listing);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetLastListing(IntPtr handle, string listing);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern LockingPolicy cgSetLockingPolicy(LockingPolicy lockingPolicy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterdc(CGparameter param, const double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterdc(IntPtr param, [In] double[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterdr(CGparameter param, const double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterdr(IntPtr param, [In] double[] matrix);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterfc(IntPtr param, [In] float[] matrix);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterfr(IntPtr param, [In] float[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameteric(CGparameter param, const int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameteric(IntPtr param, [In] int[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterir(CGparameter param, const int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterir(IntPtr param, [In] int[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="sizes"></param>
        // CGDLL_API void cgSetMultiDimArraySize(CGparameter param, const int *sizes);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMultiDimArraySize(IntPtr param, [In] int[] sizes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1d(CGparameter param, double x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1d(IntPtr param, double x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1f(IntPtr param, float x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1i(CGparameter param, int x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1i(IntPtr param, int x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2d(CGparameter param, double x, double y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2d(IntPtr param, double x, double y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2f(IntPtr param, float x, float y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2i(CGparameter param, int x, int y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2i(IntPtr param, int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        // CGDLL_API void cgSetParameter3d(CGparameter param, double x, double y, double z);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3d(IntPtr param, double x, double y, double z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3f(IntPtr param, float x, float y, float z);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        // CGDLL_API void cgSetParameter3i(CGparameter param, int x, int y, int z);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3i(IntPtr param, int x, int y, int z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        // CGDLL_API void cgSetParameter4d(CGparameter param, double x, double y, double z, double w);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4d(IntPtr param, double x, double y, double z, double w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4f(IntPtr param, float x, float y, float z, float w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        // CGDLL_API void cgSetParameter4i(CGparameter param, int x, int y, int z, int w);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4i(IntPtr param, int x, int y, int z, int w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="semantic"></param>
        // CGDLL_API void cgSetParameterSemantic(CGparameter param, const char *semantic);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterSemantic(IntPtr param, string semantic);

        //CG_API void CGENTRY cgSetParameterSettingMode(CGcontext context, CGenum parameterSettingMode);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterSettingMode(IntPtr context, ParameterSettingMode parameterSettingMode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuedc(CGparameter param, int n, out double vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuedc(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuedr(CGparameter param, int n, const double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuedr(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuefc(CGparameter param, int n, const float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuefc(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuefr(CGparameter param, int n, const float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuefr(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValueic(CGparameter param, int n, const int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValueic(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValueir(CGparameter param, int n, const int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValueir(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="vary"></param>
        // CGDLL_API void cgSetParameterVariability(CGparameter param, CGenum vary);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterVariability(IntPtr param, Variability vary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        // CGDLL_API void cgSetPassProgramParameters(CGprogram);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetPassProgramParameters(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        // CGDLL_API void cgSetPassState(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetPassState(IntPtr pass);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetProgramBuffer(IntPtr program, int bufferIndex, IntPtr buffer);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetProgramOutputVertices(IntPtr handle, int value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetProgramProfile(IntPtr prog, ProfileType profile);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetProgramStateAssignment(IntPtr stateassignment, IntPtr program);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        // CGDLL_API void cgSetSamplerState(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetSamplerState(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetSamplerStateAssignment(IntPtr stateassignment, IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern CasePolicy cgSetSemanticCasePolicy(CasePolicy casePolicy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="set"></param>
        /// <param name="reset"></param>
        /// <param name="validate"></param>
        // CGDLL_API void cgSetStateCallbacks(CGstate, CGstatecallback set, CGstatecallback reset, CGstatecallback validate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetStateCallbacks(IntPtr state, State.CallbackDelegate set, State.CallbackDelegate reset, State.CallbackDelegate validate);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetStateLatestProfile(IntPtr state, ProfileType profile);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetStringAnnotation(IntPtr ann, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="str"></param>
        // CGDLL_API void cgSetStringParameterValue(CGparameter param, const char *str);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetStringParameterValue(IntPtr param, string str);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetStringStateAssignment(IntPtr stateassignment, string value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgSetTextureStateAssignment(IntPtr stateassignment, IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgSetUniformBufferParameter(IntPtr param, IntPtr buffer);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgUnmapBuffer(IntPtr buffer);

        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgUpdatePassParameters(IntPtr pass);

        //CG_API void CGENTRY cgUpdateProgramParameters(CGprogram program);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void cgUpdateProgramParameters(IntPtr program);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgValidateTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cgValidateTechnique(IntPtr technique);

        #endregion Public Static Methods

        #endregion Methods
    }
}