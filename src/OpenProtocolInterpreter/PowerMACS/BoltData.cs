using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Represents a Bolt entity
    /// </summary>
    public class BoltData
    {
        public int OrdinalBoltNumber { get; set; }
        public bool SimpleBoltStatus { get; set; }
        public TorqueStatus TorqueStatus { get; set; }
        public AngleStatus AngleStatus { get; set; }
        public decimal BoltTorque { get; set; }
        public decimal BoltAngle { get; set; }
        public decimal BoltTorqueHighLimit { get; set; }
        public decimal BoltTorqueLowLimit { get; set; }
        public decimal BoltAngleHighLimit { get; set; }
        public decimal BoltAngleLowLimit { get; set; }
    }

    public class BoltDataCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public int EachFieldSize { get; set; } = 67;

        public BoltDataCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public BoltDataCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<BoltData>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackBoltData,
                DefaultParser = ParseBoltData
            }.Bind(owner, propertyInfo);
        }

        private static string PackBoltData(char paddingChar, int size, PaddingOrientation orientation, List<BoltData> boltsData)
        {
            var builder = new StringBuilder();
            foreach (var bolt in boltsData)
            {
                builder.Append($"13{OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, bolt.OrdinalBoltNumber)}");
                builder.Append($"14{OpenProtocolConvert.ToString(bolt.SimpleBoltStatus)}");
                builder.Append($"15{OpenProtocolConvert.ToString(bolt.TorqueStatus)}");
                builder.Append($"16{OpenProtocolConvert.ToString(bolt.AngleStatus)}");
                builder.Append($"17{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorque)}");
                builder.Append($"18{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngle)}");
                builder.Append($"19{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorqueHighLimit)}");
                builder.Append($"20{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorqueLowLimit)}");
                builder.Append($"21{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngleHighLimit)}");
                builder.Append($"22{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngleLowLimit)}");
            }

            return builder.ToString();
        }

        private List<BoltData> ParseBoltData(string value)
        {
            var list = new List<BoltData>();
            if (string.IsNullOrWhiteSpace(value))
            {
                return list;
            }

            var numberOfBolts = value.Length / EachFieldSize;
            var span = value.AsSpan();
            for (int i = 0; i < numberOfBolts; i++)
            {
                var bolt = span.Slice(i * EachFieldSize, EachFieldSize);
                var obj = new BoltData()
                {
                    OrdinalBoltNumber = OpenProtocolConvert.ToInt32(bolt.Slice(2, 2)),
                    SimpleBoltStatus = OpenProtocolConvert.ToBoolean(bolt.Slice(6, 1)),
                    TorqueStatus = (TorqueStatus)OpenProtocolConvert.ToInt32(bolt.Slice(9, 1)),
                    AngleStatus = (AngleStatus)OpenProtocolConvert.ToInt32(bolt.Slice(12, 1)),
                    BoltTorque = OpenProtocolConvert.ToDecimal(bolt.Slice(15, 7)),
                    BoltAngle = OpenProtocolConvert.ToDecimal(bolt.Slice(24, 7)),
                    BoltTorqueHighLimit = OpenProtocolConvert.ToDecimal(bolt.Slice(33, 7)),
                    BoltTorqueLowLimit = OpenProtocolConvert.ToDecimal(bolt.Slice(42, 7)),
                    BoltAngleHighLimit = OpenProtocolConvert.ToDecimal(bolt.Slice(51, 7)),
                    BoltAngleLowLimit = OpenProtocolConvert.ToDecimal(bolt.Slice(60, 7)),
                };

                list.Add(obj);
            }

            return list;
        }
    }
}
