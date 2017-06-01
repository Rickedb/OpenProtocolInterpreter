namespace OpenProtocolInterpreter.MIDs.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset all Identifiers
    /// Description: 
    ///    This message is used by the integrator to reset all identifiers in the current work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0157 : MID, IMultipleIdentifier
    {
        public const int MID = 157;
        private const int length = 20;
        private const int revision = 1;

        public MID_0157() : base(length, MID, revision) { }

        internal MID_0157(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0157)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
