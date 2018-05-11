namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID request
    /// Description:
    ///     Used by the integrator to request Tool tag ID information.
    /// Message sent by: Controller
    /// Answer: MID 0262 Tool tag ID or
    ///         MID 0004 Command error, Tool tag ID unknown or MID revision unsupported.
    /// </summary>
    public class MID_0260 : Mid, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 260;
        private const int revision = 1;

        public MID_0260() : base(length, MID, revision) { }

        internal MID_0260(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0260)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
