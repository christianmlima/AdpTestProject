using Adp.Interview.Calc.Shared.ApiUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate
{
    public class GetTaskAndCalculateResponseDto : ResponseDto
    {
        public Guid Id { get; set; }
        public long? Result { get; set; }
        public string AdpResponseDescription { get; set; }
    }
}
