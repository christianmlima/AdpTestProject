using Adp.Interview.Calc.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Infrastructure.Configurations
{
    public static class Params
    {
        public static string UrlBaseAdp(this IParsableKeyValuePairs configKvps) =>
            GetVariable<string>(configKvps, "URL_BASE", string.Empty);

        private static T GetVariable<T>(this IParsableKeyValuePairs configKvps, string variableName, T defaultValue = default)
        {
            var variable = configKvps.TryGetAndParse<T>(variableName);
            var declaredAndNonEmpty = (variable.KeyDeclared ?? false) && variable.ValueNonEmpty;
            return declaredAndNonEmpty ? variable.ParsedValue : defaultValue;
        }
    }
}
