namespace OpenProtocolInterpreter.MIDs.MultipleIdentifiers
{
    /// <summary>
    /// MID: Bypass Identifier
    /// Description: 
    ///    This message is used by the integrator to bypass the next identifier expected in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0155 : MID, IMultipleIdentifier
    {
        public const int MID = 155;
        private const int length = 20;
        private const int revision = 1;

        public MID_0155() : base(length, MID, revision) { }

        internal MID_0155(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0155)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
