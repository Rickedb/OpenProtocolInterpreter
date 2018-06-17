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
    public class Mid0151 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 151;

        public Mid0151(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        internal Mid0151(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
