namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Rexroth job result acknowledge
    /// <para>Acknowledgement of job result upload (<see cref="Mid0555"/>).</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0556 : Mid, IRexrothJob, IIntegrator, IAcknowledge
    {
        public const int MID = 556;

        public Mid0556() : this(DEFAULT_REVISION) { }

        public Mid0556(Header header) : base(header) { }

        public Mid0556(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
