namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Identifier download request
    /// Description: Used by the integrator to send an identifier to the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Identifier input source not granted
    /// </summary>
    public class MID_0150 : MID, IMultipleIdentifier
    {
        public const int MID = 150;
        private const int length = 9999;
        private const int revision = 1;

        public string IdentifierData { get; set; }

        public MID_0150() : base(length, MID, revision) { }

        public MID_0150(string identifierData) : base(length, MID, revision)
        {
            this.IdentifierData = identifierData;
        }

        internal MID_0150(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            this.IdentifierData = (this.IdentifierData.Length > 100) ? this.IdentifierData.Substring(0, 100) : this.IdentifierData;
            return base.BuildHeader() + this.IdentifierData;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = this.ProcessHeader(package);
                this.HeaderData.Length = package.Length;

                this.IdentifierData = package.Substring(base.RegisteredDataFields[(int)DataFields.IDENTIFIER_DATA].Index);

                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.IDENTIFIER_DATA, 20, 100));
        }

        public enum DataFields
        {
            IDENTIFIER_DATA
        }
    }
}
