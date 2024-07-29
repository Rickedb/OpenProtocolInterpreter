using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    public class TighteningSummary
    {
        public long Index { get; set; }
        public DateTime StartTime { get; set; }
        public bool Status { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 10, PaddingOrientation.LeftPadded, Index) +
                    OpenProtocolConvert.ToString(StartTime) +
                    OpenProtocolConvert.ToString(Status);
        }

        public static TighteningSummary Parse(string value)
        {
            return new TighteningSummary()
            {
                Index = OpenProtocolConvert.ToInt64(value.Substring(0, 10)),
                StartTime = OpenProtocolConvert.ToDateTime(value.Substring(10, 19)),
                Status = OpenProtocolConvert.ToBoolean(value.Substring(29, 1))
            };
        }

        public static IEnumerable<TighteningSummary> ParseAll(string value)
        {
            const int sectionSize = 30;
            for (int i = 0; i < value.Length; i += sectionSize)
            {
                var section = value.Substring(i, sectionSize);
                yield return Parse(section);
            }
        }
    }
}
