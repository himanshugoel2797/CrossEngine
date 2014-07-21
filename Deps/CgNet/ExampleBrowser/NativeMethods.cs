namespace ExampleBrowser
{
    using System;
    using System.Runtime.InteropServices;

    internal static class NativeMethods
    {
        #region Methods

        #region Public Static Methods

        [DllImport("glut32.dll")]
        public static extern void glutSolidCone(double radius, double outerRadius, int nsides, int rings);

        [DllImport("glut32.dll")]
        public static extern void glutSolidCube(double d);

        [DllImport("glut32.dll")]
        public static extern void glutSolidSphere(double radius, int slices, int stacks);

        [DllImport("glut32.dll")]
        public static extern void glutSolidTorus(double radius, double outerRadius, int nsides, int rings);

        [DllImport("glut32.dll")]
        public static extern void glutWireCone(double bse, double height, int slices, int stacks);

        [DllImport("glut32.dll")]
        public static extern void glutWireSphere(double radius, int slices, int stacks);

        #endregion Public Static Methods

        #endregion Methods
    }
}