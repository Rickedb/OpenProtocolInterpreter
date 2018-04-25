namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: reset all Identifiers
    /// Description: 
    ///    This message is used by the integrator to reset all identifiers in the current work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0157 : Mid, IMultipleIdentifier
    {
        public const int MID = 157;
        private const int length = 20;
        private const int revision = 1;

        public MID_0157() : base(length, MID, revision) { }

        internal MID_0157(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0157)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
