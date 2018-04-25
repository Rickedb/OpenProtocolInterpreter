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
    public class MID_0264 : Mid, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 264;
        private const int revision = 1;

        public MID_0264() : base(length, MID, revision) { }

        internal MID_0264(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0264)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
