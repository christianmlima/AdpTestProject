using System;

namespace Adp.Interview.Calc.Shared.Util
{
    public interface ITypeParser
    {
        Type TargetType
        {
            get;
        }

        bool TryParse(string value, out object result);
    }

    public interface ITypeParser<T> : ITypeParser
    {
        bool TryParse(string value, out T result);
    }
}
