namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data acknowledge
    /// Description: 
    ///     Acknowledgement of user data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0243 : Mid, IPLCUserData
    {
        private const int length = 20;
        public const int MID = 243;
        private const int revision = 1;

        public MID_0243() : base(length, MID, revision) { }

        internal MID_0243(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0243)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
