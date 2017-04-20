namespace OpenProtocolInterpreter.MIDs.Alarm
{
    /// <summary>
    /// MID: Alarm status acknowledge
    /// Description: 
    ///      Acknowledgement of MID 0076 Alarm Status.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0077 : MID, IAlarm
    {
        public const int MID = 77;
        private const int length = 20;
        private const int revision = 1;

        public MID_0077() : base(length, MID, revision)
        {

        }

        internal MID_0077(IMID nextTemplate) : base(length, MID, revision)
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
