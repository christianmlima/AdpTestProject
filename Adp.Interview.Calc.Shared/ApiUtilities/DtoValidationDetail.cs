using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public class DtoValidationDetail
    {
        private string _memberName;
        public string Message
        {
            get;
            set;
        }

        public string MemberName
        {
            get
            {
                return string.IsNullOrEmpty(_memberName) ? "__geral__" : _memberName;
            }
            set
            {
                _memberName = value;
            }
        }

        public DtoValidationDetail(string message, string memberName)
        {
            Message = message;
            MemberName = memberName;
        }

        public DtoValidationDetail(string mensagem)
            : this(mensagem, null)
        {
        }

        public DtoValidationDetail()
        {
        }
    }
}
