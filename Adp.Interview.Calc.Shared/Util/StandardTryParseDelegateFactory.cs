using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.Util
{
    internal static class StandardTryParseDelegateFactory
    {
        public static Delegate CreateTryParseDelegateFromType(Type parsableType)
        {
            if (parsableType == null)
            {
                throw new Exception("parsableType");
            }

            MethodInfo methodInfo2;
            if (parsableType.IsEnum)
            {
                MethodInfo methodInfo = typeof(Enum).GetMethods(BindingFlags.Static | BindingFlags.Public).Single((MethodInfo x) => x.Name.Equals("TryParse") && x.GetParameters().Length.Equals(2));
                methodInfo2 = methodInfo.MakeGenericMethod(parsableType);
            }
            else
            {
                Type type = parsableType.MakeByRefType();
                Type[] types = new Type[2]
                {
                    typeof(string),
                    type
                };
                methodInfo2 = parsableType.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, types, null);
            }

            if (methodInfo2 == null)
            {
                throw new Exception("public static method with signature " + $"\"System.Boolean TryParse(System.String, out {parsableType})\" not found in type '{parsableType}'");
            }

            return Delegate.CreateDelegate(typeof(StandardTryParse<>).MakeGenericType(parsableType), methodInfo2);
        }

        public static StandardTryParse<T> CreateTryParseDelegateFromType<T>()
        {
            return (StandardTryParse<T>)CreateTryParseDelegateFromType(typeof(T));
        }
    }
}
