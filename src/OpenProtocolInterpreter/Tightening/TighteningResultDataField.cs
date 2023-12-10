using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    public class TighteningResultDataField
    {
        public int ParameterId { get; set; }
        public int Length { get; set; }
        public DataTypeDefinition DataType { get; set; }
        public DataUnitType Unit { get; set; }
        public string DataValue { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, ParameterId) +
                    OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, Length) +
                    OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, DataType) +
                    OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, Unit) +
                    OpenProtocolConvert.TruncatePadded(' ', Length, PaddingOrientation.RightPadded, DataValue);
        }

        public static TighteningResultDataField Parse(string value)
        {
            var length = OpenProtocolConvert.ToInt32(value.Substring(5, 3));
            return Parse(value, length);
        }

        public static IEnumerable<TighteningResultDataField> ParseAll(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            int valueLength;
            const int fixedLength = 13;
            for (int i = 0; i < value.Length; i += fixedLength + valueLength)
            {
                valueLength = OpenProtocolConvert.ToInt32(value.Substring(i + 5, 3));
                var section = value.Substring(i, fixedLength + valueLength);
                yield return Parse(section, valueLength);
            }
        }

        private static TighteningResultDataField Parse(string value, int length)
        {
            return new TighteningResultDataField()
            {
                ParameterId = OpenProtocolConvert.ToInt32(value.Substring(0, 5)),
                Length = length,
                DataType = (DataTypeDefinition)OpenProtocolConvert.ToInt32(value.Substring(8, 2)),
                Unit = (DataUnitType)OpenProtocolConvert.ToInt32(value.Substring(10, 3)),
                DataValue = value.Substring(13, length)
            };
        }

    }
}
