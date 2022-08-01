using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.Util
{
    public static class TypeIndexedTypeParsersDictionaryExtensions
    {
        public static bool TryGet<T>(this IDictionary<Type, ITypeParser> @this, out ITypeParser<T> value)
        {
            if (@this == null)
            {
                throw new Exception("this");
            }

            ITypeParser value2;
            bool result = @this.TryGetValue(typeof(T), out value2);
            value = (ITypeParser<T>)value2;
            return result;
        }

        public static ITypeParser<T> Get<T>(this IDictionary<Type, ITypeParser> @this)
        {
            if (!@this.TryGet(out ITypeParser<T> value))
            {
                throw new Exception($"TypeParser for type '{typeof(T)}' was not found.");
            }

            return value;
        }
    }
}
