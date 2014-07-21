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

    [ExampleDescription(NodePath = "OpenTK/Basic/21 Bump Map Wall")]
    public class BumpMapWall : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/C8E2f_bumpSurf.cg";
        private const string FragmentProgramName = "C8E2f_bumpSurf";
        private const string VertexProgramFileName = "Data/C8E1v_bumpWall.cg";
        private const string VertexProgramName = "C8E1v_bumpWall";

        private readonly int[] texObj = new int[2];

        private Parameter fragmentParamNormalizeCube;
        private Parameter fragmentParamNormalMap;
        private ProfileType fragmentProfile;
        private Program fragmentProgram;
        private float my2Pi = 2.0f * 3.14159265358979323846f;
        private float myLightAngle = 4.0f; /* Angle light rotates around scene. */
        private Parameter vertexParamLightPosition;
        private Parameter vertexParamModelViewProj;
        private ProfileType vertexProfile;
        private Program vertexProgram;

        #endregion Fields

        #region Constructors

        public BumpMapWall()
            : base("21_bump_map_wall")
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
                12.5f * (float)Math.Sin(this.myLightAngle),
                12.5f * (float)Math.Cos(this.myLightAngle),
                4
            };

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            Glu.LookAt(
                0.0, 0.0, 20.0,
                0.0, 0.0, 0.0, /* XYZ view center */
                0.0, 1.0, 0.0); /* Up is in positive Y direction */

            vertexProgram.Bind();

            this.vertexParamModelViewProj.SetStateMatrix(MatrixType.ModelviewProjectionMatrix, MatrixTransform.MatrixIdentity);

            this.vertexParamLightPosition.Set(lightPosition);

            vertexProfile.EnableProfile();

            fragmentProgram.Bind();

            this.fragmentParamNormalMap.EnableTexture();
            this.fragmentParamNormalizeCube.EnableTexture();

            fragmentProfile.EnableProfile();

            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();
            
            GL.Begin(BeginMode.Quads);
            /* Counter clockwise (GL_CCW) winding */
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(-7f, -7f);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(7f, -7f);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(7f, 7f);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(-7f, 7f);
            GL.End();

            fragmentParamNormalizeCube.DisableTexture();
            fragmentParamNormalMap.DisableTexture();
            
            vertexProfile.DisableProfile();
            fragmentProfile.DisableProfile();
            
            /*** Render light as white ball using fixed function pipe ***/
            GL.Translate(lightPosition[0], lightPosition[1], lightPosition[2]);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Color3(0.8, 0.8, 0.1); /* yellow */
            NativeMethods.glutSolidSphere(0.4, 12, 12);

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

            this.vertexParamLightPosition =
                vertexProgram.GetNamedParameter("lightPosition");

            this.vertexParamModelViewProj =
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

            this.fragmentParamNormalMap =
                fragmentProgram.GetNamedParameter("normalMap");

            this.fragmentParamNormalizeCube =
                fragmentProgram.GetNamedParameter("normalizeCube");

            this.fragmentParamNormalMap.SetTexture(texObj[1]);

            this.fragmentParamNormalizeCube.SetTexture(texObj[0]);
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
            this.myLightAngle += 0.008f; /* Add a small angle (in radians). */
            if (this.myLightAngle > my2Pi)
            {
                this.myLightAngle -= my2Pi;
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