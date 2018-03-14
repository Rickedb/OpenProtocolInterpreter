namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm acknowledge
    /// Description: 
    ///      Acknowledgement for MID 0071 Alarm.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0072 : MID, IAlarm
    {
        private const int length = 20;
        public const int MID = 72;
        private const int revision = 1;

        public MID_0072() : base(length, MID, revision)
        {

        }

        internal MID_0072(IMID nextTemplate) : base(length, MID, revision)
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
