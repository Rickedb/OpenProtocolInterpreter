using System;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Represents a Strategy Options entity
    /// </summary>
    public class StrategyOptions
    {
        //Byte 0
        public bool Torque { get; set; }
        public bool Angle { get; set; }
        public bool Batch { get; set; }
        public bool PvtMonitoring { get; set; }
        public bool PvtCompensate { get; set; }
        public bool Selftap { get; set; }
        public bool Rundown { get; set; }
        public bool CM { get; set; }
        //Byte 1
        public bool DsControl { get; set; }
        public bool ClickWrench { get; set; }
        public bool RbwMonitoring { get; set; }

        public string Pack()
        {
            byte[] bytes = PackBytes();
            return Encoding.ASCII.GetString(bytes);
        }

        public byte[] PackBytes()
        {
            byte[] bytes = new byte[5];
            bytes[0] = OpenProtocolConvert.ToByte(new bool[]
            {
                Torque,
                Angle,
                Batch,
                PvtMonitoring,
                PvtCompensate,
                Selftap,
                Rundown,
                CM
            });
            bytes[1] = OpenProtocolConvert.ToByte(new bool[]
            {
                 DsControl,
                 ClickWrench,
                 RbwMonitoring,
                 false,
                 false,
                 false,
                 false,
                 false
            });

            var asciiInt = BitConverter.ToInt32(bytes, 0).ToString("D5");
            return Encoding.ASCII.GetBytes(asciiInt);
        }

        public static StrategyOptions Parse(string value)
            => Parse(value.AsSpan());

        public static StrategyOptions Parse(ReadOnlySpan<char> value)
        {
            var intValue = OpenProtocolConvert.ToInt32(value);
            var bytes = BitConverter.GetBytes(intValue);
            return Parse(bytes);
        }

        public static StrategyOptions Parse(byte[] value)
        {
            return new StrategyOptions()
            {
                //Byte 0
                Torque = OpenProtocolConvert.GetBit(value[0], 1),
                Angle = OpenProtocolConvert.GetBit(value[0], 2),
                Batch = OpenProtocolConvert.GetBit(value[0], 3),
                PvtMonitoring = OpenProtocolConvert.GetBit(value[0], 4),
                PvtCompensate = OpenProtocolConvert.GetBit(value[0], 5),
                Selftap = OpenProtocolConvert.GetBit(value[0], 6),
                Rundown = OpenProtocolConvert.GetBit(value[0], 7),
                CM = OpenProtocolConvert.GetBit(value[0], 8),
                //Byte 1
                DsControl = OpenProtocolConvert.GetBit(value[1], 1),
                ClickWrench = OpenProtocolConvert.GetBit(value[1], 2),
                RbwMonitoring = OpenProtocolConvert.GetBit(value[1], 3)
            };
        }
    }

    public class StrategyOptionsDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public StrategyOptionsDefinitionAttribute(int revision) : base(revision)
        {

        }
        public StrategyOptionsDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<StrategyOptions>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackStrategyOptions,
                DefaultParser = ParseStrategyOptions
            }.Bind(mid, propertyInfo);
        }

        private static string PackStrategyOptions(char paddingChar, int size, PaddingOrientation orientation, StrategyOptions strategyOptions)
            => strategyOptions.Pack().PadLeft(size, paddingChar);

        private static StrategyOptions ParseStrategyOptions(string value)
            => StrategyOptions.Parse(value);
    }
}
