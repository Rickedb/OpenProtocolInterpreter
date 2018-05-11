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
    public class MID_0403 : Mid, IAutomaticManualMode
    {
        public const int MID = 403;
        private const int length = 20;
        private const int revision = 1;

        public MID_0403() : base(length, MID, revision) { }

        internal MID_0403(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0403)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
