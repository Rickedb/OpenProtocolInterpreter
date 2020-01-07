namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job info acknowledge
    /// <para>Acknowledgement of a Job info message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0036 : Mid, IJob, IIntegrator
    {
        private const int LAST_REVISION = 4;
        public const int MID = 36;

        public Mid0036() : this(LAST_REVISION)
        {

        }

        public Mid0036(int revision = LAST_REVISION) : base(MID, revision) {  }
    }
}