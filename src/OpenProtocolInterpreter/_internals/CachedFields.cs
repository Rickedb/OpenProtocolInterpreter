using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    internal static class CachedFields
    {
        private static object _lock = new object();
        private static Dictionary<int, Dictionary<int, List<DataField>>> _cache = new Dictionary<int, Dictionary<int, List<DataField>>>();

        public static Dictionary<int, List<DataField>> GetRegisteredFields(int mid, Func<Dictionary<int, List<DataField>>> func)
        {
            lock(_lock)
            {
                if(!_cache.TryGetValue(mid, out Dictionary<int, List<DataField>> fields))
                {
                    fields = func();
                    if (_cache.Count > 10)
                        _cache.Remove(_cache.Last().Key);

                    _cache.Add(mid, fields);
                }

                return fields;
            }
        }
    }
}
