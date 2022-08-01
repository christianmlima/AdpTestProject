using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Domain.Models.CalcTaskAggregate
{
    public interface ICalcTaskRepository
    {
        ValueTask AddCalcTaskAsync(CalcTask calcTask, CancellationToken ct);
        ValueTask AddCalcTaskResultAsync(CalcTaskResult calcTaskResult, CancellationToken ct);
    }
}
