using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    public class ResultData
    {
        public long Index { get; set; }
        public DateTime StartTime { get; set; }
        public int Status { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 10, PaddingOrientation.LeftPadded, Index) +
                    OpenProtocolConvert.ToString(StartTime) +
                    OpenProtocolConvert.ToString('0', 1, PaddingOrientation.LeftPadded, Status);
        }

        public static ResultData Parse(string value)
            => Parse(value.AsSpan());

        public static ResultData Parse(ReadOnlySpan<char> value)
        {
            return new ResultData()
            {
                Index = OpenProtocolConvert.ToInt64(value.Slice(0, 10)),
                StartTime = OpenProtocolConvert.ToDateTime(value.Slice(10, 19)),
                Status = OpenProtocolConvert.ToInt32(value.Slice(29, 1))
            };
        }

        public static IEnumerable<ResultData> ParseAll(string value)
            => ParseAll(value.AsSpan());

        public static IEnumerable<ResultData> ParseAll(ReadOnlySpan<char> value)
        {
            var result = new List<ResultData>();
            const int sectionSize = 30;
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(value.Slice(i, sectionSize)));
            return result;
        }
    }

    public class ResultDataCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public ResultDataCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public ResultDataCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<ResultData>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = Pack,
                DefaultParser = Parse
            }.Bind(owner, propertyInfo);
        }

        private static string Pack(char paddingChar, int size, PaddingOrientation orientation, List<ResultData> value)
        {
            var builder = new StringBuilder(value.Count * 30);
            foreach (var v in value)
                builder.Append(v.Pack());

            return builder.ToString();
        }

        private static List<ResultData> Parse(string value)
            => ResultData.ParseAll(value).ToList();
    }
}
