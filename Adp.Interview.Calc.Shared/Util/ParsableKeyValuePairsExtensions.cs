using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.Util
{
    public static class ParsableKeyValuePairsExtensions
    {
        public static IParsableKeyValuePairs ToParsable(this IConfiguration @this, bool canCheckContainsKey, IDictionary<Type, ITypeParser> typeParsers)
        {
            return new ParsableKeyValuePairs(new ConfigurationKeyValuePairsAdapter(@this ?? throw new Exception(), canCheckContainsKey), typeParsers ?? throw new Exception("typeParsers"));
        }

        public static IParsableKeyValuePairs ToParsable(this IConfiguration @this, bool canCheckContainsKey)
        {
            return new ParsableKeyValuePairs(new ConfigurationKeyValuePairsAdapter(@this ?? throw new Exception(), canCheckContainsKey));
        }
    }
}
