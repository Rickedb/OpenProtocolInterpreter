namespace OpenProtocolInterpreter.MIDs.MultiSpindle.Result
{
    /// <summary>
    /// MID: Multi-spindle result acknowledge
    /// Description:
    ///    Multi-spindle result acknowledge.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0102 : MID, IMultiSpindle
    {
        public const int MID = 102;
        private const int length = 20;
        private const int revision = 1;

        public MID_0102() : base(length, MID, revision) { }

        internal MID_0102(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0102)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
