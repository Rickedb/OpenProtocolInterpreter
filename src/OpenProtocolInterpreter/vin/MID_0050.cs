namespace OpenProtocolInterpreter.VIN
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
        public const int MID = 50;
        private const int revision = 1;

        public string VINNumber{ get; set; }

        public MID_0050() : base(length, MID, revision) { }

        internal MID_0050(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + VINNumber.PadRight(25,' ');
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = base.ProcessHeader(package);
                var field = this.RegisteredDataFields[(int)DataFields.VIN_NUMBER];
                this.VINNumber = package.Substring(field.Index, field.Size);
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.VIN_NUMBER, 20, 25));
        }

        public enum DataFields
        {
            VIN_NUMBER
        }
    }
}
