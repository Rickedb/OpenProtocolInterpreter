namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control started
    /// Description: This message tells the integrator that Job Line control start has been set in the controller.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class MID_0121 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 121;

        public MID_0121(int? noAckFlag = 1) : base(MID, LAST_REVISION, noAckFlag) { }

        internal MID_0121(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
