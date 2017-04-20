namespace OpenProtocolInterpreter.MIDs.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number
    /// Description: 
    ///     Transmission of the current identifiers of the tightening by the controller to the subscriber.
    ///     The tightening result can be stamped with up to four identifiers:
    ///         - VIN number(identifier result part 1)
    ///         - Identifier result part 2
    ///         - Identifier result part 3
    ///         - Identifier result part 4
    ///     The identifiers are received by the controller from several input sources,
    ///     for example serial, Ethernet, or field bus.
    /// Message sent by: Controller
    /// Answer: MID 0053 Vehicle ID Number acknowledge
    /// </summary>
    public class MID_0052 : MID, IVIN
    {
        private const int length = 45;
        private const int mid = 52;
        private const int revision = 1;

        public string VINNumber { get; set; }

        public MID_0052() : base(length, mid, revision) { }

        internal MID_0052(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            return base.buildHeader() + VINNumber.PadRight(25, ' ');
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);
                var field = this.RegisteredDataFields[(int)DataFields.VIN_NUMBER];
                this.VINNumber = package.Substring(field.Index, field.Size);
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.VIN_NUMBER, 20, 25));
        }

        public enum DataFields
        {
            VIN_NUMBER
        }
    }
}
