namespace OpenProtocolInterpreter.MIDs.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset latest Identifier
    /// Description: 
    ///    This message is used by the integrator to reset the latest identifier 
    ///    or bypassed identifier in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0156 : MID, IMultipleIdentifier
    {
        public const int MID = 156;
        private const int length = 20;
        private const int revision = 1;

        public MID_0156() : base(length, MID, revision) { }

        internal MID_0156(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0156)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
