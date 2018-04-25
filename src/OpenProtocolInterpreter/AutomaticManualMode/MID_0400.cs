namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode subscribe
    /// Description: 
    ///     A subscription for Automatic/Manual mode. When the mode changes the MID 0401 Automatic/Manual mode 
    ///     upload is sent to the integrator.
    ///     After a successful subscription the message MID 0401 Automatic/Manual mode upload with the 
    ///     current mode status is sent to the integrator.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Automatic/Manual mode subscribe already exists
    /// </summary>
    public class MID_0400 : Mid, IAutomaticManualMode
    {
        private const int length = 20;
        public const int MID = 400;
        private const int revision = 1;

        public MID_0400() : base(length, MID, revision) { }

        internal MID_0400(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0400)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
