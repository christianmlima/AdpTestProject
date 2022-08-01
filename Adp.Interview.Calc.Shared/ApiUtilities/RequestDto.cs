using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public abstract class RequestDto : Dto
    {
        private readonly Dictionary<string, string> _headers;
        public IReadOnlyDictionary<string, string> Headers => _headers;
        public RequestDto()
        {
            _headers = new();
        }
    }
}
