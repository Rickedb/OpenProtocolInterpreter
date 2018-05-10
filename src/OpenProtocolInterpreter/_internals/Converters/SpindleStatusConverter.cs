using OpenProtocolInterpreter.MultiSpindle;

namespace OpenProtocolInterpreter.Converters
{
    internal class SpindleStatusConverter : IValueConverter<SpindleStatus>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;

        public SpindleStatusConverter()
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        public SpindleStatus Convert(string value)
        {
            return new SpindleStatus()
            {
                SpindleNumber = _intConverter.Convert(value.Substring(0, 2)),
                ChannelId = _intConverter.Convert(value.Substring(2, 2)),
                SyncOverallStatus = _boolConverter.Convert(value.Substring(4, 1))
            };
        }

        public string Convert(SpindleStatus value)
        {
            return _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, value.SpindleNumber) +
                   _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, value.ChannelId) +
                   _boolConverter.Convert(value.SyncOverallStatus);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, SpindleStatus value) => Convert(value);
    }
}
