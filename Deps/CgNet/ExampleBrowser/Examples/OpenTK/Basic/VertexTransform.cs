namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Basic/08 Vertex Transform")]
    public class VertexTransform : Example
    {
        #region Fields

        private const string VertexProgramFileName = "Data/C4E1v_transform.cg";
        private const string VertexProgramName = "C4E1v_transform";

        private static readonly float[] MyProjectionMatrix = new float[16];

        private static float myEyeAngle; /* Angle eye rotates around scene. */

        private Parameter vertexParamModelViewProj, fragmentParamC;
        private ProfileType vertexProfile, fragmentProfile;
        private Program vertexProgram, fragmentProgram;

        #endregion Fields

        #region Constructors

        public VertexTransform()
            : base("08_vertex_transform")
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
            float[] viewMatrix = new float[16];
            BuildLookAtMatrix(13 * Math.Sin(myEyeAngle), 0, 13 * Math.Cos(myEyeAngle), /* eye position */
                              0, 0, 0, /* view center */
                              0, 1, 0, /* up vector */
                              viewMatrix);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            vertexProgram.Bind();
            vertexProfile.EnableProfile();

            fragmentProgram.Bind();
            fragmentProfile.EnableProfile();

            /* modelView = rotateMatrix * translateMatrix */
            float[] rotateMatrix = new float[16];
            float[] translateMatrix = new float[16];
            float[] modelMatrix = new float[16];
            float[] modelViewMatrix = new float[16];
            float[] modelViewProjMatrix = new float[16];

            MakeRotateMatrix(70, 1, 1, 1, rotateMatrix);
            MakeTranslateMatrix(2, 0, 0, translateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, MyProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.vertexParamModelViewProj.SetMatrix(modelViewProjMatrix);
            this.fragmentParamC.Set(0.1f, 0.7f, 0.1f, 1f); /* Green */
            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();
            NativeMethods.glutWireSphere(2.0, 30, 30);

            /*** Render red wireframe cone ***/
            MakeTranslateMatrix(-2, -1.5f, 0, translateMatrix);
            MakeRotateMatrix(90, 1, 0, 0, rotateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, MyProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.vertexParamModelViewProj.SetMatrix(modelViewProjMatrix);
            this.fragmentParamC.Set(0.8f, 0.1f, 0.1f, 1); /* Red */
            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();
            NativeMethods.glutWireCone(1.5, 3.5, 20, 20);

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

            this.vertexParamModelViewProj = vertexProgram.GetNamedParameter("modelViewProj");

            fragmentProfile = ProfileClass.Fragment.GetLatestProfile();
            fragmentProfile.SetOptimalOptions();

            /* Specify fragment program with a string. */
            fragmentProgram =
                this.CgContext.CreateProgram(
                    ProgramType.Source, /* Program in human-readable form */
                    "float4 main(uniform float4 c) : COLOR { return c; }",
                    fragmentProfile, /* Profile: latest fragment profile */
                    "main", /* Entry function name */
                    null); /* No extra compiler options */
            fragmentProgram.Load();

            this.fragmentParamC = fragmentProgram.GetNamedParameter("c");
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
            Reshape(this.Width, this.Height);
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
            myEyeAngle += 0.008f; /* Add a small angle (in radians). */
            if (myEyeAngle > 2 * Pi)
            {
                myEyeAngle -= (2 * Pi);
            }

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        /* Build a row-major (C-style) 4x4 matrix transform based on the
           parameters for gluLookAt. */
        private static void Reshape(int width, int height)
        {
            double aspectRatio = (float)width / height;
            const double FieldOfView = 40.0;

            /* Build projection matrix once. */
            BuildPerspectiveMatrix(FieldOfView, aspectRatio,
                                   1.0, 20.0, /* Znear and Zfar */
                                   MyProjectionMatrix);
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}