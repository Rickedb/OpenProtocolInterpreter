using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    internal static class MessageTemplateFactory
    {
        public static IDictionary<int, Type> Except(this IDictionary<int, Type> defaultMids, IEnumerable<Type> selectedMids)
        {
            if (!selectedMids.Any())
                return defaultMids;

            var unusedMids = defaultMids.Values.Except(selectedMids);

            foreach (var unused in unusedMids)
            {
                defaultMids.Remove(defaultMids.First(x => x.Value == unused));
            }

            return defaultMids;
        }
    }
}
