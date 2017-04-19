namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected acknowledge
    /// Description: 
    ///     Acknowledgement for a new parameter set selected.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0016 : MID, IParameterSet
    {
        private const int length = 20;
        private const int mid = 16;
        private const int revision = 1;

        public MID_0016() : base(length, mid, revision) { }

        internal MID_0016(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0016)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
