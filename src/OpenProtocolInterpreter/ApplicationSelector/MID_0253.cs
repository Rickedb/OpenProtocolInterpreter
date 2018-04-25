namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info unsubscribe
    /// Description:
    ///     Unsubscribe for the selector socket info. The subscription is reset for all selector devices.  
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, The selector socket info subscription does not exist
    /// </summary>
    public class MID_0253 : Mid, IApplicationSelector
    {
        private const int length = 20;
        public const int MID = 253;
        private const int revision = 1;

        public MID_0253() : base(length, MID, revision) { }

        internal MID_0253(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0253)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
