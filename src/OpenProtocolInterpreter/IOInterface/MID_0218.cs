namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function acknowledge
    /// Description: 
    ///     Acknowledgement of relay function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0218 : Mid, IIOInterface
    {
        public const int MID = 218;
        private const int length = 20;
        private const int revision = 1;

        public MID_0218() : base(length, MID, revision) { }

        internal MID_0218(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0218)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
