namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job ID upload request
    /// Description:
    ///     This is a request for a transmission of all the valid Job IDs of the controller.
    ///     The result of this command is a transmission of all the valid Job IDs.
    /// Message sent by: Integrator
    /// Answer: MID 0031 Job ID upload reply
    /// </summary>
    public class Mid0030 : Mid, IJob, IIntegrator
    {
        private const int LAST_REVISION = 2;
        public const int MID = 30;

        public Mid0030() : this(LAST_REVISION)
        {

        }

        public Mid0030(int revision = LAST_REVISION) : base(MID, revision) { }
    }
}
