using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Domain.Models.CalcTaskAggregate
{
    public class CalcTaskResult
    {
        public Guid id { get; set; }
        public long result { get; set; }

        public CalcTaskResult(Guid id, long result)
        {
            this.id = id;
            this.result = result;
        }
    }
}
