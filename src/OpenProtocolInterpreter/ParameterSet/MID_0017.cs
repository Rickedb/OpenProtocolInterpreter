namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected unsubscribe
    /// Description: 
    ///     Reset the subscription for the parameter set selection.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Parameter set subscription does not exist
    /// </summary>
    public class MID_0017 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 17;
        private const int revision = 1;

        public MID_0017() : base(length, MID, revision) { }

        internal MID_0017(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0017)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
