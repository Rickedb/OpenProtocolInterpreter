using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Represents a Spindle or a Press status entity, depending on <see cref="SystemSubType"/>
    /// </summary>
    public class SpindleOrPressStatus
    {
        internal const int DefaultSize = 18;

        public int SpindleOrPressNumber { get; set; }
        public int ChannelId { get; set; }
        public bool OverallStatus { get; set; }
        public TighteningValueStatus TorqueOrForceStatus { get; set; }
        public decimal TorqueOrForce { get; set; }
        public bool AngleOrStrokeStatus { get; set; }
        public int AngleOrStroke { get; set; }

        public string Pack()
        {
            return string.Concat(
                OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, SpindleOrPressNumber),
                OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, ChannelId),
                OpenProtocolConvert.ToString(OverallStatus),
                OpenProtocolConvert.ToString(TorqueOrForceStatus),
                OpenProtocolConvert.TruncatedDecimalToString('0', 6, PaddingOrientation.LeftPadded, TorqueOrForce),
                OpenProtocolConvert.ToString(AngleOrStrokeStatus),
                OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, AngleOrStroke)
            );
        }

        public static SpindleOrPressStatus Parse(string section)
            => Parse(section.AsSpan());

        public static SpindleOrPressStatus Parse(ReadOnlySpan<char> section)
        {
            return new SpindleOrPressStatus()
            {
                SpindleOrPressNumber = OpenProtocolConvert.ToInt32(section.Slice(0, 2)),
                ChannelId = OpenProtocolConvert.ToInt32(section.Slice(2, 2)),
                OverallStatus = OpenProtocolConvert.ToBoolean(section.Slice(4, 1)),
                TorqueOrForceStatus = (TighteningValueStatus)OpenProtocolConvert.ToInt32(section.Slice(5, 1)),
                TorqueOrForce = OpenProtocolConvert.ToTruncatedDecimal(section.Slice(6, 6)),
                AngleOrStrokeStatus = OpenProtocolConvert.ToBoolean(section.Slice(12, 1)),
                AngleOrStroke = OpenProtocolConvert.ToInt32(section.Slice(13, 5))
            };
        }

        public static List<SpindleOrPressStatus> ParseAll(string section)
            => ParseAll(section.AsSpan());

        public static List<SpindleOrPressStatus> ParseAll(ReadOnlySpan<char> section)
        {
            var list = new List<SpindleOrPressStatus>();
            for (int i = 0; i < section.Length; i += DefaultSize)
            {
                list.Add(Parse(section.Slice(i, DefaultSize)));
            }

            return list;
        }
    }

    public class SpindleOrPressStatusCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public SpindleOrPressStatusCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public SpindleOrPressStatusCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<SpindleOrPressStatus>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = Pack,
                DefaultParser = SpindleOrPressStatus.ParseAll
            }.Bind(mid, propertyInfo);
        }

        private static string Pack(char paddingChar, int size, PaddingOrientation orientation, List<SpindleOrPressStatus> spindleOrPressStatus)
        {
            var sb = new StringBuilder();
            foreach (var spindle in spindleOrPressStatus)
            {
                sb.Append(spindle.Pack());
            }
            return sb.ToString();
        }
    }
}
