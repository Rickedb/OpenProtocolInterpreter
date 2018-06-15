using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

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
    public class MID_0225 : Mid, IIOInterface
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 225;

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DIGITAL_INPUT_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DIGITAL_INPUT_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0225() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public MID_0225(DigitalInputNumber digitalInputNumber) : this()
        {
            DigitalInputNumber = digitalInputNumber;
        }

        internal MID_0225(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DIGITAL_INPUT_NUMBER, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            DIGITAL_INPUT_NUMBER
        }
    }
}
