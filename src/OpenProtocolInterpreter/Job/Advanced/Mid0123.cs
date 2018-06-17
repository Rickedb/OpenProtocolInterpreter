namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control alert 2
    /// Description: This message tells the integrator that the Job line control alert 2 is set in the controller.
    /// Only available when a job has been selected.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class Mid0123 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 123;

        public Mid0123(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        internal Mid0123(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
