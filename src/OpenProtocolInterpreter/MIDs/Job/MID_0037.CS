namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job info unsubscribe
    /// Description: Reset the subscription for a Job info message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Job info subscription does not exist
    /// </summary>
    public class MID_0037 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 20;
        private const int mid = 37;
        private const int revision = 1;
        
        public MID_0037() : base(length, mid, revision) { }

        public MID_0037(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0037)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
