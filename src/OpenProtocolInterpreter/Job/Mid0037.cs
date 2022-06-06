namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job info unsubscribe
    /// <para>Reset the subscription for a Job info message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job info subscription does not exist</para>
    /// </summary>
    public class Mid0037 : Mid, IJob, IIntegrator
    {
        private const int LAST_REVISION = 4;
        public const int MID = 37;

        public Mid0037() : this(LAST_REVISION)
        {

        }

        public Mid0037(int revision = LAST_REVISION) : base(MID, revision) { }

        public Mid0037(Header header) : base(header)
        {
        }
    }
}
