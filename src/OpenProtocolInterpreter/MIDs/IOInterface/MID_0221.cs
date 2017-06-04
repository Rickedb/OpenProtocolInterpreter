using System;

namespace OpenProtocolInterpreter.MIDs.IOInterface
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
    public class MID_0221 : MID, IIOInterface
    {
        public const int MID = 221;
        private const int length = 28;
        private const int revision = 1;

        public DigitalInput.DigitalInputNumbers DigitalInputNumber { get; set; }
        public bool DigitalInputStatus { get; set; }

        public MID_0221() : base(length, MID, revision) { }

        internal MID_0221(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string pkg = base.buildHeader();
            pkg += "01" + ((int)this.DigitalInputNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER].Size, '0');
            pkg += "02" + Convert.ToInt32(this.DigitalInputStatus).ToString();
            return pkg;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);
                this.DigitalInputNumber = (DigitalInput.DigitalInputNumbers)base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER].ToInt32();
                this.DigitalInputStatus = base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_STATUS].ToBoolean();
                return this;
            }


            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
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
