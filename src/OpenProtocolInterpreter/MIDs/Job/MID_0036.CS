namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job info acknowledge
    /// Description: Acknowledgement of a Job info message.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0036 : MID, IJob
    {
        private const int length = 20;
        public const int MID = 36;
        private const int revision = 1;

        public MID_0036() : base(length, MID, revision) {  }

        internal MID_0036(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if(base.isCorrectType(package))
                return (MID_0036)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
