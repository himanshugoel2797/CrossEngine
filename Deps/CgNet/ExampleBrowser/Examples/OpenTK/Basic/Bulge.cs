namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Basic/14 Bulge")]
    public class Bulge : Example
    {
        #region Fields

        private const string VertexProgramFileName = "Data/C6E1v_bulge.cg";
        private const string VertexProgramName = "C6E1v_bulge";

        private readonly float[] myLightColor = { 0.95f, 0.95f, 0.95f }; /* White */
        private readonly float[] myProjectionMatrix = new float[16];

        private static float lightVelocity = 0.008f;
        private static float timeFlow = 0.01f;

        private float myLightAngle = -0.4f; /* Angle light rotates around scene. */
        private float myTime; /* Timing of bulge. */
        private Parameter vertexParamModelViewProj, vertexParamTime, vertexParamFrequency, vertexParamScaleFactor, vertexParamKd, vertexParamShininess, vertexParamEyePosition, vertexParamLightPosition, vertexParamLightColor, lightVertexParamModelViewProj;
        private ProfileType vertexProfile, fragmentProfile;
        private Program vertexProgram, fragmentProgram, lightVertexProgram;

        #endregion Fields

        #region Constructors

        public Bulge()
            : base("14_bulge")
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
            /* World-space positions for light and eye. */
            float[] eyePosition = { 0, 0, 13, 1 };
            float[] lightPosition = { (float)(5 * Math.Sin(myLightAngle)), 1.5f, (float)(5 * Math.Cos(myLightAngle)), 1 };

            float[] translateMatrix = new float[16], rotateMatrix = new float[16], modelMatrix = new float[16], invModelMatrix = new float[16],
                    viewMatrix = new float[16], modelViewMatrix = new float[16], modelViewProjMatrix = new float[16];
            float[] objSpaceEyePosition = new float[4], objSpaceLightPosition = new float[4];

            this.vertexParamTime.Set(myTime);

            BuildLookAtMatrix(eyePosition[0], eyePosition[1], eyePosition[2],
                              0, 0, 0,
                              0, 1, 0,
                              viewMatrix);

            vertexProfile.EnableProfile();

            fragmentProfile.EnableProfile();

            vertexProgram.Bind();

            fragmentProgram.Bind();

            /*** Render green solid bulging sphere ***/

            /* modelView = rotateMatrix * translateMatrix */
            MakeRotateMatrix(70, 1, 1, 1, rotateMatrix);
            MakeTranslateMatrix(2.2f, 1, 0.2f, translateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceEyePosition, invModelMatrix, eyePosition);
            this.vertexParamEyePosition.Set3(objSpaceEyePosition);
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            this.vertexParamLightPosition.Set3(objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.vertexParamModelViewProj.SetMatrix(modelViewProjMatrix);
            this.vertexParamKd.Set(0.1f, 0.7f, 0.1f, 1); /* Green */
            vertexProgram.UpdateParameters();
            NativeMethods.glutSolidSphere(1.0, 40, 40);

            /*** Render red solid bulging torus ***/

            /* modelView = viewMatrix * translateMatrix */
            MakeTranslateMatrix(-2, -1.5f, 0, translateMatrix);
            MakeRotateMatrix(55, 1, 0, 0, rotateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceEyePosition, invModelMatrix, eyePosition);
            this.vertexParamEyePosition.Set3(objSpaceEyePosition);
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            this.vertexParamLightPosition.Set3(objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.vertexParamModelViewProj.SetMatrix(modelViewProjMatrix);
            this.vertexParamKd.Set(0.8f, 0.1f, 0.1f, 1); /* Red */
            vertexProgram.UpdateParameters();
            NativeMethods.glutSolidTorus(0.15, 1.7, 40, 40);

            /*** Render light as emissive yellow ball ***/

            this.lightVertexProgram.Bind();

            /* modelView = translateMatrix */
            MakeTranslateMatrix(lightPosition[0], lightPosition[1], lightPosition[2],
                                modelMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.lightVertexParamModelViewProj.SetMatrix(modelViewProjMatrix);
            vertexProgram.UpdateParameters();
            NativeMethods.glutSolidSphere(0.1, 12, 12);

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
            GL.Enable(EnableCap.DepthTest);
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
            this.vertexParamTime = vertexProgram.GetNamedParameter("time");
            this.vertexParamFrequency = vertexProgram.GetNamedParameter("frequency");
            this.vertexParamScaleFactor = vertexProgram.GetNamedParameter("scaleFactor");
            this.vertexParamKd = vertexProgram.GetNamedParameter("Kd");
            this.vertexParamShininess = vertexProgram.GetNamedParameter("shininess");
            this.vertexParamEyePosition = vertexProgram.GetNamedParameter("eyePosition");
            this.vertexParamLightPosition = vertexProgram.GetNamedParameter("lightPosition");
            this.vertexParamLightColor = vertexProgram.GetNamedParameter("lightColor");

            /* Set light source color parameters once. */
            this.vertexParamLightColor.Set(myLightColor);

            this.vertexParamScaleFactor.Set(0.3f);
            this.vertexParamFrequency.Set(2.4f);
            this.vertexParamShininess.Set(35f);

            fragmentProfile = ProfileClass.Fragment.GetLatestProfile();
            fragmentProfile.SetOptimalOptions();

            fragmentProgram =
                this.CgContext.CreateProgram(
                    ProgramType.Source, /* Program in human-readable form */
                    "float4 main(float4 c : COLOR) : COLOR { return c; }",
                    fragmentProfile, /* Profile: OpenGL ARB vertex program */
                    "main", /* Entry function name */
                    null); /* No extra compiler options */
            fragmentProgram.Load();

            /* Specify vertex program for rendering the light source with a string. */
            this.lightVertexProgram =
                this.CgContext.CreateProgram(
                    ProgramType.Source, /* Program in human-readable form */
                    @"void main(inout float4 p : POSITION,
                uniform float4x4 modelViewProj,
                out float4 c : COLOR)
                { p = mul(modelViewProj, p); c = float4(1,1,0,1); }",
                    vertexProfile, /* Profile: latest fragment profile */
                    "main", /* Entry function name */
                    null); /* No extra compiler options */

            this.lightVertexProgram.Load();

            this.lightVertexParamModelViewProj =
                this.lightVertexProgram.GetNamedParameter("modelViewProj");
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);

            Reshape(this.Width, this.Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            vertexProgram.Dispose();
            fragmentProgram.Dispose();
            this.lightVertexProgram.Dispose();
            this.CgContext.Dispose();
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            /* Repeat rotating light around front 180 degrees. */
            if (myLightAngle > Pi / 2)
            {
                myLightAngle = Pi / 2;
                lightVelocity = -lightVelocity;
            }
            else if (myLightAngle < -Pi / 2)
            {
                myLightAngle = -Pi / 2;
                lightVelocity = -lightVelocity;
            }
            myLightAngle += lightVelocity; /* Add a small angle (in radians). */

            /* Repeatedly advance and rewind time. */
            if (myTime > 10)
            {
                myTime = 10;
                timeFlow = -timeFlow;
            }
            else if (myTime < 0)
            {
                myTime = 0;
                timeFlow = -timeFlow;
            }
            myTime += timeFlow; /* Add time delta. */

            if (this.Keyboard[Key.Escape])
            {
                this.Exit();
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void Reshape(int width, int height)
        {
            double aspectRatio = (float)width / height;
            const double FieldOfView = 40.0;

            /* Build projection matrix once. */
            BuildPerspectiveMatrix(FieldOfView, aspectRatio,
                                   1.0, 20.0, /* Znear and Zfar */
                                   myProjectionMatrix);
        }

        #endregion Private Methods

        #endregion Methods
    }
}