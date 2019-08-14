namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job Info Subscribe
    /// Description:
    ///     A subscription for the Job info. MID 0035 Job info is sent to the integrator when a new Job is selected and after each tightening 
    ///     performed during the Job.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command Accepted or MID 0004 Command error, Job info subscription already exists
    /// </summary>
    public class Mid0034 : Mid, IJob, IIntegrator
    {
        private const int LAST_REVISION = 4;
        public const int MID = 34;

        public Mid0034() : this(LAST_REVISION)
        {

        }

        /// <summary>
        /// Revision 1 to 4 Constructor
        /// </summary>
        /// <param name="noAckFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public Mid0034(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, revision, noAckFlag) { }
    }
}
