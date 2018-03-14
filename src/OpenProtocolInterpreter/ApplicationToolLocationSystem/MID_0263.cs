namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID acknowledge
    /// Description:
    ///     Acknowledgement of MID 0262 Tool tag ID.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0263 : MID, IApplicationToolLocationSystem
    {
        private const int length = 20;
        public const int MID = 263;
        private const int revision = 1;

        public MID_0263() : base(length, MID, revision) { }

        internal MID_0263(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0263)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
