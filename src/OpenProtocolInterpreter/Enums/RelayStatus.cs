namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Relay status. Used in <see cref="IOInterface.Mid0200"/>.
    /// </summary>
    public enum RelayStatus
    {
        OFF = 0,
        ON = 1,
        FLASHING = 2,
        KEEP_CURRENT_STATUS = 3
    }
}
