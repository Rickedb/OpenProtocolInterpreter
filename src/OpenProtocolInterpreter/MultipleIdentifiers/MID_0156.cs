namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset latest Identifier
    /// Description: 
    ///    This message is used by the integrator to reset the latest identifier 
    ///    or bypassed identifier in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0156 : MID, IMultipleIdentifier
    {
        public const int MID = 156;
        private const int length = 20;
        private const int revision = 1;

        public MID_0156() : base(length, MID, revision) { }

        internal MID_0156(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0156)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
