namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Represents a single Digital Input.
    /// </summary>
    public class DigitalInput
    {
        public DigitalInputNumber Number { get; set; }
        public bool Status { get; set; }
    }
}
