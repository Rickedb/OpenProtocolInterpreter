namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job line control info acknowledge
    /// <para>Acknowledgement of Job line control info messages <see cref="Mid0121"/>, <see cref="Mid0122"/>, <see cref="Mid0123"/>, and <see cref="Mid0124"/>.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0125 : Mid, IAdvancedJob, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 1;
        public const int MID = 125;

        public Mid0125() : base(MID, LAST_REVISION)
        {

        }

        public Mid0125(Header header) : base(header)
        {
        }
    }
}
