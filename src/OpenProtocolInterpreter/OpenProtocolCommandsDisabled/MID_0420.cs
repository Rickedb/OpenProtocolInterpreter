namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled subscribe
    /// Description: 
    ///     Set the subscription for the Open Protocol commands disable digital input. This command will result in
    ///     transmission of the Open Protocol commands disable input status.When a subscription is set the Open
    ///     Protocol commands disable digital input status is once uploaded(MID 0421) automatically.Thereafter,
    ///     the status is uploaded each time the digital input status changes(push function).
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Open Protocol commands disabled
    ///         subscription already exists
    /// </summary>
    public class MID_0420 : MID, IOpenProtocolCommandsDisabled
    {
        private const int length = 20;
        public const int MID = 420;
        private const int revision = 1;

        public MID_0420() : base(length, MID, revision) { }

        internal MID_0420(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0420)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
