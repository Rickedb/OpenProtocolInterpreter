namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done subscribe
    /// Description: 
    ///     A subscription for the Lock at batch done relay status.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// Message: MID 0022 relay status immediately after MID 0005 Command accepted
    /// </summary>
    public class MID_0021 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 20;
        private const int mid = 21;
        private const int revision = 1;

        public MID_0021() : base(length, mid, revision) { }

        public MID_0021(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0021)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
