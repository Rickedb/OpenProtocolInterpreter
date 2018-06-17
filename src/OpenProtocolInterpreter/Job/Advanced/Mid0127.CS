namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Abort Job
    /// Description: Abort the current running job if there is one.
    /// Message sent by: Integrator
    /// Answer: MID 0005
    /// </summary>
    public class Mid0127 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 127;

        public Mid0127() : base(MID, LAST_REVISION)
        {

        }

        internal Mid0127(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
