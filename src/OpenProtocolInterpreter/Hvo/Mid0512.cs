namespace OpenProtocolInterpreter.Hvo
{
    /// <summary>
    /// HVO signal change acknowledge
    /// <para>Acknowledgement of HVO signal change upload (MID 0511).</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0512 : Mid, IHvo, IIntegrator, IAcknowledge
    {
        public const int MID = 512;

        public Mid0512() : this(DEFAULT_REVISION) { }

        public Mid0512(Header header) : base(header) { }

        public Mid0512(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
