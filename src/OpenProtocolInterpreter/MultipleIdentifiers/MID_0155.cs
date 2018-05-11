namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Bypass Identifier
    /// Description: 
    ///    This message is used by the integrator to bypass the next identifier expected in the work order.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0155 : Mid, IMultipleIdentifier
    {
        public const int MID = 155;
        private const int length = 20;
        private const int revision = 1;

        public MID_0155() : base(length, MID, revision) { }

        internal MID_0155(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0155)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
