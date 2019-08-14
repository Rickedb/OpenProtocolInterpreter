namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job info unsubscribe
    /// Description: Reset the subscription for a Job info message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Job info subscription does not exist
    /// </summary>
    public class Mid0037 : Mid, IJob, IIntegrator
    {
        private const int LAST_REVISION = 4;
        public const int MID = 37;

        public Mid0037() : this(LAST_REVISION)
        {

        }

        public Mid0037(int revision = LAST_REVISION) : base(MID, revision) { }
    }
}
