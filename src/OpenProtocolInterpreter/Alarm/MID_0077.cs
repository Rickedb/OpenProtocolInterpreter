namespace OpenProtocolInterpreter.Alarm
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
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
