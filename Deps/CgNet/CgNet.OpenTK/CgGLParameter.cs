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
    using System.Runtime.InteropServices;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public static class CgGLParameter
    {
        #region Methods

        #region Public Static Methods

        public static void DisableClientState(this Parameter param)
        {
            NativeMethods.cgGLDisableClientState(param.Handle);
        }

        // TODO: TextureParameter
        public static void DisableTexture(this Parameter param)
        {
            NativeMethods.cgGLDisableTextureParameter(param.Handle);
        }

        public static void EnableClientState(this Parameter param)
        {
            NativeMethods.cgGLEnableClientState(param.Handle);
        }

        // TODO: TextureParameter
        public static void EnableTexture(this Parameter param)
        {
            NativeMethods.cgGLEnableTextureParameter(param.Handle);
        }

        public static T Get<T>(this Parameter param)
            where T : struct
        {
            IntPtr param1 = param.Handle;
            GCHandle handle = GCHandle.Alloc(new T(), GCHandleType.Pinned);
            try
            {
                if (typeof(T) == typeof(float))
                {
                    NativeMethods.cgGLGetParameter1f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(double))
                {
                    NativeMethods.cgGLGetParameter1d(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector2))
                {
                    NativeMethods.cgGLGetParameter2f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector2d))
                {
                    NativeMethods.cgGLGetParameter2d(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector3))
                {
                    NativeMethods.cgGLGetParameter3f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector3d))
                {
                    NativeMethods.cgGLGetParameter3d(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector4))
                {
                    NativeMethods.cgGLGetParameter4f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector4d))
                {
                    NativeMethods.cgGLGetParameter4d(param1, handle.AddrOfPinnedObject());
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

        public static void Get(this Parameter param, float[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (values.Length)
                {
                    case 1:
                        NativeMethods.cgGLGetParameter1f(param1, handle.AddrOfPinnedObject());
                        break;
                    case 2:
                        NativeMethods.cgGLGetParameter2f(param1, handle.AddrOfPinnedObject());
                        break;
                    case 3:
                        NativeMethods.cgGLGetParameter3f(param1, handle.AddrOfPinnedObject());
                        break;
                    case 4:
                        NativeMethods.cgGLGetParameter4f(param1, handle.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public static void Get(this Parameter param, double[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle handle = GCHandle.Alloc(values);
            try
            {
                switch (values.Length)
                {
                    case 1:
                        NativeMethods.cgGLGetParameter1d(param1, handle.AddrOfPinnedObject());
                        break;
                    case 2:
                        NativeMethods.cgGLGetParameter2d(param1, handle.AddrOfPinnedObject());
                        break;
                    case 3:
                        NativeMethods.cgGLGetParameter3d(param1, handle.AddrOfPinnedObject());
                        break;
                    case 4:
                        NativeMethods.cgGLGetParameter4d(param1, handle.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public static void GetArray(this Parameter param, int offset, int nelements, float[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle g = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (values.Length / nelements)
                {
                    case 1:
                        NativeMethods.cgGLGetParameterArray1f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 2:
                        NativeMethods.cgGLGetParameterArray2f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 3:
                        NativeMethods.cgGLGetParameterArray3f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 4:
                        NativeMethods.cgGLGetParameterArray4f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                g.Free();
            }
        }

        public static void GetArray(this Parameter param, int offset, int nelements, double[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle g = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (values.Length / nelements)
                {
                    case 1:
                        NativeMethods.cgGLGetParameterArray1d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 2:
                        NativeMethods.cgGLGetParameterArray2d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 3:
                        NativeMethods.cgGLGetParameterArray3d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 4:
                        NativeMethods.cgGLGetParameterArray4d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                g.Free();
            }
        }

        public static void GetMatrix(this Parameter param, out Matrix4 value)
        {
            value = CgGL.GetMatrixParameter<Matrix4>(param.Handle, Cg.DefaultMatrixOrder);
        }

        public static void GetMatrix(this Parameter param, out Matrix4d value)
        {
            value = CgGL.GetMatrixParameter<Matrix4d>(param.Handle, Cg.DefaultMatrixOrder);
        }

        public static T GetMatrix<T>(this Parameter param)
            where T : struct
        {
            return CgGL.GetMatrixParameter<T>(param.Handle, Cg.DefaultMatrixOrder);
        }

        public static T GetMatrix<T>(this Parameter param, MatrixOrder order)
            where T : struct
        {
            return CgGL.GetMatrixParameter<T>(param.Handle, order);
        }

        public static void GetMatrixArray(this Parameter param, int offset, int nelements, out Matrix4[] values)
        {
            values = CgGL.GetMatrixParameterArray<Matrix4>(param.Handle, offset, nelements, Cg.DefaultMatrixOrder);
        }

        public static void GetMatrixArray(this Parameter param, int offset, int nelements, out Matrix4d[] values)
        {
            values = CgGL.GetMatrixParameterArray<Matrix4d>(param.Handle, offset, nelements, Cg.DefaultMatrixOrder);
        }

        public static T[] GetMatrixArray<T>(this Parameter param, int offset, int nelements)
            where T : struct
        {
            return CgGL.GetMatrixParameterArray<T>(param.Handle, offset, nelements, Cg.DefaultMatrixOrder);
        }

        public static T[] GetMatrixArray<T>(this Parameter param, int offset, int nelements, MatrixOrder order)
            where T : struct
        {
            return CgGL.GetMatrixParameterArray<T>(param.Handle, offset, nelements, order);
        }

        public static int GetTextureEnum(this Parameter param)
        {
            return NativeMethods.cgGLGetTextureEnum(param.Handle);
        }

        public static int GetTextureParameter(this Parameter param)
        {
            return NativeMethods.cgGLGetTextureParameter(param.Handle);
        }

        public static void Set(this Parameter param, double x)
        {
            NativeMethods.cgGLSetParameter1d(param.Handle, x);
        }

        public static void Set(this Parameter param, double[] v)
        {
            IntPtr param1 = param.Handle;
            switch (v.Length)
            {
                case 1:
                    NativeMethods.cgGLSetParameter1dv(param1, v);
                    break;
                case 2:
                    NativeMethods.cgGLSetParameter2dv(param1, v);
                    break;
                case 3:
                    NativeMethods.cgGLSetParameter3dv(param1, v);
                    break;
                case 4:
                    NativeMethods.cgGLSetParameter4dv(param1, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void Set(this Parameter param, float[] v)
        {
            IntPtr param1 = param.Handle;
            switch (v.Length)
            {
                case 1:
                    NativeMethods.cgGLSetParameter1fv(param1, v);
                    break;
                case 2:
                    NativeMethods.cgGLSetParameter2fv(param1, v);
                    break;
                case 3:
                    NativeMethods.cgGLSetParameter3fv(param1, v);
                    break;
                case 4:
                    NativeMethods.cgGLSetParameter4fv(param1, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void Set(this Parameter param, float x)
        {
            NativeMethods.cgGLSetParameter1f(param.Handle, x);
        }

        public static void Set(this Parameter param, double x, double y)
        {
            NativeMethods.cgGLSetParameter2d(param.Handle, x, y);
        }

        public static void Set(this Parameter param, float x, float y)
        {
            NativeMethods.cgGLSetParameter2f(param.Handle, x, y);
        }

        public static void Set(this Parameter param, double x, double y, double z)
        {
            NativeMethods.cgGLSetParameter3d(param.Handle, x, y, z);
        }

        public static void Set(this Parameter param, float x, float y, float z)
        {
            NativeMethods.cgGLSetParameter3f(param.Handle, x, y, z);
        }

        public static void Set(this Parameter param, double x, double y, double z, double w)
        {
            NativeMethods.cgGLSetParameter4d(param.Handle, x, y, z, w);
        }

        public static void Set(this Parameter param, float x, float y, float z, float w)
        {
            NativeMethods.cgGLSetParameter4f(param.Handle, x, y, z, w);
        }

        public static void Set(this Parameter param, Vector2 v)
        {
            Vector2 v1 = v;
            NativeMethods.cgGLSetParameter2f(param.Handle, v1.X, v1.Y);
        }

        public static void Set(this Parameter param, Vector2d v)
        {
            Vector2d v1 = v;
            NativeMethods.cgGLSetParameter2d(param.Handle, v1.X, v1.Y);
        }

        public static void Set(this Parameter param, Vector3 v)
        {
            Vector3 v1 = v;
            NativeMethods.cgGLSetParameter3f(param.Handle, v1.X, v1.Y, v1.Z);
        }

        public static void Set(this Parameter param, Vector3d v)
        {
            Vector3d v1 = v;
            NativeMethods.cgGLSetParameter3d(param.Handle, v1.X, v1.Y, v1.Z);
        }

        public static void Set(this Parameter param, Vector4 v)
        {
            Vector4 v1 = v;
            NativeMethods.cgGLSetParameter4f(param.Handle, v1.X, v1.Y, v1.Z, v1.W);
        }

        public static void Set(this Parameter param, Vector4d v)
        {
            Vector4d v1 = v;
            NativeMethods.cgGLSetParameter4d(param.Handle, v1.X, v1.Y, v1.Z, v1.W);
        }

        public static void SetArray(this Parameter param, int offset, int nelements, float[] values)
        {
            IntPtr param1 = param.Handle;
            switch (values.Length / nelements)
            {
                case 1:
                    NativeMethods.cgGLSetParameterArray1f(param1, offset, nelements, values);
                    break;
                case 2:
                    NativeMethods.cgGLSetParameterArray2f(param1, offset, nelements, values);
                    break;
                case 3:
                    NativeMethods.cgGLSetParameterArray3f(param1, offset, nelements, values);
                    break;
                case 4:
                    NativeMethods.cgGLSetParameterArray4f(param1, offset, nelements, values);
                    break;
            }
        }

        public static void SetArray(this Parameter param, int offset, int nelements, double[] values)
        {
            IntPtr param1 = param.Handle;
            switch (values.Length / nelements)
            {
                case 1:
                    NativeMethods.cgGLSetParameterArray1d(param1, offset, nelements, values);
                    break;
                case 2:
                    NativeMethods.cgGLSetParameterArray2d(param1, offset, nelements, values);
                    break;
                case 3:
                    NativeMethods.cgGLSetParameterArray3d(param1, offset, nelements, values);
                    break;
                case 4:
                    NativeMethods.cgGLSetParameterArray4d(param1, offset, nelements, values);
                    break;
            }
        }

        public static void SetMatrix(this Parameter param, Matrix4 matrix)
        {
            SetMatrix(param, matrix, Cg.DefaultMatrixOrder);
        }

        public static void SetMatrix(this Parameter param, Matrix4 matrix, MatrixOrder order)
        {
            switch (order)
            {
                case MatrixOrder.ColumnMajor:
                    NativeMethods.cgGLSetMatrixParameterfc(param.Handle, ref matrix);
                    break;
                case MatrixOrder.RowMajor:
                    NativeMethods.cgGLSetMatrixParameterfr(param.Handle, ref matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public static void SetMatrix(this Parameter param, Matrix4d matrix)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix, Cg.DefaultMatrixOrder);
        }

        public static void SetMatrix(this Parameter param, Matrix4d matrix, MatrixOrder order)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix, order);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4d[] matrices)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, Cg.DefaultMatrixOrder);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4[] matrices)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, Cg.DefaultMatrixOrder);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4d[] matrices, MatrixOrder order)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, order);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4[] matrices, MatrixOrder order)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, order);
        }

        public static void SetPointer(this Parameter param, int fsize, DataType type, int stride, IntPtr pointer)
        {
            NativeMethods.cgGLSetParameterPointer(param.Handle, fsize, type, stride, pointer);
        }

        public static void SetStateMatrix(this Parameter param, MatrixType matrix, MatrixTransform transform)
        {
            NativeMethods.cgGLSetStateMatrixParameter(param.Handle, matrix, transform);
        }

        // TODO: TextureParameter
        public static void SetTexture(this Parameter param, int texobj)
        {
            NativeMethods.cgGLSetTextureParameter(param.Handle, texobj);
        }

        public static void SetupSampler(this Parameter param, int texobj)
        {
            NativeMethods.cgGLSetupSampler(param.Handle, texobj);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}