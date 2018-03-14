namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs acknowledge
    /// Description: 
    ///     Acknowledgement for the message status externally monitored inputs upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0212 : MID, IIOInterface
    {
        public const int MID = 212;
        private const int length = 20;
        private const int revision = 1;

        public MID_0212() : base(length, MID, revision) { }

        internal MID_0212(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0212)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
