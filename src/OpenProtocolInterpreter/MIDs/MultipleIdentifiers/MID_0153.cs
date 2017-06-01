namespace OpenProtocolInterpreter.MIDs.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifiers and result parts acknowledge
    /// Description: 
    ///    Acknowledgement of multiple identifiers and result parts upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0153 : MID, IMultipleIdentifier
    {
        public const int MID = 153;
        private const int length = 20;
        private const int revision = 1;

        public MID_0153() : base(length, MID, revision) { }

        internal MID_0153(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0153)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
