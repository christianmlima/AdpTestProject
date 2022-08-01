using Adp.Interview.Calc.Infrastructure.Configurations;
using Adp.Interview.Calc.Integrations.Task;
using Adp.Interview.Calc.Shared.Util;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adp.Interview.Calc.Infrastructure.DI
{
    public static class IntegrationServiceCollection
    {
        public static void AddIntegrationServiceCollection(this IServiceCollection services, IParsableKeyValuePairs configKvps)
        {
            AddHttpClients(services, configKvps);
        }

        private static void AddHttpClients(IServiceCollection services, IParsableKeyValuePairs configKvps)
        {
            services.AddScoped<ITaskClient>(p => new TaskClient(configKvps.UrlBaseAdp()));
        }
    }
}
