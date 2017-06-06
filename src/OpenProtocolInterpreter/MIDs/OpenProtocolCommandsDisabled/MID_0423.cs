namespace OpenProtocolInterpreter.MIDs.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled unsubscribe
    /// Description: 
    ///     Reset the subscription for the Open Protocol commands disabled digital input.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Open Protocol commands disabled
    ///         subscription does not exist
    /// </summary>
    public class MID_0423 : MID, IOpenProtocolCommandsDisabled
    {
        private const int length = 20;
        public const int MID = 423;
        private const int revision = 1;

        public MID_0423() : base(length, MID, revision) { }

        internal MID_0423(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0423)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
