namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job ID upload request
    /// Description:
    ///     This is a request for a transmission of all the valid Job IDs of the controller.
    ///     The result of this command is a transmission of all the valid Job IDs.
    /// Message sent by: Integrator
    /// Answer: MID 0031 Job ID upload reply
    /// </summary>
    public class MID_0030 : MID, IJob
    {
        private const int length = 20;
        public const int MID = 30;
        private const int revision = 1;

        public MID_0030() : base(length, MID, revision) { }

        internal MID_0030(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0030)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
