using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Represents a single Digital Input.
    /// </summary>
    public class DigitalInput
    {
        public DigitalInputNumber Number { get; set; }
        public bool Status { get; set; }

        public DigitalInput()
        {

        }

        public DigitalInput(DigitalInputNumber number, bool status)
        {
            Number = number;
            Status = status;
        }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, (int)Number) +
                    OpenProtocolConvert.ToString(Status);
        }

        public static DigitalInput Parse(string section)
            => Parse(section.AsSpan());

        public static DigitalInput Parse(ReadOnlySpan<char> section)
        {
            return new DigitalInput()
            {
                Number = (DigitalInputNumber)OpenProtocolConvert.ToInt32(section.Slice(0, 3)),
                Status = OpenProtocolConvert.ToBoolean(section.Slice(3, 1))
            };
        }

        public static IEnumerable<DigitalInput> ParseAll(string value)
            => ParseAll(value.AsSpan());

        public static IEnumerable<DigitalInput> ParseAll(ReadOnlySpan<char> value)
        {
            if (value.IsEmpty)
                return Array.Empty<DigitalInput>();

            var result = new List<DigitalInput>();
            const int sectionSize = 4;
            for (int i = 0; i < value.Length; i += sectionSize)
                result.Add(Parse(value.Slice(i, sectionSize)));
            return result;
        }
    }

    public class DigitalInputCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public DigitalInputCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public DigitalInputCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<DigitalInput>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackDigitalInputs,
                DefaultParser = ParseDigitalInputs
            }.Bind(owner, propertyInfo);
        }

        private static string PackDigitalInputs(char paddingChar, int size, PaddingOrientation orientation, List<DigitalInput> digitalInputs)
        {
            var builder = new StringBuilder(digitalInputs.Count * 4);
            foreach (var digitalInput in digitalInputs)
                builder.Append(digitalInput.Pack());

            return builder.ToString();
        }

        private static List<DigitalInput> ParseDigitalInputs(string value)
            => DigitalInput.ParseAll(value).ToList();
    }
}
