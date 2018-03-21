namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job info unsubscribe
    /// Description: Reset the subscription for a Job info message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Job info subscription does not exist
    /// </summary>
    public class MID_0037 : MID, IJob
    {
        private const int LAST_REVISION = 4;
        public const int MID = 37;
        
        public MID_0037(int revision = LAST_REVISION) : base(MID, revision) { }

        internal MID_0037(IMID nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;
    }
}
