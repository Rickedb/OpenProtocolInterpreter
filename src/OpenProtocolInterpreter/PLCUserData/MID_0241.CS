namespace OpenProtocolInterpreter.PLCUserData
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
    public class MID_0241 : Mid, IPLCUserData
    {
        private const int length = 20;
        public const int MID = 241;
        private const int revision = 1;

        public MID_0241() : base(length, MID, revision) { }

        internal MID_0241(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0241)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}