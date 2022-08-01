using Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate;
using Adp.Interview.Calc.Shared.ApiUtilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Adp.Interview.Calc.Shared.ApiUtilities.ResponseResults;

namespace Adp.Interview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : CoreControllerBase
    {
        public CalculationController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var requestDto = new GetTaskAndCalculateRequestDto();
            var responseDto = await Mediator.Send(requestDto, ct);
            return ResponseToActionResult(responseDto, _ => responseDto);
        }
    }
}
