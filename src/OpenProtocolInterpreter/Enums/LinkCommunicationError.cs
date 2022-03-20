namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Error codes. Used in <see cref="LinkCommunication.Mid9998"/>.
    /// </summary>
    public enum LinkCommunicationError
    {
        INVALID_LENGTH = 1,
        INVALID_REVISION = 2,
        INVALID_SEQUENCE_NUMBER = 3,
        INCONSISTENCY_OF_MESSAGE_NUMBER = 4
    }
}
