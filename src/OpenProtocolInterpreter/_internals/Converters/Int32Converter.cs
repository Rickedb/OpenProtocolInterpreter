namespace OpenProtocolInterpreter.Converters
{
    internal class Int32Converter : ValueConverter, IValueConverter<int>
    {
        public int Convert(string value)
        {
            int convertedValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out convertedValue);

            return convertedValue;
        }

        public string Convert(int value) => value.ToString();

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, int value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
