using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Adp.Interview.Calc.Domain.Models.CalcTaskAggregate
{
    public class CalcTask
    {
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public long Left { get; set; }
        public long Right { get; set; }

        public CalcTaskResult Calculate()
        {
            if (Operation.Equals("addition"))
                return DoAddition();
            else if (Operation.Equals("subtraction"))
                return DoSubtraction();
            else if (Operation.Equals("remainder"))
                return DoRemainder ();
            else if (Operation.Equals("multiplication"))
                return DoMultiplication ();
            else
                return DoDivision();
        }

        private CalcTaskResult DoAddition() => new CalcTaskResult(Id, Left + Right);
        private CalcTaskResult DoSubtraction() => new CalcTaskResult(Id, Left - Right);
        private CalcTaskResult DoMultiplication() => new CalcTaskResult(Id, Left * Right);
        private CalcTaskResult DoDivision() => new CalcTaskResult(Id, Left / Right);
        private CalcTaskResult DoRemainder() => new CalcTaskResult(Id, Left % Right);

        public static CalcTask Create(Guid id, string operation, long left, long right)
        {
            return new CalcTask()
            {
                Id = id,
                Operation = operation,
                Left = left,
                Right = right
            };
        }
    }
}
