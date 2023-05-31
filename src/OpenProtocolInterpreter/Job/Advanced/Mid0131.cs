namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Set Job line control start
    /// <para>The integrator can set the line control start in the controller with this message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0131 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        public const int MID = 131;

        public Mid0131() : base(MID, DEFAULT_REVISION) { }

        public Mid0131(Header header) : base(header)
        {
        }
    }
}