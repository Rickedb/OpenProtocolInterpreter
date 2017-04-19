namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Tool data upload request
    /// Description: 
    ///     A request for some of the data stored in the tool. The result of this command is the transmission of the
    ///     tool data.
    /// Message sent by: Integrator
    /// Answer: MID 0041 Tool data upload reply
    /// </summary>
    public class MID_0040 : MID, ITool
    {
        private const int length = 20;
        private const int mid = 40;
        private const int revision = 1;

        public MID_0040() : base(length, mid, revision)
        {

        }

        internal MID_0040(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
