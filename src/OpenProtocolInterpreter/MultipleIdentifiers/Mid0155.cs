namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Bypass Identifier
    /// Description: 
    ///    This message is used by the integrator to bypass the next identifier expected in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0155 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 155;

        public Mid0155() : base(MID, LAST_REVISION) { }

        internal Mid0155(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
