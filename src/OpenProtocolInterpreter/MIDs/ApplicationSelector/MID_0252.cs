namespace OpenProtocolInterpreter.MIDs.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info acknowledge
    /// Description:
    ///     Acknowledgement of the MID 0251 Selector socket info.   
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0252 : MID, IApplicationSelector
    {
        private const int length = 20;
        public const int MID = 252;
        private const int revision = 1;

        public MID_0252() : base(length, MID, revision) { }

        internal MID_0252(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0252)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
