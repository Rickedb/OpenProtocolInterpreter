using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Represents a single Relay
    /// </summary>
    public class Relay
    {
        public RelayNumber Number { get; set; }
        public bool Status { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, (int)Number) +
                    OpenProtocolConvert.ToString(Status);
        }

        public static Relay Parse(string section)
        {
            return new Relay()
            {
                Number = (RelayNumber)OpenProtocolConvert.ToInt32(section.Substring(0, 3)),
                Status = OpenProtocolConvert.ToBoolean(section.Substring(3, 1))
            };
        }

        public static IEnumerable<Relay> ParseAll(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                yield break;
            }

            const int sectionSize = 4;
            for (int i = 0; i < value.Length; i += sectionSize)
            {
                var section = value.Substring(i, sectionSize);
                yield return Parse(section);
            }
        }
    }
}
