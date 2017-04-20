namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload Acknowledge
    /// Description: 
    ///     This message is an acknowledge to MID 0022.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0023 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 23;
        private const int revision = 1;

        public MID_0023() : base(length, MID, revision) { }

        internal MID_0023(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0023)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
