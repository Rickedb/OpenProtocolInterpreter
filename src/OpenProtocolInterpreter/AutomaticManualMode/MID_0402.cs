namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode acknowledge
    /// Description: 
    ///     Acknowledgement of automatic/manual mode upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0402 : Mid, IAutomaticManualMode
    {
        public const int MID = 402;
        private const int length = 20;
        private const int revision = 1;

        public MID_0402() : base(length, MID, revision) { }

        internal MID_0402(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0402)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
