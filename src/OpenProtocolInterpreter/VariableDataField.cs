using OpenProtocolInterpreter.Converters;
using System;
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
                    return Math.Abs(new Int32Converter().Convert(DataValue));

                case DataTypeDefinition.Integer:
                    return new Int32Converter().Convert(DataValue);

                case DataTypeDefinition.Float:
                    return new DecimalConverter().Convert(DataValue);

                case DataTypeDefinition.Timestamp:
                    return DateTime.TryParseExact(DataValue, "yyyy-MM-dd:HH:mm:ss", null, DateTimeStyles.None, out DateTime dateTime) ? dateTime : DataValue;
                case DataTypeDefinition.Boolean:
                    return new BoolConverter().Convert(DataValue);

                //TODO
                case DataTypeDefinition.PlottingPoint1:
                case DataTypeDefinition.PlottingPoint2:
                case DataTypeDefinition.PlottingPoint4:
                case DataTypeDefinition.FloatArray:
                case DataTypeDefinition.UnsignedIntegerArray:
                case DataTypeDefinition.IntegerArray:
                    return DataValue;

                case DataTypeDefinition.String:
                case DataTypeDefinition.Hexadecimal:
                default:
                    return DataValue;
            }
        }
    }
}
