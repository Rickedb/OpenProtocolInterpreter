
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
        public const int MID = 70;

        private const int length = 20;
        private const int revision = 1;

        public MID_0070() : base(length, MID, revision)
        {

        }

        internal MID_0070(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
