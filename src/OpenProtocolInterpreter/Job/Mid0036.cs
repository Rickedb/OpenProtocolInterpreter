namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job info acknowledge
    /// <para>Acknowledgement of a Job info message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0036 : Mid, IJob, IIntegrator, IAcknowledge
    {
        public const int MID = 36;

        public Mid0036() : this(DEFAULT_REVISION)
        {

        }

        public Mid0036(int revision = DEFAULT_REVISION) : base(MID, revision) {  }

        public Mid0036(Header header) : base(header)
        {
        }
    }
}