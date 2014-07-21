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

    using SlimDX.Direct3D9;

    public static class CgD3D9Parameter
    {
        #region Methods

        #region Public Static Methods

        public static BaseTexture GetTextureParameter(this Parameter param)
        {
            return (BaseTexture)Resource.FromPointer(NativeMethods.cgD3D9GetTextureParameter(param.Handle));
        }

        public static int SetSamplerState(this Parameter param, SlimDX.Direct3D9.SamplerState type, int value)
        {
            return NativeMethods.cgD3D9SetSamplerState(param.Handle, type, (uint)value);
        }

        public static int SetTexture(this Parameter param, BaseTexture tex)
        {
            return NativeMethods.cgD3D9SetTexture(param.Handle, tex.ComPointer);
        }

        public static void SetTextureParameter(this Parameter param, BaseTexture tex)
        {
            NativeMethods.cgD3D9SetTextureParameter(param.Handle, tex.ComPointer);
        }

        public static int SetTextureWrapMode(this Parameter param, int value)
        {
            return NativeMethods.cgD3D9SetTextureWrapMode(param.Handle, (uint)value);
        }

        public static int SetUniform(this Parameter param, float[] floats)
        {
            return NativeMethods.cgD3D9SetUniform(param.Handle, floats);
        }

        public static int SetUniformArray(this Parameter param, int offset, int numItems, IntPtr values)
        {
            return NativeMethods.cgD3D9SetUniformArray(param.Handle, (uint)offset, (uint)numItems, values);
        }

        public static int SetUniformMatrix(this Parameter param, SlimDX.Matrix matrix)
        {
            return NativeMethods.cgD3D9SetUniformMatrix(param.Handle, matrix);
        }

        public static int SetUniformMatrixArray(this Parameter param, int offset, SlimDX.Matrix[] matrices)
        {
            return NativeMethods.cgD3D9SetUniformMatrixArray(param.Handle, (uint)offset, (uint)matrices.Length, matrices);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}