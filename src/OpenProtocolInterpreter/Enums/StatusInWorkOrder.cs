namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Status in work order. Used in <see cref="MultipleIdentifiers.IdentifierStatus"/>.
    /// </summary>
    public enum StatusInWorkOrder
    {
        NOT_ACCEPTED = 0,
        ACCEPTED = 1,
        BYPASSED = 2,
        RESET = 3,
        NEXT = 4,
        INITIAL = 5
    }
}
