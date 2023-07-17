namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Pairing status. Used in <see cref="Tool.Mid0048"/>.
    /// </summary>
    public enum PairingStatus
    {
        /// <summary>
        /// Tool not mounted yet
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Pairing allowed and started
        /// </summary>
        Accepted = 1,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        Inquiry = 2,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        SendPin = 3,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        PinOk = 4,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        Ready = 5,
        /// <summary>
        /// Ongoing Pairing Aborted
        /// </summary>
        Aborted = 6,
        /// <summary>
        /// Pairing not allowed. Program control.
        /// </summary>
        Denied = 7,
        /// <summary>
        /// Pairing attempt failed
        /// </summary>
        Failed = 8,
        /// <summary>
        /// Pairing never done before or disconnected
        /// </summary>
        Unready = 9
    }
}
