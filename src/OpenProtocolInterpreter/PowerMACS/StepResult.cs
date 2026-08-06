using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Represents a Step Result entity
    /// </summary>
    public class StepResult
    {
        public string VariableName { get; set; }
        public DataType Type { get; set; }
        public object Value { get; set; }
        public int StepNumber { get; set; }
    }

    public class StepResultCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public StepResultCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public StepResultCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<StepResult>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackStepResults,
                DefaultParser = ParseStepResults
            }.Bind(owner, propertyInfo);
        }

        protected static string PackStepResults(char paddingChar, int size, PaddingOrientation orientation, List<StepResult> stepResults)
        {
            var builder = new StringBuilder();
            foreach (var step in stepResults)
            {
                builder.Append(OpenProtocolConvert.TruncatePadded(' ', 20, PaddingOrientation.RightPadded, step.VariableName));
                builder.Append(step.Type.Type);
                if (DataType.DataTypes[1].Type.Equals(step.Type.Type)) // Integer
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (int)step.Value));
                }
                else if (DataType.DataTypes[2].Type.Equals(step.Type.Type)) // Decimal
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (decimal)step.Value));
                }
                else
                {
                    throw new ArgumentException($"Unsupported data type: '{step.Type.Type}', it should be only either Integer ('I ') or Decimal ('F ')");
                }
                builder.Append(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, step.StepNumber));
            }

            return builder.ToString();
        }

        protected static List<StepResult> ParseStepResults(string package)
        {
            var list = new List<StepResult>();
            var section = package.AsSpan();
            for (int i = 0; i < section.Length; i += 31)
            {
                var type = section.Slice(20 + i, 2).ToString();
                var result = new StepResult()
                {
                    VariableName = section.Slice(i, 20).ToString(),
                    Type = DataType.DataTypes.First(x => x.Type.Trim() == type.Trim()),
                    StepNumber = OpenProtocolConvert.ToInt32(section.Slice(29 + i, 2))
                };

                var resultValue = section.Slice(22 + i, 7);
                if (result.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    result.Value = OpenProtocolConvert.ToInt32(resultValue);
                }
                else if (result.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    var decimalPointIndex = resultValue.IndexOf('.');
                    int decimalPlaces = decimalPointIndex >= 0 ? resultValue.Slice(decimalPointIndex + 1).Length : 0;
                    result.Value = OpenProtocolConvert.ToDecimal(resultValue);
                }

                list.Add(result);
            }

            return list;
        }
    }
}
