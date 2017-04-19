namespace OpenProtocolInterpreter.MIDs.ParameterSet
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
        private const int mid = 17;
        private const int revision = 1;

        public MID_0017() : base(length, mid, revision) { }

        internal MID_0017(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0017)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
