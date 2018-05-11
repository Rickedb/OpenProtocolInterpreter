namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID acknowledge
    /// Description:
    ///     Acknowledgement of MID 0262 Tool tag ID.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0263 : Mid, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 263;
        private const int revision = 1;

        public MID_0263() : base(length, MID, revision) { }

        internal MID_0263(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0263)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
