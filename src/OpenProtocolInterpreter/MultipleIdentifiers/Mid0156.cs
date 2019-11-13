namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset latest Identifier
    /// Description: 
    ///    This message is used by the integrator to reset the latest identifier 
    ///    or bypassed identifier in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0156 : Mid, IMultipleIdentifier, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 156;

        public Mid0156() : base(MID, LAST_REVISION) { }
    }
}
