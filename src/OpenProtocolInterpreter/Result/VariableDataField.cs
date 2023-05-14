namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Represents a Variable Data entity
    /// </summary>
    public class VariableDataField
    {
        public int ParameterId { get; set; }
        public int Length { get; set; }
        public int DataType { get; set; }
        public int Unit { get; set; }
        public int StepNumber { get; set; }
        public string DataValue { get; set; }
    }
}
