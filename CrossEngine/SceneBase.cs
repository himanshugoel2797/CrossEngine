using ECS.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine
{
    public class SceneBase
    {
        public EntityComponentSystem UpdateSystem, RenderSystem;

        public SceneBase()
        {
            UpdateSystem = new EntityComponentSystem();
            RenderSystem = new EntityComponentSystem();
        }

        public virtual void Initialize() { }

        public void Update(double delta)
        {
            UpdateSystem.Activate();
        }

        public void Render(double delta)
        {
            RenderSystem.Activate();
        }

    }
}
