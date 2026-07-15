using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Represents a Spindle Status entity
    /// </summary>
    public class SpindleStatus
    {
        internal const int DefaultSize = 5;

        public int SpindleNumber { get; set; }
        public int ChannelId { get; set; }
        public bool SyncOverallStatus { get; set; }

        public string Pack()
        {
            return string.Concat(
                OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, SpindleNumber),
                OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, ChannelId),
                OpenProtocolConvert.ToString(SyncOverallStatus)
            );
        }

        public static SpindleStatus Parse(string section)
            => Parse(section.AsSpan());

        public static SpindleStatus Parse(ReadOnlySpan<char> section)
        {
            return new SpindleStatus()
            {
                SpindleNumber = OpenProtocolConvert.ToInt32(section.Slice(0, 2)),
                ChannelId = OpenProtocolConvert.ToInt32(section.Slice(2, 2)),
                SyncOverallStatus = OpenProtocolConvert.ToBoolean(section.Slice(4, 1))
            };
        }

        public static List<SpindleStatus> ParseAll(string section)
            => ParseAll(section.AsSpan());

        public static List<SpindleStatus> ParseAll(ReadOnlySpan<char> section)
        {
            var list = new List<SpindleStatus>();
            for (int i = 0; i < section.Length; i += DefaultSize)
            {
                list.Add(Parse(section.Slice(i, DefaultSize)));
            }

            return list;
        }
    }

    public class SpindleStatusCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public SpindleStatusCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public SpindleStatusCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<SpindleStatus>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = Pack,
                DefaultParser = SpindleStatus.ParseAll
            }.Bind(mid, propertyInfo);
        }

        private static string Pack(char paddingChar, int size, PaddingOrientation orientation, List<SpindleStatus> spindleStatus)
        {
            var sb = new StringBuilder();
            foreach (var spindle in spindleStatus)
            {
                sb.Append(spindle.Pack());
            }
            return sb.ToString();
        }
    }
}
