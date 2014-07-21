namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Basic/02 Vertex And Fragment Program")]
    public class VertexAndFragmentProgram : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/C2E2f_passthru.cg";
        private const string FragmentProgramName = "C2E2f_passthru";
        private const string VertexProgramFileName = "Data/C2E1v_green.cg";
        private const string VertexProgramName = "C2E1v_green";

        private ProfileType fragmentProfile;
        private Program fragmentProgram;
        private ProfileType vertexProfile;
        private Program vertexProgram;

        #endregion Fields

        #region Constructors

        public VertexAndFragmentProgram()
            : base("02_vertex_and_fragment_program")
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

            vertexProgram.Bind();
            vertexProfile.EnableProfile();

            fragmentProgram.Bind();
            fragmentProfile.EnableProfile();

            DrawStars();

            vertexProfile.DisableProfile();
            fragmentProfile.DisableProfile();
            SwapBuffers();
        }

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f); /* Blue background */

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
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

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
            if (Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        private static void DrawStar(float x, float y, int starPoints, float R, float r)
        {
            int i;
            double piOverStarPoints = 3.14159 / starPoints,
                   angle = 0.0;

            GL.Begin(BeginMode.TriangleFan);
            GL.Vertex2(x, y); /* Center of star */
            /* Emit exterior vertices for star's points. */
            for (i = 0; i < starPoints; i++)
            {
                GL.Vertex2(x + R * Math.Cos(angle), y + R * Math.Sin(angle));
                angle += piOverStarPoints;
                GL.Vertex2(x + r * Math.Cos(angle), y + r * Math.Sin(angle));
                angle += piOverStarPoints;
            }
            /* End by repeating first exterior vertex of star. */
            angle = 0;
            GL.Vertex2(x + R * Math.Cos(angle), y + R * Math.Sin(angle));
            GL.End();
        }

        private static void DrawStars()
        {
            /*                     star    outer   inner  */
            /*        x      y     Points  radius  radius */
            /*       =====  =====  ======  ======  ====== */
            DrawStar(-0.1f, 0, 5, 0.5f, 0.2f);
            DrawStar(-0.84f, 0.1f, 5, 0.3f, 0.12f);
            DrawStar(0.92f, -0.5f, 5, 0.25f, 0.11f);
            DrawStar(0.3f, 0.97f, 5, 0.3f, 0.1f);
            DrawStar(0.94f, 0.3f, 5, 0.5f, 0.2f);
            DrawStar(-0.97f, -0.8f, 5, 0.6f, 0.2f);
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}