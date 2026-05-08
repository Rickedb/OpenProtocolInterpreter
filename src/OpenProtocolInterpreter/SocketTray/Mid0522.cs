namespace OpenProtocolInterpreter.SocketTray
{
    /// <summary>
    /// Socket tray change acknowledge
    /// <para>Acknowledgement of socket tray change upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0522 : Mid, ISocketTray, IIntegrator, IAcknowledge
    {
        public const int MID = 522;

        public Mid0522() : this(DEFAULT_REVISION) { }

        public Mid0522(Header header) : base(header) { }

        public Mid0522(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
