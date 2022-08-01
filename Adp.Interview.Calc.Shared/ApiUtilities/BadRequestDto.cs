using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public class BadRequestDto : List<BadRequestDetailDto>
    {
        public BadRequestDto()
        {

        }

        public BadRequestDto(int capacity) : base(capacity)
        {

        }

        public BadRequestDto(IEnumerable<BadRequestDetailDto> collection) : base(collection)
        {

        }
        public BadRequestDto(params BadRequestDetailDto[] collection) : this((IEnumerable<BadRequestDetailDto>) collection)
        {

        }
    }
}
