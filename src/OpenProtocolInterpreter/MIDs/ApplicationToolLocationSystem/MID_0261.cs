namespace OpenProtocolInterpreter.MIDs.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID subscribe
    /// Description:
    ///     Used by the integrator to order a Tool tag ID subscription from the controller.
    /// Message sent by: Controller
    /// Answer: MID 0262 Tool tag ID or
    ///         MID 0004 Command error, Tool tag ID unknown , Tool tag ID subscription already exist or MID revision unsupported.
    /// </summary>
    public class MID_0261 : MID, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 261;
        private const int revision = 1;

        public MID_0261() : base(length, MID, revision) { }

        internal MID_0261(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0261)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
