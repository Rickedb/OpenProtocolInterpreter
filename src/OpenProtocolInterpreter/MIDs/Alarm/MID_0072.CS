namespace OpenProtocolInterpreter.MIDs.Alarm
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
        private const int mid = 72;
        private const int revision = 1;

        public MID_0072() : base(length, mid, revision)
        {

        }

        public MID_0072(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
