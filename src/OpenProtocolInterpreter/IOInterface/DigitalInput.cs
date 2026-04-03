using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Represents a single Digital Input.
    /// </summary>
    public class DigitalInput
    {
        public DigitalInputNumber Number { get; set; }
        public bool Status { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, (int)Number) +
                    OpenProtocolConvert.ToString(Status);
        }

        public static DigitalInput Parse(string section)
        {
            return new DigitalInput()
            {
                Number = (DigitalInputNumber)OpenProtocolConvert.ToInt32(section.Substring(0, 3)),
                Status = OpenProtocolConvert.ToBoolean(section.Substring(3, 1))
            };
        }

        public static DigitalInput Parse(ReadOnlySpan<char> section)
        {
            return new DigitalInput()
            {
                Number = (DigitalInputNumber)OpenProtocolConvert.ToInt32(section.Slice(0, 3)),
                Status = OpenProtocolConvert.ToBoolean(section.Slice(3, 1))
            };
        }

        public static IEnumerable<DigitalInput> ParseAll(string value)
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

        public static IEnumerable<DigitalInput> ParseAll(ReadOnlySpan<char> value)
        {
            if (value.IsEmpty)
                return System.Array.Empty<DigitalInput>();

            var result = new System.Collections.Generic.List<DigitalInput>();
            const int sectionSize = 4;
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(value.Slice(i, sectionSize)));
            return result;
        }

    }
}
