using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Represents a single Relay
    /// </summary>
    public class Relay
    {
        public RelayNumber Number { get; set; }
        public bool Status { get; set; }

        public Relay()
        {

        }

        public Relay(RelayNumber number, bool status)
        {
            Number = number;
            Status = status;
        }

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

        public static Relay Parse(ReadOnlySpan<char> section)
        {
            return new Relay()
            {
                Number = (RelayNumber)OpenProtocolConvert.ToInt32(section.Slice(0, 3)),
                Status = OpenProtocolConvert.ToBoolean(section.Slice(3, 1))
            };
        }

        public static IEnumerable<Relay> ParseAll(string value)
        {
            if (string.IsNullOrEmpty(value))
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

        public static IEnumerable<Relay> ParseAll(ReadOnlySpan<char> value)
        {
            if (value.IsEmpty)
                return Array.Empty<Relay>();

            var result = new List<Relay>();
            const int sectionSize = 4;
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(value.Slice(i, sectionSize)));
            return result;
        }
    }

    public class RelayCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public RelayCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public RelayCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<Relay>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackRelays,
                DefaultParser = ParseRelays
            }.Bind(mid, propertyInfo);
        }

        private static string PackRelays(char paddingChar, int size, PaddingOrientation orientation, List<Relay> relays)
        {
            var builder = new StringBuilder(relays.Count * 4);
            foreach (var relay in relays)
                builder.Append(relay.Pack());

            return builder.ToString();
        }

        private static List<Relay> ParseRelays(string value)
            => Relay.ParseAll(value).ToList();
    }
}
