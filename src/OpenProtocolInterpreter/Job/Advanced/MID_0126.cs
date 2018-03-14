namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info unsubscribe
    /// Description: Unsubscribe for the Job line control info messages.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Job line control info subscription does not exist
    /// </summary>
    public class MID_0126 : MID, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 126;
        private const int revision = 1;

        public MID_0126() : base(length, MID, revision) { }

        internal MID_0126(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0126)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
