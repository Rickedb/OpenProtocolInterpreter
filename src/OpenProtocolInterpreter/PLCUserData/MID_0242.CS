namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data download
    /// Description: 
    ///     Used by the integrator to send user data input to the PLC.
    /// Message sent by: Controller
    /// Answer: MID 0243 User data acknowledge
    /// </summary>
    public class MID_0242 : Mid, IPLCUserData
    {
        private const int length = 220;
        public const int MID = 242;
        private const int revision = 1;

        public string UserData { get; set; }

        public MID_0242() : base(length, MID, revision) { }

        internal MID_0242(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            HeaderData.Length = 20 + UserData.Length;

            string package = BuildHeader();
            package += UserData;

            return package;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                UserData = package.Substring(20);
                return this;
            }

            return NextTemplate.ProcessPackage(package);
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
