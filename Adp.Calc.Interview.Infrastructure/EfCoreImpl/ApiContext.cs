using Adp.Interview.Calc.Domain.Models.CalcTaskAggregate;
using Microsoft.EntityFrameworkCore;

namespace Adp.Interview.Calc.Infrastructure.EfCoreImpl
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        { }
        public DbSet<CalcTask> CalcTasks { get; set; }
        public DbSet<CalcTaskResult> CalcTaskResults { get; set; }
    }
}
