namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Represents an Identifier Status
    /// </summary>
    public class IdentifierStatus
    {
        public int IdentifierTypeNumber { get; set; }
        public bool IncludedInWorkOrder { get; set; }
        public StatusInWorkOrder StatusInWorkOrder { get; set; }
        public string ResultPart { get; set; }
    }
}
