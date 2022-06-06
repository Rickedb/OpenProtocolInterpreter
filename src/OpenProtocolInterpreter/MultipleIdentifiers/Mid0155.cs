namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Bypass Identifier
    /// <para>This message is used by the integrator to bypass the next identifier expected in the work order.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0155 : Mid, IMultipleIdentifier, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 155;

        public Mid0155() : base(MID, LAST_REVISION) 
        { 
        }

        public Mid0155(Header header) : base(header)
        {
        }
    }
}
