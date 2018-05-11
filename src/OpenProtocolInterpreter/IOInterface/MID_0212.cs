namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs acknowledge
    /// Description: 
    ///     Acknowledgement for the message status externally monitored inputs upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0212 : Mid, IIOInterface
    {
        public const int MID = 212;
        private const int length = 20;
        private const int revision = 1;

        public MID_0212() : base(length, MID, revision) { }

        internal MID_0212(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0212)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
