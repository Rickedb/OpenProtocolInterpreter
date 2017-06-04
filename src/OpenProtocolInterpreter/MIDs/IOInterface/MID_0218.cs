namespace OpenProtocolInterpreter.MIDs.IOInterface
{
    /// <summary>
    /// MID: Relay function acknowledge
    /// Description: 
    ///     Acknowledgement of relay function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0218 : MID, IIOInterface
    {
        public const int MID = 218;
        private const int length = 20;
        private const int revision = 1;

        public MID_0218() : base(length, MID, revision) { }

        internal MID_0218(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0218)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
