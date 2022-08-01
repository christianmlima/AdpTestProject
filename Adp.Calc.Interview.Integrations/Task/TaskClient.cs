using Adp.Interview.Calc.Domain;
using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Integrations.Task
{
    public class TaskClient : ITaskClient
    {
        private HttpClient _client = new();
        private string _baseUrl;

        public TaskClient(string baseUrl) => _baseUrl = baseUrl;
        

        public async ValueTask<CalcTask> GetTaskAsync()
        {
            var fullUrl = $"{_baseUrl}get-task";
            var result = await _client.GetFromJsonAsync<CalcTask>(fullUrl);
            return result;
        }            

        public async Task<HttpResponseMessage> SubmitTaskAsync(CalcTaskResult calcTaskResult, CancellationToken ct)
        {
            var content = GetContent(calcTaskResult);
            var requestUri = $"{_baseUrl}submit-task";
            return await new ValueTask<HttpResponseMessage>(_client.PostAsync(requestUri, content, ct));
        }            

        private HttpContent GetContent(object request)
        {
            var body = JsonConvert.SerializeObject(request,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
        
    }
}
