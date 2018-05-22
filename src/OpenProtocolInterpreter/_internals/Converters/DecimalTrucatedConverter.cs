using System;

namespace OpenProtocolInterpreter.Converters
{
    internal class DecimalTrucatedConverter : ValueConverter, IValueConverter<decimal>
    {
        private readonly decimal _decimalPointsMultiplier;
        private readonly int _decimalPoints;

        public DecimalTrucatedConverter(int decimalPoints)
        {
            _decimalPointsMultiplier = 1;
            for (int i = 0; i < decimalPoints; i++)
                _decimalPointsMultiplier = _decimalPointsMultiplier * 10m;
            _decimalPoints = decimalPoints;
        }

        public decimal Convert(string value)
        {
            int intValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out intValue);

            return intValue / _decimalPointsMultiplier;
        }

        public string Convert(decimal value)
        {
            int convertedValue = ((int)(Math.Round(value, _decimalPoints) * _decimalPointsMultiplier));
            return convertedValue.ToString();
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, decimal value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
