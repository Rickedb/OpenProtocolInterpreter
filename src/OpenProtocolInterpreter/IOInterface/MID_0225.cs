using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Reset digital input function
    /// Description: 
    ///     Reset the digital input function with the digital input number. 
    ///     The digital input function numbers are defined in Table 80.
    ///     This MID will only affect the digital input functions of tracking type.
    ///     The digital input functions with the type flank cannot be reset (for example reset the reset 
    ///     batch digital input function will have no effect).
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Invalid data
    /// </summary>
    public class MID_0225 : MID, IIOInterface
    {
        public const int MID = 225;
        private const int length = 23;
        private const int revision = 1;

        public DigitalInput.DigitalInputNumbers DigitalInputNumber { get; set; }

        public MID_0225() : base(length, MID, revision) { }

        internal MID_0225(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + ((int)this.DigitalInputNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER].Size, '0');
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_NUMBER];
                this.DigitalInputNumber = (DigitalInput.DigitalInputNumbers)Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
                return this;
            }


            return this.NextTemplate.ProcessPackage(package);
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
