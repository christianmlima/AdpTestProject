using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public static class BadRequests
    {
        public static BadRequestDto BadRequestReasonFrom(string descricao)
        {
            return new BadRequestDto
                {
                new BadRequestDetailDto(descricao, null)
                };
        }

        public static BadRequestDto BadRequestReasonFrom(IEnumerable<string> descricoes)
        {
            return new BadRequestDto(descricoes?.Select((string x) => new BadRequestDetailDto(x, null)));
        }

        public static BadRequestDto BadRequestReasonFrom(params string[] descricoes)
        {
            return BadRequestReasonFrom((IEnumerable<string>)descricoes);
        }

        public static BadRequestDto BadRequestReasonFrom(IEnumerable<(string descricao, string tag)> descricoes)
        {
            return new BadRequestDto(descricoes?.Select<(string, string), BadRequestDetailDto>(((string descricao, string tag) x) => new BadRequestDetailDto(x.descricao, x.tag)));
        }

        public static BadRequestDto BadRequestReasonFrom(params (string descricao, string tag)[] descricoes)
        {
            return BadRequestReasonFrom((IEnumerable<(string descricao, string tag)>)descricoes);
        }

        public static BadRequestDto BadRequestReasonFrom(IEnumerable<DtoValidationDetail> dtoValidationDets)
        {
            return new BadRequestDto(dtoValidationDets?.Select((DtoValidationDetail x) => new BadRequestDetailDto(x.Message, x.MemberName)));
        }

        public static BadRequestDto BadRequestReasonFrom(IReadOnlyCollection<ValueFailureDetail> failureDetails)
        {
            return new BadRequestDto(failureDetails?.Select((ValueFailureDetail x) => new BadRequestDetailDto(x.Description, x.Tag)));
        }        
    }    
}

