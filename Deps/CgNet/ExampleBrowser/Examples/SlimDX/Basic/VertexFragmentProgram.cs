namespace ExampleBrowser.Examples.SlimDX.Basic
{
    using System;
    using System.Windows.Forms;

    using CgNet;
    using CgNet.D3D9;

    using global::SlimDX;
    using global::SlimDX.Direct3D9;
    using global::SlimDX.Windows;

    [ExampleDescription(NodePath = "SlimDX/Basic/02 Vertex And Fragment Program")]
    public class VertexFragmentProgram : Example
    {
        #region Fields

        private const string FragmentProgramFileName = "Data/C2E2f_passthru.cg";
        private const string FragmentProgramName = "C2E2f_passthru";
        private const int MyStarCount = 6;
        private const string VertexProgramFileName = "Data/C2E1v_green.cg";
        private const string VertexProgramName = "C2E1v_green";

        private readonly StarList[] myStarList = {
                                                     /*                star    outer   inner  */
                                                     /*  x       y     Points  radius  radius */
                                                     /* =====   =====  ======  ======  ====== */
                                                     new StarList(-0.1f, 0, 5, 0.5f, 0.2f),
                                                     new StarList(-0.84f, 0.1f, 5, 0.3f, 0.12f),
                                                     new StarList(0.92f, -0.5f, 5, 0.25f, 0.11f),
                                                     new StarList(0.3f, 0.97f, 5, 0.3f, 0.1f),
                                                     new StarList(0.94f, 0.3f, 5, 0.5f, 0.2f),
                                                     new StarList(-0.97f, -0.8f, 5, 0.6f, 0.2f)
                                                 };

        private Context CgContext;
        private Device device;
        private VertexBuffer vertexBuffer;
        private ProfileType vertexProfile, fragmentProfile;
        private Program vertexProgram, fragmentProgram;

        #endregion Fields

        #region Methods

        #region Public Methods

        public override void Start()
        {
            base.Start();
            var form = new RenderForm("02_vertex_and_fragment_program");
            this.device = new Device(new Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters
                                                                                                                                {
                                                                                                                                    BackBufferWidth = form.ClientSize.Width,
                                                                                                                                    BackBufferHeight = form.ClientSize.Height
                                                                                                                                });
            int vertexCount = 0;

            for (int i = 0; i < MyStarCount; i++)
            {
                vertexCount += myStarList[i].Points * 2 + 2;
            }

            vertexBuffer = new VertexBuffer(device, vertexCount * 12, Usage.WriteOnly, VertexFormat.Position, Pool.Default);

            Vector3[] starVertices = new Vector3[vertexCount];
            var dataStream = vertexBuffer.Lock(0, 0, LockFlags.Discard);
            for (int i = 0, n = 0; i < myStarList.Length; i++)
            {
                double piOverStarPoints = 3.14159 / myStarList[i].Points;
                float x = myStarList[i].X,
                      y = myStarList[i].Y,
                      outerRadius = myStarList[i].OuterRadius,
                      r = myStarList[i].InnerRadius;
                double angle = 0.0;

                /* Center of star */
                starVertices[n++] = new Vector3(x, y, 0);
                /* Emit exterior vertices for star's points. */
                for (int j = 0; j < myStarList[i].Points; j++)
                {
                    starVertices[n++] = new Vector3(x + outerRadius * (float)Math.Cos(angle), y + outerRadius * (float)Math.Sin(angle), 0);
                    angle -= piOverStarPoints;
                    starVertices[n++] = new Vector3(x + r * (float)Math.Cos(angle), y + r * (float)Math.Sin(angle), 0);
                    angle -= piOverStarPoints;
                }
                /* End by repeating first exterior vertex of star. */
                angle = 0;
                starVertices[n++] = new Vector3(x + outerRadius * (float)Math.Cos(angle), y + outerRadius * (float)Math.Sin(angle), 0);
            }
            dataStream.WriteRange(starVertices);
            dataStream.Position = 0;
            vertexBuffer.Unlock();

            this.CgContext = Context.Create();
            this.CgContext.ParameterSettingMode = ParameterSettingMode.Deferred;
            this.CreateCgPrograms();

            form.Show();
            while (form.Visible)
            {
                device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, new Color4(0.1f, 0.3f, 0.6f), 1.0f, 0);
                device.BeginScene();

                vertexProgram.Bind();
                fragmentProgram.Bind();

                /* Render the triangle. */
                device.SetStreamSource(0, vertexBuffer, 0, 12);
                device.VertexFormat = VertexFormat.Position;
                for (int i = 0; i < MyStarCount; i++)
                {
                    device.DrawPrimitives(PrimitiveType.TriangleFan, i * 12, 10);
                }
                device.EndScene();
                device.Present();
                Application.DoEvents();
            }

            fragmentProgram.Dispose();
            vertexProgram.Dispose();
            this.CgContext.Dispose();
            foreach (var item in ObjectTable.Objects)
            {
                item.Dispose();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateCgPrograms()
        {
            CgD3D9.SetDevice(this.device);
            /* Determine the best profile once a device to be set. */
            vertexProfile = CgD3D9.GetLatestVertexProfile();

            string[] profileOpts = CgD3D9.GetOptimalOptions(vertexProfile);

            vertexProgram =
                CgContext.CreateProgramFromFile(
                    ProgramType.Source, /* Program in human-readable form */
                    VertexProgramFileName, /* Name of file containing program */
                    vertexProfile, /* Profile: OpenGL ARB vertex program */
                    VertexProgramName, /* Entry function name */
                    profileOpts); /* Pass optimal compiler options */

            fragmentProfile = CgD3D9.GetLatestPixelProfile();
            profileOpts = CgD3D9.GetOptimalOptions(fragmentProfile);
            fragmentProgram =
                CgContext.CreateProgramFromFile(
                    ProgramType.Source,
                    FragmentProgramFileName,
                    fragmentProfile,
                    FragmentProgramName,
                    profileOpts);

            vertexProgram.Load(false, 0);
            fragmentProgram.Load(false, 0);
        }

        #endregion Private Methods

        #endregion Methods

        #region Nested Types

        private struct StarList
        {
            #region Fields

            public readonly float InnerRadius;
            public readonly float OuterRadius;
            public readonly int Points;
            public readonly float X;
            public readonly float Y;

            #endregion Fields

            #region Constructors

            public StarList(float x, float y, int points, float or, float ir)
            {
                this.X = x;
                this.Y = y;
                this.Points = points;
                this.OuterRadius = or;
                this.InnerRadius = ir;
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}