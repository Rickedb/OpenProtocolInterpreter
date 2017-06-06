namespace OpenProtocolInterpreter.MIDs.AutomaticManualMode
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
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0402)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
