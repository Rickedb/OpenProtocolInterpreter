using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Digital input function
    /// Description: 
    ///     Upload of one specific digital input function status. See Table 80.
    ///     For tracking event functions, MID 0221 Digital input function, is sent each time the digital input
    ///     function’s status (state) is changed. For digital input functions which are not tracking events, the
    ///     upload is sent only when the digital input function is set high, 
    ///     i.e. the data field “Digital input function status” will always be 1 for such functions.
    /// Message sent by: Controller
    /// Answer: MID 0222 Digital input function upload acknowledge
    /// </summary>
    public class MID_0221 : Mid, IIOInterface
    {
        public const int MID = 221;
        private const int length = 28;
        private const int revision = 1;

        public DigitalInput.DigitalInputNumbers DigitalInputNumber { get; set; }
        public bool DigitalInputStatus { get; set; }

        public MID_0221() : base(length, MID, revision) { }

        internal MID_0221(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string pkg = base.BuildHeader();
            pkg += "01" + ((int)DigitalInputNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER].Size, '0');
            pkg += "02" + Convert.ToInt32(DigitalInputStatus).ToString();
            return pkg;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessPackage(package);
                DigitalInputNumber = (DigitalInput.DigitalInputNumbers)base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER].ToInt32();
                DigitalInputStatus = base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_STATUS].ToBoolean();
                return this;
            }


            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.DIGITAL_INPUT_NUMBER, 20, 3));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.DIGITAL_INPUT_STATUS, 25, 1));
        }

        public enum DataFields
        {
            DIGITAL_INPUT_NUMBER,
            DIGITAL_INPUT_STATUS
        }
    }
}
