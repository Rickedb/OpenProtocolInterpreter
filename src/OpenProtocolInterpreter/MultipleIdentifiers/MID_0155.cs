namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Bypass Identifier
    /// Description: 
    ///    This message is used by the integrator to bypass the next identifier expected in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0155 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 155;

        public MID_0155() : base(MID, LAST_REVISION) { }

        internal MID_0155(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
