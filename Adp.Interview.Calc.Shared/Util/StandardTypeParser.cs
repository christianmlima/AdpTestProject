using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.Util
{
    public class StandardTypeParser<T> : ITypeParser<T>, ITypeParser
    {
        private readonly StandardTryParse<T> _typeStandardTryParse;

        public Type TargetType => typeof(T);

        public StandardTypeParser()
        {
            _typeStandardTryParse = StandardTryParseDelegateFactory.CreateTryParseDelegateFromType<T>();
        }

        public bool TryParse(string value, out T result)
        {
            return _typeStandardTryParse(value, out result);
        }

        public bool TryParse(string value, out object result)
        {
            T result2;
            bool result3 = TryParse(value, out result2);
            result = result2;
            return result3;
        }
    }
}
