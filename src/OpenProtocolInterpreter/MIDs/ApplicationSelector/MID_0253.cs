namespace OpenProtocolInterpreter.MIDs.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info unsubscribe
    /// Description:
    ///     Unsubscribe for the selector socket info. The subscription is reset for all selector devices.  
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, The selector socket info subscription does not exist
    /// </summary>
    public class MID_0253 : MID, IApplicationSelector
    {
        private const int length = 20;
        public const int MID = 253;
        private const int revision = 1;

        public MID_0253() : base(length, MID, revision) { }

        internal MID_0253(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0253)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
