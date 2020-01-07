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
        UNDEFINED,
        /// <summary>
        /// Pairing allowed and started
        /// </summary>
        ACCEPTED,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        INQUIRY,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        SENDPIN,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        PINOK,
        /// <summary>
        /// Normal pairing sequence as OK
        /// </summary>
        READY,
        /// <summary>
        /// Ongoing Pairing Aborted
        /// </summary>
        ABORTED,
        /// <summary>
        /// Pairing not allowed. Program control.
        /// </summary>
        DENIED,
        /// <summary>
        /// Pairing attempt failed
        /// </summary>
        FAILED,
        /// <summary>
        /// Pairing never done before or disconnected
        /// </summary>
        UNREADY
    }
}
