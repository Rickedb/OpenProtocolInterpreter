namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info subscribe
    /// Description: A subscription for the Job line control information.
    /// A message is sent to the integrator when the Job line control is started, for alert level 1, 
    /// for alert level 2, or when the Job is finished before the alert level 2 (Job line control done).
    /// Message sent by: Integrator
    /// Answer: MID 0005 or MID 0004 Command error, Job line control info subscription already exists
    /// </summary>
    public class Mid0120 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 120;

        public Mid0120(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
        }

        internal Mid0120(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
