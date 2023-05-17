using OpenProtocolInterpreter.PowerMACS;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Converters
{
    public class BoltResultConverter : AsciiConverter<IEnumerable<BoltResult>>
    {
        private readonly IValueConverter<int> _intConverter;
        private IValueConverter<decimal> _decimalConverter;

        public BoltResultConverter(IValueConverter<int> intConverter)
        {
            _intConverter = intConverter;
        }

        public override IEnumerable<BoltResult> Convert(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

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

        public override string Convert(IEnumerable<BoltResult> value)
        {
            string package = string.Empty;
            foreach (var bolt in value)
            {
                package += GetTruncatePadded(' ', 20, DataField.PaddingOrientations.RightPadded, bolt.VariableName);
                package += bolt.Type.Type;
                if (bolt.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    package += _intConverter.Convert('0', 7, DataField.PaddingOrientations.LeftPadded, (int)bolt.Value);
                }
                else if (bolt.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    _decimalConverter = new DecimalConverter();
                    package += _decimalConverter.Convert('0', 7, DataField.PaddingOrientations.LeftPadded, (decimal)bolt.Value);
                }

            }

            return package;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<BoltResult> value)
        {
            return Convert(value);
        }
    }
}
