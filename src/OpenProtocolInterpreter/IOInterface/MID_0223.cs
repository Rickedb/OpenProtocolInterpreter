using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function unsubscribe
    /// Description: 
    ///     Unsubscribe for a single relay function. The data field consists of three ASCII digits,
    ///     the relay number, which corresponds to the specific relay function. The relay numbers can be 
    ///     found in Table 101.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, The relay function subscription does not exist
    /// </summary>
    public class MID_0223 : Mid, IIOInterface
    {
        public const int MID = 223;
        private const int length = 23;
        private const int revision = 1;

        public DigitalInput.DigitalInputNumbers DigitalInputNumber { get; set; }

        public MID_0223() : base(length, MID, revision) { }

        internal MID_0223(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + ((int)DigitalInputNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER].Size, '0');
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER];
                DigitalInputNumber = (DigitalInput.DigitalInputNumbers)Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
                return this;
            }


            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.DIGITAL_INPUT_NUMBER, 20, 3));
        }

        public enum DataFields
        {
            DIGITAL_INPUT_NUMBER
        }
    }
}
