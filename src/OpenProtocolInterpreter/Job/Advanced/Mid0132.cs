namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Set Job line alert 1
    /// <para>The integrator can set the line control alert 1 in the controller with this message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0132 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 132;

        public Mid0132() : base(MID, LAST_REVISION) { }

        public Mid0132(Header header) : base(header)
        {
        }
    }
}
