using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Represents a Tool
    /// </summary>
    public class ToolData
    {
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
                return System.Array.Empty<ToolData>();

            var result = new System.Collections.Generic.List<ToolData>();
            const int sectionSize = 94;
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(value.Slice(i, sectionSize)));
            return result;
        }
    }
}
