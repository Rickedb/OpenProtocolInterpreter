namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Abort Job
    /// <para>Abort the current running job if there is one.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0127 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        public const int MID = 127;

        public Mid0127() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0127(Header header) : base(header)
        {
        }
    }
}
