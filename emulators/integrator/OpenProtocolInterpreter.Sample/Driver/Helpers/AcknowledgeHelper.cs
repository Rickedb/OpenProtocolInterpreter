using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Vin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Sample.Driver.Helpers
{
    public static class AcknowledgeHelper
    {
        public static Dictionary<Type, Func<string>> acknowledges = new Dictionary<Type, Func<string>>()
        {
            { typeof(Mid0061), new Mid0062().Pack },
            { typeof(Mid0035), new Mid0036().Pack },
            { typeof(Mid0052), new Mid0053().Pack },
            { typeof(Mid0071), new Mid0072().Pack },
            { typeof(Mid0076), new Mid0077().Pack }
        };

        public static string BuildAckPackage(this Mid receivedMid)
        {
            var action = acknowledges.SingleOrDefault(x => x.Key == receivedMid.GetType());
            if (action.Equals(default(KeyValuePair<Type, Func<string>>)))
                return string.Empty;
            return action.Value();
        }
    }
}