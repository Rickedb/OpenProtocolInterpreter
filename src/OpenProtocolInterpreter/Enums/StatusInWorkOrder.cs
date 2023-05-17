namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Status in work order. Used in <see cref="MultipleIdentifiers.IdentifierStatus"/>.
    /// </summary>
    public enum StatusInWorkOrder
    {
        NotAccepted = 0,
        Accepted = 1,
        Bypassed = 2,
        Reset = 3,
        Next = 4,
        Initial = 5
    }
}
