namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done unsubscribe
    /// Description: 
    ///     Reset the subscription for Lock at batch done.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// </summary>
    public class MID_0024 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 24;
        private const int revision = 1;

        public MID_0024() : base(length, MID, revision) { }

        internal MID_0024(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0024)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
