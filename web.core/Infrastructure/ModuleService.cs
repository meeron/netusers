using System;
using System.Linq;

namespace web.core.Infrastructure
{
    public class ModuleService
    {
        private ModuleService(Lifestyle lifestyle, Type componentType)
        {         
            Lifestyle = lifestyle;
            Component = componentType;
            Service = componentType.GetInterfaces().SingleOrDefault(t => t.Name == $"I{componentType.Name}");

            if (Service == null)
                throw new InvalidOperationException($"Component '{componentType.FullName}' doesn't implement service.");
        }

        internal Lifestyle Lifestyle { get; }

        internal Type Service { get; }

        internal Type Component { get; }

        public static ModuleService AsScoped<TComponent>()
        {
            return new ModuleService(Lifestyle.Scoped, typeof(TComponent));
        }

        public static ModuleService AsSingleton<TComponent>()
        {
            return new ModuleService(Lifestyle.Singleton, typeof(TComponent));
        }
    }
}