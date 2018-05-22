using OpenProtocolInterpreter.Converters;

namespace OpenProtocolInterpreter.Converters
{
    internal class Int64Converter : ValueConverter, IValueConverter<long>
    {
        public long Convert(string value)
        {
            long convertedValue = 0;
            if (value != null)
                long.TryParse(value.ToString(), out convertedValue);

            return convertedValue;
        }

        public string Convert(long value) => value.ToString();

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, long value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
