using Adp.Interview.Calc.Domain;
using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Integrations.Task
{
    public interface ITaskClient
    {
        ValueTask<CalcTask> GetTaskAsync();
        Task<HttpResponseMessage> SubmitTaskAsync(CalcTaskResult calcTaskResult, CancellationToken ct);
    }
}
