namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset all Identifiers
    /// Description: 
    ///    This message is used by the integrator to reset all identifiers in the current work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0157 : Mid, IMultipleIdentifier, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 157;

        public Mid0157() : base(MID, LAST_REVISION) { }
    }
}
