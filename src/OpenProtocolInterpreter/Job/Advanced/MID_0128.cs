namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job batch increment
    /// Description: Increment the Job batch if there is a current running Job.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0128 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 128;

        public MID_0128() : base(MID, LAST_REVISION) { }

        internal MID_0128(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
