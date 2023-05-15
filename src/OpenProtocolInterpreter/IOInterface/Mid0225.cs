using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Reset digital input function
    /// <para>
    ///     Reset the digital input function with the digital input number. 
    ///     The digital input function numbers are defined in Table 80.
    /// </para>    
    /// <para>
    ///     This MID will only affect the digital input functions of tracking type.
    ///     The digital input functions with the type flank cannot be reset (for example reset the reset 
    ///     batch digital input function will have no effect).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Invalid data</para>
    /// </summary>
    public class Mid0225 : Mid, IIOInterface, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 225;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.INVALID_DATA };

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DIGITAL_INPUT_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DIGITAL_INPUT_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0225() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0225(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

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
