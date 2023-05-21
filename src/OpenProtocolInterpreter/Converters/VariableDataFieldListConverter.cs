using OpenProtocolInterpreter.Result;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class VariableDataFieldListConverter : AsciiConverter<IEnumerable<VariableDataField>>
    {
        private readonly IValueConverter<int> _intConverter;

        public VariableDataFieldListConverter(IValueConverter<int> intConverter)
        {
            _intConverter = intConverter;
        }

        public override IEnumerable<VariableDataField> Convert(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            int length;
            for (int i = 0; i < value.Length; i += 17 + length)
            {
                length = _intConverter.Convert(value.Substring(i + 5, 3));
                yield return new VariableDataField()
                {
                    ParameterId = _intConverter.Convert(value.Substring(i, 5)),
                    Length = length,
                    DataType = (DataTypeDefinition)_intConverter.Convert(value.Substring(i + 8, 2)),
                    Unit = (DataUnitType)_intConverter.Convert(value.Substring(i + 10, 3)),
                    StepNumber = _intConverter.Convert(value.Substring(i + 13, 4)),
                    DataValue = value.Substring(i + 17, length)
                };
            }
        }

        public override string Convert(IEnumerable<VariableDataField> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
            {
                pack += _intConverter.Convert('0', 5, DataField.PaddingOrientations.LeftPadded, v.ParameterId);
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LeftPadded, v.Length);
                pack += _intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, (int)v.DataType);
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LeftPadded, (int)v.Unit);
                pack += _intConverter.Convert('0', 4, DataField.PaddingOrientations.LeftPadded, v.StepNumber);
                pack += GetTruncatePadded(' ', v.Length, DataField.PaddingOrientations.RightPadded, v.DataValue);
            }
            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<VariableDataField> value) => Convert(value);
    }
}
