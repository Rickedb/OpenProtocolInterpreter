namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled acknowledge
    /// Description: 
    ///     Acknowledgement of Open Protocol commands disabled upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0422 : Mid, IOpenProtocolCommandsDisabled
    {
        private const int length = 20;
        public const int MID = 422;
        private const int revision = 1;

        public MID_0422() : base(length, MID, revision) { }

        internal MID_0422(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0422)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
