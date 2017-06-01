namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info acknowledge
    /// Description: Acknowledgement of Job line control info messages MID 0121, 0122, 0123, and 0124.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0125 : MID
    {
        private const int length = 20;
        public const int MID = 125;
        private const int revision = 1;

        public MID_0125() : base(length, MID, revision) { }

        internal MID_0125(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0125)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
