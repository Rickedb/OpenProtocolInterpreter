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
}
