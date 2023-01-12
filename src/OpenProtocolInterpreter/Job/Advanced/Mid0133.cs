namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Set Job line alert 2
    /// <para>The integrator can set the line control alert 2 in the controller with this message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0133 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 133;

        public Mid0133() : base(MID, LAST_REVISION) { }

        public Mid0133(Header header) : base(header)
        {
        }
    }
}