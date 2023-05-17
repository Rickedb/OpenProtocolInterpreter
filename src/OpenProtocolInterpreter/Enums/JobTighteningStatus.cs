namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Job tightening status. Used in <see cref="Job.Mid0035"/>.
    /// </summary>
    public enum JobTighteningStatus
    {
        Off = 0,
        Nok = 1,
        Aborted = 3,
        Incremented = 4,
        Decremented = 5,
        Bypassed = 6,
        ResetBatch = 7,
        Loosening = 8,
        FreeBatch = 9,
        JobAborted = 10
    }
}
