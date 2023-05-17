namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Relay status. Used in <see cref="IOInterface.Mid0200"/>.
    /// </summary>
    public enum RelayStatus
    {
        Off = 0,
        On = 1,
        Flashing = 2,
        KeepCurrentStatus = 3
    }
}
