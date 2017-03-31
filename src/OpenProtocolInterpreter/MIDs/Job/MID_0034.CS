namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job Info Subscribe
    /// Description:
    ///     A subscription for the Job info. MID 0035 Job info is sent to the integrator when a new Job is selected and after each tightening 
    ///     performed during the Job.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command Accepted or MID 0004 Command error, Job info subscription already exists
    /// </summary>
    public class MID_0034 : MID
    {
        private readonly Interfaces.IMID nextTemplate;

        private const int length = 63;
        private const int mid = 35;
        private const int revision = 1;

        public MID_0034() : base(length, mid, revision) { }

        public MID_0034(Interfaces.IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0034)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
