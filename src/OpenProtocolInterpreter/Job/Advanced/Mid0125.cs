namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info acknowledge
    /// Description: Acknowledgement of Job line control info messages MID 0121, 0122, 0123, and 0124.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0125 : Mid, IAdvancedJob, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 125;

        public Mid0125() : this(0)
        {

        }

        public Mid0125(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
