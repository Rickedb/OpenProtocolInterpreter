namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    /// <summary>
    /// MID: Job line control started
    /// Description: This message tells the integrator that Job Line control start has been set in the controller.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class MID_0121 : MID, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 121;
        private const int revision = 1;

        public MID_0121() : base(length, MID, revision) { }

        internal MID_0121(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0121)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
