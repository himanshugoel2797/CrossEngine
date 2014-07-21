namespace ExampleBrowser.Examples.OpenTK.Advanced
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Advanced/gs_simple")]
    public class GsSimple : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/gs_simple.cg";
        private const string FragmentProgramName = "fragment_passthru";
        private const string GeometryProgramFileName = "Data/gs_simple.cg";
        private const string GeometryProgramName = "geometry_passthru";
        private const string VertexProgramFileName = "Data/gs_simple.cg";
        private const string VertexProgramName = "vertex_passthru";

        private Program combinedProgram;
        private ProfileType fragmentProfile;
        private Program fragmentProgram;
        private ProfileType geometryProfile;
        private Program geometryProgram;
        private ProfileType vertexProfile;
        private Program vertexProgram;

        #endregion Fields

        #region Constructors

        public GsSimple()
            : base("gs_simple")
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

            vertexProfile.EnableProfile();
            geometryProfile.EnableProfile();
            fragmentProfile.EnableProfile();

            if (combinedProgram != null)
            {
                combinedProgram.Bind();
            }
            else
            {
                vertexProgram.Bind();
                geometryProgram.Bind();
                fragmentProgram.Bind();
            }

            DrawStars();

            vertexProfile.DisableProfile();
            geometryProfile.DisableProfile();
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

            geometryProfile = CgGL.GetLatestProfile(ProfileClass.Geometry);
            if (geometryProfile == ProfileType.Unknown)
            {
                if (ProfileType.GlslG.IsProfileSupported())
                    geometryProfile = ProfileType.GlslG;
                else
                {
                    Environment.Exit(0);
                }
            }

            CgGL.SetOptimalOptions(geometryProfile);

            geometryProgram =
             Program.CreateFromFile(
                CgContext,                /* Cg runtime context */
                ProgramType.Source,                  /* Program in human-readable form */
                GeometryProgramFileName,  /* Name of file containing program */
                geometryProfile,        /* Profile: OpenGL ARB geometry program */
                GeometryProgramName,      /* Entry function name */
                null);                      /* No extra compiler options */

            vertexProfile = ProfileClass.Vertex.GetLatestProfile();
            if (geometryProfile == ProfileType.GlslG)
            {
                vertexProfile = ProfileType.GlslV;
            }

            vertexProfile.SetOptimalOptions();

            vertexProgram =
               Program.CreateFromFile(
                 CgContext,              /* Cg runtime context */
                 ProgramType.Source,                /* Program in human-readable form */
                 VertexProgramFileName,  /* Name of file containing program */
                 vertexProfile,        /* Profile: OpenGL ARB vertex program */
                 VertexProgramName,      /* Entry function name */
                 null);                    /* No extra compiler options */

            fragmentProfile = ProfileClass.Fragment.GetLatestProfile();
            if (geometryProfile == ProfileType.GlslG)
            {
                fragmentProfile = ProfileType.GlslF;
            }

            fragmentProfile.SetOptimalOptions();

            fragmentProgram =
              Program.CreateFromFile(
                CgContext,                /* Cg runtime context */
                ProgramType.Source,                  /* Program in human-readable form */
                FragmentProgramFileName,  /* Name of file containing program */
                fragmentProfile,        /* Profile: OpenGL ARB fragment program */
                FragmentProgramName,      /* Entry function name */
                null);                      /* No extra compiler options */

            if (vertexProfile == ProfileType.GlslV
                && geometryProfile == ProfileType.GlslG
                && fragmentProfile == ProfileType.GlslF)
            {
                /* Combine programs for GLSL... */
                combinedProgram = Program.Combine(vertexProgram, geometryProgram, fragmentProgram);
                combinedProgram.Load();
            }
            else
            {
                /* ...otherwise load programs orthogonally */
                vertexProgram.Load();
                geometryProgram.Load();
                fragmentProgram.Load();
            }
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
            geometryProgram.Dispose();
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

        private static void drawStar(float x, float y,
            int starPoints, float R, float r,
            float[] color)
        {
            int i;
            double piOverStarPoints = 3.14159 / starPoints,
                   angle = 0.0;

            GL.Begin(BeginMode.TriangleFan);
            GL.Color3(1f, 1f, 1f);
            GL.Vertex2(x, y);  /* Center of star */
            GL.Color3(color);

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

        #endregion Private Static Methods

        #region Private Methods

        private void DrawStars()
        {
            float[]
                red = { 1, 0, 0 },
                green = { 0, 1, 0 },
                blue = { 0, 0, 1 },
                cyan = { 0, 1, 1 },
                yellow = { 1, 1, 0 },
                gray = { 0.5f, 0.5f, 0.5f };

            /*                     star    outer   inner  */
            /*        x      y     Points  radius  radius */
            /*       =====  =====  ======  ======  ====== */
            drawStar(-0.1f, 0, 5, 0.5f, 0.2f, red);
            drawStar(-0.84f, 0.1f, 5, 0.3f, 0.12f, green);
            drawStar(0.92f, -0.5f, 5, 0.25f, 0.11f, blue);
            drawStar(0.3f, 0.97f, 5, 0.3f, 0.1f, cyan);
            drawStar(0.94f, 0.3f, 5, 0.5f, 0.2f, yellow);
            drawStar(-0.97f, -0.8f, 5, 0.6f, 0.2f, gray);
        }

        #endregion Private Methods

        #endregion Methods
    }
}