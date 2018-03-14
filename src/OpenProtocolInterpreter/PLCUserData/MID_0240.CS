namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data download
    /// Description: 
    ///     Used by the integrator to send user data input to the PLC.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Invalid data, or Controller is not a sync master/station controller
    /// </summary>
    public class MID_0240 : MID 
    {
        private const int length = 220;
        public const int MID = 240;
        private const int revision = 1;

        public string UserData { get; set; }

        public MID_0240() : base(length, MID, revision) { }

        internal MID_0240(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            this.HeaderData.Length = 20 + this.UserData.Length;

            string package = this.BuildHeader();
            package += this.UserData;

            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.UserData = package.Substring(20);
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.USER_DATA, 20, 220));
        }

        internal enum DataFields
        {
            USER_DATA
        }
    }
}
