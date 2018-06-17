namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifier and result parts unsubscribe
    /// Description: 
    ///    Reset the subscription for the multiple identifiers and result parts.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error,
    /// Multiple identifiers and result parts subscription does not exist
    /// </summary>
    public class Mid0154 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 154;

        public Mid0154() : base(MID, LAST_REVISION) { }

        internal Mid0154(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
