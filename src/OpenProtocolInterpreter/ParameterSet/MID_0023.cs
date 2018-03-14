namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload Acknowledge
    /// Description: 
    ///     This message is an acknowledge to MID 0022.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0023 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 23;
        private const int revision = 1;

        public MID_0023() : base(length, MID, revision) { }

        internal MID_0023(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0023)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
