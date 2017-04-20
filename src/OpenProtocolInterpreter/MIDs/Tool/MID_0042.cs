namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Disable tool
    /// Description: 
    ///     Disable tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0042 : MID, ITool
    {
        private const int length = 20;
        public const int MID = 42;
        private const int revision = 1;

        public MID_0042() : base(length, MID, revision)
        {

        }

        internal MID_0042(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
