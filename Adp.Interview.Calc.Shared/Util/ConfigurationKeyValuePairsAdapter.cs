using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adp.Interview.Calc.Shared.Util
{
    internal class ConfigurationKeyValuePairsAdapter : IReadOnlyStringKeyValuePairs
    {
        private readonly IConfiguration _target;

        private readonly HashSet<string> _keys;

        public string this[string key] => _target[key];

        public bool CanCheckContainsKey
        {
            get;
            private set;
        }

        public ConfigurationKeyValuePairsAdapter(IConfiguration target, bool canCheckContainsKey)
        {
            _target = (target ?? throw new Exception("target"));
            CanCheckContainsKey = canCheckContainsKey;
            if (canCheckContainsKey)
            {
                _keys = new HashSet<string>(from x in _target.AsEnumerable()
                                            select x.Key);
            }
        }

        public bool ContainsKey(string key)
        {
            if (!CanCheckContainsKey)
            {
                throw new Exception("'CanCheckContainsKey' is disabled.");
            }

            return _keys.Contains(key);
        }
    }
}
