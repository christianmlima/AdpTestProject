using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Interview.Calc.Shared.Util
{
    internal class ParsableKeyValuePairs : IParsableKeyValuePairs
    {
        private class TryGetAndParseResult<T> : ITryGetAndParseResult<T>
        {
            public string Key
            {
                get;
                set;
            }

            public bool? KeyDeclared
            {
                get;
                set;
            }

            public bool ValueNonEmpty
            {
                get;
                set;
            }

            public bool ValueParsingSucceeded
            {
                get;
                set;
            }

            public string UnparsedValue
            {
                get;
                set;
            }

            public T ParsedValue
            {
                get;
                set;
            }

            public T EnsureParsedValue(Predicate<T> condition)
            {
                if (condition == null)
                {
                    throw new Exception("condition");
                }

                Type typeFromHandle = typeof(T);
                if (KeyDeclared.HasValue && !KeyDeclared.Value)
                {
                    throw new Exception($"Key '{Key}', whose value expected type is '{typeFromHandle}', is not declared.");
                }

                if (!ValueNonEmpty)
                {
                    throw new Exception((KeyDeclared.HasValue && KeyDeclared.Value) ? $"Value associated with key '{Key}', whose expected type is '{typeFromHandle}', is empty." : $"Value associated with key '{Key}', whose expected type is '{typeFromHandle}', is not declared or empty.");
                }

                if (!ValueParsingSucceeded)
                {
                    throw new Exception($"Value associated with key '{Key}' cannot be parsed as type '{typeFromHandle}' -- the unparsable value is '{UnparsedValue}'.");
                }

                if (!condition(ParsedValue))
                {
                    throw new Exception($"Value associated with key '{Key}', parsed as type '{typeFromHandle}', is not valid -- the invalid parsed value is '{ParsedValue}'");
                }

                return ParsedValue;
            }

            public T EnsureParsedValue()
            {
                return EnsureParsedValue((T _) => true);
            }
        }

        private readonly IReadOnlyStringKeyValuePairs _target;

        private readonly IDictionary<Type, ITypeParser> _typeParsers;

        public ParsableKeyValuePairs(IReadOnlyStringKeyValuePairs target, IDictionary<Type, ITypeParser> typeParsers)
        {
            _target = (target ?? throw new Exception("target"));
            _typeParsers = (typeParsers ?? throw new Exception("typeParsers"));
        }

        public ParsableKeyValuePairs(IReadOnlyStringKeyValuePairs keyValuePairs)
            : this(keyValuePairs, DefaultTypeParsers.CommonTypeParsersByType)
        {
        }

        public ITryGetAndParseResult<T> TryGetAndParse<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("key");
            }

            TryGetAndParseResult<T> tryGetAndParseResult = new TryGetAndParseResult<T>
            {
                Key = key
            };
            if (_target.CanCheckContainsKey && !(tryGetAndParseResult.KeyDeclared = _target.ContainsKey(key)).GetValueOrDefault())
            {
                return tryGetAndParseResult;
            }

            tryGetAndParseResult.UnparsedValue = _target[key];
            if (!(tryGetAndParseResult.ValueNonEmpty = !string.IsNullOrEmpty(tryGetAndParseResult.UnparsedValue)))
            {
                return tryGetAndParseResult;
            }

            tryGetAndParseResult.KeyDeclared = true;
            if (typeof(T).Equals(typeof(string)))
            {
                tryGetAndParseResult.ValueParsingSucceeded = true;
                tryGetAndParseResult.ParsedValue = (T)(object)tryGetAndParseResult.UnparsedValue;
                return tryGetAndParseResult;
            }

            T result;
            bool flag3 = _typeParsers.Get<T>().TryParse(tryGetAndParseResult.UnparsedValue, out result);
            if (!(tryGetAndParseResult.ValueParsingSucceeded = flag3))
            {
                return tryGetAndParseResult;
            }

            tryGetAndParseResult.ParsedValue = result;
            return tryGetAndParseResult;
        }

        public T EnsureValue<T>(string key, Predicate<T> condition)
        {
            return TryGetAndParse<T>(key).EnsureParsedValue(condition);
        }

        public T EnsureValue<T>(string key)
        {
            return EnsureValue(key, (T _) => true);
        }
    }
}
