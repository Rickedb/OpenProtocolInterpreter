namespace OpenProtocolInterpreter.MotorTuning
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
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0504)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
