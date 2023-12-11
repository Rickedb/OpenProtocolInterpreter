using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a Variable Data entity
    /// </summary>
    public class VariableDataField
    {
        public int ParameterId { get; set; }
        public int Length { get; set; }
        public DataTypeDefinition DataType { get; set; }
        public DataUnitType Unit { get; set; }
        public int StepNumber { get; set; }
        public string DataValue { get; set; }

        public object Convert()
        {
            switch (DataType)
            {
                case DataTypeDefinition.UnsignedInteger:
                    return Math.Abs(OpenProtocolConvert.ToInt32(DataValue));

                case DataTypeDefinition.Integer:
                    return OpenProtocolConvert.ToInt32(DataValue);

                case DataTypeDefinition.Float:
                    return OpenProtocolConvert.ToDecimal(DataValue);

                case DataTypeDefinition.Timestamp:
                    return DateTime.TryParseExact(DataValue, "yyyy-MM-dd:HH:mm:ss", null, DateTimeStyles.None, out DateTime dateTime) ? dateTime : DataValue;
                
                case DataTypeDefinition.Boolean:
                    return OpenProtocolConvert.ToBoolean(DataValue);

                //TODO
                case DataTypeDefinition.PlottingPoint1:
                case DataTypeDefinition.PlottingPoint2:
                case DataTypeDefinition.PlottingPoint4:
                case DataTypeDefinition.FloatArray:
                case DataTypeDefinition.UnsignedIntegerArray:
                case DataTypeDefinition.IntegerArray:
                case DataTypeDefinition.String:
                case DataTypeDefinition.Hexadecimal:
                default:
                    return DataValue;
            }
        }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, ParameterId) +
                    OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, Length) +
                    OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, (int)DataType) + 
                    OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, (int)Unit) +
                    OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, StepNumber) +
                    OpenProtocolConvert.TruncatePadded(' ', Length, PaddingOrientation.RightPadded, DataValue);
        }

        public static VariableDataField Parse(string value)
        {
            var length = OpenProtocolConvert.ToInt32(value.Substring(5, 3));
            return Parse(value, length);
        }

        public static IEnumerable<VariableDataField> ParseAll(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            int valueLength;
            const int fixedLength = 17;
            for (int i = 0; i < value.Length; i += fixedLength + valueLength)
            {
                valueLength = OpenProtocolConvert.ToInt32(value.Substring(i + 5, 3));
                var section = value.Substring(i, fixedLength + valueLength);
                yield return Parse(section, valueLength);
            }
        }

        private static VariableDataField Parse(string value, int length)
        {
            return new VariableDataField()
            {
                ParameterId = OpenProtocolConvert.ToInt32(value.Substring(0, 5)),
                Length = length,
                DataType = (DataTypeDefinition)OpenProtocolConvert.ToInt32(value.Substring(8, 2)),
                Unit = (DataUnitType)OpenProtocolConvert.ToInt32(value.Substring(10, 3)),
                StepNumber = OpenProtocolConvert.ToInt32(value.Substring(13, 4)),
                DataValue = value.Substring(17, length)
            };
        }

    }
}
