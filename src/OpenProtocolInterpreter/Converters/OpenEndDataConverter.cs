
using OpenProtocolInterpreter.Tool;

namespace OpenProtocolInterpreter.Converters
{
    public class OpenEndDataConverter : AsciiConverter<OpenEndData>
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<int> _intConverter;

        public OpenEndDataConverter(IValueConverter<int> intConverter, IValueConverter<bool> boolConverter)
        {
            _boolConverter = boolConverter;
            _intConverter = intConverter;
        }

        public override OpenEndData Convert(string value)
        {
            return new OpenEndData()
            {
                UseOpenEnd = _boolConverter.Convert(value[0].ToString()),
                TighteningDirection = (TighteningDirection)_intConverter.Convert(value[1].ToString()),
                MotorRotation = (MotorRotation)_intConverter.Convert(value[2].ToString()),
            };
        }

        public override string Convert(OpenEndData value)
        {
            return _boolConverter.Convert(value.UseOpenEnd) +
                _intConverter.Convert((int)value.TighteningDirection) +
                _intConverter.Convert((int)value.MotorRotation);
        }


        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, OpenEndData value)
        {
            return Convert(value);
        }
    }
}
