namespace OpenProtocolInterpreter.MultiSpindle.Status
{
    /// <summary>
    /// MID: Multi-spindle status subscribe
    /// Description:
    ///     A subscription for the multi-spindle status. For Power Focus, the subscription must be addressed to the sync Master.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, 
    ///         Controller is not a sync master/station controller, 
    ///         or Multi-spindle status subscription already exists
    /// </summary>
    public class MID_0090 : MID, IMultiSpindle
    {   
        public const int MID = 90;
        private const int length = 20;
        private const int revision = 1;

        public MID_0090() : base(length, MID, revision) { }

        internal MID_0090(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0090)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
