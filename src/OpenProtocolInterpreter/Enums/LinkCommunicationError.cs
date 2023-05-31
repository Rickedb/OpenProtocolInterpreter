namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Error codes. Used in <see cref="LinkCommunication.Mid9998"/>.
    /// </summary>
    public enum LinkCommunicationError
    {
        InvalidLength = 1,
        InvalidRevision = 2,
        InvalidSequenceNumber = 3,
        InconsistencyOfMessageNumber = 4
    }
}
