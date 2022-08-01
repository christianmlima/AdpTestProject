using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public abstract class ResponseDto : Dto
    {
        public virtual ResponseStatus Status { get; set; }
        public virtual BadRequestDto BadRequestReason { get; set; }
        protected ResponseDto()
        {
            Status = ResponseStatus.OK;
        }
    }
}
