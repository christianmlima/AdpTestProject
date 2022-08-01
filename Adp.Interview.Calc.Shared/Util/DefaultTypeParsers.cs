using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.Util
{
    public static class DefaultTypeParsers
    {
        private static readonly IEnumerable<Type> CommonTypes = new Type[16]
        {
            typeof(bool),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(char),
            typeof(TimeSpan),
            typeof(DateTime),
            typeof(DateTimeOffset)
        };

        private static readonly IDictionary<Type, ITypeParser> CommonTypeParsersByTypeInt = CommonTypes.Select((Type x) => (x, CreateFromType(x))).Union(new (Type, ITypeParser)[1]
        {
            (typeof(Type), new TypeTypeParser())
        }).ToDictionary<(Type, ITypeParser), Type, ITypeParser>(((Type key, ITypeParser value) x) => x.key, ((Type key, ITypeParser value) x) => x.value);

        public static IDictionary<Type, ITypeParser> CommonTypeParsersByType => new Dictionary<Type, ITypeParser>(CommonTypeParsersByTypeInt);

        public static ITypeParser CreateFromType(Type parsableType)
        {
            if (parsableType == null)
            {
                throw new Exception("parsableType");
            }

            Type type = typeof(StandardTypeParser<>).MakeGenericType(parsableType);
            return (ITypeParser)Activator.CreateInstance(type);
        }

        public static ITypeParser<T> CreateFromType<T>()
        {
            return new StandardTypeParser<T>();
        }
    }
}
