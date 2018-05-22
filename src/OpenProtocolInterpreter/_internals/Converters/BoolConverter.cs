namespace OpenProtocolInterpreter.Converters
{
    internal class BoolConverter : IValueConverter<bool>
    {
        public bool Convert(string value)
        {
            int intValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out intValue);

            bool.TryParse(intValue.ToString(), out bool convertedValue);
            return convertedValue;
        }

        public string Convert(bool value)
        {
            int.TryParse(value.ToString(), out int convertedValue);
            return convertedValue.ToString();
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, bool value) => Convert(value);
    }
}
