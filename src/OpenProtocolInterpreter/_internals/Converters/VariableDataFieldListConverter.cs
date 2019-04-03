using OpenProtocolInterpreter.Result;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class VariableDataFieldListConverter : AsciiConverter<IEnumerable<VariableDataField>>
    {
        private readonly IValueConverter<int> _intConverter;

        public VariableDataFieldListConverter(IValueConverter<int> intConverter)
        {
            _intConverter = intConverter;
        }

        public override IEnumerable<VariableDataField> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 18)
                yield return new VariableDataField()
                {
                    ParameterId = _intConverter.Convert(value.Substring(i, 5)),
                    Length = _intConverter.Convert(value.Substring(i + 5, 3)),
                    DataType = _intConverter.Convert(value.Substring(i + 8, 2)),
                    Unit = _intConverter.Convert(value.Substring(i + 10, 3)),
                    StepNumber = _intConverter.Convert(value.Substring(i + 13, 4)),
                    RealValue = value.Substring(i + 17, 1)
                };
        }

        public override string Convert(IEnumerable<VariableDataField> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
            {
                pack += _intConverter.Convert('0', 5, DataField.PaddingOrientations.LEFT_PADDED, v.ParameterId);
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, v.Length);
                pack += _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, v.DataType);
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, v.Unit);
                pack += _intConverter.Convert('0', 4, DataField.PaddingOrientations.LEFT_PADDED, v.StepNumber);
                pack += GetPadded(' ', 1, DataField.PaddingOrientations.RIGHT_PADDED, v.RealValue);
            }
            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<VariableDataField> value) => Convert(value);
    }
}
