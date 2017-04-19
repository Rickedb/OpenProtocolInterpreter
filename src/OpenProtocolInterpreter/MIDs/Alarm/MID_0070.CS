
using System;

namespace OpenProtocolInterpreter.MIDs.Alarm
{
    /// <summary>
    /// MID: Alarm subscribe
    /// Description: 
    ///      A subscription for the alarms that can appear in the controller.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Alarm subscription already exists
    /// </summary>
    public class MID_0070 : MID, IAlarm
    {
        private const int length = 20;
        private const int mid = 70;
        private const int revision = 1;

        public MID_0070() : base(length, mid, revision)
        {

        }

        internal MID_0070(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
