namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using ExampleBrowser.Data;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Basic/07 Two Texture Accesses")]
    public class TwoTextureAccesses : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/C3E6f_twoTextures.cg";
        private const string FragmentProgramName = "C3E6f_twoTextures";
        private const string VertexProgramFileName = "Data/C3E5v_twoTextures.cg";
        private const string VertexProgramName = "C3E5v_twoTextures";

        private Parameter fragmentParamDecal;
        private ProfileType fragmentProfile;
        private Program fragmentProgram;
        private float mySeparation = 0.1f,
                      mySeparationVelocity = 0.005f;
        private Parameter vertexParamLeftSeparation, vertexParamRightSeparation;
        private ProfileType vertexProfile;
        private Program vertexProgram;

        #endregion Fields

        #region Constructors

        public TwoTextureAccesses()
            : base("07_two_texture_accesses")
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (mySeparation > 0)
            {
                /* Separate in the horizontal direction. */
                this.vertexParamLeftSeparation.Set(-mySeparation, 0);
                this.vertexParamRightSeparation.Set(mySeparation, 0);
            }
            else
            {
                /* Separate in the vertical direction. */
                this.vertexParamLeftSeparation.Set(0, -mySeparation);
                this.vertexParamRightSeparation.Set(0, mySeparation);
            }

            vertexProgram.Bind();

            vertexProfile.EnableProfile();

            fragmentProgram.Bind();

            fragmentProfile.EnableProfile();

            this.fragmentParamDecal.EnableTexture();

            GL.Begin(BeginMode.Triangles);
            GL.TexCoord2(0, 0);
            GL.Vertex2(-0.8f, 0.8f);

            GL.TexCoord2(1, 0);
            GL.Vertex2(0.8f, 0.8f);

            GL.TexCoord2(0.5f, 1);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            vertexProfile.EnableProfile();

            fragmentProfile.DisableProfile();

            this.fragmentParamDecal.DisableTexture();

            this.SwapBuffers();
        }

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f); /* Blue background */

            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1); /* Tightly packed texture data. */
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, 666);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb8, 128, 128, 0,
                          PixelFormat.Rgb, PixelType.UnsignedByte, ImageDemon.Array);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

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

            this.vertexParamLeftSeparation =
                vertexProgram.GetNamedParameter("leftSeparation");
            this.vertexParamRightSeparation =
                vertexProgram.GetNamedParameter("rightSeparation");

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

            this.fragmentParamDecal =
                fragmentProgram.GetNamedParameter("decal");

            this.fragmentParamDecal.SetTexture(666);
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
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
            if (mySeparation > 0.4f)
            {
                mySeparationVelocity = -0.005f;
            }
            else if (mySeparation < -0.4f)
            {
                mySeparationVelocity = 0.005f;
            }
            mySeparation += mySeparationVelocity;

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}