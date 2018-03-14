namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
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
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0264)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
