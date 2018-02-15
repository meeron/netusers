using System.Collections.Generic;

namespace web.core.Infrastructure
{
    public interface IModule
    {
        IEnumerable<ModuleService> GetServices();
    }
}