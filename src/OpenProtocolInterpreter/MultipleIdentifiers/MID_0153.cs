namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifiers and result parts acknowledge
    /// Description: 
    ///    Acknowledgement of multiple identifiers and result parts upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0153 : Mid, IMultipleIdentifier
    {
        public const int MID = 153;
        private const int length = 20;
        private const int revision = 1;

        public MID_0153() : base(length, MID, revision) { }

        internal MID_0153(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0153)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
