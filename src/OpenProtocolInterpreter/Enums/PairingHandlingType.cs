namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Pairing handling types. Used in <see cref="Tool.Mid0047"/>.
    /// </summary>
    public enum PairingHandlingType
    {
        StartPairing = 01,
        PairingAbortOrDisconnect = 02,
        FetchLatestPairingStatus = 03
    }
}
