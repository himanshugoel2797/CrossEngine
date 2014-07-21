namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using ExampleBrowser.Data;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    using Glu = global::OpenTK.Graphics.Glu;

    [ExampleDescription(NodePath = "OpenTK/Basic/22 Specular Bump Map")]
    public class SpecularBumpMap : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/C8E4f_specSurf.cg";
        private const string FragmentProgramName = "C8E4f_specSurf";
        const float my2Pi = 2.0f * 3.14159265f;
        private const string VertexProgramFileName = "Data/C8E3v_specWall.cg";
        private const string VertexProgramName = "C8E3v_specWall";

        private readonly int[] texObj = new int[2];

        static float eyeAngle = 0; /* Angle in radians eye rotates around scene. */
        static float eyeHeight = 0; /* Vertical height of light. */
        static float lightAngle = 4.0f; /* Angle light rotates around scene. */

        private Parameter myCgFragmentParam_ambient;
        private Parameter myCgFragmentParam_LMd;
        private Parameter myCgFragmentParam_LMs;
        private Parameter myCgFragmentParam_normalizeCube;
        private Parameter myCgFragmentParam_normalizeCube2;
        private Parameter myCgFragmentParam_normalMap;
        private Parameter myCgVertexParam_eyePosition;
        private Parameter myCgVertexParam_lightPosition;
        private Parameter myCgVertexParam_modelViewProj;
        private ProfileType vertexProfile, fragmentProfile;
        private Program vertexProgram, fragmentProgram;

        #endregion Fields

        #region Constructors

        public SpecularBumpMap()
            : base("22_specular_bump_map")
        {
        }

        #endregion Constructors

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void DoRender(FrameEventArgs e)
        {
            float[] lightPosition = {
                12.5f * (float)Math.Sin(lightAngle),
                12.5f * (float)Math.Cos(lightAngle),
                4
            };

            float[] eyePosition = {
                20f * (float)Math.Sin(eyeAngle),
                eyeHeight,
                20 * (float)Math.Cos(eyeAngle)
            };

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            Glu.LookAt(
                eyePosition[0], eyePosition[1], eyePosition[2],
                0.0, 0.0, 0.0, /* XYZ view center */
                0.0, 1.0, 0.0); /* Up is in positive Y direction */

            vertexProgram.Bind();

            myCgVertexParam_modelViewProj.SetStateMatrix(MatrixType.ModelviewProjectionMatrix, MatrixTransform.MatrixIdentity);

            myCgVertexParam_lightPosition.Set3(lightPosition);
            myCgVertexParam_eyePosition.Set3(eyePosition);

            vertexProfile.EnableProfile();
            fragmentProgram.Bind();
            myCgFragmentParam_normalMap.EnableTexture();
            myCgFragmentParam_normalizeCube.EnableTexture();

            fragmentProfile.EnableProfile();

            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();

            GL.Begin(BeginMode.Quads);
            /* Counter clockwise (GL_CCW) winding */
            GL.TexCoord2(0f,0f); GL.Vertex2(-7f,-7f);
            GL.TexCoord2(1f,0f); GL.Vertex2( 7f,-7f);
            GL.TexCoord2(1f,1f); GL.Vertex2( 7f, 7f);
            GL.TexCoord2(0f,1f); GL.Vertex2(-7f, 7f);
            GL.End();

            vertexProfile.DisableProfile();
            fragmentProfile.DisableProfile();
            
            /*** Render light as white ball using fixed function pipe ***/
            GL.Translate(lightPosition[0], lightPosition[1], lightPosition[2]);
                  GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Color3(0.8f, 0.8f, 0.1f); /* yellow */
            NativeMethods.glutSolidSphere(0.4f, 12, 12);

            this.SwapBuffers();
        }

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f); /* Blue background */
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1); /* Tightly packed texture data. */

            GL.GenTextures(2, texObj);

            GL.BindTexture(TextureTarget.Texture2D, texObj[1]);
            /* Load each mipmap level of range-compressed 128x128 brick normal
               map texture. */
            unsafe
            {
                fixed (byte* b = ImageBrick.Array)
                {
                    byte* image = b;

                    int size;
                    int level;
                    for (size = 128, level = 0;
                         size > 0;
                         image += 3 * size * size, size /= 2, level++)
                    {
                        GL.TexImage2D(TextureTarget.Texture2D, level,
                                      PixelInternalFormat.Rgba8, size, size, 0,
                                      PixelFormat.Rgb, PixelType.UnsignedByte, new IntPtr(image));
                    }
                }
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.LinearMipmapLinear);

            GL.BindTexture(TextureTarget.TextureCubeMap, texObj[0]);
            /* Load each 32x32 face (without mipmaps) of range-compressed "normalize
               vector" cube map. */
            unsafe
            {
                fixed (byte* b = ImageNormcm.Array)
                {
                    byte* image = b;

                    int face;
                    for (face = 0;
                         face < 6;
                         face++, image += 3 * 32 * 32)
                    {
                        GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + face, 0,
                                      PixelInternalFormat.Rgba8, 32, 32, 0,
                                      PixelFormat.Rgb, PixelType.UnsignedByte, new IntPtr(image));
                    }
                }
            }

            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)All.ClampToEdge);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)All.ClampToEdge);

            this.CgContext = CgNet.Context.Create();
            CgGL.SetDebugMode(false);
            this.CgContext.ParameterSettingMode = ParameterSettingMode.Deferred;
            this.CgContext.SetManageTextureParameters(true);

            vertexProfile = ProfileClass.Vertex.GetLatestProfile();
            vertexProfile.SetOptimalOptions();

            vertexProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    VertexProgramFileName, /* Name of file containing program */
                    vertexProfile, /* Profile: OpenGL ARB vertex program */
                    VertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            vertexProgram.Load();

            this.myCgVertexParam_lightPosition =
                vertexProgram.GetNamedParameter("lightPosition");

            this.myCgVertexParam_eyePosition =
                vertexProgram.GetNamedParameter("eyePosition");

            this.myCgVertexParam_modelViewProj =
                vertexProgram.GetNamedParameter("modelViewProj");

            fragmentProfile = ProfileClass.Fragment.GetLatestProfile();
            fragmentProfile.SetOptimalOptions();

            fragmentProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    FragmentProgramFileName, /* Name of file containing program */
                    fragmentProfile, /* Profile: OpenGL ARB vertex program */
                    FragmentProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            fragmentProgram.Load();

            myCgFragmentParam_ambient =
                fragmentProgram.GetNamedParameter("ambient");
            myCgFragmentParam_ambient.Set(0.2f);

            myCgFragmentParam_LMd =
                fragmentProgram.GetNamedParameter("LMd");
            myCgFragmentParam_LMd.Set(0.8f, 0.7f, 0.2f);

            myCgFragmentParam_LMs =
                fragmentProgram.GetNamedParameter("LMs");
            myCgFragmentParam_LMs.Set(0.5f, 0.5f, 0.8f);

            myCgFragmentParam_normalMap =
                fragmentProgram.GetNamedParameter("normalMap");

            myCgFragmentParam_normalizeCube =
                fragmentProgram.GetNamedParameter("normalizeCube");

            myCgFragmentParam_normalizeCube2 =
                fragmentProgram.GetNamedParameter("normalizeCube2");

            myCgFragmentParam_normalMap.SetTexture(texObj[1]);
            myCgFragmentParam_normalizeCube.SetTexture(texObj[0]);
            myCgFragmentParam_normalizeCube2.SetTexture(texObj[0]);
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            double aspectRatio = (float)this.Width / this.Height;
            double fieldOfView = 75.0; /* Degrees */

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Glu.Perspective(fieldOfView, aspectRatio,
                            0.1, /* Z near */
                            100.0); /* Z far */
            GL.MatrixMode(MatrixMode.Modelview);

            GL.Viewport(0, 0, this.Width, this.Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            vertexProgram.Dispose();
            fragmentProgram.Dispose();
            this.CgContext.Dispose();
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            lightAngle += 0.008f; /* Add a small angle (in radians). */
            if (lightAngle > my2Pi)
            {
                lightAngle -= my2Pi;
            }

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}