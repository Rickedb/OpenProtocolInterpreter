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
    }
}
