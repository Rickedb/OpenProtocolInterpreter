namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job info acknowledge
    /// Description: Acknowledgement of a Job info message.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0036 : Mid, IJob
    {
        private const int LAST_REVISION = 4;
        public const int MID = 36;

        public Mid0036(int revision = LAST_REVISION) : base(MID, revision) {  }

        internal Mid0036(IMid nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;
    }
}
