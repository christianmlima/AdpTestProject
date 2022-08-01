using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public class BadRequestDetailDto : Dto
    {
        public string Tag { get; set; }
        public string Description { get; set; }
        public BadRequestDetailDto()
        {

        }
        public BadRequestDetailDto(string tag, string description)
        {
            Tag = tag;
            Description = description;
        }
    }
}
