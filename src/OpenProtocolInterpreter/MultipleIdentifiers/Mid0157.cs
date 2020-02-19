namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Reset all Identifiers
    /// <para>This message is used by the integrator to reset all identifiers in the current work order.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0157 : Mid, IMultipleIdentifier, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 157;

        public Mid0157() : base(MID, LAST_REVISION) { }
    }
}
