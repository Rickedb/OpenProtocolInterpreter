namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done subscribe
    /// Description: 
    ///     A subscription for the Lock at batch done relay status.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// Message: MID 0022 relay status immediately after MID 0005 Command accepted
    /// </summary>
    public class MID_0021 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 21;
        private const int revision = 1;

        public MID_0021() : base(length, MID, revision) { }

        internal MID_0021(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0021)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
