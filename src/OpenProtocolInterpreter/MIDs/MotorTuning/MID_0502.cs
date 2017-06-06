namespace OpenProtocolInterpreter.MIDs.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data acknowledge
    /// Description: 
    ///     Acknowledgement of motor tuning result data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0502 : MID, IMotorTuning
    {
        private const int length = 20;
        public const int MID = 502;
        private const int revision = 1;

        public MID_0502() : base(length, MID, revision) { }

        internal MID_0502(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0502)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
