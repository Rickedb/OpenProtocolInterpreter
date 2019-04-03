using OpenProtocolInterpreter.MultiSpindle;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class SpindleStatusConverter : AsciiConverter<IEnumerable<SpindleStatus>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;

        public SpindleStatusConverter(IValueConverter<int> intConverter, IValueConverter<bool> boolConverter)
        {
            _intConverter = intConverter;
            _boolConverter = boolConverter;
        }

        public override IEnumerable<SpindleStatus> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 5)
                yield return new SpindleStatus()
                {
                    SpindleNumber = _intConverter.Convert(value.Substring(i, 2)),
                    ChannelId = _intConverter.Convert(value.Substring(i + 2, 2)),
                    SyncOverallStatus = _boolConverter.Convert(value.Substring(i + 4, 1))
                };
        }

        public override string Convert(IEnumerable<SpindleStatus> value)
        {
            string pack = string.Empty;
            foreach(var spindle in value)
            pack += _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, spindle.SpindleNumber) +
                       _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, spindle.ChannelId) +
                       _boolConverter.Convert(spindle.SyncOverallStatus);

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<SpindleStatus> value) => Convert(value);
    }
}
