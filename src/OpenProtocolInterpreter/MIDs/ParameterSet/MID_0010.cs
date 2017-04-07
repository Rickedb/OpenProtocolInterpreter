namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set ID upload request
    /// Description: 
    ///     A request to get the valid parameter set IDs from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0011 Parameter set ID upload reply
    /// </summary>
    public class MID_0010 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 20;
        private const int mid = 10;
        private const int revision = 1;

        public MID_0010() : base(length, mid, revision) { }

        internal MID_0010(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0010)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
