using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using Adp.Interview.Calc.Infrastructure.EfCoreImpl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Infrastructure.Models.CalcTaskAggregate
{
    public class CalcTaskRepository : ICalcTaskRepository
    {
        private readonly ApiContext DbContext;

        public CalcTaskRepository(ApiContext dbContext)
        {
            DbContext = dbContext;
        }

        public async ValueTask AddCalcTaskAsync(CalcTask calcTask, CancellationToken ct) =>
            await DbContext.CalcTasks.AddAsync(calcTask, ct);       

        public async ValueTask AddCalcTaskResultAsync(CalcTaskResult calcTaskResult, CancellationToken ct) =>
            await DbContext.CalcTaskResults.AddAsync(calcTaskResult, ct);
    }
}
