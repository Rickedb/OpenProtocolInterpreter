namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset all Identifiers
    /// Description: 
    ///    This message is used by the integrator to reset all identifiers in the current work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0157 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 157;

        public MID_0157() : base(MID, LAST_REVISION) { }

        internal MID_0157(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
