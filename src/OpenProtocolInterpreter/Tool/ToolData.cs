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
            return OpenProtocolConvert.ToString('0', 4, DataField.PaddingOrientations.LeftPadded, Number) +
                    OpenProtocolConvert.TruncatePadded(' ', 30, DataField.PaddingOrientations.RightPadded, SerialNumber) +
                    OpenProtocolConvert.TruncatePadded(' ', 30, DataField.PaddingOrientations.RightPadded, ModelName) +
                    OpenProtocolConvert.TruncatePadded(' ', 30, DataField.PaddingOrientations.RightPadded, ModelArticleNumber);
        }

        public static ToolData Parse(string value)
        {
            return new ToolData()
            {
                Number = OpenProtocolConvert.ToInt32(value.Substring(0, 4)),
                SerialNumber = value.Substring(4, 30),
                ModelName = value.Substring(34, 30),
                ModelArticleNumber = value.Substring(64, 30)
            };
        }

        public static IEnumerable<ToolData> ParseAll(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                yield break;
            }

            const int sectionSize = 94;
            for (int i = 0; i < value.Length; i += sectionSize)
            {
                var section = value.Substring(i, sectionSize);
                yield return Parse(section);
            }
        }
    }
}
