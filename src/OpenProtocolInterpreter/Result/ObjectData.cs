using System.Collections.Generic;

namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Represents an Object Data entity
    /// </summary>
    public class ObjectData
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public string Pack()
        {
            string pack = string.Empty;
            pack += OpenProtocolConvert.ToString('0', 4, DataField.PaddingOrientations.LeftPadded, Id);
            pack += OpenProtocolConvert.ToString(Status);
            return pack;
        }

        public static ObjectData Parse(string value)
        {
            return new ObjectData()
            {
                Id = OpenProtocolConvert.ToInt32(value.Substring(0, 4)),
                Status = OpenProtocolConvert.ToBoolean(value.Substring(4, 1))
            };
        }

        public static IEnumerable<ObjectData> ParseAll(string value)
        {
            const int sectionSize = 5;
            for (int i = 0; i < value.Length; i += sectionSize)
            {
                var section = value.Substring(i, sectionSize);
                yield return Parse(section);
            }
        }
    }
}
