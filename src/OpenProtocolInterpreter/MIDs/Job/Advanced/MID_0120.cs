namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info subscribe
    /// Description: A subscription for the Job line control information.
    /// A message is sent to the integrator when the Job line control is started, for alert level 1, 
    /// for alert level 2, or when the Job is finished before the alert level 2 (Job line control done).
    /// Message sent by: Integrator
    /// Answer: MID 0005 or MID 0004 Command error, Job line control info subscription already exists
    /// </summary>
    public class MID_0120 : MID
    {
        private const int length = 20;
        public const int MID = 120;
        private const int revision = 1;

        public MID_0120() : base(length, MID, revision) { }

        internal MID_0120(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0120)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
