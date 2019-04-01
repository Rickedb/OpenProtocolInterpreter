using OpenProtocolInterpreter.MIDs.Alarm;
using OpenProtocolInterpreter.MIDs.Job;
using OpenProtocolInterpreter.MIDs.Tightening;
using OpenProtocolInterpreter.MIDs.VIN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Sample.Driver.Helpers
{
    public static class AcknowledgeHelper
    {
        public static Dictionary<Type, Func<string>> acknowledges = new Dictionary<Type, Func<string>>()
        {
            { typeof(MID_0061), new MID_0062().buildPackage },
            { typeof(MID_0035), new MID_0036().buildPackage },
            { typeof(MID_0052), new MID_0053().buildPackage },
            { typeof(MID_0071), new MID_0072().buildPackage},
            { typeof(MID_0076), new MID_0077().buildPackage}
        };

        public static string BuildAckPackage(this MIDs.MID receivedMid)
        {
            var action = acknowledges.SingleOrDefault(x => x.Key == receivedMid.GetType());
            if (action.Equals(default(KeyValuePair<Type, Func<string>>)))
                return string.Empty;
            return action.Value();
        }
    }
}
