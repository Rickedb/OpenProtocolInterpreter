namespace OpenProtocolInterpreter.MIDs.Alarm
{
    /// <summary>
    /// MID: Alarm unsubscribe
    /// Description: 
    ///      Reset the subscription for the controller alarms.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Alarm subscription does not exist
    /// </summary>
    public class MID_0073 : MID, IAlarm
    {
        public const int MID = 73;
        private const int length = 20;
        private const int revision = 1;

        public MID_0073() : base(length, MID, revision)
        {

        }

        internal MID_0073(IMID nextTemplate) : base(length, MID, revision)
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
