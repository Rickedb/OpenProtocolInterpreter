using OpenProtocolInterpreter.PowerMACS;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Converters
{
    internal class BoltResultConverter : ValueConverter, IValueConverter<IEnumerable<BoltResult>>
    {
        private readonly IValueConverter<int> _intConverter;
        private IValueConverter<decimal> _decimalConverter;

        public BoltResultConverter()
        {
            _intConverter = new Int32Converter();
        }

        public IEnumerable<BoltResult> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 29)
            {
                var result = new BoltResult()
                {
                    VariableName = value.Substring(i, 20),
                    Type = DataType.DataTypes.First(x => x.Type.Trim() == value.Substring(20 + i, 2).Trim())
                };

                var resultValue = value.Substring(22 + i, 7);
                if (result.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    result.Value = _intConverter.Convert(resultValue);
                }
                else if (result.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    _decimalConverter = new DecimalConverter();
                    result.Value = _decimalConverter.Convert(resultValue);
                }

                yield return result;
            }
        }

        public string Convert(IEnumerable<BoltResult> value)
        {
            string package = string.Empty;
            foreach (var bolt in value)
            {
                package += GetPadded(' ', 20, DataField.PaddingOrientations.RIGHT_PADDED, bolt.VariableName);
                package += bolt.Type.Type;
                if (bolt.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    package += _intConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (int)bolt.Value);
                }
                else if (bolt.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    _decimalConverter = new DecimalConverter();
                    package += _decimalConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (decimal)bolt.Value);
                }

            }

            return package;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<BoltResult> value)
        {
            return Convert(value);
        }
    }
}
