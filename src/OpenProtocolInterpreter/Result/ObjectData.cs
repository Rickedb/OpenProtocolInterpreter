using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Represents an Object Data entity
    /// </summary>
    public class ObjectData
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public ObjectType ObjectType { get; set; }
        public int ReferenceObjectId { get; set; }

        public string Pack()
            => Pack(1);

        public string Pack(int revision)
        {
            var package = OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, Id) + OpenProtocolConvert.ToString(Status);
            if(revision > 2)
            {
                return string.Concat(package, 
                                    OpenProtocolConvert.ToString((int)ObjectType), 
                                    OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, ReferenceObjectId));
            }

            return package;
        }

        public static ObjectData Parse(string value)
            => Parse(1, value);

        public static ObjectData Parse(int revision, string value)
            => Parse(revision, value.AsSpan());

        public static ObjectData Parse(int revision, ReadOnlySpan<char> value)
        {
            var obj = new ObjectData()
            {
                Id = OpenProtocolConvert.ToInt32(value.Slice(0, 4)),
                Status = OpenProtocolConvert.ToBoolean(value.Slice(4, 1))
            };

            if (revision > 2)
            {
                obj.ObjectType = (ObjectType)OpenProtocolConvert.ToInt32(value.Slice(5, 1));
                obj.ReferenceObjectId = OpenProtocolConvert.ToInt32(value.Slice(6, 4));
            }

            return obj;
        }

        public static IEnumerable<ObjectData> ParseAll(int revision, string value)
            => ParseAll(revision, value.AsSpan());

        public static IEnumerable<ObjectData> ParseAll(int revision, ReadOnlySpan<char> value)
        {
            int sectionSize = Size(revision);
            var result = new List<ObjectData>();
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(revision, value.Slice(i, sectionSize)));
            return result;
        }

        public static IEnumerable<ObjectData> ParseAll(string value)
            => ParseAll(1, value);

        internal static int Size(int revision) => revision > 2 ? 10 : 5;
    }
}
