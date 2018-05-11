namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// MID: Display user text on compact
    /// Description: 
    ///     By sending this message the integrator can display a text on the compact display. The text must be maximum 4 bytes long.
    ///     The characters that can be displayed are limited due to the hardware of the compact display.
    ///     Each character must fit into seven segments. This means for example that it is not possible to display an M on the compact display.
    ///     The text will be displayed until next tightening, new parameter set or Job selection, or alarm code.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, User text could not be displayed
    /// </summary>
    public class MID_0110 : Mid, IUserInterface
    {
        private const int length = 24;
        public const int MID = 110;
        private const int revision = 1;

        public string UserText { get; set; }

        public MID_0110() : base(length, MID, revision)
        {

        }

        internal MID_0110(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + UserText.ToString().PadLeft(4, ' ');
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                HeaderData = base.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.USER_TEXT];
                UserText = package.Substring(dataField.Index, dataField.Size);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }

        public enum DataFields
        {
            USER_TEXT
        }
    }
}
