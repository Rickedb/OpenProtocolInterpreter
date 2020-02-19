namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Result types. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum ResultType
    {
        TIGHTENING = 1,
        LOOSENING = 2,
        BATCH_INCREMENT = 3,
        BATCH_DECREMENT = 4,
        BYPASS_PARAMETER_SET_RESULT = 5,
        ABORT_JOB_RESULT = 6,
        SYNC_TIGHTENING = 7,
        REFERENCE_SETUP = 8
    }
}
