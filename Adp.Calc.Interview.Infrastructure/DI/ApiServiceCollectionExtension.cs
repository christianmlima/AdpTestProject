using Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate;
using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using Adp.Interview.Calc.Infrastructure.EfCoreImpl;
using Adp.Interview.Calc.Infrastructure.Models.CalcTaskAggregate;
using Adp.Interview.Calc.Integrations.Task;
using Adp.Interview.Calc.Shared.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Adp.Interview.Calc.Infrastructure.DI
{
    public static class ApiServiceCollectionExtension
    {
        public static void AddApiServiceCollection(this IServiceCollection services, IParsableKeyValuePairs configKvps)
        {
            AddRepositories(services, configKvps);
            AddHandlers(services, configKvps);            
        }

        private static void AddHandlers(IServiceCollection services, IParsableKeyValuePairs configKvps)
        {
            services.AddScoped<IRequestHandler<GetTaskAndCalculateRequestDto, GetTaskAndCalculateResponseDto>>(x =>            
                new GetTaskAndCalculateHandler(x.GetRequiredService<ITaskClient>(), x.GetRequiredService<ICalcTaskRepository>()));
            services.AddMediatR(typeof(GetTaskAndCalculateHandler));
        }

        private static void AddRepositories(IServiceCollection services, IParsableKeyValuePairs configKvps)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("AdpInterviewTest"));

            services.AddScoped<ICalcTaskRepository>(x => new CalcTaskRepository(x.GetRequiredService<ApiContext>()));
        }
    }
}
