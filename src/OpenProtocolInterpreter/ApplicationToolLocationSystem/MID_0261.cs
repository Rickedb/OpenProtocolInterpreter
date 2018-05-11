namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID subscribe
    /// Description:
    ///     Used by the integrator to order a Tool tag ID subscription from the controller.
    /// Message sent by: Controller
    /// Answer: MID 0262 Tool tag ID or
    ///         MID 0004 Command error, Tool tag ID unknown , Tool tag ID subscription already exist or MID revision unsupported.
    /// </summary>
    public class MID_0261 : Mid, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 261;
        private const int revision = 1;

        public MID_0261() : base(length, MID, revision) { }

        internal MID_0261(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0261)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
