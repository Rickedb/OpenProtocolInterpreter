using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Represents a Bolt Result entity
    /// </summary>
    public class BoltResult
    {
        public string VariableName { get; set; }
        public DataType Type { get; set; }
        public object Value { get; set; }
    }

    public class BoltResultCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public BoltResultCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public BoltResultCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<BoltResult>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackBoltResult,
                DefaultParser = ParseBoltResult
            }.Bind(owner, propertyInfo);
        }

        private static string PackBoltResult(char paddingChar, int size, PaddingOrientation orientation, List<BoltResult> boltResults)
        {
            var builder = new StringBuilder();
            foreach (var bolt in boltResults)
            {
                builder.Append(OpenProtocolConvert.TruncatePadded(' ', 20, PaddingOrientation.RightPadded, bolt.VariableName));
                builder.Append(bolt.Type.Type);
                if (DataType.DataTypes[1].Type.Equals(bolt.Type.Type)) // Integer
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (int)bolt.Value));
                }
                else if (DataType.DataTypes[2].Type.Equals(bolt.Type.Type)) // Decimal
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (decimal)bolt.Value));
                }
            }

            return builder.ToString();
        }


        private static List<BoltResult> ParseBoltResult(string value)
        {
            var list = new List<BoltResult>();
            if (string.IsNullOrWhiteSpace(value))
            {
                return list;
            }

            var section = value.AsSpan();
            for (int i = 0; i < section.Length; i += 29)
            {
                var type = section.Slice(20 + i, 2).ToString();
                var result = new BoltResult()
                {
                    VariableName = section.Slice(i, 20).ToString(),
                    Type = DataType.DataTypes.First(x => x == type)
                };

                var resultValue = section.Slice(22 + i, 7);
                if (result.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    result.Value = OpenProtocolConvert.ToInt32(resultValue);
                }
                else if (result.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    result.Value = OpenProtocolConvert.ToDecimal(resultValue);
                }

                list.Add(result);
            }

            return list;
        }
    }
}
