using OpenProtocolInterpreter.PowerMACS;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Converters
{
    internal class SpecialValueListConverter : IValueConverter<IEnumerable<SpecialValue>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly int _totalSpecialValues;

        public SpecialValueListConverter(int totalSpecialValues)
        {
            _intConverter = new Int32Converter();
            _totalSpecialValues = totalSpecialValues;
        }

        public IEnumerable<SpecialValue> Convert(string value)
        {
            int index = 0;
            for (int i = 0; i < _totalSpecialValues; i++)
            {
                SpecialValue obj = new SpecialValue
                {
                    VariableName = value.Substring(0 + index, 20),
                    Type = DataType.DataTypes.First(x => x.Type == value.Substring(20 + index, 2).Trim()),
                    Length = _intConverter.Convert(value.Substring(22 + index, 2))
                };
                obj.Value = value.Substring(24 + index, obj.Length);
                index += 24 + obj.Length;
                yield return obj;
            }
        }

        public string Convert(IEnumerable<SpecialValue> value)
        {
            string package = _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, value.Count());
            foreach (var v in value)
            {
                package += v.VariableName.PadRight(20);
                package += v.Type.Type;
                package += _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, v.Length);
                package += v.VariableName.PadRight(v.Length);
            }

            return package;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<SpecialValue> value) => Convert(value);
    }
}
