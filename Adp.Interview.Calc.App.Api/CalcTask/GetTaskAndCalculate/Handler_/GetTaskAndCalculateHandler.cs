using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using Adp.Interview.Calc.Integrations.Task;
using Adp.Interview.Calc.Shared.ApiUtilities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Adp.Interview.Calc.Shared.ApiUtilities.Responses;

namespace Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate
{
    public class GetTaskAndCalculateHandler : ICoreHandler<GetTaskAndCalculateRequestDto, GetTaskAndCalculateResponseDto>
    {
        private readonly ITaskClient _client;
        private readonly ICalcTaskRepository _repository;

        public GetTaskAndCalculateHandler(ITaskClient client, ICalcTaskRepository repository)
        {
            _client = client;
            _repository = repository;
        }

        public async Task<GetTaskAndCalculateResponseDto> Handle(GetTaskAndCalculateRequestDto request, CancellationToken ct)
        {
            try
            {
                var task = await _client.GetTaskAsync();

                await _repository.AddCalcTaskAsync(task, ct);

                var calcTaskResult = task.Calculate();

                await _repository.AddCalcTaskResultAsync(calcTaskResult, ct);

                var response = await _client.SubmitTaskAsync(calcTaskResult, ct);

                return CreateResponse(response, calcTaskResult);
            }
            catch (Exception ex)
            {
                return BadRequest<GetTaskAndCalculateResponseDto>(new BadRequestDto(new BadRequestDetailDto("Exception", ex.Message)));
            }
        }

        private GetTaskAndCalculateResponseDto CreateResponse(HttpResponseMessage response, CalcTaskResult calcTaskResult)
        {
            return new GetTaskAndCalculateResponseDto()
            {
                Id = calcTaskResult.id,
                Result = calcTaskResult.result,
                AdpResponseDescription = CreateAdpResponseDescription(response.StatusCode)
            };
        }

        private string CreateAdpResponseDescription(HttpStatusCode httpStatusCode)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                    return "Success - The result was validated";
                case HttpStatusCode.BadRequest:
                    return "BadRequest - Incorrect value in result; No ID specified;Value is invalid";
                case HttpStatusCode.NotFound:
                    return "NotFound - Value not found for specified ID";
                case HttpStatusCode.ServiceUnavailable:
                    return "ServiceUnavailable - Error communicating with database";
                default:
                    return string.Empty;
            }
        }
    }
}
