namespace OpenProtocolInterpreter.MIDs.PLCUserData
{
    /// <summary>
    /// MID: User data acknowledge
    /// Description: 
    ///     Acknowledgement of user data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0243 : MID, IPLCUserData
    {
        private const int length = 20;
        public const int MID = 243;
        private const int revision = 1;

        public MID_0243() : base(length, MID, revision) { }

        internal MID_0243(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0243)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
