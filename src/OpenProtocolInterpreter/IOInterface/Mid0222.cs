namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Digital input function acknowledge
    /// <para>Acknowledgement of the digital input function upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0222 : Mid, IIOInterface, IIntegrator, IAcknowledge
    {
        public const int MID = 222;

        public Mid0222() : base(MID, DEFAULT_REVISION) { }

        public Mid0222(Header header) : base(header)
        {
        }
    }
}
