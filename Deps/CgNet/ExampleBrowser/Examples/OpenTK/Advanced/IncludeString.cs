namespace ExampleBrowser.Examples.OpenTK.Advanced
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    using OpenTK;

    [ExampleDescription(NodePath = "OpenTK/Advanced/Inclusion")]
    public class IncludeString : Example
    {
        #region Fields

        private static readonly string[] Args = { "-I", "shader" };

        private ProfileType vertexProfile;
        private Program vertexProgram;

        #endregion Fields

        #region Constructors

        public IncludeString()
            : base("inclusion")
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

            /* Rendering code verbatim from Chapter 1, Section 2.4.1 "Rendering
               a Triangle with OpenGL" (page 57). */
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(-0.8f, 0.8f);
            GL.Vertex2(0.8f, 0.8f);
            GL.Vertex2(0.0f, -0.8f);
            GL.End();

            vertexProfile.DisableProfile();
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

            this.CgContext.SetCompilerIncludeString("shader/output.cg",
            @"
            struct Output {
                float4 position : POSITION;
                float3 color    : COLOR;
            };");

            this.CgContext.SetCompilerIncludeString("shader/vertexProgram.cg",
            @"
            #include ""output.cg""
            Output vertexProgram(float2 position : POSITION)
            {
                Output OUT;
                OUT.position = float4(position,0,1);
                OUT.color = float3(0,1,0);
                return OUT;
            }");

            vertexProgram =
              this.CgContext.CreateProgram(
                ProgramType.Source,                 /* Program in human-readable form */
               "#include \"vertexProgram.cg\"\n",
                vertexProfile,         /* Profile: OpenGL ARB vertex program */
                "vertexProgram",           /* Entry function name */
                Args);                    /* Include path options */
            vertexProgram.Load();
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
                this.Exit();
        }

        #endregion Protected Methods

        #endregion Methods
    }
}