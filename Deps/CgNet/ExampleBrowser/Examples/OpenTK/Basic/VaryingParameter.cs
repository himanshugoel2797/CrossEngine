namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Basic/04 Varying Parameter")]
    public class VaryingParameter : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/C2E2f_passthru.cg";
        private const string FragmentProgramName = "C2E2f_passthru";
        private const string VertexProgramFileName = "Data/C3E2v_varying.cg";
        private const string VertexProgramName = "C3E2v_varying";

        private ProfileType fragmentProfile;
        private Program fragmentProgram;
        private ProfileType vertexProfile;
        private Program vertexProgram;

        #endregion Fields

        #region Constructors

        public VaryingParameter()
            : base("04_varying_parameter")
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

            GL.Begin(BeginMode.Triangles);
            GL.Color3(1f, 0f, 0f); /* Red */
            GL.Vertex2(-0.8f, 0.8f);

            GL.Color3(0f, 1f, 0f); /* Green */
            GL.Vertex2(0.8f, 0.8f);

            GL.Color3(0f, 0f, 1f); /* Blue */
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            vertexProfile.DisableProfile();
            fragmentProfile.DisableProfile();
            this.SwapBuffers();
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
            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}