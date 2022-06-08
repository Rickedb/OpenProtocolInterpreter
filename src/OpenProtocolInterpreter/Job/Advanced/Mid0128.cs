namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job batch increment
    /// <para>Increment the Job batch if there is a current running Job.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0128 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 128;

        public Mid0128() : base(MID, LAST_REVISION) { }

        public Mid0128(Header header) : base(header)
        {
        }
    }
}
