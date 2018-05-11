namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job batch increment
    /// Description: Decrement the Job batch if there is a current running Job. 
    /// Two revisions are available for this MID.
    /// The default revision or revision 1 does not contain any argument and always decrement the last
    /// tightening completed in a Job.
    /// 
    /// The revision 2 contains two parameters; the channel ID and parameter set ID to be decremented.
    /// 
    /// The MID is always sent to the cell master/reference.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Job batch decrement failed (only for MID revision 2)
    /// </summary>
    public class MID_0129 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 129;
        private const int revision = 1;

        public MID_0129() : base(length, MID, revision) { }

        internal MID_0129(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0129)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
