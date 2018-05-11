namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifier and result parts subscribe
    /// Description: 
    ///    This message is used by the integrator to set a subscription for the work order status, optional
    ///    identifiers and result parts extracted from the identifiers received and accepted by the controller.The
    ///    identifiers may have been received by the controller from one or several input sources (Serial,
    ///    Ethernet, Field bus, ST scanner etc.).
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Multiple identifier and result parts subscription already exists
    /// </summary>
    public class MID_0151 : Mid, IMultipleIdentifier
    {
        public const int MID = 151;
        private const int length = 20;
        private const int revision = 1;

        public MID_0151() : base(length, MID, revision) { }

        internal MID_0151(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0151)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
