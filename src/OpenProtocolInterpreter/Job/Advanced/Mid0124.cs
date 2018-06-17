namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control done
    /// Description: This message tells the integrator that the Job has 
    /// been completed before the alert level 2 was reached.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class Mid0124 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 124;

        public Mid0124(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        internal Mid0124(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
