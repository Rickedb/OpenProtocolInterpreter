using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Represents a Tool
    /// </summary>
    public class ToolData
    {
        internal const int SectionSize = 94;

        public int Number { get; set; }
        public string SerialNumber { get; set; }
        public string ModelName { get; set; }
        public string ModelArticleNumber { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, Number) +
                    OpenProtocolConvert.TruncatePadded(' ', 30, PaddingOrientation.RightPadded, SerialNumber) +
                    OpenProtocolConvert.TruncatePadded(' ', 30, PaddingOrientation.RightPadded, ModelName) +
                    OpenProtocolConvert.TruncatePadded(' ', 30, PaddingOrientation.RightPadded, ModelArticleNumber);
        }

        public static ToolData Parse(string value)
            => Parse(value.AsSpan());

        public static ToolData Parse(ReadOnlySpan<char> value)
        {
            return new ToolData()
            {
                Number = OpenProtocolConvert.ToInt32(value.Slice(0, 4)),
                SerialNumber = value.Slice(4, 30).ToString(),
                ModelName = value.Slice(34, 30).ToString(),
                ModelArticleNumber = value.Slice(64, 30).ToString()
            };
        }

        public static IEnumerable<ToolData> ParseAll(string value)
            => ParseAll(value.AsSpan());

        public static IEnumerable<ToolData> ParseAll(ReadOnlySpan<char> value)
        {
            if (value.IsEmpty)
                return Array.Empty<ToolData>();

            var result = new List<ToolData>();
            for (int i = 0; i < value.Length; i += SectionSize)
                result.Add(Parse(value.Slice(i, SectionSize)));
            return result;
        }
    }

    public class ToolDataCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public ToolDataCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public ToolDataCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<ToolData>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackToolData,
                DefaultParser = ParseToolData
            }.Bind(owner, propertyInfo);
        }

        private string PackToolData(char paddingChar, int size, PaddingOrientation orientation, List<ToolData> toolData)
            => string.Join("", toolData.Select(t => t.Pack()));

        private List<ToolData> ParseToolData(string value)
            => ToolData.ParseAll(value).ToList();
    }
}
