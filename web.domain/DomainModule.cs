using System.Collections.Generic;
using web.core.Infrastructure;
using web.domain.Collections;
using web.domain.Repositories;

namespace web.domain
{
    public class DomainModule : IModule
    {
        public IEnumerable<ModuleService> GetServices()
        {
            return new[]
            {
                ModuleService.AsSingleton<CollectionFactory>(),
                ModuleService.AsSingleton<UsersRepository>(),
            };
        }
    }
}