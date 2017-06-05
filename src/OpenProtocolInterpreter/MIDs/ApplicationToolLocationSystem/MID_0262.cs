namespace OpenProtocolInterpreter.MIDs.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID
    /// Description:
    ///     Used by the controller to send a Tool tag ID to the integrator.
    /// Message sent by: Controller
    /// Answer: MID 0263 Tool tag ID acknowledge
    /// </summary>
    public class MID_0262 : MID, IApplicationToolLocationSystem
    {
        private const int length = 30;
        public const int MID = 262;
        private const int revision = 1;

        public string ToolTagID { get; set; }

        public MID_0262() : base(length, MID, revision) {  }

        internal MID_0262(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            base.RegisteredDataFields[(int)DataFields.TOOL_TAG_ID].Value = ToolTagID;
            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);
                this.ToolTagID = base.RegisteredDataFields[(int)DataFields.TOOL_TAG_ID].Value.ToString();
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.TOOL_TAG_ID, 20, 8));
        }

        public enum DataFields
        {
            TOOL_TAG_ID
        }
    }
}
