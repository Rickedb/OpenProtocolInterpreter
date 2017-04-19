namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data unsubscribe
    /// Description: Reset the last tightening result subscription.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Last tightening result subscription does not exist
    /// </summary>
    public class MID_0063 : MID, ITightening
    {
        private const int length = 20;
        private const int mid = 63;
        private const int revision = 1;


        public MID_0063() : base(length, mid, revision)
        {

        }

        internal MID_0063(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
