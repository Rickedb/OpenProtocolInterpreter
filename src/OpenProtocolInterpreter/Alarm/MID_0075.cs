namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm acknowledged on controller acknowledge
    /// Description: 
    ///      Acknowledgement of MID 0074 Alarm acknowledged on controller.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0075 : MID, IAlarm
    {
        public const int MID = 75;
        private const int length = 20;
        private const int revision = 1;

        public MID_0075() : base(length, MID, revision)
        {

        }

        internal MID_0075(IMID nextTemplate) : base(length, MID, revision)
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
