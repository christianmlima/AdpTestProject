using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public class ValueFailureDetail
    {
        public string Tag
        {
            get;
        }
        public string Description
        {
            get;
            private set;
        }

        public ValueFailureDetail(string description, string tag = null)
        {
            Tag = (string.IsNullOrEmpty(tag) ? "__general__" : tag);
            Description = description;
        }

        public static implicit operator ValueFailureDetail(string description)
        {
            return new ValueFailureDetail(description);
        }
    }
}
