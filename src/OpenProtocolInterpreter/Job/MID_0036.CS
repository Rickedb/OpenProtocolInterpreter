namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job info acknowledge
    /// Description: Acknowledgement of a Job info message.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0036 : MID, IJob
    {
        public const int MID = 36;
        private const int length = 20;
        private const int revision = 1;

        public MID_0036() : base(length, MID, revision) {  }

        internal MID_0036(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if(base.IsCorrectType(package))
                return (MID_0036)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
