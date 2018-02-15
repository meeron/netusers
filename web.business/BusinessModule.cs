using System.Collections.Generic;
using web.business.Services;
using web.core.Infrastructure;

namespace web.business
{
    public class BusinessModule : IModule
    {
        public IEnumerable<ModuleService> GetServices()
        {
            return new[]
            {
                ModuleService.AsScoped<UserService>(),
            };
        }
    }
}