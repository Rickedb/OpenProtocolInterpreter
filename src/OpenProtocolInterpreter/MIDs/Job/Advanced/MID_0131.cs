namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    /// <summary>
    /// MID: Set Job line control start
    /// Description: The integrator can set the line control start in the controller with this message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0131 : MID
    {
        private const int length = 20;
        public const int MID = 131;
        private const int revision = 1;

        public MID_0131() : base(length, MID, revision) { }

        internal MID_0131(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0131)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
