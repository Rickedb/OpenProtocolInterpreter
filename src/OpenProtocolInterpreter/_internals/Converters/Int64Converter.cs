namespace OpenProtocolInterpreter.Converters
{
    internal class Int64Converter : AsciiConverter<long>
    {
        public override long Convert(string value)
        {
            long convertedValue = 0;
            if (value != null)
                long.TryParse(value.ToString(), out convertedValue);

            return convertedValue;
        }

        public override string Convert(long value) => value.ToString();

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, long value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
