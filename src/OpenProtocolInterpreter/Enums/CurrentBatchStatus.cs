namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Current Batch Status. Used in <see cref="Job.Advanced.Mid0140"/> in <see cref="Job.Advanced.AdvancedJob"/>.
    /// </summary>
    public enum CurrentBatchStatus
    {
        NOT_STARTED = 0,
        OK = 1,
        NOK = 2
    }
}
