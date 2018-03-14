namespace OpenProtocolInterpreter.Tightening
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
        public const int MID = 63;
        private const int revision = 1;


        public MID_0063() : base(length, MID, revision)
        {

        }

        internal MID_0063(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
