using static OpenProtocolInterpreter.Tool.Mid0041;

namespace OpenProtocolInterpreter.Converters
{
    internal class OpenEndDataConverter : IValueConverter<OpenEndDatas>
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<int> _intConverter;

        public OpenEndDataConverter()
        {
            _boolConverter = new BoolConverter();
            _intConverter = new Int32Converter();
        }

        public OpenEndDatas Convert(string value)
        {
            return new OpenEndDatas()
            {
                UseOpenEnd = _boolConverter.Convert(value[0].ToString()),
                TighteningDirection = (TighteningDirection)_intConverter.Convert(value[1].ToString()),
                MotorRotation = (MotorRotation)_intConverter.Convert(value[2].ToString()),
            };
        }

        public string Convert(OpenEndDatas value)
        {
            return _boolConverter.Convert(value.UseOpenEnd) +
                _intConverter.Convert((int)value.TighteningDirection) +
                _intConverter.Convert((int)value.MotorRotation);
        }


        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, OpenEndDatas value)
        {
            return Convert(value);
        }
    }
}
