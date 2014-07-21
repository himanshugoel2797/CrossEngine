namespace ExampleBrowser.Examples.CgNet.OpenTK.Basic
{
    using System;

    using ExampleBrowser.Examples.CgNet.OpenTK;

    using global::CgNet;
    using global::CgNet.GL;

    using global::Examples.Helper;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [Example(NodePath = "CgNet/OpenTK/Basic/01 Vertex Program")]
    public class VertexProgram : Example
    {
        #region Fields

        private const string MyVertexProgramFileName = "Data/C2E1v_green.cg";
        private const string MyVertexProgramName = "C2E1v_green";

        private ProfileType myCgVertexProfile;
        private IntPtr myCgVertexProgram;

        #endregion Fields

        #region Constructors

        public VertexProgram()
            : base("01_vertex_program")
        {
        }

        #endregion Constructors

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.0f); /* Blue background */

            this.MyCgContext = Cg.CreateContext();

            CgGL.SetDebugMode(false);
            Cg.SetParameterSettingMode(this.MyCgContext, ParameterSettingMode.Deferred);

            myCgVertexProfile = CgGL.GetLatestProfile(ProfileClass.Vertex);
            CgGL.SetOptimalOptions(myCgVertexProfile);

            this.myCgVertexProgram =
                Cg.CreateProgramFromFile(
                    this.MyCgContext, /* Cg runtime context */
                    ProgramType.Source, /* Program in human-readable form */
                    MyVertexProgramFileName, /* Name of file containing program */
                    myCgVertexProfile, /* Profile: OpenGL ARB vertex program */
                    MyVertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            CgGL.LoadProgram(myCgVertexProgram);
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            CgGL.BindProgram(this.myCgVertexProgram);

            CgGL.EnableProfile(this.myCgVertexProfile);

            /* Rendering code verbatim from Chapter 1, Section 2.4.1 "Rendering
               a Triangle with OpenGL" (page 57). */
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(-0.8f, 0.8f);
            GL.Vertex2(0.8f, 0.8f);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            CgGL.DisableProfile(this.myCgVertexProfile);
            SwapBuffers();
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
            Cg.DestroyProgram(myCgVertexProgram);
            Cg.DestroyContext(this.MyCgContext);
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

        #endregion Methods
    }
}