namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode acknowledge
    /// Description: 
    ///     Acknowledgement of automatic/manual mode upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0402 : MID, IAutomaticManualMode
    {
        public const int MID = 402;
        private const int length = 20;
        private const int revision = 1;

        public MID_0402() : base(length, MID, revision) { }

        internal MID_0402(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0402)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
