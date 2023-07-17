using System.Collections.Generic;

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
            var pack = string.Empty;
            pack += OpenProtocolConvert.TruncatedDecimalToString('0', 6, PaddingOrientation.LeftPadded, Torque);
            pack += OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, Angle);
            return pack;
        }

        public static StageResult Parse(string value)
        {
            return new StageResult()
            {
                Torque = OpenProtocolConvert.ToTruncatedDecimal(value.Substring(0, 6)),
                Angle = OpenProtocolConvert.ToInt32(value.Substring(6, 5))
            };
        }

        public static IEnumerable<StageResult> ParseAll(string value)
        {
            const int sectionSize = 11;
            for (int i = 0; i < value.Length; i += sectionSize)
            {
                var section = value.Substring(i, sectionSize);
                yield return Parse(section);
            }
        }
    }
}
