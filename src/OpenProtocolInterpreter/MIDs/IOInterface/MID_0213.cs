namespace OpenProtocolInterpreter.MIDs.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs unsubscribe
    /// Description: 
    ///     Unsubscribe for the MID 0211 Status externally monitored inputs.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    /// MID 0004 Command error, 
    /// Status externally monitored inputs subscription does not exist
    /// </summary>
    public class MID_0213 : MID, IIOInterface
    {
        public const int MID = 213;
        private const int length = 20;
        private const int revision = 1;

        public MID_0213() : base(length, MID, revision) { }

        internal MID_0213(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0213)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
