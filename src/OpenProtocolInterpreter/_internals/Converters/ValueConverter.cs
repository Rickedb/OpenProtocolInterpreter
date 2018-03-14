namespace OpenProtocolInterpreter.Converters
{
    internal class ValueConverter
    {
        public string GetPadded(char paddingChar, int size, DataField.PaddingOrientations orientation, string value)
        {
            if (value == null)
                return string.Empty.PadLeft(size, paddingChar);

            if (orientation == DataField.PaddingOrientations.RIGHT_PADDED)
                return value.PadRight(size, paddingChar);

            return value.PadLeft(size, paddingChar);
        }
    }
}
