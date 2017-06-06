namespace OpenProtocolInterpreter.MIDs.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning request
    /// Description: 
    ///     Request the start of the motor tuning.
    ///     
    ///     Warning !: This command must be implemented during hard restrictions and 
    ///     customer dependent requirements.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Tool motor tuning failed
    /// </summary>
    public class MID_0504 : MID, IMotorTuning
    {
        private const int length = 20;
        public const int MID = 504;
        private const int revision = 1;

        public MID_0504() : base(length, MID, revision) { }

        internal MID_0504(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0504)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
