namespace OpenProtocolInterpreter.MIDs.PLCUserData
{
    /// <summary>
    /// MID: User data unsubscribe
    /// Description: 
    ///     Unsubscribe for the user data.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Subscription already exists
    /// </summary>
    public class MID_0244 : MID, IPLCUserData
    {
        private const int length = 20;
        public const int MID = 243;
        private const int revision = 1;

        public MID_0244() : base(length, MID, revision) { }

        internal MID_0244(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0244)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
