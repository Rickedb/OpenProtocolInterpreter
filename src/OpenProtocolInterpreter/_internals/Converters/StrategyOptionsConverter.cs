using OpenProtocolInterpreter.Tightening;

namespace OpenProtocolInterpreter.Converters
{
    internal class StrategyOptionsConverter : BitConverter, IValueConverter<StrategyOptions>
    {
        private readonly IValueConverter<byte[]> _byteArrayConverter;

        public StrategyOptionsConverter()
        {
            _byteArrayConverter = new ByteArrayConverter();
        }

        public StrategyOptions Convert(string value)
        {
            var bytes = _byteArrayConverter.Convert(value);
            return new StrategyOptions()
            {
                //Byte 0
                Torque = GetBit(bytes[0], 1),
                Angle = GetBit(bytes[0], 2),
                Batch = GetBit(bytes[0], 3),
                PvtMonitoring = GetBit(bytes[0], 4),
                PvtCompensate = GetBit(bytes[0], 5),
                Selftap = GetBit(bytes[0], 6),
                Rundown = GetBit(bytes[0], 7),
                CM = GetBit(bytes[0], 8),
                //Byte 1
                DsControl = GetBit(bytes[1], 1),
                ClickWrench = GetBit(bytes[1], 2),
                RbwMonitoring = GetBit(bytes[1], 3)
            };
        }

        public string Convert(StrategyOptions value)
        {
            byte[] bytes = new byte[10];
            bytes[0] = SetByte(new bool[]
            {
                value.Torque,
                value.Angle,
                value.Batch,
                value.PvtMonitoring,
                value.PvtCompensate,
                value.Selftap,
                value.Rundown,
                value.CM
            });
            bytes[1] = SetByte(new bool[]
            {
                 value.DsControl,
                 value.ClickWrench,
                 value.RbwMonitoring,
                 false,
                 false,
                 false,
                 false,
                 false
            });

            bytes[2] = bytes[3] = bytes[4] = bytes[5] = bytes[6] = bytes[7] = bytes[8] = bytes[9] = 0;

            return _byteArrayConverter.Convert(bytes);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, StrategyOptions value) => Convert(value);
    }
}
