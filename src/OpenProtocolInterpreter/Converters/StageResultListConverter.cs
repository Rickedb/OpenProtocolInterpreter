using OpenProtocolInterpreter.Tightening;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class StageResultListConverter : AsciiConverter<IEnumerable<StageResult>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<decimal> _decimalConverter;

        public StageResultListConverter(IValueConverter<int> intConverter, IValueConverter<decimal> decimalConverter)
        {
            _intConverter = intConverter;
            _decimalConverter = decimalConverter;
        }

        public override IEnumerable<StageResult> Convert(string value)
        {
            for(int i = 0; i < value.Length; i += 11)
            {
                yield return new StageResult()
                {
                    Torque = _decimalConverter.Convert(value.Substring(i, 6)),
                    Angle = _intConverter.Convert(value.Substring(i + 6, 5))
                };
            }
        }

        public override string Convert(IEnumerable<StageResult> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
            {
                pack += _decimalConverter.Convert('0', 6, DataField.PaddingOrientations.LEFT_PADDED, v.Torque);
                pack += _intConverter.Convert('0', 5, DataField.PaddingOrientations.LEFT_PADDED, v.Angle);
            }

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<StageResult> value) => Convert(value);
    }
}
