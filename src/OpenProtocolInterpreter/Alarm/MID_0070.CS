
using System;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm subscribe
    /// Description: 
    ///      A subscription for the alarms that can appear in the controller.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Alarm subscription already exists
    /// </summary>
    public class MID_0070 : Mid, IAlarm
    {
        private const int LAST_REVISION = 2;
        public const int MID = 70;

        public MID_0070(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, revision, noAckFlag)
        {

        }

        internal MID_0070(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

    }
}
