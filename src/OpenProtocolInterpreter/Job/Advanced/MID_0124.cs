namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control done
    /// Description: This message tells the integrator that the Job has 
    /// been completed before the alert level 2 was reached.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class MID_0124 : MID, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 124;
        private const int revision = 1;

        public MID_0124() : base(length, MID, revision) { }

        internal MID_0124(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0124)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
