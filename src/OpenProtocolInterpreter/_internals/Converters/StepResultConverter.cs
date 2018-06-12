using OpenProtocolInterpreter.PowerMACS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Converters
{
    internal class StepResultConverter : ValueConverter, IValueConverter<IEnumerable<StepResult>>
    {
        private readonly IValueConverter<int> _intConverter;
        private IValueConverter<decimal> _decimalConverter;

        public StepResultConverter()
        {
            _intConverter = new Int32Converter();
        }

        public IEnumerable<StepResult> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 31)
            {
                var result = new StepResult()
                {
                    VariableName = value.Substring(i, 20),
                    Type = DataType.DataTypes.First(x => x.Type.Trim() == value.Substring(20 + i, 2).Trim()),
                    StepNumber = _intConverter.Convert(value.Substring(29 + i, 2))
                };

                var resultValue = value.Substring(22 + i, 7);
                if (result.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    result.Value = _intConverter.Convert(resultValue);
                }
                else if (result.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    int decimalPlaces = resultValue.Split('.')[1].Length;
                    _decimalConverter = new DecimalConverter();
                    result.Value = _decimalConverter.Convert(resultValue);
                }

                yield return result;
            }
        }

        public string Convert(IEnumerable<StepResult> value)
        {
            string package = string.Empty;
            foreach (var step in value)
            {
                package += GetPadded(' ', 20, DataField.PaddingOrientations.RIGHT_PADDED, step.VariableName);
                package += step.Type.Type;
                if (step.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    package += _intConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (int)step.Value);
                }
                else if (step.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    _decimalConverter = new DecimalConverter();
                    package += _decimalConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (decimal)step.Value);
                }
            }

            return package;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<StepResult> value)
        {
            return Convert(value);
        }
    }
}
