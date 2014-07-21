#if PC
using OpenTK;
using CgNet;
#elif PSM
using Sce.PlayStation.Core.Graphics;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine
{
    /// <summary>
    /// The main game engine object
    /// </summary>
    public static class Engine
    {
        public static Dictionary<string, SceneBase> Scenes;
        private static SceneBase curScene;

#if PC
        static GameWindow window;
        static Context cgContext;
#elif PSM
		static GraphicsContext graphics;
#endif
        public static void Initialize(int width, int height)
        {
            Scenes = new Dictionary<string, SceneBase>();
#if PC
            window = new GameWindow(width, height);
            cgContext = Context.Create();
            window.RenderFrame += (a, b) =>
            {
                curScene.Render(b.Time);
            };
            window.UpdateFrame += (a, b) =>
            {
                curScene.Update(b.Time);
            };
            window.Run(30, 30);
#elif PSM
			graphics = new GraphicsContext(
				width, height, PixelFormat.Rgba, PixelFormat.Depth24, MultiSampleMode.Msaa2x);
#endif

        }


    }
}
