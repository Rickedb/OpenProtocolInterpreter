namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Operation Types. Used in <see cref="Result.Mid1201"/>.
    /// </summary>
    public enum OperationType
    {
        NonSynchronizedTightening = 0,
        SynchronizedTightening = 1,
        Pressing = 2,
        Drilling = 3,
        Pulse = 4
    }
}
