namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Abort Job
    /// <para>Abort the current running job if there is one.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0127 : Mid, IAdvancedJob, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 127;

        public Mid0127() : base(MID, LAST_REVISION)
        {

        }

        public Mid0127(Header header) : base(header)
        {
        }
    }
}
