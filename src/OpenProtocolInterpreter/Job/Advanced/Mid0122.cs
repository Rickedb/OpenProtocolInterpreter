namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control alert 1
    /// Description: This message tells the integrator that, for example, 
    /// a car has reached 80% of the station and that the
    /// Job line control alert 1 is set in the controller.
    /// Only available when a job has been selected.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class Mid0122 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 122;

        public Mid0122(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        internal Mid0122(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
