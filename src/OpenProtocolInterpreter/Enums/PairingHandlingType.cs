namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Pairing handling types. Used in <see cref="Tool.Mid0047"/>.
    /// </summary>
    public enum PairingHandlingType
    {
        START_PAIRING = 01,
        PAIRING_ABORT_OR_DISCONNECT = 02,
        FETCH_LATEST_PAIRING_STATUS = 03
    }
}
