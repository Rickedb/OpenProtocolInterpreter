namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job batch increment
    /// Description: Increment the Job batch if there is a current running Job.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0128 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 128;

        public Mid0128() : base(MID, LAST_REVISION) { }

        internal Mid0128(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
