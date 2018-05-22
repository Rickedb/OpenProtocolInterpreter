using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Converters
{
    internal class FloatConverter : ValueConverter, IValueConverter<float>
    {
        private readonly int _decimalPoints;

        public FloatConverter(int decimalPoints)
        {
            _decimalPoints = decimalPoints;
        }

        public float Convert(string value)
        {
            float convertedValue = 0f;
            if (!string.IsNullOrWhiteSpace(value.ToString()))
                float.TryParse(value.ToString().Replace('.', ','), out convertedValue);
            return convertedValue;
        }

        public string Convert(float value)
        {
            throw new NotImplementedException();
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, float value)
        {
            throw new NotImplementedException();
        }
    }
}
