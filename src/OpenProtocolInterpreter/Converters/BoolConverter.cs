namespace OpenProtocolInterpreter.Converters
{
    public class BoolConverter : AsciiConverter<bool>
    {
        public override bool Convert(string value)
        {
            int intValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out intValue);

            return System.Convert.ToBoolean(intValue);
        }

        public override string Convert(bool value) => value ? "1" : "0";

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, bool value) => Convert(value);
    }
}
