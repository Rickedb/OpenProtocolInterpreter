namespace OpenProtocolInterpreter.MIDs.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled acknowledge
    /// Description: 
    ///     Acknowledgement of Open Protocol commands disabled upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0422 : MID, IOpenProtocolCommandsDisabled
    {
        private const int length = 20;
        public const int MID = 422;
        private const int revision = 1;

        public MID_0422() : base(length, MID, revision) { }

        internal MID_0422(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0422)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
