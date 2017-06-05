namespace OpenProtocolInterpreter.MIDs.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID request
    /// Description:
    ///     Used by the integrator to request Tool tag ID information.
    /// Message sent by: Controller
    /// Answer: MID 0262 Tool tag ID or
    ///         MID 0004 Command error, Tool tag ID unknown or MID revision unsupported.
    /// </summary>
    public class MID_0260 : MID, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 260;
        private const int revision = 1;

        public MID_0260() : base(length, MID, revision) { }

        internal MID_0260(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0260)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
