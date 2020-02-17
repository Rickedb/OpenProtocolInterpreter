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
}
