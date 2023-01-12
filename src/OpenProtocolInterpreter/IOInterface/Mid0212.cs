namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Status externally monitored inputs acknowledge
    /// <para>Acknowledgement for the message status externally monitored inputs upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0212 : Mid, IIOInterface, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 1;
        public const int MID = 212;

        public Mid0212() : base(MID, LAST_REVISION) { }

        public Mid0212(Header header) : base(header)
        {
        }
    }
}
