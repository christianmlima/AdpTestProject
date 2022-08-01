using System;

namespace Adp.Interview.Calc.Shared.Util
{
    public class TypeTypeParser : ITypeParser<Type>, ITypeParser
    {
        public Type TargetType => typeof(Type);

        public bool TryParse(string value, out Type result)
        {
            result = Type.GetType(value, throwOnError: false);
            return result != null;
        }

        public bool TryParse(string value, out object result)
        {
            Type result2;
            bool result3 = TryParse(value, out result2);
            result = result2;
            return result3;
        }
    }
}
