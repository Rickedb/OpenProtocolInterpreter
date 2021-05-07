using System;
using System.Globalization;

namespace OpenProtocolInterpreter.Converters
{
    public class DecimalConverter : AsciiConverter<decimal>
    {
        private readonly IFormatProvider _formatProvider;

        public DecimalConverter()
        {
            _formatProvider = new CultureInfo("en-US");
        }

        public override decimal Convert(string value)
        {
            decimal decimalValue = 0;
            if (value != null)
                decimal.TryParse(value.Replace(',', '.'), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, _formatProvider,  out decimalValue);

            return decimalValue;
        }

        public override string Convert(decimal value)
        {
            return value.ToString("00.0###", _formatProvider);
        }


        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, decimal value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
