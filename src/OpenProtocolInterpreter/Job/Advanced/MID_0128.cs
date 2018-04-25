namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job batch increment
    /// Description: Increment the Job batch if there is a current running Job.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0128 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 128;
        private const int revision = 1;

        public MID_0128() : base(length, MID, revision) { }

        internal MID_0128(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0128)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
