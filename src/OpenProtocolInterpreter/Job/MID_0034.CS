namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job Info Subscribe
    /// Description:
    ///     A subscription for the Job info. MID 0035 Job info is sent to the integrator when a new Job is selected and after each tightening 
    ///     performed during the Job.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command Accepted or MID 0004 Command error, Job info subscription already exists
    /// </summary>
    public class MID_0034 : MID, IJob
    {
        private const int length = 20;
        public const int MID = 34;
        private const int revision = 1;

        public MID_0034() : base(length, MID, revision) { }

        internal MID_0034(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0034)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
