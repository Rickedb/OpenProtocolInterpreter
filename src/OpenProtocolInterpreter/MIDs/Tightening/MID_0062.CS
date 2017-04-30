namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data acknowledge
    /// Description: Acknowledgement of last tightening result data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0062 : MID, ITightening
    {
        private const int length = 20;
        public const int MID = 62;
        private const int revision = 1;
        

        public MID_0062() : base(length, MID, revision)
        {

        }

        internal MID_0062(IMID nextTemplate) : base(length, MID, revision)
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
