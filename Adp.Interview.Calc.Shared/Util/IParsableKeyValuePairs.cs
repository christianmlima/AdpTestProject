using System;

namespace Adp.Interview.Calc.Shared.Util
{
    public interface IParsableKeyValuePairs
    {
        T EnsureValue<T>(string key);
        T EnsureValue<T>(string key, Predicate<T> condition);
        ITryGetAndParseResult<T> TryGetAndParse<T>(string key);
    }
}
