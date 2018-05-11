namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info unsubscribe
    /// Description: Unsubscribe for the Job line control info messages.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Job line control info subscription does not exist
    /// </summary>
    public class MID_0126 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 126;

        public MID_0126() : base(MID, LAST_REVISION) { }

        internal MID_0126(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
