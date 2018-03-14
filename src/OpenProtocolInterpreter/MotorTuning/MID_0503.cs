namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data unsubscribe
    /// Description: 
    ///     Reset the motor tuning result subscription.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Motor Tuning result subscription does not exist
    /// </summary>
    public class MID_0503 : MID, IMotorTuning
    {
        private const int length = 20;
        public const int MID = 503;
        private const int revision = 1;

        public MID_0503() : base(length, MID, revision) { }

        internal MID_0503(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0503)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
