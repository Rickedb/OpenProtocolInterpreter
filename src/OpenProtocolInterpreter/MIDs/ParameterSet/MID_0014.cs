namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected subscribe
    /// Description: 
    ///     A subscription for the parameter set selection. Each time a new parameter set is selected the MID 0015
    ///     Parameter set selected is sent to the integrator.Note that the immediate response is MID 0005 Command
    ///     accepted and MID 0015 Parameter set selected with the current parameter set number selected.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted and MID 0015 Parameter set selected
    /// </summary>
    public class MID_0014 : MID
    {
        private const int length = 20;
        private const int mid = 14;
        private const int revision = 1;

        public MID_0014() : base(length, mid, revision) { }

        internal MID_0014(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0014)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
