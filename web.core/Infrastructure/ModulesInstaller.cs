using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace web.core.Infrastructure
{
    public static class ModulesInstaller
    {
        public static void Install(IServiceCollection services)
        {
            var asm = Assembly.GetEntryAssembly();

            var baseDir = Path.GetDirectoryName(asm.Location);

            var paths = Directory.GetFiles(baseDir, "web*.dll");

            foreach (var path in paths)
            {
                asm = Assembly.LoadFrom(path);
                var moduleType = asm.GetTypes().SingleOrDefault(t => t.GetInterface("IModule") != null);
                if (moduleType != null)
                {
                    var module = Activator.CreateInstance(moduleType) as IModule;
                    var moduleServices = module.GetServices();

                    foreach (var moduleService in moduleServices)
                    {
                        switch (moduleService.Lifestyle)
                        {
                            case Lifestyle.Scoped:
                                services.AddScoped(moduleService.Service, moduleService.Component);
                                break;
                            case Lifestyle.Singleton:
                                services.AddSingleton(moduleService.Service, moduleService.Component);
                                break;
                            case Lifestyle.Transient:
                                services.AddTransient(moduleService.Service, moduleService.Component);
                                break;                                 
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}