using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Represents a Stage Result entity
    /// </summary>
    public class StageResult
    {
        public decimal Torque { get; set; }
        public int Angle { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.TruncatedDecimalToString('0', 6, PaddingOrientation.LeftPadded, Torque) +
                    OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, Angle);
        }

        public static StageResult Parse(string value)
            => Parse(value.AsSpan());

        public static StageResult Parse(ReadOnlySpan<char> value)
        {
            return new StageResult()
            {
                Torque = OpenProtocolConvert.ToTruncatedDecimal(value.Slice(0, 6)),
                Angle = OpenProtocolConvert.ToInt32(value.Slice(6, 5))
            };
        }

        public static IEnumerable<StageResult> ParseAll(string value)
            => ParseAll(value.AsSpan());

        public static IEnumerable<StageResult> ParseAll(ReadOnlySpan<char> value)
        {
            var result = new List<StageResult>();
            const int sectionSize = 11;
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(value.Slice(i, sectionSize)));
            return result;
        }
    }

    public class StageResultCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public StageResultCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public StageResultCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<StageResult>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackStageResults,
                DefaultParser = ParseStageResults
            }.Bind(owner, propertyInfo);
        }

        private static string PackStageResults(char paddingChar, int size, PaddingOrientation orientation, List<StageResult> stageResults)
        {
            var builder = new StringBuilder(stageResults.Count * 11);
            foreach (var stageResult in stageResults)
                builder.Append(stageResult.Pack());

            return builder.ToString();
        }

        private static List<StageResult> ParseStageResults(string value)
            => StageResult.ParseAll(value).ToList();
    }
}
