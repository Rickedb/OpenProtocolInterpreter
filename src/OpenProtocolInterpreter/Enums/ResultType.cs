namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Result types. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum ResultType
    {
        Tightening = 1,
        Loosening = 2,
        BatchIncrement = 3,
        BatchDecrement = 4,
        BypassParameterSetResult = 5,
        AbortJobResult = 6,
        SyncTightening = 7,
        ReferenceSetup = 8
    }
}
