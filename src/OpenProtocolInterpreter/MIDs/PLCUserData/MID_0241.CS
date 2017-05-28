namespace OpenProtocolInterpreter.MIDs.PLCUserData
{
    /// <summary>
    /// MID: User data subscribe
    /// Description: 
    ///     Subscribe for user data. This command will activate the MID 0242 User data message to be sent when a
    ///     change in the user data output has been detected.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Subscription already exists, or
    ///         Controller is not a sync master/station controller
    /// </summary>
    public class MID_0241 : MID, IPLCUserData
    {
        private const int length = 20;
        public const int MID = 241;
        private const int revision = 1;

        public MID_0241() : base(length, MID, revision) { }

        internal MID_0241(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0241)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}