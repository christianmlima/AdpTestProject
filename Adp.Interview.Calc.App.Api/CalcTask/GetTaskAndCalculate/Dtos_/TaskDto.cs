using Adp.Interview.Calc.Shared.ApiUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.App.Api.CalcTask.GetTaskAndCalculate
{
    public class TaskDto : Dto
    {
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public long Left { get; set; }
        public long Right { get; set; }
    }
}
