namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info acknowledge
    /// Description: Acknowledgement of Job line control info messages MID 0121, 0122, 0123, and 0124.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0125 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 125;
        private const int revision = 1;

        public MID_0125() : base(length, MID, revision) { }

        internal MID_0125(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0125)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
