using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Represents a Special Value entity
    /// </summary>
    public class SpecialValue
    {
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
        {
            var obj = new SpecialValue
            {
                VariableName = value.Substring(0, 20),
                Type = (DataType)value.Substring(20, 2),
                Length = OpenProtocolConvert.ToInt32(value.Substring(22, 2))
            };
            obj.Value = value.Substring(24, obj.Length);
            if (useStepNumber)
            {
                obj.StepNumber = OpenProtocolConvert.ToInt32(value.Substring(24 + obj.Length, 2));
            }

            return obj;
        }

        public static IEnumerable<SpecialValue> ParseAll(string value, int totalSpecialValues, bool useStepNumber)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            int index = 0;
            const int sectionSize = 24;
            for (int i = 0; i < totalSpecialValues; i++)
            {
                var length = OpenProtocolConvert.ToInt32(value.Substring(22 + index, 2));
                var totalSize = length + (useStepNumber ? sectionSize + 2 : sectionSize);
                var section = value.Substring(index, totalSize);
                index += totalSize;
                yield return Parse(section, useStepNumber);
            }
        }


    }
}
