namespace OpenProtocolInterpreter.MIDs.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode subscribe
    /// Description: 
    ///     A subscription for Automatic/Manual mode. When the mode changes the MID 0401 Automatic/Manual mode 
    ///     upload is sent to the integrator.
    ///     After a successful subscription the message MID 0401 Automatic/Manual mode upload with the 
    ///     current mode status is sent to the integrator.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Automatic/Manual mode subscribe already exists
    /// </summary>
    public class MID_0400 : MID, IAutomaticManualMode
    {
        private const int length = 20;
        public const int MID = 400;
        private const int revision = 1;

        public MID_0400() : base(length, MID, revision) { }

        internal MID_0400(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0400)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
