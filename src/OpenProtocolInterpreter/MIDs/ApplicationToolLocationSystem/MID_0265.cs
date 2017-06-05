namespace OpenProtocolInterpreter.MIDs.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: External Tool tag ID and status
    /// Description:
    ///     Used by the controller to detect a Tool tag ID with its status from the integrator.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, MID revision unsupported.
    /// </summary>
    public class MID_0265 : MID, IApplicationToolLocationSystem
    {
        private const int length = 30;
        public const int MID = 265;
        private const int revision = 1;

        public string ToolTagID { get; set; }
        public Statuses Status { get; set; }

        public MID_0265() : base(length, MID, revision) { }

        internal MID_0265(IMID nextTemplate) : base(length, MID, revision)
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
                this.Status = (Statuses)base.RegisteredDataFields[(int)DataFields.STATUS].ToInt32();
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[] {
                                        new DataField((int)DataFields.TOOL_TAG_ID, 20, 8),
                                        new DataField((int)DataFields.STATUS, 30, 2)
                                });
        }

        public enum Statuses
        {
            OPERABLE = 1,
            INOPERABLE = 2
        }

        public enum DataFields
        {
            TOOL_TAG_ID,
            STATUS
        }
    }
}
