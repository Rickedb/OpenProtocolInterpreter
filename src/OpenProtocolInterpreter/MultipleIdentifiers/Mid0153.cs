namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Multiple identifiers and result parts acknowledge
    /// <para>Acknowledgement of multiple identifiers and result parts upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0153 : Mid, IMultipleIdentifier, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 1;
        public const int MID = 153;

        public Mid0153() : base(MID, LAST_REVISION)
        {
        }

        public Mid0153(Header header) : base(header)
        {
        }
    }
}
