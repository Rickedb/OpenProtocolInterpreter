using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Represents a Special Value entity
    /// </summary>
    public class SpecialValue
    {
        public int TotalFieldLength => 20 + 2 + 2 + Length + (StepNumber > 0 ? 2 : 0);

        public string VariableName { get; set; }
        public DataType Type { get; set; }
        public int Length { get; set; }
        public object Value { get; set; }
        public int StepNumber { get; set; }

        public string Pack(bool useStepNumber)
        {
            var builder = new StringBuilder();
            builder.Append(VariableName.PadRight(20, ' ') +
                           Type.Type.PadRight(2, ' ') +
                           OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, Length) +
                           Value.ToString().PadRight(Length, ' '));

            if (useStepNumber)
                builder.Append(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, StepNumber));

            return builder.ToString();
        }

        public static SpecialValue Parse(string value, bool useStepNumber)
            => Parse(value.AsSpan(), useStepNumber);

        public static SpecialValue Parse(ReadOnlySpan<char> value, bool useStepNumber)
        {
            var obj = new SpecialValue
            {
                VariableName = value.Slice(0, 20).ToString(),
                Type = (DataType)value.Slice(20, 2).ToString(),
                Length = OpenProtocolConvert.ToInt32(value.Slice(22, 2))
            };
            obj.Value = value.Slice(24, obj.Length).ToString();
            if (useStepNumber)
            {
                obj.StepNumber = OpenProtocolConvert.ToInt32(value.Slice(24 + obj.Length, 2));
            }

            return obj;
        }

        public static IEnumerable<SpecialValue> ParseAll(string value, bool useStepNumber)
            => ParseAll(value.AsSpan(), useStepNumber);

        public static IEnumerable<SpecialValue> ParseAll(ReadOnlySpan<char> value, bool useStepNumber)
        {
            if (value.IsWhiteSpace() || value.IsEmpty)
                return Array.Empty<SpecialValue>();

            var result = new List<SpecialValue>();
            var totalSpecialValues = OpenProtocolConvert.ToInt32(value.Slice(0, 2));
            int index = 2;
            const int sectionSize = 24;
            for (int i = 0; i < totalSpecialValues; i++)
            {
                var length = OpenProtocolConvert.ToInt32(value.Slice(22 + index, 2));
                var totalSize = length + (useStepNumber ? sectionSize + 2 : sectionSize);
                var section = value.Slice(index, totalSize);
                index += totalSize;
                result.Add(Parse(section, useStepNumber));
            }
            return result;
        }

        public static IEnumerable<SpecialValue> ParseAll(string value, int totalSpecialValues, bool useStepNumber)
            => ParseAll(value.AsSpan(), totalSpecialValues, useStepNumber);

        public static IEnumerable<SpecialValue> ParseAll(ReadOnlySpan<char> value, int totalSpecialValues, bool useStepNumber)
        {
            if (value.IsWhiteSpace() || value.IsEmpty)
                return Array.Empty<SpecialValue>();

            var result = new List<SpecialValue>();
            int index = 0;
            const int sectionSize = 24;
            for (int i = 0; i < totalSpecialValues; i++)
            {
                var length = OpenProtocolConvert.ToInt32(value.Slice(22 + index, 2));
                var totalSize = length + (useStepNumber ? sectionSize + 2 : sectionSize);
                var section = value.Slice(index, totalSize);
                index += totalSize;
                result.Add(Parse(section, useStepNumber));
            }
            return result;
        }
    }

    public class SpecialValueCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public bool UseStepNumber { get; set; }

        public SpecialValueCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public SpecialValueCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<SpecialValue>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackSpecialValues,
                DefaultParser = ParseSpecialValues
            }.Bind(owner, propertyInfo);
        }

        private string PackSpecialValues(char paddingChar, int size, PaddingOrientation orientation, List<SpecialValue> specialValues)
        {
            var packages = string.Join(string.Empty, specialValues.Select(x => x.Pack(UseStepNumber)));
            return string.Concat(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, specialValues.Count), packages);
        }

        private List<SpecialValue> ParseSpecialValues(string value)
        {
            return SpecialValue.ParseAll(value, UseStepNumber).ToList();
        }
    }
}
