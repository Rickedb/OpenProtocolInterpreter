namespace OpenProtocolInterpreter.Converters
{
    internal class BoolConverter : IValueConverter<bool>
    {
        public bool Convert(string value)
        {
            int intValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out intValue);

            return System.Convert.ToBoolean(intValue);
        }

        public string Convert(bool value) => value ? "1" : "0";

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, bool value) => Convert(value);
    }
}
