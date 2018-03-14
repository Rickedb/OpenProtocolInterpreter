namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Enable tool
    /// Description: 
    ///     Enable tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0043 : MID, ITool
    {
        private const int length = 20;
        public const int MID = 43;
        private const int revision = 1;

        public MID_0043() : base(length, MID, revision)
        {

        }

        internal MID_0043(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
