namespace OpenProtocolInterpreter.MIDs.AutomaticManualMode
{
    /// <summary>
    /// MID: AutoDisable settings request
    /// Description: 
    ///     Request for AutoDisable settings. This request is intended to be used while 
    ///     running single parameter sets with batch and does not provide batch information while running Job.
    /// Message sent by: Integrator
    /// Answer: MID 0411 AutoDisable settings reply
    /// </summary>
    public class MID_0410 : MID, IAutomaticManualMode
    {
        public const int MID = 410;
        private const int length = 20;
        private const int revision = 1;

        public MID_0410() : base(length, MID, revision) { }

        internal MID_0410(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0410)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
