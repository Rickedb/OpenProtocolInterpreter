namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode unsubscribe
    /// Description: 
    ///     Reset the subscription for the automatic/manual mode.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Automatic/Manual mode subscribe does not exist
    /// </summary>
    public class MID_0403 : MID, IAutomaticManualMode
    {
        public const int MID = 403;
        private const int length = 20;
        private const int revision = 1;

        public MID_0403() : base(length, MID, revision) { }

        internal MID_0403(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0403)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
