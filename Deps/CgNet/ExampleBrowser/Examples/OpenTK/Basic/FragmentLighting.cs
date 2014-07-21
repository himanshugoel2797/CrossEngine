namespace ExampleBrowser.Examples.OpenTK.Basic
{
    using System;

    using CgNet;
    using CgNet.GL;

    using global::OpenTK;
    using global::OpenTK.Graphics.OpenGL;
    using global::OpenTK.Input;

    [ExampleDescription(NodePath = "OpenTK/Basic/10 Fragment Lighting")]
    public class FragmentLighting : Example
    {
        #region Fields

        private readonly float[] myGlobalAmbient = { 0.1f, 0.1f, 0.1f }; /* Dim */
        private readonly float[] myLightColor = { 0.95f, 0.95f, 0.95f }; /* White */
        private readonly float[] myProjectionMatrix = new float[16];

        private Parameter myCgVertexParam_modelViewProj, myCgFragmentParam_globalAmbient, myCgFragmentParam_lightColor, myCgFragmentParam_lightPosition, myCgFragmentParam_eyePosition, myCgFragmentParam_Ke, myCgFragmentParam_Ka, myCgFragmentParam_Kd, myCgFragmentParam_Ks, myCgFragmentParam_shininess;
        private double myLightAngle = -0.4f; /* Angle light rotates around scene. */
        private ProfileType vertexProfile, fragmentProfile;
        private Program vertexProgram, fragmentProgram;
        private string vertexProgramFileName = "Data/C5E2v_fragmentLighting.cg",
            /* Page 124 */    vertexProgramName = "C5E2v_fragmentLighting",
                  fragmentProgramFileName = "Data/C5E3f_basicLight.cg",
            /* Page 125 */    fragmentProgramName = "C5E3f_basicLight";

        #endregion Fields

        #region Constructors

        public FragmentLighting()
            : base("10_fragment_lighting")
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
            float[] lightPosition = {
                                        5 * (float)Math.Sin(this.myLightAngle),
                                        1.5f,
                                        5 * (float)Math.Cos(this.myLightAngle), 1
                                    };

            float[] translateMatrix = new float[16], rotateMatrix = new float[16], modelMatrix = new float[16], invModelMatrix = new float[16],
                    viewMatrix = new float[16], modelViewMatrix = new float[16], modelViewProjMatrix = new float[16];
            float[] objSpaceEyePosition = new float[4], objSpaceLightPosition = new float[4];

            BuildLookAtMatrix(eyePosition[0], eyePosition[1], eyePosition[2],
                              0, 0, 0,
                              0, 1, 0,
                              viewMatrix);

            vertexProgram.Bind();
            vertexProfile.EnableProfile();

            fragmentProgram.Bind();
            fragmentProfile.EnableProfile();

            this.setBrassMaterial();

            /* modelView = rotateMatrix * translateMatrix */
            MakeRotateMatrix(70, 1, 1, 1, rotateMatrix);
            MakeTranslateMatrix(2, 0, 0, translateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceEyePosition, invModelMatrix, eyePosition);
            this.myCgFragmentParam_eyePosition.Set3(objSpaceEyePosition);
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            this.myCgFragmentParam_lightPosition.Set3(objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, this.myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.myCgVertexParam_modelViewProj.SetMatrix(modelViewProjMatrix);
            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();
            NativeMethods.glutSolidSphere(2.0, 40, 40);

            /*** Render red plastic solid cone ***/

            this.setRedPlasticMaterial();

            /* modelView = viewMatrix * translateMatrix */
            MakeTranslateMatrix(-2, -1.5f, 0, translateMatrix);
            MakeRotateMatrix(90, 1, 0, 0, rotateMatrix);
            MultMatrix(modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            InvertMatrix(invModelMatrix, modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            Transform(objSpaceEyePosition, invModelMatrix, eyePosition);
            this.myCgFragmentParam_eyePosition.Set3(objSpaceEyePosition);
            Transform(objSpaceLightPosition, invModelMatrix, lightPosition);
            this.myCgFragmentParam_lightPosition.Set3(objSpaceLightPosition);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, this.myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            this.myCgVertexParam_modelViewProj.SetMatrix(modelViewProjMatrix);
            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();
            NativeMethods.glutSolidCone(1.5, 3.5, 30, 30);

            /*** Render light as emissive white ball ***/

            /* modelView = translateMatrix */
            MakeTranslateMatrix(lightPosition[0], lightPosition[1], lightPosition[2],
                                modelMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            MultMatrix(modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            MultMatrix(modelViewProjMatrix, this.myProjectionMatrix, modelViewMatrix);

            this.setEmissiveLightColorOnly();
            /* Avoid degenerate lightPosition. */
            this.myCgFragmentParam_lightPosition.Set(0f, 0f, 0f);

            /* Set matrix parameter with row-major matrix. */
            this.myCgVertexParam_modelViewProj.SetMatrix(modelViewProjMatrix);
            vertexProgram.UpdateParameters();
            fragmentProgram.UpdateParameters();
            NativeMethods.glutSolidSphere(0.2, 12, 12);

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
                    vertexProgramFileName, /* Name of file containing program */
                    vertexProfile, /* Profile: OpenGL ARB vertex program */
                    vertexProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            vertexProgram.Load();

            this.myCgVertexParam_modelViewProj = vertexProgram.GetNamedParameter("modelViewProj");

            fragmentProfile = ProfileClass.Fragment.GetLatestProfile();
            fragmentProfile.SetOptimalOptions();

            /* Specify "color passthrough" fragment program with a string. */
            fragmentProgram =
                this.CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    fragmentProgramFileName,
                    fragmentProfile, /* Profile: latest fragment profile */
                    fragmentProgramName, /* Entry function name */
                    null); /* No extra compiler options */
            fragmentProgram.Load();

            this.myCgFragmentParam_globalAmbient = fragmentProgram.GetNamedParameter("globalAmbient");
            this.myCgFragmentParam_lightColor = fragmentProgram.GetNamedParameter("lightColor");
            this.myCgFragmentParam_lightPosition = fragmentProgram.GetNamedParameter("lightPosition");
            this.myCgFragmentParam_eyePosition = fragmentProgram.GetNamedParameter("eyePosition");
            this.myCgFragmentParam_Ke = fragmentProgram.GetNamedParameter("Ke");
            this.myCgFragmentParam_Ka = fragmentProgram.GetNamedParameter("Ka");
            this.myCgFragmentParam_Kd = fragmentProgram.GetNamedParameter("Kd");
            this.myCgFragmentParam_Ks = fragmentProgram.GetNamedParameter("Ks");
            this.myCgFragmentParam_shininess = fragmentProgram.GetNamedParameter("shininess");

            /* Set light source color parameters once. */
            this.myCgFragmentParam_globalAmbient.Set(this.myGlobalAmbient);
            this.myCgFragmentParam_lightColor.Set(this.myLightColor);
        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            this.Reshape(this.Width, this.Height);
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
            if (this.myLightAngle > 2 * Pi)
            {
                this.myLightAngle -= 2 * Pi;
            }

            if (this.Keyboard[Key.Escape])
                this.Exit();
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
                                   this.myProjectionMatrix);
        }

        private void setBrassMaterial()
        {
            float[] brassEmissive = { 0.0f, 0.0f, 0.0f },
                    brassAmbient = { 0.33f, 0.22f, 0.03f },
                    brassDiffuse = { 0.78f, 0.57f, 0.11f },
                    brassSpecular = { 0.99f, 0.91f, 0.81f };
            float brassShininess = 27.8f;

            this.myCgFragmentParam_Ke.Set(brassEmissive);
            this.myCgFragmentParam_Ka.Set(brassAmbient);
            this.myCgFragmentParam_Kd.Set(brassDiffuse);
            this.myCgFragmentParam_Ks.Set(brassSpecular);
            this.myCgFragmentParam_shininess.Set(brassShininess);
        }

        private void setEmissiveLightColorOnly()
        {
            float[] zero = { 0.0f, 0.0f, 0.0f };

            this.myCgFragmentParam_Ke.Set(this.myLightColor);
            this.myCgFragmentParam_Ka.Set(zero);
            this.myCgFragmentParam_Kd.Set(zero);
            this.myCgFragmentParam_Ks.Set(zero);
            this.myCgFragmentParam_shininess.Set(0);
        }

        private void setRedPlasticMaterial()
        {
            float[] redPlasticEmissive = { 0.0f, 0.0f, 0.0f },
                    redPlasticAmbient = { 0.0f, 0.0f, 0.0f },
                    redPlasticDiffuse = { 0.5f, 0.0f, 0.0f },
                    redPlasticSpecular = { 0.7f, 0.6f, 0.6f };
            float redPlasticShininess = 32.0f;

            this.myCgFragmentParam_Ke.Set(redPlasticEmissive);
            this.myCgFragmentParam_Ka.Set(redPlasticAmbient);
            this.myCgFragmentParam_Kd.Set(redPlasticDiffuse);
            this.myCgFragmentParam_Ks.Set(redPlasticSpecular);
            this.myCgFragmentParam_shininess.Set(redPlasticShininess);
        }

        #endregion Private Methods

        #endregion Methods
    }
}