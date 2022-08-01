using Adp.Interview.Calc.Shared.ApiUtilities;
using MediatR;

namespace Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate
{
    public class GetTaskAndCalculateRequestDto : RequestDto, IRequest<GetTaskAndCalculateResponseDto>
    {
    }
}
