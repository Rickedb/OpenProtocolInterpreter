namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done unsubscribe
    /// Description: 
    ///     Reset the subscription for Lock at batch done.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// </summary>
    public class MID_0024 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 20;
        private const int mid = 24;
        private const int revision = 1;

        public MID_0024() : base(length, mid, revision) { }

        public MID_0024(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0024)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
