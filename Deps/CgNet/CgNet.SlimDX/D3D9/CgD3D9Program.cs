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
    using SlimDX.Direct3D9;

    public static class CgD3D9Program
    {
        #region Methods

        #region Public Static Methods

        public static int Bind(this Program program)
        {
            return NativeMethods.cgD3D9BindProgram(program.Handle);
        }

        public static int EnableParameterShadowing(this Program prog, bool enable)
        {
            return NativeMethods.cgD3D9EnableParameterShadowing(prog.Handle, enable);
        }

        public static VertexElement[] GetVertexDeclaration(this Program program)
        {
            var buf = new VertexElement[64];
            return NativeMethods.cgD3D9GetVertexDeclaration(program.Handle, buf) ? buf : null;
        }

        public static bool IsLoaded(this Program program)
        {
            return NativeMethods.cgD3D9IsProgramLoaded(program.Handle);
        }

        public static bool IsParameterShadowingEnabled(this Program program)
        {
            return NativeMethods.cgD3D9IsParameterShadowingEnabled(program.Handle);
        }

        public static int Load(this Program program, bool paramShadowing, int assemFlags)
        {
            return NativeMethods.cgD3D9LoadProgram(program.Handle, paramShadowing, (uint)assemFlags);
        }

        public static int Unbind(this Program prog)
        {
            return NativeMethods.cgD3D9UnbindProgram(prog.Handle);
        }

        public static int Unload(this Program program)
        {
            return NativeMethods.cgD3D9UnloadProgram(program.Handle);
        }

        public static bool ValidateVertexDeclaration(this Program program, VertexElement[] decl)
        {
            return NativeMethods.cgD3D9ValidateVertexDeclaration(program.Handle, decl);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}