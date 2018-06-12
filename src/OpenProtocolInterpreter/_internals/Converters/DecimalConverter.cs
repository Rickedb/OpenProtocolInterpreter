using System.Globalization;

namespace OpenProtocolInterpreter.Converters
{
    internal class DecimalConverter : ValueConverter, IValueConverter<decimal>
    {
        public decimal Convert(string value)
        {
            decimal decimalValue = 0;
            if (value != null)
                decimal.TryParse(value.ToString(), out decimalValue);

            return decimalValue;
        }

        public string Convert(decimal value)
        {
            return value.ToString("00.0###", new CultureInfo("en-US"));
        }


        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, decimal value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
