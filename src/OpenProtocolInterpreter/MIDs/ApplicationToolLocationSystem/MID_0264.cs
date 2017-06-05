namespace OpenProtocolInterpreter.MIDs.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID unsubscribe
    /// Description:
    ///     Used by the integrator to send a Tool tag ID unsubscription to the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Tool tag ID subscription does not exist or MID revision unsupported.
    /// </summary>
    public class MID_0264 : MID, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 264;
        private const int revision = 1;

        public MID_0264() : base(length, MID, revision) { }

        internal MID_0264(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0264)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
