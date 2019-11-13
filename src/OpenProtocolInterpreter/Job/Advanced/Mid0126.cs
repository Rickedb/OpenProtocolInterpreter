namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control info unsubscribe
    /// Description: Unsubscribe for the Job line control info messages.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Job line control info subscription does not exist
    /// </summary>
    public class Mid0126 : Mid, IAdvancedJob, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 126;

        public Mid0126() : base(MID, LAST_REVISION) { }
        
    }
}
