namespace OpenProtocolInterpreter.MIDs.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number download request
    /// Description: 
    ///     This message is replaced by MID 0150. MID 0050 is still supported.
    ///     Used by the integrator to send a VIN number to the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, VIN input source not granted
    /// </summary>
    public class MID_0050 : MID, IVIN
    {
        private const int length = 45;
        private const int mid = 50;
        private const int revision = 1;

        public string VINNumber{ get; set; }

        public MID_0050() : base(length, mid, revision) { }

        internal MID_0050(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            return base.buildHeader() + VINNumber.PadRight(25,' ');
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
