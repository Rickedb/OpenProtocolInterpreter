namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job Info Subscribe
    /// <para>
    ///     A subscription for the Job info. <see cref="Mid0035"/> Job info is sent to the integrator when a new Job is selected and after 
    ///     each tightening performed during the Job.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command Accepted or <see cref="Communication.Mid0004"/> Command error, Job info subscription already exists</para>
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
        /// <param name="noAckFlag">False=Ack needed, True=No Ack needed</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public Mid0034(int revision = LAST_REVISION, bool noAckFlag = false) : base(MID, revision, noAckFlag) { }
    }
}
